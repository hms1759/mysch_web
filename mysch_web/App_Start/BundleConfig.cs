using System.Web;
using System.Web.Optimization;

namespace mysch_web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/asset/css/bootstrap-1.css",
                      "~/Content/asset/css/font-awesome.min.css",
                      "~/Content/asset/css/materialize.css",
                      "~/Content/asset/css/style-mob.css",
                      "~/Content/asset/css/style.css",
                      "~/Content/asset/css/site.css"));

            #region for template design
             
            bundles.Add(new ScriptBundle("~/template/js").Include(
                    "~/Content/asset/js/bootstrap.min.js",
                    "~/Content/asset/js/custom.js",
                    "~/Content/asset/js/main.min.js",
                    "~/Content/asset/js/materialize.min.js"));


            bundles.Add(new StyleBundle("~/template/css").Include(
                    "~/Content/asset/css/materialize.css",
                    "~/Content/asset/css/style-mob.css",
                     "~/Content/asset/css/style.css",
                    "~/Content/asset/css/bootstrap-1.css",
                    "~/Content/asset/css/font-awesome.min.css"));


            #endregion

        }
    }
}
