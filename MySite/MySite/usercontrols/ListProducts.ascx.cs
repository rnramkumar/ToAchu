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
using System.IO;
using System.Text;

using BusinessObjects;
using EasyWay.BusinessLayer;


namespace Easyway.usercontrols
{
    public partial class ListProducts : System.Web.UI.UserControl
    {

        string searchText="";

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; }
        }

        int statusId;

        public int StatusId
        {
            get { return statusId; }
            set { statusId = value; }
        }
        int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DisplayProducts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisplayProducts()
        {
            Products oProducts = new Products();
            ProductBiz objProductBiz = new ProductBiz();
            
            objProductBiz.StatusId = StatusId;
            objProductBiz.CategoryId = CategoryId;
            objProductBiz.SearchText = SearchText;

            ArrayList arrProducts = oProducts.getListAllProducts(objProductBiz);

            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("<table cellpadding='2' cellspacing='2' border='0' width='100%'><tr>");
            for (int i = 0; i < arrProducts.Count; i++)
            {
                if (i % 3 == 0)
                       strBuild.Append("</tr><tr>");

                strBuild.Append("<td>");

                ProductBiz oProductBiz = (ProductBiz)arrProducts[i];
                
                int pid = oProductBiz.ProductId;
                using (StreamReader sr = new StreamReader(Server.MapPath(@"~\admin\Templates\products.htm")))
                {
                    string fullText = sr.ReadToEnd();
                    fullText = fullText.Replace("{#PRODUCTNAME#}", "<a id='easyView' href='/control/products/" + pid + "/details'>"+oProductBiz.ProductName+"</a><br/>");
                    string prodImage = oProductBiz.ImagePath;
                    if (prodImage != "")
                    {
                        string imgPath = "/admin/upload/" + prodImage;
                        prodImage = "<a href='javascript:void(0)'><img src='" + imgPath + "' border='0' width='125px' height='125px'><span class='qkview'><input type='button' data_id=" + pid + " name='btnQuickView' onClick='javascript:fnQuickView(this);' value='Quick View' /></span></a>";
                    }
                    else
                        prodImage = "No Image";



                    fullText = fullText.Replace("{#IMAGE#}", prodImage);

                    decimal price = oProductBiz.Price;
                    decimal offerPrice = 0.0m;
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
                        }
                        else
                        {
                            offerPrice = price - (price * (oProductBiz.Priceorpercent / 100));
                            offer = oProductBiz.Priceorpercent;
                            saleType = " % OFF";
                        }

                    }

                    fullText = fullText.Replace("{#PRICE#}", String.Format("{0:0,0}", price));

                    fullText = fullText.Replace("{#PRICEORPERCENT#}", offer > 0 ? String.Format("{0:0}", offer) + " " + saleType : "");
                    fullText = fullText.Replace("{#OFFERPRICE#}", offerPrice > 0 ? String.Format("{0:0,0}", offerPrice) : "");
                    string strHot = string.Empty;
                    if (oProductBiz.IsHot)
                    {
                        strHot = "<img src='/admin/includes/images/hoticon.gif' border='0' width='30' height='30' />";

                    }

                    string hotText = string.Empty;
                    if (oProductBiz.HotText != null && oProductBiz.HotText != "")
                    {
                        hotText = oProductBiz.HotText;
                        strHot += "<font size='1'>" + hotText + "</font>";
                    }
                    // fullText = fullText.Replace("{#ISHOT#}", strHot);

                    strBuild.Append(fullText);
                    strBuild.Append("</td>");
                    //sr.Close();
                }
            }
            strBuild.Append("</tr></table>");
            
            divList.InnerHtml = strBuild.ToString();
        }
    }
}