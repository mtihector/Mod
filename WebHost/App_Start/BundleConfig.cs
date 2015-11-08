﻿using System.Web;
using System.Web.Optimization;

namespace WebHost
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/baseScripts").Include(
                        "~/Scripts/libs/JQuery/jquery.js",
                        "~/Scripts/libs/underscore/underscore.js",
                        "~/Scripts/libs/knockout/knockout.js",
                        "~/Scripts/libs/Bootstrap/bootstrap.js",
                        "~/Scripts/libs/jqueryscrollbar/jquery.scrollbar.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/jquery.scrollbar.css",
                "~/Content/site.css",
                "~/Content/fontawesome/font-awesome.min.css"
                ));
        }
    }
}
