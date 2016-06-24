namespace Nightscout.Controllers
{
    /// <summary>
    /// Defines a given query field, comparitor and value
    /// </summary>
    public class QueryItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryItem"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <param name="comparitor">The comparitor, defaults to equals.</param>
        public QueryItem(string field, string value, string comparitor = null)
        {
            Field = field?.ToLowerInvariant().Trim() ?? string.Empty;
            Value = value;
            Comparitor = comparitor?.ToLowerInvariant().Trim().TrimStart('$') ?? "eq";
        }

        public string Field { get; private set; }

        public string Value { get; private set; }

        public string Comparitor { get; private set; }
    }
}