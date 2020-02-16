using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCA.Controllers
{
	public class CadastroAtivoController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "SCA - Cadastro de Ativos";

			return View();
		}
	}
}
