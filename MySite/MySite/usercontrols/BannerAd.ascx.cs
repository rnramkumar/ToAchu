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

using EasyWay.BusinessLayer;
using BusinessObjects;


namespace Easyway.usercontrols
{
    public partial class BannerAd : System.Web.UI.UserControl
    {
        string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Banner oBanner = new Banner();

            BannerBiz oBannerBiz = new BannerBiz();

            oBannerBiz = oBanner.getRandomAdBanner(Category);

                //hypLnkBanner.NavigateUrl = "/adtracker.aspx?AdId=" +oBannerBiz.AdId;
            hypLnkBanner.Attributes.Add("onClick", "return fnTrackAd("+oBannerBiz.AdId+")");
                bannerImg.ImageUrl = "/admin/banners/" + oBannerBiz.ImgPath;
                   bannerImg.Height = Unit.Parse(oBannerBiz.Height.ToString());
                    bannerImg.Width = Unit.Parse(oBannerBiz.Width.ToString());
                   bannerImg.AlternateText = oBannerBiz.AltText;
                  // bannerImg.BorderStyle = BorderStyle.None;
                                  
        }
    }
}