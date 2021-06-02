using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiWebiner_2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                //id göndermesek de çalışması için opsiyonel olarak işaretledik.
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
