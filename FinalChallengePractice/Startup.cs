using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalChallengePractice.Startup))]
namespace FinalChallengePractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
