using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodOrderMgmtApplication.Startup))]
namespace FoodOrderMgmtApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
