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
    public class ProductData
    {
        public ProductData()
        {
        }


        public DataSet getStates()
        {
            DataSet dsStates = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsStates = new DataSet();
                dsStates = objCoreDataLayer.ExecuteDataSet("pr_fillstates", new object[] { }, new object[] { }, new object[] { });
 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsStates;
            
        }

        public DataSet getCityByStateId(int stateId)
        {
            DataSet dsCity = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsCity = new DataSet();
                dsCity = objCoreDataLayer.ExecuteDataSet("pr_getcitybystateid", new object[] { stateId });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsCity;

        }

        public DataSet getAreaByCityId(int cityId)
        {
            DataSet dsArea = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsArea = new DataSet();
                dsArea = objCoreDataLayer.ExecuteDataSet("pr_getareabycityid", new object[] { cityId });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsArea;

        }

        public DataSet getStatus()
        {
            DataSet dsStatus = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsStatus = new DataSet();
                dsStatus = objCoreDataLayer.ExecuteDataSet("pr_selStatus", new object[] { });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsStatus;

        }

        public DataSet getBrands()
        {
            DataSet dsBrands = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsBrands = new DataSet();
                dsBrands = objCoreDataLayer.ExecuteDataSet("pr_getAllBrands", new object[] { });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsBrands;

        }

        public DataSet getCategory()
        {
            DataSet dsCat = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsCat = new DataSet();
                dsCat = objCoreDataLayer.ExecuteDataSet("pr_selcategory", new object[] { });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsCat;

        }

        public DataSet getAllProducts()
        {
            DataSet dsProducts = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsProducts = new DataSet();
                dsProducts = objCoreDataLayer.ExecuteDataSet("pr_getallproductsAdmin", new object[] { });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsProducts;

        }

        public DataSet getListAllProducts(ProductBiz oProductBiz)
        {
            DataSet dsProducts = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsProducts = new DataSet();
                dsProducts = objCoreDataLayer.ExecuteDataSet("pr_getallproducts", new object[] { oProductBiz.CategoryId ,oProductBiz.SearchText});

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsProducts;

        }

        public DataSet getAllCategoriesWithProdCount()
        {
            DataSet dsCategories = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsCategories = new DataSet();
                dsCategories = objCoreDataLayer.ExecuteDataSet("pr_getallcategories", new object[] { });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsCategories;

        }

        
        public Boolean deleteProduct(int pid)
        {
             CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
             Boolean flag= false;
             try
             {
                 string strReturnVal =  objCoreDataLayer.ExecuteScalar("pr_delproduct", new object[] { pid }, true);
                 if (strReturnVal == "0")
                     flag = true;  
                    
             }
             catch (Exception e)
             {
                 throw e;
             }

             return flag;
        }

        public Boolean changeStatus(int statusId,string productIds)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            Boolean flag = false;
            try
            {
                string strReturnVal = objCoreDataLayer.ExecuteScalar("pr_changestatus", new object[] { statusId, productIds }, true);
                if (strReturnVal == "0")
                    flag = true;

            }
            catch (Exception e)
            {
                throw e;
            }

            return flag;
        }

        public DataSet getProductDetailsById(int pid)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            DataSet dsProductDetails = null;
            try
            {
                dsProductDetails = new DataSet();
                dsProductDetails = objCoreDataLayer.ExecuteDataSet("pr_getProductDetailsById", new object[] { pid});

            }
            catch (Exception e)
            {
                throw e;
            }

            return dsProductDetails;
        }

        public Boolean insertReviews(RatingBiz oRatingBiz)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            Boolean flag = false;
            try
            {
                string strRetValue = string.Empty;


                strRetValue = objCoreDataLayer.ExecuteScalar("PR_INSPRODREVIEW", new object[] { oRatingBiz.ReviewTitle, oRatingBiz.Pid,oRatingBiz.ReviewText,oRatingBiz.ReviewerName,oRatingBiz.Rating }, true);


                if (strRetValue == "0")
                    flag = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }

        public DataSet getReviewsByProduct(RatingBiz oRatingBiz)
        {
            DataSet dsProductReview = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsProductReview = new DataSet();
                dsProductReview = objCoreDataLayer.ExecuteDataSet("pr_getallprodreviews", new object[] { oRatingBiz.Pid});

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsProductReview;

        }


        
        public Boolean addProduct(ProductBiz oProductBiz)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            Boolean flag = false;
            try
            {
                ArrayList arrImages = new ArrayList();
                arrImages = oProductBiz.ArrImages;
                StringBuilder strBuildImg = new StringBuilder();

                ArrayList arrCat = new ArrayList();
                arrCat = oProductBiz.ArrCategories;
                StringBuilder strBuildCat = new StringBuilder();

                string strRetValue = string.Empty;

                foreach (BaseBiz arr in arrImages)
                {
                    
                    strBuildImg.Append(arr.Name);
                    strBuildImg.Append(",");
                }

                foreach (string cat in arrCat)
                {
                    strBuildCat.Append(cat);
                    strBuildCat.Append(",");
                }


                if (oProductBiz.UserAction != "")
                {
                    strRetValue = objCoreDataLayer.ExecuteScalar("pr_updProduct", new object[] {oProductBiz.ProductId, oProductBiz.ProductName,oProductBiz.ProductCode,oProductBiz.ProdShortDesc,oProductBiz.ProdLongDesc,
                 oProductBiz.Price,oProductBiz.BrandId,oProductBiz.IsActive,oProductBiz.IsProductSale,oProductBiz.SaleType,oProductBiz.Priceorpercent,oProductBiz.IsHot,oProductBiz.HotText,strBuildImg.ToString(),strBuildCat.ToString(),oProductBiz.QtyInCart,oProductBiz.QtyText }, true);
                }
                else
                {
                    strRetValue = objCoreDataLayer.ExecuteScalar("pr_insProduct", new object[] { oProductBiz.ProductName,oProductBiz.ProductCode,oProductBiz.ProdShortDesc,oProductBiz.ProdLongDesc,
                 oProductBiz.Price,oProductBiz.BrandId,oProductBiz.IsActive,oProductBiz.IsProductSale,oProductBiz.SaleType,oProductBiz.Priceorpercent,oProductBiz.IsHot,oProductBiz.HotText,strBuildImg.ToString(),strBuildCat.ToString(),oProductBiz.QtyInCart,oProductBiz.QtyText }, true);
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
