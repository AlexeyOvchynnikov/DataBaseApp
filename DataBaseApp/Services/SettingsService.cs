using DataBaseApp.Services.Interfaces;
using Plugin.Settings;

namespace DataBaseApp.Services
{
    public class SettingsService : ISettingsService
    {
        private const string DatabaseVersionKey = "DatabaseVersion";

        public int DatabaseVersion
        {
            get
            {
                var res = CrossSettings.Current.GetValueOrDefault(DatabaseVersionKey, 0);
                return res;
            }
            set => CrossSettings.Current.AddOrUpdateValue(DatabaseVersionKey, value);
        }
    }
}
