using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;
using SCA.Logical;
using System.Configuration;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;

namespace SCA {
	public static class WebApiConfig {
		public static void Register(HttpConfiguration config) {
			// Serviços e configuração da API da Web

			// Rotas da API da Web
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

			config.Filters.Add(new AuthorizeAttribute());
		}
	}
}
