using SCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCA.Logical {
	public static class CategoriaAtivoLogical {
		private static string[] categorias = {
			"Caminhões Articulados",
			"Tratores Grandes",
			"Draglines",
			"Perfuratrizes",
			"Escavadeiras a Cabo",
			"Escavadeiras Médias",
			"Escavadeiras Grandes",
			"Escavadeiras Hidráulicas de Mineração",
			"Motoniveladoras",
			"Caminhões de Mineração",
			"Minicarregadeiras",
			"Manipuladores Telescópicos",
			"Subterrâneo - Rocha Dura",
			"Subterrâneo - Longwall",
			"Carregadeiras de Rodas Grandes",
			"Tratores-escrêiperes de Rodas"
		};
		public static List<CategoriaAtivo> RecuperarCategoriaAtivo() {
			try {
				using (var dbCategoriaAtivo = new CategoriaAtivoContext()) {
					return dbCategoriaAtivo.Records.ToList();
				}
			}
			catch (Exception e) {
				throw (e);
			}
		}

		public static void CarregarCategoriaAtivo() {
			using (var dbCategoriaAtivo = new CategoriaAtivoContext()) {
				if (dbCategoriaAtivo.Records.Count() == 0) {
					int idCategoria = 1;

					foreach (string nomCategoria in categorias) {
						CategoriaAtivo categoriaAtivo = new CategoriaAtivo(idCategoria, nomCategoria);
						dbCategoriaAtivo.Records.Add(categoriaAtivo);

						idCategoria++;
					}

					dbCategoriaAtivo.SaveChanges();
				}
			}
		}
	}
}