using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Nightscout.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Settings : IEquatable<Settings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Settings" /> class.
        /// </summary>
        /// <param name="Units">Default units for glucose measurements across the server..</param>
        /// <param name="TimeFormat">Default time format.</param>
        /// <param name="CustomTitle">Default custom title to be displayed system wide..</param>
        /// <param name="NightMode">Should Night mode be enabled by default?.</param>
        /// <param name="Theme">Default theme to be displayed system wide, `default`, `colors`, `colorblindfriendly`..</param>
        /// <param name="Language">Default language code to be used system wide.</param>
        /// <param name="ShowPlugins">Plugins that should be shown by default.</param>
        /// <param name="ShowRawbg">If Raw BG is enabled when should it be shown? `never`, `always`, `noise`.</param>
        /// <param name="AlarmTypes">Enabled alarm types, can be multiple.</param>
        /// <param name="AlarmUrgentHigh">Enable/Disable client-side Urgent High alarms by default, for use with `simple` alarms..</param>
        /// <param name="AlarmHigh">Enable/Disable client-side High alarms by default, for use with `simple` alarms..</param>
        /// <param name="AlarmLow">Enable/Disable client-side Low alarms by default, for use with `simple` alarms..</param>
        /// <param name="AlarmUrgentLow">Enable/Disable client-side Urgent Low alarms by default, for use with `simple` alarms..</param>
        /// <param name="AlarmTimeagoWarn">Enable/Disable client-side stale data alarms by default..</param>
        /// <param name="AlarmTimeagoWarnMins">Number of minutes before a stale data warning is generated..</param>
        /// <param name="AlarmTimeagoUrgent">Enable/Disable client-side urgent stale data alarms by default..</param>
        /// <param name="AlarmTimeagoUrgentMins">Number of minutes before a stale data warning is generated..</param>
        /// <param name="Enable">Enabled features.</param>
        /// <param name="Thresholds">Thresholds.</param>
        public Settings(string Units = null, string TimeFormat = null, string CustomTitle = null, bool? NightMode = null,
            string Theme = null, string Language = null, string ShowPlugins = null, string ShowRawbg = null,
            List<string> AlarmTypes = null, bool? AlarmUrgentHigh = null, bool? AlarmHigh = null, bool? AlarmLow = null,
            bool? AlarmUrgentLow = null, bool? AlarmTimeagoWarn = null, double? AlarmTimeagoWarnMins = null,
            bool? AlarmTimeagoUrgent = null, double? AlarmTimeagoUrgentMins = null, List<string> Enable = null,
            Threshold Thresholds = null)
        {
            this.Units = Units;
            this.TimeFormat = TimeFormat;
            this.CustomTitle = CustomTitle;
            this.NightMode = NightMode;
            this.Theme = Theme;
            this.Language = Language;
            this.ShowPlugins = ShowPlugins;
            this.ShowRawbg = ShowRawbg;
            this.AlarmTypes = AlarmTypes;
            this.AlarmUrgentHigh = AlarmUrgentHigh;
            this.AlarmHigh = AlarmHigh;
            this.AlarmLow = AlarmLow;
            this.AlarmUrgentLow = AlarmUrgentLow;
            this.AlarmTimeagoWarn = AlarmTimeagoWarn;
            this.AlarmTimeagoWarnMins = AlarmTimeagoWarnMins;
            this.AlarmTimeagoUrgent = AlarmTimeagoUrgent;
            this.AlarmTimeagoUrgentMins = AlarmTimeagoUrgentMins;
            this.Enable = Enable;
            this.Thresholds = Thresholds;
        }


        /// <summary>
        /// Default units for glucose measurements across the server.
        /// </summary>
        /// <value>Default units for glucose measurements across the server.</value>
        public string Units { get; set; }


        /// <summary>
        /// Default time format
        /// </summary>
        /// <value>Default time format</value>
        public string TimeFormat { get; set; }


        /// <summary>
        /// Default custom title to be displayed system wide.
        /// </summary>
        /// <value>Default custom title to be displayed system wide.</value>
        public string CustomTitle { get; set; }


        /// <summary>
        /// Should Night mode be enabled by default?
        /// </summary>
        /// <value>Should Night mode be enabled by default?</value>
        public bool? NightMode { get; set; }


        /// <summary>
        /// Default theme to be displayed system wide, `default`, `colors`, `colorblindfriendly`.
        /// </summary>
        /// <value>Default theme to be displayed system wide, `default`, `colors`, `colorblindfriendly`.</value>
        public string Theme { get; set; }


        /// <summary>
        /// Default language code to be used system wide
        /// </summary>
        /// <value>Default language code to be used system wide</value>
        public string Language { get; set; }


        /// <summary>
        /// Plugins that should be shown by default
        /// </summary>
        /// <value>Plugins that should be shown by default</value>
        public string ShowPlugins { get; set; }


        /// <summary>
        /// If Raw BG is enabled when should it be shown? `never`, `always`, `noise`
        /// </summary>
        /// <value>If Raw BG is enabled when should it be shown? `never`, `always`, `noise`</value>
        public string ShowRawbg { get; set; }


        /// <summary>
        /// Enabled alarm types, can be multiple
        /// </summary>
        /// <value>Enabled alarm types, can be multiple</value>
        public List<string> AlarmTypes { get; set; }


        /// <summary>
        /// Enable/Disable client-side Urgent High alarms by default, for use with `simple` alarms.
        /// </summary>
        /// <value>Enable/Disable client-side Urgent High alarms by default, for use with `simple` alarms.</value>
        public bool? AlarmUrgentHigh { get; set; }


        /// <summary>
        /// Enable/Disable client-side High alarms by default, for use with `simple` alarms.
        /// </summary>
        /// <value>Enable/Disable client-side High alarms by default, for use with `simple` alarms.</value>
        public bool? AlarmHigh { get; set; }


        /// <summary>
        /// Enable/Disable client-side Low alarms by default, for use with `simple` alarms.
        /// </summary>
        /// <value>Enable/Disable client-side Low alarms by default, for use with `simple` alarms.</value>
        public bool? AlarmLow { get; set; }


        /// <summary>
        /// Enable/Disable client-side Urgent Low alarms by default, for use with `simple` alarms.
        /// </summary>
        /// <value>Enable/Disable client-side Urgent Low alarms by default, for use with `simple` alarms.</value>
        public bool? AlarmUrgentLow { get; set; }


        /// <summary>
        /// Enable/Disable client-side stale data alarms by default.
        /// </summary>
        /// <value>Enable/Disable client-side stale data alarms by default.</value>
        public bool? AlarmTimeagoWarn { get; set; }


        /// <summary>
        /// Number of minutes before a stale data warning is generated.
        /// </summary>
        /// <value>Number of minutes before a stale data warning is generated.</value>
        public double? AlarmTimeagoWarnMins { get; set; }


        /// <summary>
        /// Enable/Disable client-side urgent stale data alarms by default.
        /// </summary>
        /// <value>Enable/Disable client-side urgent stale data alarms by default.</value>
        public bool? AlarmTimeagoUrgent { get; set; }


        /// <summary>
        /// Number of minutes before a stale data warning is generated.
        /// </summary>
        /// <value>Number of minutes before a stale data warning is generated.</value>
        public double? AlarmTimeagoUrgentMins { get; set; }


        /// <summary>
        /// Enabled features
        /// </summary>
        /// <value>Enabled features</value>
        public List<string> Enable { get; set; }


        /// <summary>
        /// Gets or Sets Thresholds
        /// </summary>
        public Threshold Thresholds { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Settings {\n");
            sb.Append("  Units: ").Append(Units).Append("\n");
            sb.Append("  TimeFormat: ").Append(TimeFormat).Append("\n");
            sb.Append("  CustomTitle: ").Append(CustomTitle).Append("\n");
            sb.Append("  NightMode: ").Append(NightMode).Append("\n");
            sb.Append("  Theme: ").Append(Theme).Append("\n");
            sb.Append("  Language: ").Append(Language).Append("\n");
            sb.Append("  ShowPlugins: ").Append(ShowPlugins).Append("\n");
            sb.Append("  ShowRawbg: ").Append(ShowRawbg).Append("\n");
            sb.Append("  AlarmTypes: ").Append(AlarmTypes).Append("\n");
            sb.Append("  AlarmUrgentHigh: ").Append(AlarmUrgentHigh).Append("\n");
            sb.Append("  AlarmHigh: ").Append(AlarmHigh).Append("\n");
            sb.Append("  AlarmLow: ").Append(AlarmLow).Append("\n");
            sb.Append("  AlarmUrgentLow: ").Append(AlarmUrgentLow).Append("\n");
            sb.Append("  AlarmTimeagoWarn: ").Append(AlarmTimeagoWarn).Append("\n");
            sb.Append("  AlarmTimeagoWarnMins: ").Append(AlarmTimeagoWarnMins).Append("\n");
            sb.Append("  AlarmTimeagoUrgent: ").Append(AlarmTimeagoUrgent).Append("\n");
            sb.Append("  AlarmTimeagoUrgentMins: ").Append(AlarmTimeagoUrgentMins).Append("\n");
            sb.Append("  Enable: ").Append(Enable).Append("\n");
            sb.Append("  Thresholds: ").Append(Thresholds).Append("\n");

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
            return Equals((Settings) obj);
        }

        /// <summary>
        /// Returns true if Settings instances are equal
        /// </summary>
        /// <param name="other">Instance of Settings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Settings other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Units == other.Units ||
                    Units != null &&
                    Units.Equals(other.Units)
                    ) &&
                (
                    TimeFormat == other.TimeFormat ||
                    TimeFormat != null &&
                    TimeFormat.Equals(other.TimeFormat)
                    ) &&
                (
                    CustomTitle == other.CustomTitle ||
                    CustomTitle != null &&
                    CustomTitle.Equals(other.CustomTitle)
                    ) &&
                (
                    NightMode == other.NightMode ||
                    NightMode != null &&
                    NightMode.Equals(other.NightMode)
                    ) &&
                (
                    Theme == other.Theme ||
                    Theme != null &&
                    Theme.Equals(other.Theme)
                    ) &&
                (
                    Language == other.Language ||
                    Language != null &&
                    Language.Equals(other.Language)
                    ) &&
                (
                    ShowPlugins == other.ShowPlugins ||
                    ShowPlugins != null &&
                    ShowPlugins.Equals(other.ShowPlugins)
                    ) &&
                (
                    ShowRawbg == other.ShowRawbg ||
                    ShowRawbg != null &&
                    ShowRawbg.Equals(other.ShowRawbg)
                    ) &&
                (
                    AlarmTypes == other.AlarmTypes ||
                    AlarmTypes != null &&
                    AlarmTypes.SequenceEqual(other.AlarmTypes)
                    ) &&
                (
                    AlarmUrgentHigh == other.AlarmUrgentHigh ||
                    AlarmUrgentHigh != null &&
                    AlarmUrgentHigh.Equals(other.AlarmUrgentHigh)
                    ) &&
                (
                    AlarmHigh == other.AlarmHigh ||
                    AlarmHigh != null &&
                    AlarmHigh.Equals(other.AlarmHigh)
                    ) &&
                (
                    AlarmLow == other.AlarmLow ||
                    AlarmLow != null &&
                    AlarmLow.Equals(other.AlarmLow)
                    ) &&
                (
                    AlarmUrgentLow == other.AlarmUrgentLow ||
                    AlarmUrgentLow != null &&
                    AlarmUrgentLow.Equals(other.AlarmUrgentLow)
                    ) &&
                (
                    AlarmTimeagoWarn == other.AlarmTimeagoWarn ||
                    AlarmTimeagoWarn != null &&
                    AlarmTimeagoWarn.Equals(other.AlarmTimeagoWarn)
                    ) &&
                (
                    AlarmTimeagoWarnMins == other.AlarmTimeagoWarnMins ||
                    AlarmTimeagoWarnMins != null &&
                    AlarmTimeagoWarnMins.Equals(other.AlarmTimeagoWarnMins)
                    ) &&
                (
                    AlarmTimeagoUrgent == other.AlarmTimeagoUrgent ||
                    AlarmTimeagoUrgent != null &&
                    AlarmTimeagoUrgent.Equals(other.AlarmTimeagoUrgent)
                    ) &&
                (
                    AlarmTimeagoUrgentMins == other.AlarmTimeagoUrgentMins ||
                    AlarmTimeagoUrgentMins != null &&
                    AlarmTimeagoUrgentMins.Equals(other.AlarmTimeagoUrgentMins)
                    ) &&
                (
                    Enable == other.Enable ||
                    Enable != null &&
                    Enable.SequenceEqual(other.Enable)
                    ) &&
                (
                    Thresholds == other.Thresholds ||
                    Thresholds != null &&
                    Thresholds.Equals(other.Thresholds)
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

                if (Units != null)
                    hash = hash*59 + Units.GetHashCode();

                if (TimeFormat != null)
                    hash = hash*59 + TimeFormat.GetHashCode();

                if (CustomTitle != null)
                    hash = hash*59 + CustomTitle.GetHashCode();

                if (NightMode != null)
                    hash = hash*59 + NightMode.GetHashCode();

                if (Theme != null)
                    hash = hash*59 + Theme.GetHashCode();

                if (Language != null)
                    hash = hash*59 + Language.GetHashCode();

                if (ShowPlugins != null)
                    hash = hash*59 + ShowPlugins.GetHashCode();

                if (ShowRawbg != null)
                    hash = hash*59 + ShowRawbg.GetHashCode();

                if (AlarmTypes != null)
                    hash = hash*59 + AlarmTypes.GetHashCode();

                if (AlarmUrgentHigh != null)
                    hash = hash*59 + AlarmUrgentHigh.GetHashCode();

                if (AlarmHigh != null)
                    hash = hash*59 + AlarmHigh.GetHashCode();

                if (AlarmLow != null)
                    hash = hash*59 + AlarmLow.GetHashCode();

                if (AlarmUrgentLow != null)
                    hash = hash*59 + AlarmUrgentLow.GetHashCode();

                if (AlarmTimeagoWarn != null)
                    hash = hash*59 + AlarmTimeagoWarn.GetHashCode();

                if (AlarmTimeagoWarnMins != null)
                    hash = hash*59 + AlarmTimeagoWarnMins.GetHashCode();

                if (AlarmTimeagoUrgent != null)
                    hash = hash*59 + AlarmTimeagoUrgent.GetHashCode();

                if (AlarmTimeagoUrgentMins != null)
                    hash = hash*59 + AlarmTimeagoUrgentMins.GetHashCode();

                if (Enable != null)
                    hash = hash*59 + Enable.GetHashCode();

                if (Thresholds != null)
                    hash = hash*59 + Thresholds.GetHashCode();

                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Settings left, Settings right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Settings left, Settings right)
        {
            return !Equals(left, right);
        }

        #endregion Operators
    }
}