using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

using EasyWay.BusinessLayer;
using BusinessObjects;

namespace Easyway.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        Products oProducts = new Products();

         DataTable dtcategory = new DataTable();
           DataColumn dc = new DataColumn("catId");
           DataColumn dc1 = new DataColumn("catName");
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                hdnUpdate.Value = "";
                btnBack.Visible = false;
                             
               
                
                DataSet dsStatus = new DataSet();
                dsStatus = oProducts.getStatus();
                fillDropDown(ddlStatus, dsStatus, "statusname", "statusid");


                DataSet dsBrands = new DataSet();
                dsBrands = oProducts.getBrands();
                fillDropDown(ddlBrand, dsBrands, "brandname", "brandid");

                DataSet dsCat = new DataSet();
                dsCat = oProducts.getCategory();

                dtcategory.Columns.Add(dc);
                dtcategory.Columns.Add(dc1);

                DataView dv = dsCat.Tables[0].DefaultView;
                dv.RowFilter = "parentid=0";

                foreach (DataRowView drv in dv)
                {
                    DataRow drCat = dtcategory.NewRow();
                    drCat["catId"] = drv["categoryid"].ToString();
                    drCat["catName"] = drv["categoryName"].ToString();
                    dtcategory.Rows.Add(drCat);
                    displayChild(drv["categoryid"].ToString(), dsCat);
                }

                dsCat = new DataSet();
                dsCat.Tables.Add(dtcategory);
                fillListBox(lstCategory, dsCat, "catName", "catId");

                if (Request["type"]!= null)
                {
                    btnBack.Visible = true;
                  
                    int pid = Convert.ToInt32(Request.QueryString["pid"].ToString());
                    oProducts = new Products();
                    ProductBiz oProductBiz = oProducts.getProductDetailsById(pid);

                    setProductDetails(oProductBiz,sender,e);
                }
               
            }

        }

        private void setProductDetails(ProductBiz oProductBiz,object sender, EventArgs e)
        {
            hdnUpdate.Value = oProductBiz.ProductId.ToString();
            txtProdName.Value = oProductBiz.ProductName;
            txtProdCode.Value = oProductBiz.ProductCode;
            txtShortDesc.Content = oProductBiz.ProdShortDesc;
            txtLongDesc.Content = oProductBiz.ProdLongDesc;
            txtPrice.Value = Convert.ToString(oProductBiz.Price);
            txtMarketPrice.Value = Convert.ToString(oProductBiz.MarketPrice);
            txtQty.Value = Convert.ToString(oProductBiz.QtyInCart);
            txtDisplayText.Value = oProductBiz.QtyText;
            

            ddlBrand.Items.FindByValue(oProductBiz.BrandId.ToString()).Selected = true;

            if (oProductBiz.IsHot)
                chkHot.Checked = true;

            txtHotText.Value = oProductBiz.HotText;

            if (oProductBiz.IsProductSale)
            {
                chkSale.Checked = true;
                radSale.Items.FindByValue(oProductBiz.SaleType.ToString()).Selected = true;
                txtOffer.Value = Convert.ToString(oProductBiz.Priceorpercent);
            }
            
            //Category            
            for(int i=0;i<oProductBiz.ArrCategories.Count;i++)
            {
                lstCategory.Items.FindByValue(oProductBiz.ArrCategories[i].ToString()).Selected = true;
            }
                       
            ddlStatus.Items.FindByValue(oProductBiz.StatusId.ToString()).Selected = true;

            //Displaying images
            StringBuilder strBuild = new StringBuilder();
            StringBuilder strImg = new StringBuilder();
            if (oProductBiz.ArrImages != null)
            {
                for (int j = 0; j < oProductBiz.ArrImages.Count; j++)
                {
                    BaseBiz opic = (BaseBiz)oProductBiz.ArrImages[j];

                    string imgPath = "/admin/upload/" + opic.Name;
                    strImg.Append(opic.Name);
                    strImg.Append(",");
                    strBuild.Append("<input type='file' size='20' name='dynamic" + j + "'>&nbsp;&nbsp;<img src='" + imgPath + "' border='0' width='25' height='25'>&nbsp;<a id='lnkRemove' runat='server' href='javascript:fnRemoveImg();'>Remove</a>");
                    strBuild.Append("<br/>");

                }
                hdnFileName.Value = strImg.ToString().Substring(0, strImg.Length - 1);
            }
            

            if(oProductBiz.IsProductSale)
                strBuild.Append("<script>document.getElementById('divSale').style.display='block'</script>");

            divImgView.InnerHtml = strBuild.ToString();

           
        }

        private void displayChild(string catId, DataSet ds)
        {

            foreach(DataRow dr in ds.Tables[0].Select("parentid="+catId))
            {
                int seqNo = getSeqNo(dr["categoryid"].ToString(), ds);
                String strText = "";
                for (int i = 1; i < seqNo; i++)
                {
                    strText += "---";
                }
                strText += dr["categoryname"].ToString();
                
                DataRow drCat = dtcategory.NewRow();
                drCat["catId"] = dr["categoryid"].ToString();
                drCat["catName"] = strText;
                dtcategory.Rows.Add(drCat);

                displayChild(dr["categoryid"].ToString(), ds);
            }
           

          
        }

        private int getSeqNo(string catId , DataSet ds)
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

        protected void fillDropDown(DropDownList ddl, DataSet ds,string textName,string valueName)
        {
            ddl.DataSource = ds.Tables[0];
            ddl.DataTextField = textName;
            ddl.DataValueField = valueName;
            ddl.DataBind();
                       
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
           
        }
        protected void fillListBox(ListBox lst, DataSet ds, string textName, string valueName)
        {
            lst.DataSource = ds.Tables[0];
            lst.DataTextField = textName;
            lst.DataValueField = valueName;
            lst.DataBind();

            lst.Items.Insert(0, new ListItem("--Select--", "0"));

        }

       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                
                ProductBiz oProductBiz = new ProductBiz();

              
                oProductBiz.ProductName = txtProdName.Value.Trim();
                oProductBiz.ProductCode = txtProdCode.Value.Trim();
                oProductBiz.ProdShortDesc = txtShortDesc.Content;
                oProductBiz.ProdLongDesc = txtLongDesc.Content;
               
                if (txtPrice.Value != "")
                {
                    oProductBiz.Price = Convert.ToDecimal(txtPrice.Value.Trim());
                }
                else
                    oProductBiz.Price = 0.0m;

                if (txtMarketPrice.Value != "")
                {
                    oProductBiz.MarketPrice = Convert.ToDecimal(txtMarketPrice.Value.Trim());
                }
                else
                    oProductBiz.MarketPrice = 0.0m;

                oProductBiz.IsProductSale = chkSale.Checked;

                if (oProductBiz.IsProductSale)
                {
                    oProductBiz.SaleType = radSale.SelectedItem.Value;
                    oProductBiz.Priceorpercent = Convert.ToDecimal(txtOffer.Value);
                }
               // String effDate = HelperFunction.FormatDate(txtEffective.Value, "dd-MMM-yyyy");
                //String expDate = HelperFunction.FormatDate(txtExpiry.Value, "dd-MMM-yyyy");
             
          

                oProductBiz.BrandId = Convert.ToInt32(ddlBrand.SelectedItem.Value);
                oProductBiz.StatusId = Convert.ToInt32(ddlStatus.SelectedItem.Value);
                oProductBiz.IsHot = chkHot.Checked;
                oProductBiz.HotText = txtHotText.Value;
                ArrayList arrCategory = new ArrayList();
                foreach (ListItem li in lstCategory.Items)
                {
                    if (li.Selected)
                    {
                        arrCategory.Add(li.Value);
                    }
                }
                oProductBiz.ArrCategories = arrCategory;
                if (hdnUpdate.Value != "")
                {
                    oProductBiz.UserAction = "update";
                    oProductBiz.ProductId = Convert.ToInt32(hdnUpdate.Value);

                    
                    
                        string[] strArr = hdnFileName.Value.Split(',');
                        if (strArr.Length > 0)
                        {
                            for (int j = 0; j < strArr.Length; j++)
                            {
                                
                                File.Delete(Server.MapPath("upload\\" + strArr[j]));
                                
                            }
                        }
          
                        
                    
                }
                
              oProductBiz.ArrImages = uploadImages();
                
              oProductBiz.QtyInCart = Int32.Parse(txtQty.Value);
              oProductBiz.QtyText = txtDisplayText.Value;
                
                bool isStatus =  oProducts.addProduct(oProductBiz);
                if (isStatus)
                {
                    if(oProductBiz.UserAction!="")
                        Response.Write("<script>alert('Product updated successfully');</script>");
                    else
                        Response.Write("<script>alert('Product added successfully');</script>");

                    Response.Redirect("ManageProducts.aspx");
                }


            }

        }

        protected void uploadValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {

            HttpFileCollection uploads = HttpContext.Current.Request.Files;
            for (int i = 0; i < uploads.Count; i++)
            {
                HttpPostedFile upload = uploads[i];

                if (upload.ContentLength == 0)
                    continue;

                string fileName = System.IO.Path.GetFileName(upload.FileName); // We don't need the path, just the name.

                if (fileName != "" && fileName.LastIndexOf(".") > 0)
                {
                    string extension = fileName.Substring(fileName.LastIndexOf(".") + 1);
                    if (extension.ToLower() != "jpg" && extension.ToLower() != "gif" && extension.ToLower() != "bmp")
                    {
                        uploadValidator.Text = "Upload only with .jpg,.gif,.bmp extension";
                        args.IsValid = false;
                        break;
                    }
                    else
                    {
                        // if(txtUpload.PostedFile.ContentLength > 
                        args.IsValid = true;
                        
                    }
                    
                }
            }

           
        }

        protected ArrayList uploadImages()
        {
            ArrayList arrImg = new ArrayList();
            HttpFileCollection uploads = HttpContext.Current.Request.Files;
            for (int i = 0; i < uploads.Count; i++)
            {
                HttpPostedFile upload = uploads[i];

                if (upload.ContentLength == 0)
                    continue;

                BaseBiz objPic = new BaseBiz();

                //Getting actual file name of picture 
                string fileName = System.IO.Path.GetFileName(upload.FileName); // We don't need the path, just the name.
                string extension = fileName.Substring(fileName.LastIndexOf(".") + 1);
                //creating new filename before saving
                string fileSaveName = "Image" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString()+"."+extension;

                objPic.Name = fileSaveName;
                arrImg.Add(objPic);
                
                try
                {
                    upload.SaveAs(Server.MapPath("upload\\" + fileSaveName));
                    
                }
                catch (Exception Exp)
                {
                    throw Exp;
                }
            }
            return arrImg;
        }
        

       
    }
}
