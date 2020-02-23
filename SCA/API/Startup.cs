using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SCA.Logical;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(SCA.API.Startup))]
namespace SCA.API {
	public class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureOAuth(app);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);            

            CarregarDados();
		}

        public void ConfigureOAuth(IAppBuilder app) {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions {
                Provider = new OAuthBearerAuthenticationProvider()
            });

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