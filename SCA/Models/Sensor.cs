using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SCA.Models {
	public class Sensor {
		[Key]
		public int ID { get; set; }
		public int IDTipoSensor { get; set; }
		public int IDBarragem { get; set; }
		public string Name { get; set; }
		public double MedicaoMinima { get; set; }
		public double MedicaoMaximaSeguranca { get; set; }
		public double MedicaoMaximaAlerta { get; set; }

		public Sensor() {

		}

		public Sensor(int ID, int idTipoSensor, int idBarragem, string name, double medicaoMinima, double medicaoMaximaSeguranca, double medicaoMaximaAlerta) {
			this.ID = ID;
			this.IDTipoSensor = idTipoSensor;
			this.IDBarragem = idBarragem;
			this.Name = name;
			this.MedicaoMinima = medicaoMinima;
			this.MedicaoMaximaSeguranca = medicaoMaximaSeguranca;
			this.MedicaoMaximaAlerta = medicaoMaximaAlerta;
		}		
	}
	public class SensorRequest {
		public int IDTipoSensor { get; set; }
		public int IDBarragem { get; set; }
		public string Name { get; set; }
		public double MedicaoMinima { get; set; }
		public double MedicaoMaximaSeguranca { get; set; }
		public double MedicaoMaximaAlerta { get; set; }
	}
}