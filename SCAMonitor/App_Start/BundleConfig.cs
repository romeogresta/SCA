using System.Web;
using System.Web.Optimization;

namespace SCAMonitor {
	public class BundleConfig {
		// Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles) {
			BundleTable.EnableOptimizations = false;

			bundles.Add(new ScriptBundle("~/bundles/site").Include(
						"~/Scripts/site.js"));

			bundles.Add(new ScriptBundle("~/bundles/jquery.oauth").Include(
						"~/Scripts/jquery.oauth.js"));

			bundles.Add(new ScriptBundle("~/bundles/OAuthClient").Include(
						"~/Scripts/OAuthClient.js"));

			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/json").Include(
						"~/Scripts/json2.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/jquery.mask").Include(
						"~/Scripts/jquery.mask.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/Chart.js").Include(
						"~/Scripts/Chart.js/Chart.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/store.js").Include(
						"~/Scripts/store.js/store.min.js"));

			// Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
			// pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css",
					  "~/Scripts/Chart.js/Chart.min.css"));
		}
	}
}
