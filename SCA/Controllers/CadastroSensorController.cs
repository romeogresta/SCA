using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCA.Controllers
{
	public class CadastroSensorController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "SCA - Cadastro de Sensor";

			return View();
		}
	}
}
