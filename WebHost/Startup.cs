using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebHost.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.xml", Watch = true)]
namespace WebHost
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
