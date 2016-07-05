using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(examenII_Lenguajes.Startup))]
namespace examenII_Lenguajes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
