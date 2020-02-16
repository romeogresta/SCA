using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SCA.Logical;

namespace SCA.API {
	[RoutePrefix("api/categoriaativo")]
	public class CategoriaAtivoController : BaseApiController {		
		[Route("")]
		[HttpGet]
		public IHttpActionResult RecuperarCategoriaAtivo() {
			return Ok(CategoriaAtivoLogical.RecuperarCategoriaAtivo().OrderBy(p => p.Name));			
		}		
	}
}