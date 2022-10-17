using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ecommerce_Website.Startup))]
namespace Ecommerce_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
