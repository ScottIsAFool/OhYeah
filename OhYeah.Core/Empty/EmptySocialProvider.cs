using Cimbalino.Toolkit.Services;
using OhYeah.Core.Model;
using OhYeah.Core.Social;

namespace OhYeah.Core.Empty
{
    public class EmptySocialProvider : BaseSocialProvider
    {
        public override string Name { get; } = "Design time";
        public override Provider Provider { get; } = Provider.Facebook;

        public override User User { get; protected set; } = new User {Name = "Scott Lovegrove"};

        public EmptySocialProvider(IApplicationSettingsService applicationSettingsService) : base(applicationSettingsService)
        {
        }
    }
}
