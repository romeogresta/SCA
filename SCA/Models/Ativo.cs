using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SCA.Models {
	public class Ativo {
		[Key]
		public int ID { get; set; }
		public int IDCategoriaAtivo { get; set; }
		public string Name { get; set; }
		public DateTime DataManutencao { get; set; }
		public Ativo() {

		}
		public Ativo(int ID, int iDCategoriaAtivo, string name, DateTime dataManutencao) {
			this.ID = ID;
			this.IDCategoriaAtivo = iDCategoriaAtivo;
			this.Name = name;
			this.DataManutencao = dataManutencao;
		}
	}

	public class AtivoRequest {
		public int IDCategoriaAtivo { get; set; }
		public string Name { get; set; }
		public DateTime DataManutencao { get; set; }
	}

	public class DataManutencaoRequest {
		public DateTime DataManutencao { get; set; }
	}
}