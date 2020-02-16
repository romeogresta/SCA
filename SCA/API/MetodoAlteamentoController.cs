using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SCA.Logical;

namespace SCA.API {
	[RoutePrefix("api/metodoalteamento")]
	public class MetodoAlteamentoController : BaseApiController {
		[Route("")]
		[HttpGet]
		public IHttpActionResult RecuperarMetodoAlteamento() {
			return Ok(MetodoAlteamentoLogical.RecuperarMetodoAlteamento().OrderBy(p => p.Name));
		}
		
	}
}