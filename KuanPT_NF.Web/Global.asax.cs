using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using KuanPT_NF.Web.Controllers;

namespace KuanPT_NF.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            EngineContext.Initialize(false);
            var container = EngineContext.Current.ContainerManager.Container;
            var builder = EngineContext.Current.ContainerBuilder;
            var typeFinder = EngineContext.Current.Resolve<ITypeFinder>();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
        }
        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
             
            //process 404 HTTP errors
            var httpException = exception as HttpException; 
            if (httpException != null && httpException.GetHttpCode() == 404)
            {

                Response.Clear();
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;

                // Call target Controller and pass the routeData.
                IController errorController = EngineContext.Current.Resolve<HomeController>();

                var routeData = new RouteData();
                routeData.Values.Add("controller", "Home");
                routeData.Values.Add("action", "PageNotFound");

                errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));

            }
            else
            {
                Response.Clear();
                Server.ClearError();
                Response.TrySkipIisCustomErrors = true;
                // Call target Controller and pass the routeData.
                IController errorController = EngineContext.Current.Resolve<HomeController>();

                var routeData = new RouteData();
                routeData.Values.Add("controller", "Home");
                routeData.Values.Add("action", "PageError");

                errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));


            }
        }

    }
}