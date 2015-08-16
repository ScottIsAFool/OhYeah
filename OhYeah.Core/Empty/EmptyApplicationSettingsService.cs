using Cimbalino.Toolkit.Services;

namespace OhYeah.Core.Empty
{
    public class EmptyApplicationSettingsService : IApplicationSettingsService
    {
        public IApplicationSettingsServiceHandler Local { get; }
        public IApplicationSettingsServiceHandler Roaming { get; }
        public IApplicationSettingsServiceHandler Legacy { get; }
    }
}