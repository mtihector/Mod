using System.Web;
using System.Web.Optimization;

namespace WebHost
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/baseScripts").Include(
                        
                      ));
            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/jquery.scrollbar.css",
                "~/Content/site.css",
                "~/Content/fontawesome/font-awesome.min.css"
                ));
        }
    }
}
