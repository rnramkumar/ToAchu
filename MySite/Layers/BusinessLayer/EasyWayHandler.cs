using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Data;
using System.Xml;

using BusinessObjects;

namespace EasyWay.BusinessLayer
{
    class EasyWayHandler : IHttpHandler, IReadOnlySessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string type = context.Request.QueryString["TYPE"];
                if (type.ToUpper().Equals("DELETEPRODUCT"))
                {

                    DeleteProduct(context);
                }
                else if (type.ToUpper().Equals("CHANGESTATUS"))
                {
                    ChangeStatus(context);
                }
                else if (type.ToUpper().Equals("DELETEBANNER"))
                {
                    DeleteBannerAd(context);
                }
                else if (type.ToUpper().Equals("TRACKBANNERAD"))
                {
                    TrackBannerAd(context);
                }
                else if (type.ToUpper().Equals("GETCRITICALUPDATES"))
                {
                    GetCriticalUpdates(context);
                }
                
                
                else if (type.ToUpper().Equals("REVIEWSUBMIT"))
                {
                    ReviewSubmit(context);
                }
                else if (type.ToUpper().Equals("READREVIEW"))
                {
                    GetReviewsByProduct(context);
                }
                else if (type.ToUpper().Equals("CUSTSTATUS"))
                {
                    ChangeCustomerStatus(context);
                }
                    
                else if (type.ToUpper().Equals("LOGOUT"))
                {
                    context.Session.Remove("name");
                    context.Session.Remove("UEmail");
                    HttpResponse oResponse = context.Response;
                    oResponse.Write(true);
                }

    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ChangeCustomerStatus(HttpContext context)
        {

            try
            {
                string custId="";
                int statusId = 0;
                if (context.Request.QueryString["id"]!=null)
                     custId = context.Request.QueryString["id"].ToString();
                if (context.Request.QueryString["val"] != null)
                             statusId =  Convert.ToInt32(context.Request.QueryString["val"].ToString());
                                
                bool blnSucc = false;                                            
                HttpResponse oResponse = context.Response;
                oResponse.Write(blnSucc);
         
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        

        private void ForgotPwd(HttpContext context)
        {

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(context.Server.MapPath(@"~\EmailConfig.xml"));

                XmlNode node = xmlDoc.SelectSingleNode("//forgotpassword/subject");
                String subject = node.InnerText;
                XmlNode node1 = xmlDoc.SelectSingleNode("//forgotpassword/messagebody");
                string bodyFrmXml = node1.InnerText;
                string resetPwd = "aa";
                string email = context.Request.Form["txtEmail"];
                //HelperFunction.SendMail(txtEmail.Text, subject, string.Format(bodyFrmXml, resetPwd));
                //Get customer pwd and send to email or need to give the link for resetting pwd
                bool blnSucc = true;
                if (blnSucc)
                {
                    context.Session.Add("ChngePwdMsg", "An email with password reset instructions has been sent to your registered email id.!!!");

                }
                else
                {
                    context.Session.Add("ChngePwdMsg", "Error Occured !!! when fetching your password.Please try again !!!");
                }

                
                HttpResponse oResponse = context.Response;
                oResponse.Write(true);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
        public void GetReviewsByProduct(HttpContext context)
        {
            DataSet dsReviews = null;
            RatingBiz oRatingBiz = new RatingBiz();
            StringBuilder strBuildRev = new StringBuilder();
            try
            {
                Products oProducts = new Products();
                dsReviews = new DataSet();
                oRatingBiz.Pid = Convert.ToInt32(context.Request.Form["hdnPid"]);
                dsReviews = oProducts.GetReviewsByProduct(oRatingBiz);
                foreach (DataRow dr in dsReviews.Tables[0].Rows)
                {
                    string strRating = @"
                <div class='ratethis'><span class='fl'>Rate</span>
                    <ul class='star-rating'>
                        <li id='liRating' class='current-rating' style='width:" + Convert.ToDecimal(20*Convert.ToDecimal(dr["rating"].ToString())) + @"%'></li>
                        <li><a title='Poor'>1</a></li>
                        <li><a title='OK'>2</a></li>
                        <li><a title='Good'>3</a></li>
                        <li><a title='Useful'>4</a></li>
                        <li><a title='Excellent'>5</a></li>
                    </ul>
               </div>";

                    
                    strBuildRev.Append("<table><tr><td style='width:200px' rowspan='2'>");
                    strBuildRev.Append(strRating+"<br />" + dr["reviewdate"] + "<br />"+dr["name"].ToString()+"</td>");
                    strBuildRev.Append("<td>"+dr["title"].ToString()+"</td></tr>");
                    strBuildRev.Append("<tr><td>"+dr["reviewtext"].ToString()+"</td></tr></table>");
                                
                }
                HttpResponse oResponse = context.Response;
                oResponse.Write(strBuildRev.ToString());
             
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
        

        private void ReviewSubmit(HttpContext context)
        {
            RatingBiz oRatingBiz = new RatingBiz();
            string pid = context.Request.Form["hdnPid"];
            oRatingBiz.Pid = Convert.ToInt32(pid);
            oRatingBiz.ReviewerName = context.Request.Form["Reviews1$txtName"];
            oRatingBiz.ReviewText = context.Request.Form["Reviews1$txtReviewText"];
            oRatingBiz.ReviewTitle = context.Request.Form["Reviews1$txtTitle"];
            oRatingBiz.Rating = Convert.ToDecimal(context.Request.Form["hdnRating"]);
             
            Products oProducts = new Products();
            bool flag = oProducts.insertProductRating(oRatingBiz);
            HttpResponse oResponse = context.Response;
            oResponse.Write(flag);
            
        }


        private void GetCriticalUpdates(HttpContext context)
        {
            Contact oContact = new Contact();
             DataSet dsCritical = oContact.getCriticalUpdates();
            String criticalMessage = string.Empty;
             if (dsCritical.Tables.Count > 0 && dsCritical.Tables[0].Rows.Count > 0)
             {
                 criticalMessage = dsCritical.Tables[0].Rows[0]["criticalMessage"].ToString();
             }
             HttpResponse oResponse = context.Response;
            // string output = @"<div class='container'>
              //          <b class='rtop'><b class='r1'></b> <b class='r2'></b> <b class='r3'></b> <b class='r4'></b></b>
                //        <p>"+criticalMessage+@"</p>
                  //      <b class='rbottom'><b class='r4'></b> <b class='r3'></b> <b class='r2'></b> <b class='r1'></b></b>
                    //    </div>";
            string output = @"<table cellSpacing='0' cellPadding='0' border='1' bgcolor='white' width='400' height='300' id='elementDiv' style='visibility:hidden; position:absolute; top:0; left:0; border-color:black'>
<tr>
<td align='left' valign='top' bgcolor='blue' width='100%' height='10px'>
<font color='white' size='2' face='arial'><b>
<!--################ Your page title goes here  -->
Updates
</b></font>
</td>
<td width='10px' height='10px' bgcolor='red' align='right'>
<font color='white' size='3' face='arial'><span onclick='closeElement()' style='cursor:hand' title='Click here to close this window'><b>X</b></span></font>
</td></tr>
<tr>
<td colspan='2'>
<font color='black' size='2' face='arial'><b><center>
"+criticalMessage+@"
</center></b></font>

</td></tr></table>
";
             oResponse.Write(output);
        
        }

        private void TrackBannerAd(HttpContext context)
        {
            Banner oBanner = new Banner();
            string adId = context.Request.QueryString["adId"];
            string redirectUrl = "";
            BannerBiz oBannerBiz = new BannerBiz();
            oBannerBiz.AdId = Convert.ToInt32(adId);
            oBannerBiz.IpAddress = context.Request.UserHostAddress;
            redirectUrl = oBanner.insAdTrackingAndBannerURL(oBannerBiz);
            HttpResponse oResponse = context.Response;
            oResponse.Redirect(redirectUrl);
        }

         private void ChangeStatus(HttpContext context)
        {
            Products oProducts = new Products();
            string statusId = context.Request.QueryString["statusId"];
            string arrPids = context.Request.QueryString["pIds"];
            bool isStatus = oProducts.changeStatus(Convert.ToInt32(statusId), arrPids);
            string statusMsg = "";
            HttpResponse oResponse = context.Response;
            if (isStatus)
            {
                statusMsg = "Status changed successfully";
            }
            else
                statusMsg = "Error occured while changing the status";

            oResponse.Write(statusMsg);
        }

        private void DeleteProduct(HttpContext context)
        {
            Products oProducts = new Products();
            string pid = context.Request.QueryString["pid"];
            bool isStatus = oProducts.deleteProduct(Convert.ToInt32(pid));
            string statusMsg = "";
            
            HttpResponse oResponse = context.Response;
            if (isStatus)
            {
               
                statusMsg =  "Product deleted successfully";
              
            }
            else
                statusMsg =  "Error occured while deleting the product";

            oResponse.Write(statusMsg);
        }

        private void DeleteBannerAd(HttpContext context)
        {
            Banner oBanner = new Banner();
            string adId = context.Request.QueryString["adId"];
            bool isStatus = oBanner.deleteBannerAd(Convert.ToInt32(adId));
            string statusMsg = "";
            HttpResponse oResponse = context.Response;

            if (isStatus)
            {
                string imgName = context.Request.QueryString["imgName"];
                File.Delete(context.Server.MapPath("banners\\" + imgName));
                statusMsg = "Banner Ad deleted successfully";

            }
            else
                statusMsg = "Error occured while deleting the banner ad";

            oResponse.Write(statusMsg);
        }

        #endregion
    }
}
