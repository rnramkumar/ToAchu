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
    public class CustomerData
    {
        
        public Boolean isEmailExist(CustomerBiz oCustomerBiz)
        {
            int cnt = 0;
            bool flg = false;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {

                cnt = Convert.ToInt32(objCoreDataLayer.ExecuteScalar("pr_checkemailexist", new object[] { oCustomerBiz.Email}, false));

                if (cnt > 0)
                    flg = true;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flg;

        }

        public Boolean isUserExist(CustomerBiz oCustomerBiz)
        {
            int cnt = 0;
            bool flg = false;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {

                cnt = Convert.ToInt32(objCoreDataLayer.ExecuteScalar("pr_checkcustomer", new object[] { oCustomerBiz.Email,oCustomerBiz.Pwd}, false));

                if (cnt > 0)
                    flg = true;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flg;

        }

        public Boolean customerSignUp(CustomerBiz oCustomerBiz)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            Boolean flag = false;
            try
            {
                string strRetValue = string.Empty;


                strRetValue = objCoreDataLayer.ExecuteScalar("pr_insertcustomer", new object[] { oCustomerBiz.Email,oCustomerBiz.Name,oCustomerBiz.Pwd }, true);


                if (strRetValue == "0")
                    flag = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }

        public Boolean changePwd(CustomerBiz oCustomerBiz)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            Boolean flag = false;
            try
            {
                string strRetValue = string.Empty;


                strRetValue = objCoreDataLayer.ExecuteScalar("pr_changepwd", new object[] { oCustomerBiz.Email,oCustomerBiz.CustomerId, oCustomerBiz.Pwd }, true);


                if (strRetValue == "0")
                    flag = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }

        public int insertShippingAddress(CustomerBiz oCustomerBiz)
        {
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            
            int iCustomerAddID = 0;
            try
            {
                


                iCustomerAddID = objCoreDataLayer.ExecuteIdentity("pr_InsShippingAdd", new object[] { oCustomerBiz.CustomerId,oCustomerBiz.ShippingName,oCustomerBiz.ShippingAddress,oCustomerBiz.ShippingPincode,oCustomerBiz.ShippingCity,oCustomerBiz.ShippingState,oCustomerBiz.ShippingMobile,oCustomerBiz.ShippingSaveName});


             }
            catch (Exception ex)
            {
                throw ex;
            }

            return iCustomerAddID;
        }


        public DataSet getCustomer(CustomerBiz oCustomerBiz)
        {
            DataSet dsCustomer = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsCustomer = new DataSet();
                dsCustomer = objCoreDataLayer.ExecuteDataSet("pr_getcustomer", new object[] { oCustomerBiz.Email,oCustomerBiz.Pwd});

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsCustomer;

        }

        public DataSet getAllCustomer()
        {
            DataSet dsCustomer = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsCustomer = new DataSet();
                dsCustomer = objCoreDataLayer.ExecuteDataSet("pr_getallcustomer", new object[] {});

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsCustomer;

        }

        public DataSet getCustomerSavedAddress(CustomerBiz oCustomerBiz)
        {
            DataSet dsCustomerAdd = null;
            CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
            try
            {
                dsCustomerAdd = new DataSet();
                dsCustomerAdd = objCoreDataLayer.ExecuteDataSet("pr_getcustomerSavedAdd", new object[] { oCustomerBiz.CustomerId });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dsCustomerAdd;

        }


    }
}
