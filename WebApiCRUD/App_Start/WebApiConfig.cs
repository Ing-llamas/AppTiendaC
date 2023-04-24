using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiCRUD
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            //  var cors = EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(false);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static object EnableCorsAttribute(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}
