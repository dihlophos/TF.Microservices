using System;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Hosting;

namespace TF.ProductMicroservice
{
    public class Startup
    {
        private IDisposable application;

        public void Configuration(IAppBuilder app)
        {            
            HttpConfiguration config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config); 
        }


        public void Start(string baseAddress)
        {
            application = WebApp.Start<Startup>(url: baseAddress);
        }

        public void Stop()
        {
            application.Dispose();
        }
    }
}
