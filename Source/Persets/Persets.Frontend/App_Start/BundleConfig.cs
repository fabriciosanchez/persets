using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Persets.Frontend
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css")
                .Include("~/scripts/bootstrap/dist/css/bootstrap.css",
                         "~/scripts/font-awesome/css/font-awesome.css",
                         "~/scripts/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.css",
                         "~/content/css/custom.min.css"));

            bundles.Add(new ScriptBundle("~/scripts/js")
                .Include("~/scripts/jquery/dist/jquery.js",
                         "~/scripts/bootstrap/dist/js/bootstrap.js",
                         "~/scripts/bootstrap-progressbar/bootstrap-progressbar.js",
                         "~/scripts/iCheck/icheck.min.js",
                         "~/content/js/custom.js"));
        }
    }
}