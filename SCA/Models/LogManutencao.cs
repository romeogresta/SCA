using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SCA.Models {
	public class LogManutencao {
		[Key]
		public int ID { get; set; }
		public int IDAtivo { get; set; }
		public DateTime DataLogManutencao { get; set; }
		public DateTime DataManutencaoAnterior { get; set; }
		public DateTime DataNovaManutencao { get; set; }
		public LogManutencao() {

		}
		public LogManutencao(int ID, int iDAtivo, DateTime dataManutencaoAnterior, DateTime dataNovaManutencao) {
			this.ID = ID;
			this.IDAtivo = IDAtivo;
			this.DataLogManutencao = DateTime.Now;
			this.DataManutencaoAnterior = dataManutencaoAnterior;
			this.DataNovaManutencao = dataNovaManutencao;
		}
	}
}