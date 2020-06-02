using Weather.Services;

namespace Weather.Web
{
    public class UserSettings : IUserSettings
    {
        public bool IsMetric { get; } = false;
    }
}