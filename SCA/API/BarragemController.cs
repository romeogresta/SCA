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
	[RoutePrefix("api/barragem")]
	public class BarragemController : BaseApiController {
		[Route("")]
		[HttpGet]
		public IHttpActionResult RecuperarBarragem() {			
			var barragens = (
				from b in BarragemLogical.RecuperarBarragem()
				join ma in MetodoAlteamentoLogical.RecuperarMetodoAlteamento() on b.IDMetodoAlteamento equals ma.ID
				orderby b.ID
				select new {
					ID = b.ID,
					Name = b.Name,
					IdMetodoAlteamento = ma.ID,
					NameMetodoAlteamento = ma.Name,
					Volume = b.Volume
				}).ToList();

			return Ok(barragens);
		}

		[Route("{id}")]
		[HttpGet]
		public IHttpActionResult RecuperarBarragem(int id) {			
			var barragem = (
				from b in BarragemLogical.RecuperarBarragem()
				join ma in MetodoAlteamentoLogical.RecuperarMetodoAlteamento() on b.IDMetodoAlteamento equals ma.ID
				where b.ID == id
				select new {
					ID = b.ID,
					Name = b.Name,
					IdMetodoAlteamento = ma.ID,
					NameMetodoAlteamento = ma.Name,
					LocalizacaoGeografica = b.LocalizacaoGeografica,
					Volume = b.Volume,
					Comunidade = b.Comunidade
				}).FirstOrDefault();


			if (barragem != null) {
				return Ok(barragem);
			}
			else {
				return NotFound();
			}
		}

		[Route("")]
		[HttpPost]
		public IHttpActionResult IncluirBarragem([FromBody]BarragemRequest barragemRequest) {
			Barragem barragem = BarragemLogical.IncluirBarragem(barragemRequest);

			return Ok(barragem);
		}

		[Route("{id}")]
		[HttpPost]
		public IHttpActionResult AlterarBarragem(int id, [FromBody]BarragemRequest barragemRequest) {
			Barragem barragem = BarragemLogical.AlterarBarragem(id, barragemRequest);

			if (barragem != null) {
				return Ok(barragem);
			}
			else {
				return NotFound();
			}
		}

		[Route("{id}")]
		[HttpDelete]
		public IHttpActionResult ExcluirBarragem(int id) {
			Barragem barragem = BarragemLogical.ExcluirBarragem(id);

			if (barragem != null) {
				return Ok(barragem);
			}
			else {
				return NotFound();
			}
		}
	}
}