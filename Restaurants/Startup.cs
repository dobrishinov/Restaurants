using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restaurants.Startup))]
namespace Restaurants
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
