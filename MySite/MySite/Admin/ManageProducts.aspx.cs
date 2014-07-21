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

using BusinessObjects;
using EasyWay.BusinessLayer; 


namespace Easyway.Admin
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {

                    Products oProducts = new Products();
                    ArrayList arrProducts = oProducts.getAllProducts();
                    StringBuilder strBuild = new StringBuilder();
                    strBuild.Append("<div><select id='ddlStatus' name='ddlStatus' onChange='javascript:fnChangestatus(this)'><option value='All'>Change Status...</option><option value='1'>New</option><option value='3'>Archived</option><option value='4'>Expired</option></select></div>");
                    strBuild.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0' id='data_sortable'>");
                    strBuild.Append("<tr><th><input type='checkbox' name='chkAll' id='chkAll' text='Select All' onClick='javascript:fnSelectAll(this.checked)'></th><th>Product Name</th><th>Product Code</th><th>Price</th><th>Status</th><th colspan='2' ></th></tr>");
                    for (int i = 0; i < arrProducts.Count; i++)
                    {
                        ProductBiz oProductBiz = (ProductBiz)arrProducts[i];

                        strBuild.Append("<tr>");
                        int prodId = oProductBiz.ProductId;

                        strBuild.Append("<td ><input type='checkbox' name='chkProd"+prodId+"' id='chkProd" + prodId + "' onClick='javascript:checkSelected(this);fnArrayPush(this.checked,"+prodId+")'></td>");
                      /*  string prodImage = "";// oProductBiz.ProdImage;
                        string imgPath = "";
                        if (prodImage != "")
                        {
                            imgPath = "/admin/upload/" + prodImage;
                            prodImage = "<img src='" + imgPath + "' border='0' width='25' height='25'>";
                        }
                        else
                            prodImage = "No Image";

                        strBuild.Append("<td><a id='example1' href='" + imgPath + "'>" + prodImage + "</a></td>");*/
                        strBuild.Append("<td> <a href='javascript:fnViewDetails("+prodId+")'>" + oProductBiz.ProductName + "</a></td>");
                       strBuild.Append("<td>" + oProductBiz.ProductCode+ "</td>");
                       strBuild.Append("<td>" + oProductBiz.Price + "</td>");
                        strBuild.Append("<td>"+oProductBiz.IsActive+"</td>");
                        strBuild.Append("<td><a href=AddProduct.aspx?type=update&pid=" + prodId + ">Edit</a></td>");
                        strBuild.Append("<td><a href='javascript:fnDelProduct("+prodId+")'>Delete</a></td></tr>");
                     }
                    strBuild.Append("</table>");

                    divProdList.InnerHtml = strBuild.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
