using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCA.Models {
	public class LogManutencao {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int IDAtivo { get; set; }
		public DateTime DataLogManutencao { get; set; }
		public DateTime DataManutencaoAnterior { get; set; }
		public DateTime DataNovaManutencao { get; set; }
		public LogManutencao() {

		}
		public LogManutencao(int iDAtivo, DateTime dataManutencaoAnterior, DateTime dataNovaManutencao) {
			this.IDAtivo = IDAtivo;
			this.DataLogManutencao = DateTime.Now;
			this.DataManutencaoAnterior = dataManutencaoAnterior;
			this.DataNovaManutencao = dataNovaManutencao;
		}
	}
}