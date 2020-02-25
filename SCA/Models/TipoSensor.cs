using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Models {
	public class TipoSensor {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string Name { get; set; }
		public string UnidadeMedida { get; set; }

		public TipoSensor(string name, string unidadeMedida) {
			this.Name = name;
			this.UnidadeMedida = unidadeMedida;
		}
	}
}