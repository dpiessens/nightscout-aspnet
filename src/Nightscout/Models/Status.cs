using System;
using System.Text;
using Newtonsoft.Json;

namespace Nightscout.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Status : IEquatable<Status>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Status" /> class.
        /// </summary>
        /// <param name="ApiEnabled">Whether or not the REST API is enabled..</param>
        /// <param name="CareportalEnabled">Whether or not the careportal is enabled in the API..</param>
        /// <param name="Head">The git identifier for the running instance of the app..</param>
        /// <param name="Name">Nightscout (static).</param>
        /// <param name="Version">The version label of the app..</param>
        /// <param name="Settings">Settings.</param>
        /// <param name="ExtendedSettings">ExtendedSettings.</param>
        public Status(bool? ApiEnabled = null, bool? CareportalEnabled = null, string Head = null, string Name = null,
            string Version = null, Settings Settings = null, ExtendedSettings ExtendedSettings = null)
        {
            this.ApiEnabled = ApiEnabled;
            this.CareportalEnabled = CareportalEnabled;
            this.Head = Head;
            this.Name = Name;
            this.Version = Version;
            this.Settings = Settings;
            this.ExtendedSettings = ExtendedSettings;
        }


        /// <summary>
        /// Whether or not the REST API is enabled.
        /// </summary>
        /// <value>Whether or not the REST API is enabled.</value>
        public bool? ApiEnabled { get; set; }


        /// <summary>
        /// Whether or not the careportal is enabled in the API.
        /// </summary>
        /// <value>Whether or not the careportal is enabled in the API.</value>
        public bool? CareportalEnabled { get; set; }


        /// <summary>
        /// The git identifier for the running instance of the app.
        /// </summary>
        /// <value>The git identifier for the running instance of the app.</value>
        public string Head { get; set; }


        /// <summary>
        /// Nightscout (static)
        /// </summary>
        /// <value>Nightscout (static)</value>
        public string Name { get; set; }


        /// <summary>
        /// The version label of the app.
        /// </summary>
        /// <value>The version label of the app.</value>
        public string Version { get; set; }


        /// <summary>
        /// Gets or Sets Settings
        /// </summary>
        public Settings Settings { get; set; }


        /// <summary>
        /// Gets or Sets ExtendedSettings
        /// </summary>
        public ExtendedSettings ExtendedSettings { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Status {\n");
            sb.Append("  ApiEnabled: ").Append(ApiEnabled).Append("\n");
            sb.Append("  CareportalEnabled: ").Append(CareportalEnabled).Append("\n");
            sb.Append("  Head: ").Append(Head).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  Settings: ").Append(Settings).Append("\n");
            sb.Append("  ExtendedSettings: ").Append(ExtendedSettings).Append("\n");

            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Status) obj);
        }

        /// <summary>
        /// Returns true if Status instances are equal
        /// </summary>
        /// <param name="other">Instance of Status to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Status other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    ApiEnabled == other.ApiEnabled ||
                    ApiEnabled != null &&
                    ApiEnabled.Equals(other.ApiEnabled)
                    ) &&
                (
                    CareportalEnabled == other.CareportalEnabled ||
                    CareportalEnabled != null &&
                    CareportalEnabled.Equals(other.CareportalEnabled)
                    ) &&
                (
                    Head == other.Head ||
                    Head != null &&
                    Head.Equals(other.Head)
                    ) &&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                    ) &&
                (
                    Version == other.Version ||
                    Version != null &&
                    Version.Equals(other.Version)
                    ) &&
                (
                    Settings == other.Settings ||
                    Settings != null &&
                    Settings.Equals(other.Settings)
                    ) &&
                (
                    ExtendedSettings == other.ExtendedSettings ||
                    ExtendedSettings != null &&
                    ExtendedSettings.Equals(other.ExtendedSettings)
                    );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                var hash = 41;
                // Suitable nullity checks etc, of course :)

                if (ApiEnabled != null)
                    hash = hash*59 + ApiEnabled.GetHashCode();

                if (CareportalEnabled != null)
                    hash = hash*59 + CareportalEnabled.GetHashCode();

                if (Head != null)
                    hash = hash*59 + Head.GetHashCode();

                if (Name != null)
                    hash = hash*59 + Name.GetHashCode();

                if (Version != null)
                    hash = hash*59 + Version.GetHashCode();

                if (Settings != null)
                    hash = hash*59 + Settings.GetHashCode();

                if (ExtendedSettings != null)
                    hash = hash*59 + ExtendedSettings.GetHashCode();

                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Status left, Status right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Status left, Status right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}