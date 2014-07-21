using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace EasyWay
{
    public class Global : System.Web.HttpApplication
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
         
                
            //ignore routes for images,css,js etc
            routes.MapPageRoute("Home", "control/home", "~/Default.aspx");
            routes.MapPageRoute("ProductDetails", "control/products/{id}/details", "~/ViewProducts.aspx");
            routes.MapPageRoute("UpdatePwd", "control/updatepwd", "~/UpdatePwd.aspx");
            routes.MapPageRoute("BrowseCat", "control/browse", "~/BrowseCategories.aspx");
        }
        protected void Application_Start(object sender, EventArgs e)
        {

            RegisterRoutes(RouteTable.Routes);   
        }

        protected void Session_Start(object sender, EventArgs e)
        {
/*            string url = HttpContext.Current.Request.Url.AbsolutePath;

            if (url.Contains("/Admin/"))
            {
                
                    if (Session["UserAdmin"] == null)
                    {
                        Server.Transfer("/Admin/nigol.aspx");
                    }
                
            }*/

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
             
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Easyway.HelperFunction.ErrorHandle(Server.GetLastError().GetBaseException());
            HttpContext.Current.RewritePath("Error.htm");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}