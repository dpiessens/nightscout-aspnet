using System;
using System.Text;
using Newtonsoft.Json;

namespace Nightscout.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Threshold : IEquatable<Threshold>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Threshold" /> class.
        /// </summary>
        /// <param name="BgHigh">High BG range..</param>
        /// <param name="BgTargetTop">Top of target range..</param>
        /// <param name="BgTargetBottom">Bottom of target range..</param>
        /// <param name="BgLow">Low BG range..</param>
        public Threshold(int? BgHigh = null, int? BgTargetTop = null, int? BgTargetBottom = null, int? BgLow = null)
        {
            this.BgHigh = BgHigh;
            this.BgTargetTop = BgTargetTop;
            this.BgTargetBottom = BgTargetBottom;
            this.BgLow = BgLow;
        }


        /// <summary>
        /// High BG range.
        /// </summary>
        /// <value>High BG range.</value>
        public int? BgHigh { get; set; }


        /// <summary>
        /// Top of target range.
        /// </summary>
        /// <value>Top of target range.</value>
        public int? BgTargetTop { get; set; }


        /// <summary>
        /// Bottom of target range.
        /// </summary>
        /// <value>Bottom of target range.</value>
        public int? BgTargetBottom { get; set; }


        /// <summary>
        /// Low BG range.
        /// </summary>
        /// <value>Low BG range.</value>
        public int? BgLow { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Threshold {\n");
            sb.Append("  BgHigh: ").Append(BgHigh).Append("\n");
            sb.Append("  BgTargetTop: ").Append(BgTargetTop).Append("\n");
            sb.Append("  BgTargetBottom: ").Append(BgTargetBottom).Append("\n");
            sb.Append("  BgLow: ").Append(BgLow).Append("\n");

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
            return Equals((Threshold) obj);
        }

        /// <summary>
        /// Returns true if Threshold instances are equal
        /// </summary>
        /// <param name="other">Instance of Threshold to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Threshold other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    BgHigh == other.BgHigh ||
                    BgHigh != null &&
                    BgHigh.Equals(other.BgHigh)
                    ) &&
                (
                    BgTargetTop == other.BgTargetTop ||
                    BgTargetTop != null &&
                    BgTargetTop.Equals(other.BgTargetTop)
                    ) &&
                (
                    BgTargetBottom == other.BgTargetBottom ||
                    BgTargetBottom != null &&
                    BgTargetBottom.Equals(other.BgTargetBottom)
                    ) &&
                (
                    BgLow == other.BgLow ||
                    BgLow != null &&
                    BgLow.Equals(other.BgLow)
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

                if (BgHigh != null)
                    hash = hash*59 + BgHigh.GetHashCode();

                if (BgTargetTop != null)
                    hash = hash*59 + BgTargetTop.GetHashCode();

                if (BgTargetBottom != null)
                    hash = hash*59 + BgTargetBottom.GetHashCode();

                if (BgLow != null)
                    hash = hash*59 + BgLow.GetHashCode();

                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Threshold left, Threshold right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Threshold left, Threshold right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}