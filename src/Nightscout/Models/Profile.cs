using System;
using System.Text;
using Newtonsoft.Json;

namespace Nightscout.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Profile : IEquatable<Profile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Profile" /> class.
        /// </summary>
        /// <param name="Sens">Internally assigned id.</param>
        /// <param name="Dia">Internally assigned id.</param>
        /// <param name="Carbratio">Internally assigned id.</param>
        /// <param name="CarbsHr">Internally assigned id.</param>
        /// <param name="Id">Internally assigned id.</param>
        public Profile(int? Sens = null, int? Dia = null, int? Carbratio = null, int? CarbsHr = null, string Id = null)
        {
            this.Sens = Sens;
            this.Dia = Dia;
            this.Carbratio = Carbratio;
            this.CarbsHr = CarbsHr;
            this.Id = Id;
        }


        /// <summary>
        /// Internally assigned id
        /// </summary>
        /// <value>Internally assigned id</value>
        public int? Sens { get; set; }


        /// <summary>
        /// Internally assigned id
        /// </summary>
        /// <value>Internally assigned id</value>
        public int? Dia { get; set; }


        /// <summary>
        /// Internally assigned id
        /// </summary>
        /// <value>Internally assigned id</value>
        public int? Carbratio { get; set; }


        /// <summary>
        /// Internally assigned id
        /// </summary>
        /// <value>Internally assigned id</value>
        public int? CarbsHr { get; set; }


        /// <summary>
        /// Internally assigned id
        /// </summary>
        /// <value>Internally assigned id</value>
        public string Id { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Profile {\n");
            sb.Append("  Sens: ").Append(Sens).Append("\n");
            sb.Append("  Dia: ").Append(Dia).Append("\n");
            sb.Append("  Carbratio: ").Append(Carbratio).Append("\n");
            sb.Append("  CarbsHr: ").Append(CarbsHr).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");

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
            return Equals((Profile) obj);
        }

        /// <summary>
        /// Returns true if Profile instances are equal
        /// </summary>
        /// <param name="other">Instance of Profile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Profile other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Sens == other.Sens ||
                    Sens != null &&
                    Sens.Equals(other.Sens)
                    ) &&
                (
                    Dia == other.Dia ||
                    Dia != null &&
                    Dia.Equals(other.Dia)
                    ) &&
                (
                    Carbratio == other.Carbratio ||
                    Carbratio != null &&
                    Carbratio.Equals(other.Carbratio)
                    ) &&
                (
                    CarbsHr == other.CarbsHr ||
                    CarbsHr != null &&
                    CarbsHr.Equals(other.CarbsHr)
                    ) &&
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
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

                if (Sens != null)
                    hash = hash*59 + Sens.GetHashCode();

                if (Dia != null)
                    hash = hash*59 + Dia.GetHashCode();

                if (Carbratio != null)
                    hash = hash*59 + Carbratio.GetHashCode();

                if (CarbsHr != null)
                    hash = hash*59 + CarbsHr.GetHashCode();

                if (Id != null)
                    hash = hash*59 + Id.GetHashCode();

                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Profile left, Profile right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Profile left, Profile right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}