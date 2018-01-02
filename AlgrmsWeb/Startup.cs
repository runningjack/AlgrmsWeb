using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlgrmsWeb.Startup))]
namespace AlgrmsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        
    }
}