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
using System.Text;

using BusinessObjects;
using EasyWay.BusinessLayer;

namespace Easyway
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string prodId = Page.RouteData.Values["id"] as string;
                    int pid = 0;
                    if (int.TryParse(prodId,out pid))
                    {
                        //int pid = Convert.ToInt32(Request["pid"].ToString());

                        ViewDetails(pid);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void ViewDetails(int pid)
        {

            Products oProducts = new Products();
            
            ProductBiz oProductBiz = oProducts.getProductDetailsById(pid);
            StringBuilder strBuild = new StringBuilder();
            StringBuilder strBuildImg = new StringBuilder();
            StringBuilder strThumbImg = new StringBuilder();
            using (StreamReader sr = new StreamReader(Server.MapPath(@"~\admin\Templates\details.html")))
            {
                string fullText = sr.ReadToEnd();
                fullText = fullText.Replace("{#PID#}", oProductBiz.ProductId.ToString());
                fullText = fullText.Replace("{#PRODUCTNAME#}", oProductBiz.ProductName);
                fullText = fullText.Replace("{#SHORTDESC#}", oProductBiz.ProdShortDesc);
                fullText = fullText.Replace("{#LONGDESC#}", oProductBiz.ProdLongDesc);

                string strRating = @"
                <div class='ratethis'><span class='fl'>Rate</span>
                    <ul class='star-rating'>
                        <li id='liRating' class='current-rating' style='width:"+oProductBiz.Rating.Rating+@"%'></li>
                        <li><a title='Poor'>1</a></li>
                        <li><a title='OK'>2</a></li>
                        <li><a title='Good'>3</a></li>
                        <li><a title='Useful'>4</a></li>
                        <li><a title='Excellent'>5</a></li>
                    </ul>
               </div>" ;

                fullText = fullText.Replace("{#RATING#}", oProductBiz.Rating.Rating > 0 ? strRating+" "+oProductBiz.Rating.TotalRating+" Ratings":strRating);

                String imgLoad = "";
                if (oProductBiz.ArrImages != null)
                {
                    strThumbImg.Append("<ul id='thumblist' class='clearfix'>");
                    for (int j = 0; j < oProductBiz.ArrImages.Count; j++)
                    {
                        BaseBiz opic = (BaseBiz)oProductBiz.ArrImages[j];

                        string imgPath = "/admin/upload/" + opic.Name;
                        if (j == 0)
                        {
                            imgLoad = imgPath;
                        }
                        //strThumbImg.Append("<img src='" + imgPath + "'  border='0' width='100px' height='100px'>&nbsp;");
                        strThumbImg.Append("<li><a  href='javascript:void(0);' rel=\"{gallery: 'gal1', smallimage: '"+imgPath+"',largeimage: '"+imgPath+"'}\"><img src='"+imgPath+"' width='60px' height='60px'></a></li>");
                    }
                    strThumbImg.Append("</ul>");
                    strBuildImg.Append("<div class='clearfix' id='content' style='width:500px;' >");
                    strBuildImg.Append("<div class='clearfix'>");
                    strBuildImg.Append("<a href='"+imgLoad+"' class='jqzoom' rel='gal1'  title='triumph'>");
                    strBuildImg.Append("<img src='"+imgLoad+"' width='150px' height='175px'  title='triumph'  style='border: 4px solid #666;'></a></div><br/>");
        
                     strBuildImg.Append("<div class='clearfix'>");
	                strBuildImg.Append(strThumbImg.ToString());
                    strBuildImg.Append("</div></div>");


                    fullText = fullText.Replace("{#IMAGES#}", strBuildImg.ToString());
                }



                decimal price = oProductBiz.Price;
                decimal offerPrice = 0.0m;
                decimal savePrice = 0.0m;
                decimal offer = 0.0m;
                String saleType = "";
                if (oProductBiz.SaleType != "")
                {
                    saleType = oProductBiz.SaleType;
                    if (saleType == "S")
                    {
                        offerPrice = price - oProductBiz.Priceorpercent;
                        offer = oProductBiz.Priceorpercent;
                        saleType = " OFF";
                        savePrice = oProductBiz.Priceorpercent;
                    }
                    else
                    {
                        offerPrice = price - (price * (oProductBiz.Priceorpercent / 100));
                        offer = oProductBiz.Priceorpercent;
                        saleType = " % OFF";
                        savePrice = price * (oProductBiz.Priceorpercent / 100);
                    }

                }

                fullText = fullText.Replace("{#PRICE#}", String.Format("{0:0,0}", price));
                fullText = fullText.Replace("{#SAVEPRICE#}", savePrice > 0 ? String.Format("{0:0,0}", savePrice) + " OFF " : "");
                fullText = fullText.Replace("{#PRICEORPERCENT#}", offer > 0 ? String.Format("{0:0}", offer) + " " + saleType : "");
                fullText = fullText.Replace("{#OFFERPRICE#}", offerPrice > 0 ? String.Format("{0:0,0}", offerPrice) : "");


                strBuild.Append(fullText);
            }

            divProductView.InnerHtml = strBuild.ToString();

        }
    }
}
