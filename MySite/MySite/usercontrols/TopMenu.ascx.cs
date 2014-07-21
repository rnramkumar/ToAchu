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
using EasyWay.BusinessLayer;

namespace Easyway.usercontrols
{
    public partial class TopMenu : System.Web.UI.UserControl
    {

        StringBuilder strBuild;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataSet dsCat = new DataSet();
                Products oProducts = new Products();
                dsCat = oProducts.getAllCategoriesWithProdCount();

                strBuild = new StringBuilder();

                /*strBuild.Append("<table cellpadding='5' cellspacing='3' border='0'><tr><td>Browse Categories</td></tr>");
                if (dsCat.Tables.Count > 0 && dsCat.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsCat.Tables[0].Rows)
                    {
                       
                        strBuild.Append("<tr><td><a href='default.aspx?catId="+dr["categoryId"].ToString()+"'>"+dr["CategoryName"].ToString()+"</a>&nbsp;&nbsp;("+dr["pcount"].ToString()+")</td></tr>");
                    }
                }
                strBuild.Append("</table>");
                */
                if (dsCat.Tables.Count > 0 && dsCat.Tables[0].Rows.Count > 0)
                {
                    strBuild.Append("<ul id='menu'>");
                    foreach (DataRow dr in dsCat.Tables[0].Select("parentId=0"))
                    {
                        string catId = dr["categoryid"].ToString();
                        string catName = dr["categoryName"].ToString();
                        strBuild.Append("<li><a href='javascript:void(0);' data_id='"+catId+"' onclick='javascript:fnBrowse(this)' class='drop'>" + catName + "</a>"); //<!-- Begin 3 columns Item -->
                        strBuild.Append("<div class='dropdown_3columns'>");
                        displayChild(dr["categoryid"].ToString(), dsCat);
                        strBuild.Append("</div>");
                    }
                    strBuild.Append("</li></ul>");
                    divCategory.InnerHtml = strBuild.ToString();
                }
            }


        }

        private void displayChild(string catId, DataSet ds)
        {
            strBuild.Append("<div class='col_1'><ul>");
            foreach (DataRow dr in ds.Tables[0].Select("parentid=" + catId))
            {
                int seqNo = getSeqNo(dr["categoryid"].ToString(), ds);

                strBuild.Append("<li><a href='javascript:void(0);' data_id='" + dr["categoryid"] + "' onclick='javascript:fnBrowse(this)'>" + dr["categoryname"].ToString() + "</a></li>");
                for (int i = 1; i < seqNo; i++)
                {


                    strBuild.Append("</ul></div>");

                }

                displayChild(dr["categoryid"].ToString(), ds);

            }
        }

        private int getSeqNo(string catId, DataSet ds)
        {
            int childHierNo = 0;
            int menuId = 0;
            do
            {
                DataRow[] dr = ds.Tables[0].Select("categoryId ='" + catId + "'");
                if (dr.Length > 0)
                {
                    catId = dr[0]["parentid"].ToString();
                    menuId = Convert.ToInt32(dr[0]["parentid"].ToString());
                    childHierNo++;
                }
            }
            while (menuId != 0);

            return childHierNo;
        }

        
    }
}