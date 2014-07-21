using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using EasyWay.DataLayer;
using System.Data;
using System.Security.Cryptography;
using System.Web.Security;
using System.IO;

namespace EasyWay.BusinessLayer
{
     
   public class Customer
    {
   
       #region Insert customer
       public int insertCustomer(CustomerBiz oCustomerBiz)
       {
                    
           try
           {
               CustomerData oCustomerData = new CustomerData();

               // Todo encryption
               String pwdEncrypt = SHA256Encrypt(oCustomerBiz.Pwd);
               oCustomerBiz.Pwd = pwdEncrypt;

               int iCheck=0;
               bool isUserExist = oCustomerData.isEmailExist(oCustomerBiz);

               if (isUserExist)
               {
                   iCheck=1;
               }
               else
               {
                   bool isSucc = oCustomerData.customerSignUp(oCustomerBiz);

                   if (isSucc)
                       iCheck=2;
               }
               
               return iCheck;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           
       }
       #endregion


       #region Get all customers to manage in admin
       public DataSet getAllCustomers()
       {
           try
           {
               
               CustomerData oCustomerData = new CustomerData();

               return oCustomerData.getAllCustomer();
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion

       #region Insert Shipping Address
       public int insertShippingAddress(CustomerBiz oCustomerBiz)
       {

           try
           {
               CustomerData oCustomerData = new CustomerData();
               return oCustomerData.insertShippingAddress(oCustomerBiz);
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }
       #endregion

       #region Get customer
       public DataSet getCustomer(CustomerBiz oCustomerBiz,out string custStatus)
       {
           try
           {
               //Todo encryption
               String pwdEncrypt = SHA256Encrypt(oCustomerBiz.Pwd);
               oCustomerBiz.Pwd = pwdEncrypt;

               CustomerData oCustomerData = new CustomerData();
               bool isStatus = false;
               
               bool isUserExist = oCustomerData.isUserExist(oCustomerBiz);
               DataSet dsCustomer = null;
               if (isUserExist)
               {
                   dsCustomer = new DataSet();
                   dsCustomer = oCustomerData.getCustomer(oCustomerBiz);
                     
               }
               if (dsCustomer!=null && dsCustomer.Tables.Count > 0)
                   isStatus = true;

               if (isStatus)
                   custStatus = "Inactive";
               else
                   custStatus = "";

               return dsCustomer;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion

       #region Get customer Saved Address
       public DataSet getCustomerSavedAddress(CustomerBiz oCustomerBiz)
       {
           try
           {

              
                   CustomerData oCustomerData = new CustomerData();

                DataSet dsCustomerAdd = new DataSet();
                dsCustomerAdd = oCustomerData.getCustomerSavedAddress(oCustomerBiz);
              

               return dsCustomerAdd;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion

       #region Change Password
       public bool changePwd(CustomerBiz oCustomerBiz)
       {
           try
           {
               CustomerData oCustomerData = new CustomerData();

               //Todo encrypt
               String pwdEncrypt = SHA256Encrypt(oCustomerBiz.Pwd);
               oCustomerBiz.Pwd = pwdEncrypt;

               return oCustomerData.changePwd(oCustomerBiz);

           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion

       #region Encrpt Pwd
       private String EncryptString(string plainText)
       {

           byte[] myUnprotectedBytes = StringToByteArray(plainText);
           byte[] myProtectedBytes = MachineKey.Protect(myUnprotectedBytes, "EasyWay");

           return Convert.ToBase64String(myProtectedBytes);

       }
        #endregion

       #region Decrypt
       private String DecryptString(string plainText)
       {    

           byte[] myUnprotectedBytes = Convert.FromBase64String(plainText);
           byte[] myProtectedBytes = MachineKey.Unprotect(myUnprotectedBytes, "EasyWay");

           return BytetoString(myProtectedBytes);

       }

       #endregion

       public static String SHA256Encrypt(String pwd)
        {
            //Encryption
            //SHA256
            //One-way hash
            //Password Token:
            // (hash(hash(userName+ pwd)+salt))
 
            String SALT ="buy2easy"; //
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();
 
            // pwd
            Byte[] inputByteArray = Encoding.UTF8.GetBytes(pwd);
 
            // salt
            Byte[] saltByteArray = Encoding.UTF8.GetBytes(SALT);
 
            // hash
            Byte[] hashedBytesArray1 = provider.ComputeHash(inputByteArray);
 
            // Combine salt and input bytes
            Byte[] inputBytesWithSalt = new Byte[hashedBytesArray1.Length + saltByteArray.Length];
 
 
            hashedBytesArray1.CopyTo(inputBytesWithSalt, 0);
            saltByteArray.CopyTo(inputBytesWithSalt, hashedBytesArray1.Length);
 
            // hash again
            Byte[] hashedBytesArray2 = provider.ComputeHash(inputBytesWithSalt);
 
 
            // return double hash encrypted string.
            return BitConverter.ToString(hashedBytesArray2);
 
        }

       private String BytetoString(byte[] myByte)
       {
           return Encoding.UTF8.GetString(myByte);
       }

       private byte[] StringToByteArray(String strConvert)
       {
           return Encoding.UTF8.GetBytes(strConvert);
       }

    }
}
