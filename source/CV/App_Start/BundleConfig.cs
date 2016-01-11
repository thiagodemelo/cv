using System.Web.Mvc;
using System.Web.Optimization;
namespace CV
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/js/jquery.min.js",
                        "~/Content/js/smoothscroll.js",
                        "~/Content/js/Chart.js",
                        "~/Content/js/bootstrap.js",                        
                        "~/Content/js/custom.js",
                        "~/Content/js/TempodeTrabalho.js",
                        "~/Content/js/valida.js"
                        ));


            bundles.Add(new StyleBundle("~/bundles/estilo").Include(
                      "~/Content/bootstrap.min.css", "~/Content/Site.css"
                      , "~/Content/css/main.css", "~/Content/css/font-awesome.min.css"
                      , "~/Content/css/scrolltop.css"));

            bundles.IgnoreList.Clear();
        }
    }
}