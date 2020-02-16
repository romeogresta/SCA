using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SCA.Logical;

namespace SCA.API {
	[RoutePrefix("api/logsensor")]
	public class LogSensorController : BaseApiController {
		[Route("{idSensor}")]
		[HttpGet]
		public IHttpActionResult RecuperarLogSensor(int idSensor) {
			return Ok(LogSensorLogical.RecuperarLogSensor(idSensor));
		}
		[Route("{idBarragem}/{idSensor}/ocorrencia")]
		[HttpGet]
		public IHttpActionResult RecuperarOcorrencias(int idBarragem, int idSensor) {
			return Ok(LogSensorLogical.RecuperarOcorrencias(idBarragem, idSensor));
		}
	}
}