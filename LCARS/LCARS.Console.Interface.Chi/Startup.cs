using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LCARS.Console.Interface.Chi.Startup))]
namespace LCARS.Console.Interface.Chi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
