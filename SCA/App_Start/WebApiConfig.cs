using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;
using SCA.Logical;
using System.Configuration;

namespace SCA {
	public static class WebApiConfig {
		public static void Register(HttpConfiguration config) {
			// Serviços e configuração da API da Web
			config.EnableCors();

			// Rotas da API da Web
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

			CarregarDados();
		}

		public static void CarregarDados() {
			CategoriaAtivoLogical.CarregarCategoriaAtivo();
			MetodoAlteamentoLogical.CarregarMetodoAlteamento();
			TipoSensorLogical.CarregarTipoSensor();

			if (bool.Parse(ConfigurationManager.AppSettings["CarregarDadosIniciais"].ToString())) {
				AtivoLogical.CarregarDadosIniciais();
				BarragemLogical.CarregarDadosIniciais();
				SensorLogical.CarregarDadosIniciais();
				LogSensorLogical.GerarDadosIniciais();
			}
		}
	}
}
