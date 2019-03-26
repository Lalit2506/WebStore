using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebStoreAssignment2.Startup))]
namespace WebStoreAssignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
