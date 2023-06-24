using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProdavnicaPiva.Startup))]
namespace ProdavnicaPiva
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
