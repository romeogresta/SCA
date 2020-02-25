using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.JsonPatch;
using SCA.Models;
using SCA.Logical;

namespace SCA.API {	
	[RoutePrefix("api/sensor")]
	public class SensorController : BaseApiController {
		[Route("")]
		[HttpGet]
		public IHttpActionResult RecuperarSensor() {
			var sensores = (
				from s in SensorLogical.RecuperarSensor()
				join ts in TipoSensorLogical.RecuperarTipoSensor() on s.IDTipoSensor equals ts.ID
				join b in BarragemLogical.RecuperarBarragem() on s.IDBarragem equals b.ID
				orderby b.ID
				select new {
					ID = s.ID,
					Name = s.Name,
					IdTipoSensor = ts.ID,
					NameTipoSensor = ts.Name,
					IdBarragem = b.ID,
					NameBarragem = b.Name
				}).ToList();

			return Ok(sensores);
		}

		[Route("{id}")]
		[HttpGet]
		public IHttpActionResult RecuperarSensor(int id) {
			var sensor = (
				from s in SensorLogical.RecuperarSensor()
				join ts in TipoSensorLogical.RecuperarTipoSensor() on s.IDTipoSensor equals ts.ID
				join b in BarragemLogical.RecuperarBarragem() on s.IDBarragem equals b.ID
				where s.ID == id
				select new {
					ID = s.ID,
					Name = s.Name,
					IdTipoSensor = ts.ID,
					NameTipoSensor = ts.Name,
					IdBarragem = b.ID,
					NameBarragem = b.Name,
					MedicaoMinima = s.MedicaoMinima,
					MedicaoMaximaSeguranca = s.MedicaoMaximaSeguranca,
					MedicaoMaximaAlerta = s.MedicaoMaximaAlerta,
				}).FirstOrDefault();

			if (sensor != null) {
				return Ok(sensor);
			}
			else {
				return NotFound();
			}
		}

		[Route("barragem/{idBarragem}")]
		[HttpGet]
		public IHttpActionResult RecuperarSensorBarragem(int idBarragem) {
			var sensor = (
				from s in SensorLogical.RecuperarSensor()
				join ts in TipoSensorLogical.RecuperarTipoSensor() on s.IDTipoSensor equals ts.ID
				join b in BarragemLogical.RecuperarBarragem() on s.IDBarragem equals b.ID
				where s.IDBarragem == idBarragem
				select new {
					ID = s.ID,
					Name = s.Name,
					IdTipoSensor = ts.ID,
					NameTipoSensor = ts.Name,
					IdBarragem = b.ID,
					NameBarragem = b.Name,
					MedicaoMinima = s.MedicaoMinima,
					MedicaoMaximaSeguranca = s.MedicaoMaximaSeguranca,
					MedicaoMaximaAlerta = s.MedicaoMaximaAlerta,
				}).ToList();

			return Ok(sensor);
		}

		[Route("")]
		[HttpPost]
		public IHttpActionResult IncluirSensor([FromBody]SensorRequest sensorRequest) {
			Sensor sensor = SensorLogical.IncluirSensor(sensorRequest);

			return Ok(sensor);
		}

		[Route("{id}")]
		[HttpPost]
		public IHttpActionResult AlterarSensor(int id, [FromBody]SensorRequest sensorRequest) {
			Sensor sensor = SensorLogical.AlterarSensor(id, sensorRequest);

			if (sensor != null) {
				return Ok(sensor);
			}
			else {
				return NotFound();
			}
		}

		[Route("{id}")]
		[HttpDelete]
		public IHttpActionResult ExcluirSensor(int id) {
			Sensor sensor = SensorLogical.ExcluirSensor(id);

			if (sensor != null) {
				return Ok(sensor);
			}
			else {
				return NotFound();
			}
		}
	}
}