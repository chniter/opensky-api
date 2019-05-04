using opensky_api.Configuration.Settings;

namespace opensky_api.Configuration
{
    public static class ConfigurationManager
    {
        private static GeneralSettings _settings;

        public static GeneralSettings Settings => _settings ?? (_settings = new GeneralSettings());
    }
}