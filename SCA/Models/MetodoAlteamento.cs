using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Models {
	public class MetodoAlteamento {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }

		public MetodoAlteamento(string name) {
			this.Name = name;
		}
	}
}