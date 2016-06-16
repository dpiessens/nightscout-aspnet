using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Nightscout.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Treatments : List<Treatment>, IEquatable<Treatments>
    {
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Treatments {\n");

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
            return Equals((Treatments) obj);
        }

        /// <summary>
        /// Returns true if Treatments instances are equal
        /// </summary>
        /// <param name="other">Instance of Treatments to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Treatments other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return false;
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            var hash = 41;
            // Suitable nullity checks etc, of course :)

            return hash;
        }

        #region Operators

        public static bool operator ==(Treatments left, Treatments right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Treatments left, Treatments right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}