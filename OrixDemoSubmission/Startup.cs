using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrixDemoSubmission.Startup))]
namespace OrixDemoSubmission
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
