using System.Web;
using System.Web.Optimization;

namespace SQLProgrammability
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // ThemeDashboard
            bundles.Add(new StyleBundle("~/assets/css").Include(
                      "~/assets/css/toolkit-inverse.css",
                      "~/assets/css/docs.css",
                      "~/assets/css/application.css"));
            bundles.Add(new ScriptBundle("~/assets/js").Include(
                      "~/assets/js/jquery.min.js",
                      "~/assets/js/chart.js",
                      "~/assets/js/tablesorter.min.js",
                      "~/assets/js/toolkit.js",
                      "~/assets/js/application.js"));
        }
    }
}
