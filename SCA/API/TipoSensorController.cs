using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SCA.Logical;

namespace SCA.API {
	[RoutePrefix("api/tiposensor")]
	public class TipoSensorController : BaseApiController {
		[Route("")]
		[HttpGet]
		public IHttpActionResult RecuperarTipoSensor() {
			return Ok(TipoSensorLogical.RecuperarTipoSensor().OrderBy(p => p.Name));
		}		
	}
}