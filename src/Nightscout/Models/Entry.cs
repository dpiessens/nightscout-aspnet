using System;
using System.Text;
using Newtonsoft.Json;

namespace Nightscout.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Entry : IEquatable<Entry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entry" /> class.
        /// </summary>
        /// <param name="Type">sgv, mbg, cal, etc.</param>
        /// <param name="DateString">dateString, prefer ISO `8601`.</param>
        /// <param name="Date">Epoch.</param>
        /// <param name="Sgv">The glucose reading. (only available for sgv types).</param>
        /// <param name="Direction">Direction of glucose trend reported by CGM. (only available for sgv types).</param>
        /// <param name="Noise">Noise level at time of reading. (only available for sgv types).</param>
        /// <param name="Filtered">The raw filtered value directly from CGM transmitter. (only available for sgv types).</param>
        /// <param name="Unfiltered">The raw unfiltered value directly from CGM transmitter. (only available for sgv types).</param>
        /// <param name="Rssi">The signal strength from CGM transmitter. (only available for sgv types).</param>
        public Entry(string Type = null, string DateString = null, double? Date = null, double? Sgv = null,
            string Direction = null, double? Noise = null, double? Filtered = null, double? Unfiltered = null,
            double? Rssi = null)
        {
            this.Type = Type;
            this.DateString = DateString;
            this.Date = Date;
            this.Sgv = Sgv;
            this.Direction = Direction;
            this.Noise = Noise;
            this.Filtered = Filtered;
            this.Unfiltered = Unfiltered;
            this.Rssi = Rssi;
        }


        /// <summary>
        /// sgv, mbg, cal, etc
        /// </summary>
        /// <value>sgv, mbg, cal, etc</value>
        public string Type { get; set; }


        /// <summary>
        /// dateString, prefer ISO `8601`
        /// </summary>
        /// <value>dateString, prefer ISO `8601`</value>
        public string DateString { get; set; }


        /// <summary>
        /// Epoch
        /// </summary>
        /// <value>Epoch</value>
        public double? Date { get; set; }


        /// <summary>
        /// The glucose reading. (only available for sgv types)
        /// </summary>
        /// <value>The glucose reading. (only available for sgv types)</value>
        public double? Sgv { get; set; }


        /// <summary>
        /// Direction of glucose trend reported by CGM. (only available for sgv types)
        /// </summary>
        /// <value>Direction of glucose trend reported by CGM. (only available for sgv types)</value>
        public string Direction { get; set; }


        /// <summary>
        /// Noise level at time of reading. (only available for sgv types)
        /// </summary>
        /// <value>Noise level at time of reading. (only available for sgv types)</value>
        public double? Noise { get; set; }


        /// <summary>
        /// The raw filtered value directly from CGM transmitter. (only available for sgv types)
        /// </summary>
        /// <value>The raw filtered value directly from CGM transmitter. (only available for sgv types)</value>
        public double? Filtered { get; set; }


        /// <summary>
        /// The raw unfiltered value directly from CGM transmitter. (only available for sgv types)
        /// </summary>
        /// <value>The raw unfiltered value directly from CGM transmitter. (only available for sgv types)</value>
        public double? Unfiltered { get; set; }


        /// <summary>
        /// The signal strength from CGM transmitter. (only available for sgv types)
        /// </summary>
        /// <value>The signal strength from CGM transmitter. (only available for sgv types)</value>
        public double? Rssi { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Entry {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  DateString: ").Append(DateString).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Sgv: ").Append(Sgv).Append("\n");
            sb.Append("  Direction: ").Append(Direction).Append("\n");
            sb.Append("  Noise: ").Append(Noise).Append("\n");
            sb.Append("  Filtered: ").Append(Filtered).Append("\n");
            sb.Append("  Unfiltered: ").Append(Unfiltered).Append("\n");
            sb.Append("  Rssi: ").Append(Rssi).Append("\n");

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
            return Equals((Entry) obj);
        }

        /// <summary>
        /// Returns true if Entry instances are equal
        /// </summary>
        /// <param name="other">Instance of Entry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Entry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                    ) &&
                (
                    DateString == other.DateString ||
                    DateString != null &&
                    DateString.Equals(other.DateString)
                    ) &&
                (
                    Date == other.Date ||
                    Date != null &&
                    Date.Equals(other.Date)
                    ) &&
                (
                    Sgv == other.Sgv ||
                    Sgv != null &&
                    Sgv.Equals(other.Sgv)
                    ) &&
                (
                    Direction == other.Direction ||
                    Direction != null &&
                    Direction.Equals(other.Direction)
                    ) &&
                (
                    Noise == other.Noise ||
                    Noise != null &&
                    Noise.Equals(other.Noise)
                    ) &&
                (
                    Filtered == other.Filtered ||
                    Filtered != null &&
                    Filtered.Equals(other.Filtered)
                    ) &&
                (
                    Unfiltered == other.Unfiltered ||
                    Unfiltered != null &&
                    Unfiltered.Equals(other.Unfiltered)
                    ) &&
                (
                    Rssi == other.Rssi ||
                    Rssi != null &&
                    Rssi.Equals(other.Rssi)
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

                if (Type != null)
                    hash = hash*59 + Type.GetHashCode();

                if (DateString != null)
                    hash = hash*59 + DateString.GetHashCode();

                if (Date != null)
                    hash = hash*59 + Date.GetHashCode();

                if (Sgv != null)
                    hash = hash*59 + Sgv.GetHashCode();

                if (Direction != null)
                    hash = hash*59 + Direction.GetHashCode();

                if (Noise != null)
                    hash = hash*59 + Noise.GetHashCode();

                if (Filtered != null)
                    hash = hash*59 + Filtered.GetHashCode();

                if (Unfiltered != null)
                    hash = hash*59 + Unfiltered.GetHashCode();

                if (Rssi != null)
                    hash = hash*59 + Rssi.GetHashCode();

                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Entry left, Entry right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entry left, Entry right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}