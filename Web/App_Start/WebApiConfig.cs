﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Web
{
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
                defaults: new { id = RouteParameter.Optional }
            );

            //Ading formatter for Json
            // /api/Controller/methos/parameter/type=json
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json",
                new MediaTypeHeaderValue("application/json")));

            //Adding formatter for XML
            // /api/Controller/methos/parameter/type=xml
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "xml",
               new MediaTypeHeaderValue("application/xml")));


        }
    }
}