using System.Web;
using System.Web.Optimization;

namespace Monedero
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.js",
                      "~/Scripts/DataTables/dataTables.responsive.js",
                      "~/Scripts/DataTables/dataTables.buttons.js",
                       "~/Scripts/DataTables/buttons.flash.js",
                       "~/Scripts/DataTables/jszip.js",
                       "~/Scripts/DataTables/pdfmake.js",
                       "~/Scripts/DataTables/vfs_fonts.js",
                       "~/Scripts/DataTables/buttons.html5.js",
                       "~/Scripts/DataTables/buttons.print.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTable/csss/dataTables.bootstrap.css",
                  "~/Content/DataTables/css/responsive.dataTables.css",
                  "~/Content/DataTables/css/buttons.dataTables.css"));

        }
    }
}
