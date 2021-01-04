using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EliteGym.Startup))]
namespace EliteGym
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
