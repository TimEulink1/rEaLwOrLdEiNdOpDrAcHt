using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindProject.Services
{
    public class ConfigService
    {
        private readonly Configuration configManager;
        private readonly KeyValueConfigurationCollection confCollection;
        public ConfigService()
        {
            configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            confCollection = configManager.AppSettings.Settings;
        }
        public double GetEfficiëntiePercentageConfig()
        {
            var x = confCollection["efficiëntiePercentage"].Value;
            if (x == "") return 0;
            return Convert.ToDouble(x);
        }

        public double GetAmountOfPanels()
        {
            var x = confCollection["AmountOfPanels"].Value;
            if (x == "") return 0;
            return Convert.ToInt32(x);
        }

        public string GetPostalCode()
        {
            return confCollection["PostalCode"].Value;
        }

        public string GetSiteID()
        {
            return confCollection["SiteId"].Value;
        }

        public string GetApiKey()
        {
            return confCollection["ApiKey"].Value;
        }
        public void SetEfficiëntiePercentageConfig(double percentage)
        {
            confCollection["efficiëntiePercentage"].Value = percentage.ToString();
            Save();
        }

        public void SetPostalCode(string postalCode)
        {
            confCollection["PostalCode"].Value = postalCode;
            Save();
        }

        public void SetSiteID(string SiteId)
        {
            confCollection["SiteId"].Value = SiteId;
            Save();
        }

        public void SetApiKey(string ApiKey)
        {
            confCollection["ApiKey"].Value = ApiKey;
            Save();
        }

        public void Save()
        {
            configManager.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configManager.AppSettings.SectionInformation.Name);
        }
    }
}
