using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNetCore.JsonPatch;
using SCA.Models;
using SCA.Logical;

namespace SCA.API {
	[RoutePrefix("api/ativo")]
	public class AtivoController : BaseApiController {
		[Route("")]
		[HttpGet]
		public IHttpActionResult RecuperarAtivo() {
			var ativos = (
				from a in AtivoLogical.RecuperarAtivo()
				join ca in CategoriaAtivoLogical.RecuperarCategoriaAtivo() on a.IDCategoriaAtivo equals ca.ID
				orderby a.ID
				select new {
					ID = a.ID,
					Name = a.Name,
					IdCategoriaAtivo = ca.ID,
					NameCategoriaAtivo = ca.Name,
					DataManutencao = a.DataManutencao.ToString("dd/MM/yyyy")
				}).ToList();

			return Ok(ativos);
		}

		[Route("{id}")]
		[HttpGet]
		public IHttpActionResult RecuperarAtivo(int id) {
			var ativo = (
				from a in AtivoLogical.RecuperarAtivo()
				join ca in CategoriaAtivoLogical.RecuperarCategoriaAtivo() on a.IDCategoriaAtivo equals ca.ID
				where a.ID == id
				select new {
					ID = a.ID,
					Name = a.Name,
					IdCategoriaAtivo = ca.ID,
					NameCategoriaAtivo = ca.Name,
					DataManutencao = a.DataManutencao.ToString("dd/MM/yyyy")
				}).FirstOrDefault();

			if (ativo != null) {
				return Ok(ativo);
			}
			else {
				return NotFound();
			}
		}

		[Route("")]
		[HttpPost]
		public IHttpActionResult IncluirAtivo([FromBody]AtivoRequest ativoRequest) {
			Models.Ativo ativo = AtivoLogical.IncluirAtivo(ativoRequest);

			return Ok(ativo);
		}

		[Route("{id}")]
		[HttpPost]
		public IHttpActionResult AlterarAtivo(int id, [FromBody]AtivoRequest ativoRequest) {
			Ativo ativo = AtivoLogical.AlterarAtivo(id, ativoRequest);

			
			if (ativo != null) {
				return Ok(ativo);
			}
			else {
				return NotFound();
			}
		}

		[Route("{id}")]
		[HttpPatch]
		public IHttpActionResult AlterarDataManutencao(int id, [FromBody]JsonPatchDocument<Ativo> patch) {
			Ativo ativo = AtivoLogical.AlterarDataManutencao(id, patch);			

			if (ativo != null) {
				return Ok(ativo);
			}
			else {
				return NotFound();
			}
		}

		[Route("{id}")]
		[HttpDelete]
		public IHttpActionResult ExcluirAtivo(int id) {
			Ativo ativo = AtivoLogical.ExcluirAtivo(id);

			if (ativo != null) {
				return Ok(ativo);
			}
			else {
				return NotFound();
			}
		}
	}
}