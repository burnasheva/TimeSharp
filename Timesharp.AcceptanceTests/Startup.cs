using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timesharp.AcceptanceTests
{
    using System.Web.Http;

    using Owin;

    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            Timesharp.WebApiConfig.Register(config);
            Timesharp.Startup.ConfigureAuth(appBuilder);
            appBuilder.UseWebApi(config);
        }
    } 
}
