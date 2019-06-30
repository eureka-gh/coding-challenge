using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;

namespace loanapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var corsAttr = new EnableCorsAttribute("http://localhost", "*", "*");
            config.EnableCors(corsAttr);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "UserLoanApi",
                routeTemplate: "api/user/{userId}/loan",
                defaults: new { controller = "Loan"}
            );
        }
    }
}
