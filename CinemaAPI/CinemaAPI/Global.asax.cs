using CinemaAPI.IoCContainer;

using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Packaging;
using Hangfire;
using System;

namespace CinemaAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        BackgroundJobServer _server;

        protected void Application_Start()
        {
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            IPackage[] packages = new IPackage[]
            {
                new DataPackage(),
                new DomainPackage()
            };

            foreach (IPackage package in packages)
            {
                package.RegisterServices(container);
            }

            container.RegisterWebApiControllers(System.Web.Http.GlobalConfiguration.Configuration);
            container.Verify();

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);

            Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage("CinemaDbContext");

            _server = new BackgroundJobServer();

            // RecurringJob.AddOrUpdate(() => Job.CancelReservation(), "*/5 * * * *");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _server.Dispose();
        }
    }
}