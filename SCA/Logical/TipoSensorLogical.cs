using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCA.Models;

namespace SCA.Logical {
	public static class TipoSensorLogical {
		private static object[] tiposSensores = {
			new { Name = "Piezométrico", UnidadeMedida = "kg/cm²" },
			new { Name = "Medição de deslocamento horizontal", UnidadeMedida = "cm" },
			new { Name = "Medição de resíduos", UnidadeMedida = "kg/m²" },
			new { Name = "Termal", UnidadeMedida = "ºC" },
			new { Name = "Meteorológico", UnidadeMedida = "mm" },
		};

		public static List<TipoSensor> RecuperarTipoSensor() {
			try {
				using (var dbTipoSensor = new TipoSensorContext()) {
					return dbTipoSensor.Records.ToList();
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static void CarregarTipoSensor() {
			using (var dbTipoSensor = new TipoSensorContext()) {
				if (dbTipoSensor.Records.Count() == 0) {
					int idTipoSensor = 1;

					foreach (object tipo in tiposSensores) {
						string name = tipo.GetType().GetProperty("Name").GetValue(tipo, null).ToString();
						string unidadeMedida = tipo.GetType().GetProperty("UnidadeMedida").GetValue(tipo, null).ToString();

						TipoSensor tipoSensor = new TipoSensor(idTipoSensor, name, unidadeMedida);
						dbTipoSensor.Records.Add(tipoSensor);

						idTipoSensor++;
					}

					dbTipoSensor.SaveChanges();
				}
			}
		}
	}
}