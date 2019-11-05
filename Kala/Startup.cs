using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kala.Startup))]
namespace Kala
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
