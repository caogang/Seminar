using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

public class Global : HttpApplication
{
    protected void Application_Start(object sender, EventArgs e)
    {
        RouteTable.Routes.Add("ListPage", new Route("List/{type}/{page}", new PageRouteHandler("~/View/List.aspx")));
        RouteTable.Routes.Add("List", new Route("List/{type}", new PageRouteHandler("~/View/List.aspx")));
        RouteTable.Routes.Add("ListEmpty", new Route("List", new PageRouteHandler("~/View/List.aspx")));
        RouteTable.Routes.Add("Content", new Route("Content/{id}", new PageRouteHandler("~/View/Content.aspx")));
        RouteTable.Routes.Add("ContentEmpty", new Route("Content", new PageRouteHandler("~/View/Content.aspx")));
        RouteTable.Routes.Add("Error", new Route("Error/{info}", new PageRouteHandler("~/View/Error.aspx")));
        RouteTable.Routes.Add("ErrorEmpty", new Route("Error", new PageRouteHandler("~/View/Error.aspx")));
        RouteTable.Routes.Add("Index", new Route("Index", new PageRouteHandler("~/View/Index.aspx")));
        RouteTable.Routes.Add("Login", new Route("Login", new PageRouteHandler("~/View/Login.aspx")));
        RouteTable.Routes.Add("Empty", new Route("", new PageRouteHandler("~/View/Index.aspx")));
    }
}