using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Models {
	public class Barragem {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int IDMetodoAlteamento { get; set; }
		public string Name { get; set; }
		public string LocalizacaoGeografica { get; set; }
		public double Volume { get; set; }
		public string Comunidade { get; set; }

		public Barragem() {

		}

		public Barragem(int idMetodoAlteamento, string name, string localizacaoGeografica, double volume, string comunidade) {
			this.IDMetodoAlteamento = idMetodoAlteamento;
			this.Name = name;
			this.LocalizacaoGeografica = localizacaoGeografica;
			this.Volume = volume;
			this.Comunidade = comunidade;
		}		
	}
	public class BarragemRequest {
		public int IDMetodoAlteamento { get; set; }
		public string Name { get; set; }
		public string LocalizacaoGeografica { get; set; }
		public double Volume { get; set; }
		public string Comunidade { get; set; }
	}
}