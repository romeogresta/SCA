using SCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCA.Logical {
	public static class LogSensorLogical {

		public static void IncluirLogSensor(int idSensor, double medicaoSensor, DateTime dataMedicao) {
			try {
				using (var dbLogSensor = new LogSensorContext()) {
					int idMaxLogSensor = 0;

					if (dbLogSensor.Records.Count() > 0) {
						idMaxLogSensor = (
							from a in dbLogSensor.Records
							select a.ID).Max();
					}

					idMaxLogSensor++;

					LogSensor logSensor = new LogSensor(idMaxLogSensor, idSensor, medicaoSensor, dataMedicao);
					dbLogSensor.Records.Add(logSensor);

					dbLogSensor.SaveChanges();
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static List<LogSensor> RecuperarLogSensor(int idSensor) {
			try {
				using (var dbLogSensor = new LogSensorContext()) {
					return dbLogSensor.Records.Where(p => p.IDSensor == idSensor).ToList();
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static void GerarDadosIniciais() {
			using (var dbSensor = new SensorContext()) {
				DateTime mesAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
				DateTime fimMesAnterior = mesAtual.AddDays(-1);

				for (int i = 1; i <= fimMesAnterior.Day; i++) {
					for (int j = 0; j < 24; j++) {
						for (int k = 0; k < 60; k+=30) {
							DateTime dataMedicao = new DateTime(fimMesAnterior.Year, fimMesAnterior.Month, i, j, k, 0);

							foreach (Sensor sensor in dbSensor.Records) {
								double medicaoSensor = GetRandomNumber(sensor.MedicaoMinima, sensor.MedicaoMaximaAlerta + 10);

								IncluirLogSensor(sensor.ID, medicaoSensor, dataMedicao);
							}
						}
					}
				}
			}
		}

		private static double GetRandomNumber(double minimum, double maximum) {
			Random random = new Random();
			return random.NextDouble() * (maximum - minimum) + minimum;
		}
	}
}