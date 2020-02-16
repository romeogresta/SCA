using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SCA.Models {
	public class TipoSensor {
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public string UnidadeMedida { get; set; }

		public TipoSensor(int ID, string name, string unidadeMedida) {
			this.ID = ID;
			this.Name = name;
			this.UnidadeMedida = unidadeMedida;
		}
	}
}