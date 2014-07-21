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

namespace Easyway.Admin
{
    public partial class nigol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName =  Login1.UserName.Trim();
            string pwd = Login1.Password.Trim();

            if (userName == "Admin" && pwd == "aadmin")
            {
                Session["UserAdmin"] = userName;
                Response.Redirect("Mainpage.aspx");
            }
            else
            {
                Login1.FailureText = "!!! Invalid username/password.Please try again !!!";
            }

        }
    }
}
