using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Config;



namespace WebHost
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            XmlConfigurator.Configure(new FileInfo(HostingEnvironment.MapPath("~/Log4Net.xml")));

            ILog log = LogManager.GetLogger(this.GetType().FullName);
            log.Debug("Guarda algo en la bitacora");
            log.Debug("Iniciando Aplicación");


            AreaRegistration.RegisterAllAreas();
            ContainerConfig.RegisterComponents();                          
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            ILog log = LogManager.GetLogger(this.GetType().FullName);
            log.Debug("Application End signal received, processing..");
            ModuleConfig.Stop();
            log.Debug("Application End signal processed");
        }
    }
}
