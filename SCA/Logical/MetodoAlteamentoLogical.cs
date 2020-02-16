using SCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCA.Logical {
	public static class MetodoAlteamentoLogical {
		private static string[] metodosAlteamento = {
			"Alteamento para montante",
			"Alteamento para jusante",
			"Alteamento na linha de centro"
		};

		public static List<MetodoAlteamento> RecuperarMetodoAlteamento() {
			try {
				using (var dbMetodoAlteamento = new MetodoAlteamentoContext()) {
					return dbMetodoAlteamento.Records.ToList();
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static void CarregarMetodoAlteamento() {
			using (var dbMetodoAlteamento = new MetodoAlteamentoContext()) {
				if (dbMetodoAlteamento.Records.Count() == 0) {
					int idMetodoAlteamento = 1;

					foreach (string nome in metodosAlteamento) {
						MetodoAlteamento metodoAlteamento = new MetodoAlteamento(idMetodoAlteamento, nome);
						dbMetodoAlteamento.Records.Add(metodoAlteamento);

						idMetodoAlteamento++;
					}

					dbMetodoAlteamento.SaveChanges();
				}
			}
		}
	}
}