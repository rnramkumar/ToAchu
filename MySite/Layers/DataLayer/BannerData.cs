using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CDL = EasyWay.CoreDataLayer;
using BusinessObjects;
using System.Collections;


namespace EasyWay.DataLayer
{
    public class BannerData
    {
        public BannerData()
        {
        }


        public Boolean deleteBannerAd(int adId)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            Boolean flag = false;
            try
            {
                string strReturnVal = objCoreDataLayer.ExecuteScalar("pr_delBannerAd", new object[] { adId }, true);
                if (strReturnVal == "0")
                    flag = true;

            }
            catch (Exception e)
            {
                throw e;
            }

            return flag;
        }

        public DataSet getAllBanners()
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            DataSet dsAllBanner = null;
            try
            {
                dsAllBanner = new DataSet();
                dsAllBanner = objCoreDataLayer.ExecuteDataSet("pr_getallbanner", new object[] { });

            }
            catch (Exception e)
            {
                throw e;
            }

            return dsAllBanner;
        }

        public DataSet getAllCarousel()
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            DataSet dsAllCarousel = null;
            try
            {
                dsAllCarousel = new DataSet();
                dsAllCarousel = objCoreDataLayer.ExecuteDataSet("pr_getallcarousels", new object[] { });

            }
            catch (Exception e)
            {
                throw e;
            }

            return dsAllCarousel;
        }

        public DataSet getBannerAdById(int adId)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            DataSet dsBannerAd = null;
            try
            {
                dsBannerAd = new DataSet();
                dsBannerAd = objCoreDataLayer.ExecuteDataSet("pr_getBannerAdById", new object[] {adId });

            }
            catch (Exception e)
            {
                throw e;
            }

            return dsBannerAd;
        }

        public DataSet getRandomAdBanner(string category)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            DataSet dsBanner = null;
            try
            {
                dsBanner = new DataSet();
                dsBanner = objCoreDataLayer.ExecuteDataSet("pr_Get_Random_Banner", new object[] { category });

            }
            catch (Exception e)
            {
                throw e;
            }

            return dsBanner;
        }

        public string insAdTrackingAndBannerURL(BannerBiz oBannerBiz)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            string redirectUrl = string.Empty;
            try
            {

                redirectUrl = objCoreDataLayer.ExecuteNonQueryAndScalar("pr_InsAdtracking", new object[] { oBannerBiz.AdId, oBannerBiz.IpAddress });

            }
            catch (Exception e)
            {
                throw e;
            }

            return redirectUrl;
        }


        public Boolean addBanner(BannerBiz oBannerBiz)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            Boolean flag = false;
            try
            {
                string strRetValue = string.Empty;

                if (oBannerBiz.UserAction.ToUpper().Equals("ADD"))
                {
                    strRetValue = objCoreDataLayer.ExecuteScalar("pr_InsBannerAd", new object[] { oBannerBiz.Category,oBannerBiz.AdvName,oBannerBiz.ImgPath,oBannerBiz.Width,oBannerBiz.Height,
                 oBannerBiz.StartDate,oBannerBiz.EndDate,oBannerBiz.RedirectURL,oBannerBiz.Active,oBannerBiz.AltText,oBannerBiz.Weightage}, true);
                }
                else
                {
                    strRetValue = objCoreDataLayer.ExecuteScalar("pr_UpdBannerAd", new object[] { oBannerBiz.AdId,oBannerBiz.Category,oBannerBiz.AdvName,oBannerBiz.ImgPath,oBannerBiz.Width,oBannerBiz.Height,
                 oBannerBiz.StartDate,oBannerBiz.EndDate,oBannerBiz.RedirectURL,oBannerBiz.Active,oBannerBiz.AltText,oBannerBiz.Weightage}, true);
                }

                if (strRetValue == "0")
                    flag = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }


    }

}    
    
