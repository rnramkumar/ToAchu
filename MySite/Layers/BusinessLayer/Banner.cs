using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using BusinessObjects;
using EasyWay.DataLayer;


namespace EasyWay.BusinessLayer
{
   public  class Banner
    {

       public Banner()
        {
        }

       
           
       #region Delete banner ad
       public Boolean deleteBannerAd(int adId)
        {
            try
            {
                BannerData oBannerData = new BannerData();
                return oBannerData.deleteBannerAd(adId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

       #region get random banners
       public BannerBiz getRandomAdBanner(string category)
       {

           BannerData oBannerData = null;
           BannerBiz oBannerBiz = null;
           try
           {
               oBannerData = new BannerData();
               oBannerBiz = new BannerBiz();
               DataSet dsBanner = oBannerData.getRandomAdBanner(category);
               if (dsBanner.Tables.Count > 0 && dsBanner.Tables[0].Rows.Count > 0)
               {
                   foreach (DataRow dr in dsBanner.Tables[0].Rows)
                   {
                       oBannerBiz.AdId = Convert.ToInt32(dr["adid"].ToString());
                       oBannerBiz.ImgPath = dr["imageName"].ToString();
                       oBannerBiz.Height = Convert.ToInt32(dr["height"].ToString());
                       oBannerBiz.RedirectURL = dr["redirectURL"].ToString();
                       oBannerBiz.Width = Convert.ToInt32(dr["width"].ToString());
                       oBannerBiz.AltText = dr["altText"].ToString();
                       
                   }
                   
                   
               }
           }
           catch (Exception ex)
           {
               throw ex;
           }

           return oBannerBiz;
       }
       #endregion

       #region get banner ad by id
       public BannerBiz getBannerAdById(int adId)
       {

           BannerData oBannerData = null;
           BannerBiz oBannerBiz = null;
           try
           {
               oBannerData = new BannerData();
               oBannerBiz = new BannerBiz();
               DataSet dsBanner = oBannerData.getBannerAdById(adId);
               if (dsBanner.Tables.Count > 0 && dsBanner.Tables[0].Rows.Count > 0)
               {
                   foreach (DataRow dr in dsBanner.Tables[0].Rows)
                   {
                       oBannerBiz.AdId = Convert.ToInt32(dr["adid"].ToString());
                       oBannerBiz.ImgPath = dr["imageName"].ToString();
                       oBannerBiz.Height = Convert.ToInt32(dr["height"].ToString());
                       oBannerBiz.RedirectURL = dr["redirectURL"].ToString();
                       oBannerBiz.Width = Convert.ToInt32(dr["width"].ToString());
                       oBannerBiz.AltText = dr["altText"].ToString();
                       oBannerBiz.Weightage = Convert.ToInt32(dr["weightage"].ToString());
                       oBannerBiz.StartDate = Convert.ToDateTime(dr["startDate"].ToString());
                       oBannerBiz.EndDate = Convert.ToDateTime(dr["endDate"].ToString());
                       oBannerBiz.AdvName = dr["advName"].ToString();
                       oBannerBiz.Category = dr["category"].ToString();
                       oBannerBiz.Active =  Convert.ToBoolean(dr["active"].ToString());

                   }


               }
           }
           catch (Exception ex)
           {
               throw ex;
           }

           return oBannerBiz;
       }
       #endregion

       #region insert banner ad tracking and get redirecturl
       public string insAdTrackingAndBannerURL(BannerBiz oBannerBiz)
       {

           BannerData oBannerData = null;
           string redirectUrl = string.Empty;
           try
           {
               oBannerData = new BannerData();
               redirectUrl = oBannerData.insAdTrackingAndBannerURL(oBannerBiz);
               
           }
           catch (Exception ex)
           {
               throw ex;
           }

           return redirectUrl;
       }
       #endregion

       #region Add update Banners
       public Boolean addBanner(BannerBiz oBannerBiz)
       {
           try
           {
               BannerData oBannerData = new BannerData();
               return oBannerData.addBanner(oBannerBiz);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion

       #region get all banners
       /// <summary>
       /// Get all the banners
       /// </summary>
       /// <param name="stateId"></param>
       /// <returns></returns>
       public DataSet getAllBanners()
       {
           try
           {
               BannerData oBannerData = new BannerData();
               return oBannerData.getAllBanners();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion

       #region get all carousels
       /// <summary>
       /// Get all the banners
       /// </summary>
       /// <param name="stateId"></param>
       /// <returns></returns>
       public DataSet getAllCarousels()
       {
           try
           {
               BannerData oBannerData = new BannerData();
               return oBannerData.getAllCarousel();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion


    }
}
