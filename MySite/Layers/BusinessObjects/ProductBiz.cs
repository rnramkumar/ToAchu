using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BusinessObjects
{
    public class ProductBiz 
    {
        int productId;
        int categoryId;
        int statusId;
        int seqNo;
        int seqPeriod;
        int cityId;
        int stateId;
        int brandId;
        int qty;
        int qtyInCart;

        Decimal price;
        Decimal marketPrice;
        Decimal priceorpercent;
        Decimal discountPrice;
        
        RatingBiz rating;
        
        string productName = string.Empty;
        string productCode = string.Empty;
        string prodShortDesc = string.Empty;
        string prodLongDesc = string.Empty;
        string userAction = string.Empty;
        string statusName = string.Empty;
        string searchText = string.Empty;
        string hotText = string.Empty;
        string saleType = string.Empty;
        string imagePath = string.Empty;
        string qtyText = string.Empty;

        public string QtyText
        {
            get { return qtyText; }
            set { qtyText = value; }
        }
        
        DateTime effectiveDate;
        DateTime expiryDate;
        DateTime postedDate;

        Boolean isHot;
        Boolean isActive;
        Boolean isProductSale;

        ArrayList areaCode;
        ArrayList products;
        ArrayList arrImages;
        ArrayList arrCategories;

        public int QtyInCart
        {
            get { return qtyInCart; }
            set { qtyInCart = value; }
        }
        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        public Decimal DiscountPrice
        {
            get { return discountPrice; }
            set { discountPrice = value; }
        }
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }
        public RatingBiz Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public ArrayList ArrImages
        {
            get { return arrImages; }
            set { arrImages = value; }
        }


        public ArrayList ArrCategories
        {
            get { return arrCategories; }
            set { arrCategories = value; }
        }

        
        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public int BrandId
        {
            get { return brandId; }
            set { brandId = value; }
        }
        public Boolean IsProductSale
        {
            get { return isProductSale; }
            set { isProductSale = value; }
        }
        public Boolean IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        

        public string HotText
        {
            get { return hotText; }
            set { hotText = value; }
        }
        public String SaleType
        {
            get { return saleType; }
            set { saleType = value; }
        }


        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; }
        }
        public string UserAction
        {
            get { return userAction; }
            set { userAction = value; }
        }
        public string StatusName
        {
            get { return statusName; }
            set { statusName = value; }
        }

        public int StateId
        {
            get { return stateId; }
            set { stateId = value; }
        }

        public int CityId
        {
            get { return cityId; }
            set { cityId = value; }
        }
        public string ProdLongDesc
        {
            get { return prodLongDesc; }
            set { prodLongDesc = value; }
        }
        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Decimal MarketPrice
        {
            get { return marketPrice; }
            set { marketPrice = value; }
        }

        public Decimal Priceorpercent
        {
            get { return priceorpercent; }
            set { priceorpercent = value; }
        }

        public int SeqPeriod
        {
            get { return seqPeriod; }
            set { seqPeriod = value; }
        }

        public int SeqNo
        {
            get { return seqNo; }
            set { seqNo = value; }
        }

        public Boolean IsHot
        {
            get { return isHot; }
            set { isHot = value; }
        }

        public DateTime EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }
        public DateTime PostedDate
        {
            get { return postedDate; }
            set { postedDate = value; }
        }
        public int StatusId
        {
            get { return statusId; }
            set { statusId = value; }
        }
       
               
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public string ProdShortDesc
        {
            get { return prodShortDesc; }
            set { prodShortDesc = value; }
        }

        public int ProductId
        {
            get { return productId; }
            set { this.productId = value; }
        }

        
        public string ProductName
        {
            get { return productName; }
            set { this.productName = value; }
        }

        public ArrayList AreaCode
        {
            get { return areaCode; }
            set { this.areaCode = value; }
        }

        public ArrayList Products
        {
            get { return products; }
            set { this.products = value; }
        }

    }
}
