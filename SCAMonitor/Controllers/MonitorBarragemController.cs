using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCA.Controllers
{
	public class MonitorBarragemController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "SCA - Monitoramento de Barragens";

			return View();
		}
	}
}
