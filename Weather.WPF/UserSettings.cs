using Weather.Services;

namespace Weather.WPF
{
    public class UserSettings : IUserSettings
    {
        public bool IsMetric { get; } = false;
    }
}