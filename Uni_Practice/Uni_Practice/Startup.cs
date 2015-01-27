using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Uni_Practice.Startup))]
namespace Uni_Practice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
