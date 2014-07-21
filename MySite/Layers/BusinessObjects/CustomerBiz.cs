using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BusinessObjects
{
   public class CustomerBiz
    {

        String email;
             
        int customerId;
              
        String name;
             
        String pwd;

        String shippingName;
        String shippingAddress;
        String shippingCity;
        String shippingState;
        String shippingPincode;
        String shippingMobile;
        String shippingSaveName;
        String signedUpDate;

        public String SignedUpDate
        {
            get { return signedUpDate; }
            set { signedUpDate = value; }
        }

        public String ShippingSaveName
        {
            get { return shippingSaveName; }
            set { shippingSaveName = value; }
        }

        public String ShippingMobile
        {
            get { return shippingMobile; }
            set { shippingMobile = value; }
        }

        public String ShippingPincode
        {
            get { return shippingPincode; }
            set { shippingPincode = value; }
        }

        public String ShippingState
        {
            get { return shippingState; }
            set { shippingState = value; }
        }

        public String ShippingCity
        {
            get { return shippingCity; }
            set { shippingCity = value; }
        }

        public String ShippingAddress
        {
            get { return shippingAddress; }
            set { shippingAddress = value; }
        }


        public String ShippingName
        {
            get { return shippingName; }
            set { shippingName = value; }
        }

        
        
       public String Email
        {
            get { return email; }
            set { email = value; }
        }


        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public String Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
