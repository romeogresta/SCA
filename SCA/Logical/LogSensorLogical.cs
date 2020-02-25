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
					LogSensor logSensor = new LogSensor(idSensor, medicaoSensor, dataMedicao);
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

		public static List<OcorrenciaSensor> RecuperarOcorrencias(int idBarragem, int idSensor) {
			try {
				List<OcorrenciaSensor> ocorrenciasSensor = new List<OcorrenciaSensor>();

				using (var dbLogSensor = new LogSensorContext()) {
					List<Sensor> sensores = new List<Sensor>();

					if (idSensor == 0) {
						sensores = SensorLogical.RecuperarSensorBarragem(idBarragem);
					}
					else {
						sensores.Add(SensorLogical.RecuperarSensor(idSensor));
					}

					foreach (Sensor sensor in sensores) {
						List<Ocorrencia> ocorrencias = new List<Ocorrencia>();

						Ocorrencia ocorrenciaSeguranca = new Ocorrencia("Segurança", 0);
						Ocorrencia ocorrenciaAlerta = new Ocorrencia("Alerta", 0);
						Ocorrencia ocorrenciaEmergencia = new Ocorrencia("Emergência", 0);

						ocorrenciaSeguranca.Quantidade = dbLogSensor.Records.Where(p => p.IDSensor == sensor.ID && p.MedicaoSensor <= sensor.MedicaoMaximaSeguranca).Count();
						ocorrenciaAlerta.Quantidade = dbLogSensor.Records.Where(p => p.IDSensor == sensor.ID && p.MedicaoSensor > sensor.MedicaoMaximaSeguranca && p.MedicaoSensor <= sensor.MedicaoMaximaAlerta).Count();
						ocorrenciaEmergencia.Quantidade = dbLogSensor.Records.Where(p => p.IDSensor == sensor.ID && p.MedicaoSensor > sensor.MedicaoMaximaAlerta).Count();

						ocorrencias.Add(ocorrenciaSeguranca);
						ocorrencias.Add(ocorrenciaAlerta);
						ocorrencias.Add(ocorrenciaEmergencia);

						OcorrenciaSensor ocorrenciaSensor = new OcorrenciaSensor(sensor, ocorrencias);

						ocorrenciasSensor.Add(ocorrenciaSensor);
					};

					return ocorrenciasSensor;
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