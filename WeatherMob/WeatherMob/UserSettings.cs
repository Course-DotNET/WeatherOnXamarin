using Weather.Services;

namespace Weather
{
    public class UserSettings : IUserSettings
    {
        public bool IsMetric { get; } = false;
    }
}