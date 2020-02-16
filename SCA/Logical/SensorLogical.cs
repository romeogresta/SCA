using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using SCA.Models;

namespace SCA.Logical {
	public static class SensorLogical {
		public static List<Sensor> RecuperarSensor() {
			try {
				using (var dbSensor = new SensorContext()) {
					return dbSensor.Records.ToList();
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static Sensor IncluirSensor(SensorRequest sensorRequest) {
			try {
				using (var dbSensor = new SensorContext()) {
					int idMaxSensor = 0;

					if (dbSensor.Records.Count() > 0) {
						idMaxSensor = (
							from a in dbSensor.Records
							select a.ID).Max();
					}

					idMaxSensor++;

					Sensor sensor = new Sensor(idMaxSensor, sensorRequest.IDTipoSensor, sensorRequest.IDBarragem, sensorRequest.Name, sensorRequest.MedicaoMinima, sensorRequest.MedicaoMaximaSeguranca, sensorRequest.MedicaoMaximaAlerta);
					dbSensor.Records.Add(sensor);

					dbSensor.SaveChanges();

					return sensor;
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}
		public static Sensor AlterarSensor(int id, SensorRequest sensorRequest) {
			try {
				Sensor sensor = new Sensor();

				using (var dbSensor = new SensorContext()) {
					sensor = (
						from s in dbSensor.Records
						where s.ID == id
						select s).FirstOrDefault();

					if (sensor != null) {
						sensor.IDTipoSensor = sensorRequest.IDTipoSensor;
						sensor.IDBarragem = sensorRequest.IDBarragem;
						sensor.Name = sensorRequest.Name;
						sensor.MedicaoMinima = sensorRequest.MedicaoMinima;
						sensor.MedicaoMaximaSeguranca = sensorRequest.MedicaoMaximaSeguranca;
						sensor.MedicaoMaximaAlerta = sensorRequest.MedicaoMaximaAlerta;

						dbSensor.Records.Update(sensor);

						dbSensor.SaveChanges();
					}

					return sensor;
				}				
			}
			catch (Exception e) {
				throw (e);
			}
		}
		public static Sensor ExcluirSensor(int id) {
			try {
				Sensor sensor = new Sensor();

				using (var dbSensor = new SensorContext()) {
					sensor = (
						from s in dbSensor.Records
						where s.ID == id
						select s).FirstOrDefault();

					if (sensor != null) {
						dbSensor.Records.Remove(sensor);

						dbSensor.SaveChanges();
					}
				}

				return sensor;
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static void CarregarDadosIniciais() {
			string json = "";

			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "SCA.DadosIniciais.Sensor.json";

			using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
				using (StreamReader reader = new StreamReader(stream)) {
					json = reader.ReadToEnd();
				}
			}

			List<Sensor> sensores = JsonConvert.DeserializeObject<List<Sensor>>(json);

			using (var dbSensor = new SensorContext()) {
				dbSensor.Records.AddRange(sensores);

				dbSensor.SaveChanges();
			}
		}
	}
}