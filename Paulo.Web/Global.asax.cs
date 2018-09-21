using Paulo.Web.App_Start;
using Paulo.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Paulo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleInjectorInitializer.Initializer();
            AutoMapperConfig.RegisterMappings();
        }
        
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
             CultureInfo ci = new CultureInfo("pt-BR");

             Thread.CurrentThread.CurrentUICulture = ci;
             Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }
    }
}
