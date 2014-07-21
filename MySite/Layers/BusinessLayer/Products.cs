using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

using BusinessObjects;
using EasyWay.DataLayer;


namespace EasyWay.BusinessLayer
{
    public class Products
    {
        public Products()
        {
        }


        #region Add Product and update product
        public Boolean addProduct(ProductBiz oProductObj)
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.addProduct(oProductObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert product rating
        public Boolean insertProductRating(RatingBiz oRatingBiz)
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.insertReviews(oRatingBiz);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region get all reviews by product
        public DataSet GetReviewsByProduct(RatingBiz oRatingBiz)
        {

            
            ProductData oProductData = null;
            try
            {
                
                oProductData = new ProductData();

                return oProductData.getReviewsByProduct(oRatingBiz);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion
         
        #region Delete Product
        public Boolean deleteProduct(int pid)
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.deleteProduct(pid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Change status
        public Boolean changeStatus(int statusId, string productIds)
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.changeStatus(statusId, productIds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region get product details by Id
        public ProductBiz getProductDetailsById(int pid)
        {

            ProductData oProductData = null;
            ProductBiz oProductBiz = null;
            try
            {
                 oProductData = new ProductData();
                 oProductBiz = new ProductBiz();
                 DataSet dsProductDetails = oProductData.getProductDetailsById(pid);
                 if (dsProductDetails.Tables.Count > 0 && dsProductDetails.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsProductDetails.Tables[0].Rows)
                    {
                        

                        oProductBiz.ProductName = dr["productname"].ToString();
                        oProductBiz.ProductId = Convert.ToInt32(dr["productid"].ToString());
                        oProductBiz.ProductCode = dr["pcode"].ToString();
                        oProductBiz.BrandId = Convert.ToInt32(dr["brandid"].ToString());
                        oProductBiz.ProdShortDesc = dr["productshortdesc"].ToString();
                        oProductBiz.ProdLongDesc = dr["productlongdesc"].ToString();

                        oProductBiz.Price = Convert.ToDecimal(dr["price"].ToString());
                        oProductBiz.MarketPrice = Convert.ToDecimal(dr["price"].ToString());
                        oProductBiz.IsActive = Convert.ToBoolean(dr["isactive"].ToString());
                        oProductBiz.IsProductSale = Convert.ToBoolean(dr["isproductsale"].ToString());
                        oProductBiz.SaleType = dr["saletype"].ToString();
                        oProductBiz.Priceorpercent = Convert.ToDecimal(dr["priceorpercent"].ToString());
                        oProductBiz.IsHot = Convert.ToBoolean(dr["ishot"].ToString());
                        oProductBiz.HotText = dr["hotdealsText"].ToString();
                        oProductBiz.QtyInCart = Convert.ToInt32(dr["qtyincart"].ToString());
                        oProductBiz.QtyText = dr["qtytext"].ToString();
                        
                    }
                    ArrayList arrCategory = new ArrayList();
                    if (dsProductDetails.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsProductDetails.Tables[1].Rows)
                        {
                            arrCategory.Add(Convert.ToInt32(dr["categoryid"].ToString()));
                        }
                        oProductBiz.ArrCategories = arrCategory;
                    }
                    ArrayList arrPhotos = new ArrayList();
                    if (dsProductDetails.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsProductDetails.Tables[2].Rows)
                        {
                            BaseBiz oBaseBiz = new BaseBiz();
                            oBaseBiz.Name = dr["photopath"].ToString();
                            arrPhotos.Add(oBaseBiz);
                        }
                        oProductBiz.ArrImages = arrPhotos;
                    }

                    if (dsProductDetails.Tables[3].Rows.Count > 0)
                    {
                        RatingBiz oRating = new RatingBiz();
                        oRating.Rating = Convert.ToDecimal(20 * Convert.ToDecimal(dsProductDetails.Tables[3].Rows[0]["rating"].ToString()));
                        oRating.TotalRating = Convert.ToInt32(dsProductDetails.Tables[3].Rows[0]["TotalRating"].ToString());
                        oProductBiz.Rating = oRating;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oProductBiz;
        }
        #endregion

        #region get all products Admin
        public ArrayList getAllProducts()
        {

            ArrayList arrProducts = null;
            ProductData oProductData = null;
            try
            {
                arrProducts = new ArrayList();
                oProductData = new ProductData();

                DataSet dsProducts = oProductData.getAllProducts();
                if (dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsProducts.Tables[0].Rows)
                    {
                        ProductBiz oProductBiz = new ProductBiz();

                        oProductBiz.ProductName = dr["productname"].ToString();
                        oProductBiz.ProductId = Convert.ToInt32(dr["productid"].ToString());
                        oProductBiz.ProductCode = dr["pcode"].ToString();
                        
                        oProductBiz.Price = Convert.ToDecimal(dr["price"].ToString());
                        oProductBiz.StatusName = dr["isactive"].ToString();
                        arrProducts.Add(oProductBiz);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return arrProducts;
        }
        #endregion

        #region get List all products
        public ArrayList getListAllProducts(ProductBiz objProductBiz)
        {

            ArrayList arrProducts = null;
            ProductData oProductData = null;
            try
            {
                arrProducts = new ArrayList();
                oProductData = new ProductData();

                DataSet dsProducts = oProductData.getListAllProducts(objProductBiz);
                if (dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsProducts.Tables[0].Rows)
                    {
                        ProductBiz oProductBiz = new ProductBiz();

                        oProductBiz.ProductName = dr["productname"].ToString();
                        oProductBiz.ProductId = Convert.ToInt32(dr["productid"].ToString());
                        oProductBiz.ImagePath = dr["photopath"].ToString();
                        //oProductBiz.ProdShortDesc = dr["productshortdesc"].ToString();
                        //oProductBiz.ProdLongDesc = dr["productlongdesc"].ToString();
                        oProductBiz.SaleType = dr["saletype"].ToString();
                        oProductBiz.Priceorpercent = Convert.ToDecimal(dr["priceorpercent"].ToString());
                        oProductBiz.Price = Convert.ToDecimal(dr["price"].ToString());
                                                
                        oProductBiz.IsHot = Convert.ToBoolean(dr["ishot"].ToString());
                        
                        oProductBiz.HotText = dr["hotdealsText"].ToString();
                        arrProducts.Add(oProductBiz);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return arrProducts;
        }
        #endregion

        #region get States
        /// <summary>
        /// getStates
        /// </summary>
        /// <returns>all the states specific to country as of now India</returns>
        public DataSet getStates()
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.getStates();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region getCityByStateId
        /// <summary>
        /// Get city based on state selection
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public DataSet getCityByStateId(int stateId)
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.getCityByStateId(stateId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region getAreaByCityId
        /// <summary>
        /// Get city based on state selection
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public DataSet getAreaByCityId(int cityId)
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.getAreaByCityId(cityId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region getStatus
        /// <summary>
        /// Get all the status
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public DataSet getStatus()
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.getStatus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region getStatus
        /// <summary>
        /// Get all the Brands
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public DataSet getBrands()
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.getBrands();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region getCategory
        /// <summary>
        /// Get all the status
        /// </summary>
        ///  <returns></returns>
        public DataSet getCategory()
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.getCategory();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region get all Categories with product count
        /// <summary>
        /// Get all the categories with product count
        /// </summary>
        ///  <returns></returns>
        public DataSet getAllCategoriesWithProdCount()
        {
            try
            {
                ProductData oProductData = new ProductData();
                return oProductData.getAllCategoriesWithProdCount();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



    }
}
