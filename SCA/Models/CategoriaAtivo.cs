using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SCA.Models {
	public class CategoriaAtivo {
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }

		public CategoriaAtivo() {

		}
		public CategoriaAtivo(int ID, string name) {
			this.ID = ID;
			this.Name = name;
		}
	}

	public class CategoriaAtivoRequest {
		public string Name { get; set; }
	}
}