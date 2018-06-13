using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoLocadora.Startup))]
namespace VideoLocadora
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
