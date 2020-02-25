using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using SCA.Models;

namespace SCA.Logical {
	public static class BarragemLogical {
		public static List<Barragem> RecuperarBarragem() {
			try {
				using (var dbBarragem = new BarragemContext()) {
					return dbBarragem.Records.ToList();
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static Barragem IncluirBarragem(BarragemRequest barragemRequest) {
			try {
				using (var dbBarragem = new BarragemContext()) {

					Barragem barragem = new Barragem(barragemRequest.IDMetodoAlteamento, barragemRequest.Name, barragemRequest.LocalizacaoGeografica, barragemRequest.Volume, barragemRequest.Comunidade);
					dbBarragem.Records.Add(barragem);

					dbBarragem.SaveChanges();

					return barragem;
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}
		public static Barragem AlterarBarragem(int id, BarragemRequest barragemRequest) {
			try {
				Barragem barragem = new Barragem();

				using (var dbBarragem = new BarragemContext()) {
					barragem = (
						from a in dbBarragem.Records
						where a.ID == id
						select a).FirstOrDefault();

					if (barragem != null) {
						barragem.IDMetodoAlteamento = barragemRequest.IDMetodoAlteamento;
						barragem.Name = barragemRequest.Name;
						barragem.LocalizacaoGeografica = barragemRequest.LocalizacaoGeografica;
						barragem.Volume = barragemRequest.Volume;
						barragem.Comunidade = barragemRequest.Comunidade;

						dbBarragem.Records.Update(barragem);

						dbBarragem.SaveChanges();					
					}

					return barragem;
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}
		public static Barragem ExcluirBarragem(int id) {
			try {
				Barragem barragem = new Barragem();

				using (var dbBarragem = new BarragemContext()) {
					barragem = (
						from b in dbBarragem.Records
						where b.ID == id
						select b).FirstOrDefault();

					if (barragem != null) {
						dbBarragem.Records.Remove(barragem);

						dbBarragem.SaveChanges();						
					}

					return barragem;
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static void CarregarDadosIniciais() {
			string json = "";

			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "SCA.DadosIniciais.Barragem.json";

			using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
				using (StreamReader reader = new StreamReader(stream)) {
					json = reader.ReadToEnd();
				}
			}

			List<Barragem> barragens = JsonConvert.DeserializeObject<List<Barragem>>(json);

			using (var dbBarragem = new BarragemContext()) {
				dbBarragem.Records.AddRange(barragens);

				dbBarragem.SaveChanges();
			}
		}
	}
}