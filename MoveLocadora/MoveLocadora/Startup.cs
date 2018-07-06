using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoveLocadora.Startup))]
namespace MoveLocadora
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
