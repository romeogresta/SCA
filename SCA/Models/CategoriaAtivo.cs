using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Models {
	public class CategoriaAtivo {		
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string Name { get; set; }

		public CategoriaAtivo() {

		}
		public CategoriaAtivo(string name) {
			this.Name = name;
		}
	}

	public class CategoriaAtivoRequest {
		public string Name { get; set; }
	}
}