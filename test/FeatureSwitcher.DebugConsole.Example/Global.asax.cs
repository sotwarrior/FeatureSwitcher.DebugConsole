﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FeatureSwitcher.DebugConsole.Behaviours;
using FeatureSwitcher.DebugConsole.Example.Features;

namespace FeatureSwitcher.DebugConsole.Example
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.ConfigureFeatures();
        }

        private void ConfigureFeatures()
        {
            Configuration.Features.Are.ConfiguredBy.Custom(
                DebugConsoleBehaviour.IsEnabled,
                Configuration.Features.OfType<Feature2>.Enabled);
        }
    }
}
