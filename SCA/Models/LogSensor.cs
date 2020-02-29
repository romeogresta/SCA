using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Models {
	public class LogSensor {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int IDSensor { get; set; }
		public double MedicaoSensor { get; set; }
		public DateTime DataMedicao { get; set; }

		public LogSensor() {

		}

		public LogSensor(int idSensor, double medicaoSensor, DateTime dataMedicao) {
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