using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCA.Models;

namespace SCA.Logical {
	public static class LogManutencaoLogical {
		public static void IncluirLogManutencao(int iDAtivo, DateTime dataManutencaoAnterior, DateTime dataNovaManutencao) {
			try {
				using (var dbLogManutencao = new LogManutencaoContext()) {
					int iDMaxLogManutencao = 0;

					if (dbLogManutencao.Records.Count() > 0) {
						iDMaxLogManutencao = (
							from a in dbLogManutencao.Records
							select a.ID).Max();
					}

					iDMaxLogManutencao++;

					LogManutencao logManutencao = new LogManutencao(iDMaxLogManutencao, iDAtivo, dataManutencaoAnterior, dataNovaManutencao);
					dbLogManutencao.Records.Add(logManutencao);

					dbLogManutencao.SaveChanges();
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}
	}
}