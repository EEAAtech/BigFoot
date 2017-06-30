using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigFoot.Startup))]
namespace BigFoot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
