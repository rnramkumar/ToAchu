using System;   
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

namespace Easyway.usercontrols
{
    public partial class Header : System.Web.UI.UserControl
    {
      
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UEmail"] == null)
                divLogin.InnerHtml = "<a href='javascript:void(0);' onclick='javascript:fnPlaceOrder();'>Login / Register</a> ";
            else
            {
                StringBuilder strBuild = new StringBuilder(); 
                   strBuild.Append("<div id='mmenu'><ul>");
                    strBuild.Append("<li><a href='javascript:void(0);'>My Account</a>");
                    strBuild.Append("<ul><li><a href='#'>Hello " + Session["name"].ToString() + "</a></li><li><a href='/control/myorders'>My Orders</a></li><li><a href='javascript:fnChangePwdOpen();'>Change Password</a></li><li><a href='javascript:void(0);' onclick='javascript:fnLogout();'>Log out</a></li></ul>");
                    
                strBuild.Append("</li></ul></div>");
                
                
                
                divLogin.InnerHtml = strBuild.ToString();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
        
            Context.Items["SearchText"] = txtSearch.Text;
           
            Server.Transfer("BrowseCategories.aspx");
            
            //ListProducts ucListProd = (ListProducts)Page.FindControl("ListProducts1");

            //ucListProd.StatusId = 1;
            //ucListProd.CategoryId = 0;
            //ucListProd.SearchText = strSearch;
           //ucListProd.DisplayProducts();
           


        }
    }
}