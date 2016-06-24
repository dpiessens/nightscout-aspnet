using System.Collections.Generic;
using System.Security.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using MongoDB.Driver;
using Newtonsoft.Json.Serialization;
using Nightscout.Binders;

namespace Nightscout
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();

            // Add framework services.
            var mvcBuilder = services.AddMvc(opt =>
            {
                opt.FormatterMappings.SetMediaTypeMappingForFormat("xml", new MediaTypeHeaderValue("application/xml"));
                opt.Conventions.Add(new QueryFilterModelBinderConvention());
            });
            mvcBuilder.AddXmlDataContractSerializerFormatters();
            mvcBuilder.AddJsonOptions(
                opts => opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());


            //services.AddSwaggerGen();
            //services.ConfigureSwaggerDocument(options =>
            //{
            //    options.SingleApiVersion(new Info
            //    {
            //        Version = "v1",
            //        Title = "IO.Swagger",
            //        Description = "IO.Swagger (ASP.NET 5 Web API 2.x)"
            //    });
            //});

            //services.ConfigureSwaggerSchema(options => {
            //    options.DescribeAllEnumsAsStrings = true;
            //});


            // Setup the database connection as a singleton
            ConfigureDatabase(services);
            ConfigureCache(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(r =>
            {
                r.MapRoute("default", "api/v1/{controller=Entries}.{format?}/{action=Get}");
            });
        }

        private void ConfigureCache(IServiceCollection services)
        {
            //TODO: Add Redis cache for multiple instances
            services.AddDistributedMemoryCache();
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            var configSection = Configuration.GetSection("Database").GetSection("mongo");

            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(configSection["server"], int.Parse(configSection["port"])),
                UseSsl = true,
                SslSettings = new SslSettings {EnabledSslProtocols = SslProtocols.Tls12}
            };

            var identity = new MongoInternalIdentity("admin", configSection["username"]);
            settings.Credentials = new List<MongoCredential>()
            {
                new MongoCredential("SCRAM-SHA-1", identity, new PasswordEvidence(configSection["password"]))
            };

            var client = new MongoClient(settings);
            services.AddSingleton(client.GetDatabase("admin"));
        }
    }
}