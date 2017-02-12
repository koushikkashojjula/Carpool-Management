using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoginSignup.Startup))]
namespace LoginSignup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
