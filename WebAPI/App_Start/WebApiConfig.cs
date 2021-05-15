using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.DependencyResolver = new NinjectResolver();
            // Web API configuration and services
            // Enable CORS for the Angular App
            //
            
            // This should pass to App settings 
            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            //var cors = new EnableCorsAttribute("https://ehiwebapp.azurewebsites.net", "*", "*");
            config.EnableCors(cors);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }     
    }
}
