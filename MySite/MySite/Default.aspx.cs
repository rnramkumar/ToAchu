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

using System.IO;

namespace Easyway
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            //TopBannerAd.Category = "Top";
            RightBannerAd.Category = "Right";
            LeftBannerAd.Category = "Left";
            BottomBannerAd.Category = "Bottom";

            int catID = -1;
            if (Request["CatId"] != null)
            {
                catID = Convert.ToInt32(Request["CatId"].ToString());
            }
           /* ListProducts1.CategoryId = catID;
            ListProducts1.StatusId = 1;

            ListProducts1.SearchText = "";
            */
            
        }
    }
}
