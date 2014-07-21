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

using BusinessObjects;
using EasyWay.BusinessLayer; 


namespace Easyway.Admin
{
    public partial class ViewBanners : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               try
            {
                if (!IsPostBack)
                {

                    Banner oBanner = new Banner();
                    DataSet dsBanner = oBanner.getAllBanners();
                    StringBuilder strBuild = new StringBuilder();
                    
                    strBuild.Append("<table widtd='100%' border='0' cellpadding='5' cellspacing='3' id='data_sortable'>");
                    strBuild.Append("<tr><td>Banner Image</td><td>Ad Name</td><td>Category</td><td>Active</td><td>Weightage</td><td>Click Count</td><td colspan='2' ></td></tr>");
                    if (dsBanner.Tables.Count > 0 && dsBanner.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsBanner.Tables[0].Rows)
                        {

                            strBuild.Append("<tr>");
                            int adId  = Convert.ToInt32(dr["adId"].ToString());

                            
                            string imageName = dr["imageName"].ToString();
                            string imgPath = "/admin/banners/" + imageName;
                                imgPath = "<img src='" + imgPath + "' border='0' widtd='45' height='45'>";
                            
                            strBuild.Append("<td>"+imgPath+"</td>");

                            strBuild.Append("<td>"+dr["advName"].ToString()+"</td>");
                            strBuild.Append("<td>"+dr["category"].ToString()+" </td>");
                            strBuild.Append("<td>" + dr["Active"].ToString()+ "</td>");
                            strBuild.Append("<td>" + dr["Weightage"]+ "</td>");
                            strBuild.Append("<td>" + dr["hitCount"] + "</td>");
                            strBuild.Append("<td><a href=ManageBanners.aspx?type=update&adid=" + adId+ ">Edit</a></td>");
                            strBuild.Append("<td><a href=javascript:fnDelBannerAd(" + adId + ",'"+imageName+"')>Delete</a></td></tr>");
                        }
                        strBuild.Append("</table>");

                        divBanners.InnerHtml = strBuild.ToString();
                    }
                    
                        
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}
