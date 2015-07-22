using System;
using System.Web;

namespace qweMVC.Modules
{
    public class CustomModule:IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Application_BeginRequest;
            context.EndRequest += Application_EndRequest;
        }
        private static void Application_BeginRequest(Object source, EventArgs e)
        {
            var application = (HttpApplication)source;
            var context = application.Context;
            context.Response.Write("<h1>Custom Module Begin</h1><hr>");
        }

        private static void Application_EndRequest(Object source, EventArgs e)
        {
            var application = (HttpApplication)source;
            var context = application.Context;
            context.Response.Write("<hr><h1>Custom Module End</h1>");
        }   
    }
}