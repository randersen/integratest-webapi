using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using DryIoc;
using DryIoc.WebApi;
using Integratest.Data.ServiceInterfaces;
using Integratest.Data.Services;
using Integratest.WebApi.Services.Interfaces;
using Integratest.WebApi.Services.Services;
using Newtonsoft.Json.Serialization;

namespace Integratest.WebApi.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));


            config.MapHttpAttributeRoutes();

            var c = new Container();
            c = (Container)c.WithWebApi(config);

            //Register Interfaces/services
            c.Register<IAccountsService, AccountsService>(Reuse.Singleton);
            c.Register<IDataAccountsService, DataAccountsService>(Reuse.Singleton);

        }
    }
}
