using System.Web;
using System.Web.Optimization;

namespace ReteaSocialaMDS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                    new ScriptBundle("~/bundles/jquery")
                            .Include("~/Scripts/jquery-{version}.js")
                            .Include("~/Scripts/jquery.unobtrusive-ajax*")
                            .Include("~/Scripts/jquery.validate*")
                            .Include("~/Scripts/jquery-ui-{version}.js")
                            .Include("~/Scripts/jquery.infinitescroll.js")
                    );
        
            bundles.Add(
                new ScriptBundle("~/bundles/masonry")
                            .Include("~/Scripts/masonry.pkgd.min.js")
                );
            //imagesloaded.pkgd.js
            bundles.Add(
                new ScriptBundle("~/bundles/imagesloaded")
                            .Include("~/Scripts/imagesloaded.pkgd.js")
                );
            
            

            bundles.Add(new ScriptBundle("~/bundles/MicrosoftAjax").Include(
                       "~/Scripts/MicrosoftAjax*"));

            bundles.Add(new ScriptBundle("~/bundles/MicrosoftMvcAjax").Include(
                       "~/Scripts/MicrosoftMvcAjax*"));

            bundles.Add(new ScriptBundle("~/bundles/MicrosoftMvcValidation").Include(
                       "~/Scripts/MicrosoftMvcValidation*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-datepicker3.css",
                      "~/Content/locales/bootstrap-datepicker.en-GB.min.js"));
            bundles.Add(new StyleBundle("~/Content/fontAwesome").Include(
                "~/Content/font-awesome.css"));

        }
    }
}
