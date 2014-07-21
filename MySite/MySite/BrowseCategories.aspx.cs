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
using System.Text;

using EasyWay.BusinessLayer;

namespace Easyway
{
    public partial class BrowseCategories : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request["hdnCatId"] != null && Request["hdnCatId"] !="")
                {
                    int catId =Convert.ToInt32(Request["hdnCatId"]);

                    ListProducts1.CategoryId = catId;
                 }
                
                    if (PreviousPage != null)
                    {
                        //TextBox txt = PreviousPage.Controls[0].FindControl("Header1_txtSearch") as TextBox;
                        //ListProducts1.SearchText = txt.Text;
                        String str = Context.Items["SearchText"] as string;
                        ListProducts1.SearchText = str;
                    }
                
            }

        }


    }
}
