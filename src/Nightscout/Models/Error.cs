using System;
using System.Text;
using Newtonsoft.Json;

namespace Nightscout.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Error : IEquatable<Error>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error" /> class.
        /// </summary>
        /// <param name="Code">Code.</param>
        /// <param name="Message">Message.</param>
        /// <param name="Fields">Fields.</param>
        public Error(int? Code = null, string Message = null, object Fields = null)
        {
            this.Code = Code;
            this.Message = Message;
            this.Fields = Fields;
        }


        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        public int? Code { get; set; }


        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// Gets or Sets Fields
        /// </summary>
        public object Fields { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Error {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Fields: ").Append(Fields).Append("\n");

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
            return Equals((Error) obj);
        }

        /// <summary>
        /// Returns true if Error instances are equal
        /// </summary>
        /// <param name="other">Instance of Error to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Error other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Code == other.Code ||
                    Code != null &&
                    Code.Equals(other.Code)
                    ) &&
                (
                    Message == other.Message ||
                    Message != null &&
                    Message.Equals(other.Message)
                    ) &&
                (
                    Fields == other.Fields ||
                    Fields != null &&
                    Fields.Equals(other.Fields)
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

                if (Code != null)
                    hash = hash*59 + Code.GetHashCode();

                if (Message != null)
                    hash = hash*59 + Message.GetHashCode();

                if (Fields != null)
                    hash = hash*59 + Fields.GetHashCode();

                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Error left, Error right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Error left, Error right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}