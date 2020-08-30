using System;
using System.Configuration;

namespace Our.Umbraco.MaskBackoffice
{
    public static class AppSettingsManager
    {
        public static bool BackofficeMaskEnabled()
        {
            if (ConfigurationManager.AppSettings["Our.MaskBackoffice.Enabled"] == null)
                throw new Exception("\"Our.MaskBackoffice.Enabled\" is missing in AppSettings.");
            var enabled = Convert.ToBoolean(ConfigurationManager.AppSettings["Our.MaskBackoffice.Enabled"]);
            return enabled;

        }

        public static string[] GetBackofficeDomain()
        {
            if (ConfigurationManager.AppSettings["Our.MaskBackoffice.Domain"] != null)
            {
                var domains = ConfigurationManager.AppSettings["Our.MaskBackoffice.Domain"].Split(',');
                return domains;
            }

            throw new Exception("\"Our.MaskBackoffice.Domain\" is missing in AppSettings.");
        }

    }
}
