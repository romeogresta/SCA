using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using SCA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SCA.Logical {
	public static class AtivoLogical {
		public static List<Ativo> RecuperarAtivo() {
			try {
				using (var dbAtivo = new AtivoContext()) {
					return dbAtivo.Records.ToList();
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static Ativo IncluirAtivo(AtivoRequest ativoRequest) {
			try {
				using (var dbAtivo = new AtivoContext()) {
					int idMaxAtivo = 0;

					if (dbAtivo.Records.Count() > 0) {
						idMaxAtivo = (
							from a in dbAtivo.Records
							select a.ID).Max();
					}

					idMaxAtivo++;

					Ativo ativo = new Ativo(idMaxAtivo, ativoRequest.IDCategoriaAtivo, ativoRequest.Name, ativoRequest.DataManutencao);
					dbAtivo.Records.Add(ativo);

					dbAtivo.SaveChanges();

					return ativo;
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static Ativo AlterarAtivo(int id, AtivoRequest ativoRequest) {
			try {
				Ativo ativo = new Ativo();

				using (var dbAtivo = new AtivoContext()) {
					ativo = (
						from a in dbAtivo.Records
						where a.ID == id
						select a).FirstOrDefault();

					if (ativo != null) {
						ativo.IDCategoriaAtivo = ativoRequest.IDCategoriaAtivo;
						ativo.Name = ativoRequest.Name;
						ativo.DataManutencao = ativoRequest.DataManutencao;

						dbAtivo.Records.Update(ativo);

						dbAtivo.SaveChanges();					
					}

					return ativo;
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static Ativo AlterarDataManutencao(int id, JsonPatchDocument<Ativo> patch) {
			try {
				Ativo ativo = new Ativo();

				using (var dbAtivo = new AtivoContext()) {
					ativo = (
						from a in dbAtivo.Records
						where a.ID == id
						select a).FirstOrDefault();

					if (ativo != null) {
						DateTime datManutencaoAnterior = ativo.DataManutencao;

						patch.ApplyTo(ativo);

						dbAtivo.Records.Update(ativo);

						dbAtivo.SaveChanges();

						LogManutencaoLogical.IncluirLogManutencao(ativo.ID, datManutencaoAnterior, ativo.DataManutencao);
					}

					return ativo;
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static Ativo ExcluirAtivo(int id) {
			try {
				Ativo ativo = new Ativo();

				using (var dbAtivo = new AtivoContext()) {
					ativo = (
						from a in dbAtivo.Records
						where a.ID == id
						select a).FirstOrDefault();

					if (ativo != null) {
						dbAtivo.Records.Remove(ativo);

						dbAtivo.SaveChanges();
					}

					return ativo;
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static void CarregarDadosIniciais() {
			string json = "";

			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "SCA.DadosIniciais.Ativo.json";

			using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
				using (StreamReader reader = new StreamReader(stream)) {
					json = reader.ReadToEnd();
				}
			}

			List<Ativo> ativos = JsonConvert.DeserializeObject<List<Ativo>>(json);
			
			using (var dbAtivo = new AtivoContext()) {
				dbAtivo.Records.AddRange(ativos);

				dbAtivo.SaveChanges();
			}
		}
	}
}