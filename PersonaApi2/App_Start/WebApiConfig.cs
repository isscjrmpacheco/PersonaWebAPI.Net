using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PersonaApi2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatters = formatters.JsonFormatter;
            var settings = jsonFormatters.SerializerSettings;
            settings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            settings.Formatting = Newtonsoft.Json.Formatting.None;
            settings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;


            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.EnableCors();
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
