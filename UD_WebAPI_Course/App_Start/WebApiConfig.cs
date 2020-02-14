using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UD_WebAPI_Course
{
    using System.Net.Http.Headers;

    using Newtonsoft.Json;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            // deleting XML formatter to give back JSON formatted return irrespectively of "Accept" HEADER value !
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            /* We want to implement :
            If client requests from:
            web browser - gets json
            postman - he can specify the format xml/json
            */

            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            //sets indentation of a response
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
        }
    }
}
