using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SCA.Models {
	public class LogSensor {
		[Key]
		public int ID { get; set; }
		public int IDSensor { get; set; }
		public double MedicaoSensor { get; set; }
		public DateTime DataMedicao { get; set; }

		public LogSensor() {

		}

		public LogSensor(int ID, int idSensor, double medicaoSensor, DateTime dataMedicao) {
			this.ID = ID;
			this.IDSensor = idSensor;
			this.MedicaoSensor = medicaoSensor;
			this.DataMedicao = dataMedicao;
		}		
	}

	public class Ocorrencia {
		public string Nome { get; set; }
		public int Quantidade { get; set; }

		public Ocorrencia (string nome, int quantidade) {
			this.Nome = nome;
			this.Quantidade = quantidade;
		}
	}

	public class OcorrenciaSensor {
		public Sensor Sensor { get; set; }
		public List<Ocorrencia> Ocorrencias { get; set; }

		public OcorrenciaSensor(Sensor sensor, List<Ocorrencia> ocorrencias) {
			this.Sensor = sensor;
			this.Ocorrencias = ocorrencias;
		}
	}
}