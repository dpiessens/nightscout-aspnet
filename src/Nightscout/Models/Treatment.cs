using System;
using System.Text;
using Newtonsoft.Json;

namespace Nightscout.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Treatment : IEquatable<Treatment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Treatment" /> class.
        /// </summary>
        /// <param name="Id">Internally assigned id..</param>
        /// <param name="EventType">The type of treatment event..</param>
        /// <param name="CreatedAt">The date of the event, might be set retroactively ..</param>
        /// <param name="Glucose">Current glucose..</param>
        /// <param name="GlucoseType">Method used to obtain glucose, Finger or Sensor..</param>
        /// <param name="Carbs">Number of carbs..</param>
        /// <param name="Insulin">Amount of insulin, if any..</param>
        /// <param name="Units">The units for the glucose value, mg/dl or mmol..</param>
        /// <param name="Notes">Description/notes of treatment..</param>
        /// <param name="EnteredBy">Who entered the treatment..</param>
        public Treatment(string Id = null, string EventType = null, string CreatedAt = null, string Glucose = null,
            string GlucoseType = null, double? Carbs = null, double? Insulin = null, string Units = null,
            string Notes = null, string EnteredBy = null)
        {
            this.Id = Id;
            this.EventType = EventType;
            this.CreatedAt = CreatedAt;
            this.Glucose = Glucose;
            this.GlucoseType = GlucoseType;
            this.Carbs = Carbs;
            this.Insulin = Insulin;
            this.Units = Units;
            this.Notes = Notes;
            this.EnteredBy = EnteredBy;
        }


        /// <summary>
        /// Internally assigned id.
        /// </summary>
        /// <value>Internally assigned id.</value>
        public string Id { get; set; }


        /// <summary>
        /// The type of treatment event.
        /// </summary>
        /// <value>The type of treatment event.</value>
        public string EventType { get; set; }


        /// <summary>
        /// The date of the event, might be set retroactively .
        /// </summary>
        /// <value>The date of the event, might be set retroactively .</value>
        public string CreatedAt { get; set; }


        /// <summary>
        /// Current glucose.
        /// </summary>
        /// <value>Current glucose.</value>
        public string Glucose { get; set; }


        /// <summary>
        /// Method used to obtain glucose, Finger or Sensor.
        /// </summary>
        /// <value>Method used to obtain glucose, Finger or Sensor.</value>
        public string GlucoseType { get; set; }


        /// <summary>
        /// Number of carbs.
        /// </summary>
        /// <value>Number of carbs.</value>
        public double? Carbs { get; set; }


        /// <summary>
        /// Amount of insulin, if any.
        /// </summary>
        /// <value>Amount of insulin, if any.</value>
        public double? Insulin { get; set; }


        /// <summary>
        /// The units for the glucose value, mg/dl or mmol.
        /// </summary>
        /// <value>The units for the glucose value, mg/dl or mmol.</value>
        public string Units { get; set; }


        /// <summary>
        /// Description/notes of treatment.
        /// </summary>
        /// <value>Description/notes of treatment.</value>
        public string Notes { get; set; }


        /// <summary>
        /// Who entered the treatment.
        /// </summary>
        /// <value>Who entered the treatment.</value>
        public string EnteredBy { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Treatment {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  EventType: ").Append(EventType).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Glucose: ").Append(Glucose).Append("\n");
            sb.Append("  GlucoseType: ").Append(GlucoseType).Append("\n");
            sb.Append("  Carbs: ").Append(Carbs).Append("\n");
            sb.Append("  Insulin: ").Append(Insulin).Append("\n");
            sb.Append("  Units: ").Append(Units).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  EnteredBy: ").Append(EnteredBy).Append("\n");

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
            return Equals((Treatment) obj);
        }

        /// <summary>
        /// Returns true if Treatment instances are equal
        /// </summary>
        /// <param name="other">Instance of Treatment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Treatment other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                    ) &&
                (
                    EventType == other.EventType ||
                    EventType != null &&
                    EventType.Equals(other.EventType)
                    ) &&
                (
                    CreatedAt == other.CreatedAt ||
                    CreatedAt != null &&
                    CreatedAt.Equals(other.CreatedAt)
                    ) &&
                (
                    Glucose == other.Glucose ||
                    Glucose != null &&
                    Glucose.Equals(other.Glucose)
                    ) &&
                (
                    GlucoseType == other.GlucoseType ||
                    GlucoseType != null &&
                    GlucoseType.Equals(other.GlucoseType)
                    ) &&
                (
                    Carbs == other.Carbs ||
                    Carbs != null &&
                    Carbs.Equals(other.Carbs)
                    ) &&
                (
                    Insulin == other.Insulin ||
                    Insulin != null &&
                    Insulin.Equals(other.Insulin)
                    ) &&
                (
                    Units == other.Units ||
                    Units != null &&
                    Units.Equals(other.Units)
                    ) &&
                (
                    Notes == other.Notes ||
                    Notes != null &&
                    Notes.Equals(other.Notes)
                    ) &&
                (
                    EnteredBy == other.EnteredBy ||
                    EnteredBy != null &&
                    EnteredBy.Equals(other.EnteredBy)
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

                if (Id != null)
                    hash = hash*59 + Id.GetHashCode();

                if (EventType != null)
                    hash = hash*59 + EventType.GetHashCode();

                if (CreatedAt != null)
                    hash = hash*59 + CreatedAt.GetHashCode();

                if (Glucose != null)
                    hash = hash*59 + Glucose.GetHashCode();

                if (GlucoseType != null)
                    hash = hash*59 + GlucoseType.GetHashCode();

                if (Carbs != null)
                    hash = hash*59 + Carbs.GetHashCode();

                if (Insulin != null)
                    hash = hash*59 + Insulin.GetHashCode();

                if (Units != null)
                    hash = hash*59 + Units.GetHashCode();

                if (Notes != null)
                    hash = hash*59 + Notes.GetHashCode();

                if (EnteredBy != null)
                    hash = hash*59 + EnteredBy.GetHashCode();

                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Treatment left, Treatment right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Treatment left, Treatment right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}