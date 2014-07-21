using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using BusinessObjects;
using EasyWay.DataLayer;

namespace EasyWay.BusinessLayer
{
    public class Contact
    {
        public Contact()
        {
        }

        #region get critical updates
        /// <summary>
        /// Get all the banners
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public DataSet getCriticalUpdates()
        {
            try
            {
                ContactData oContactData = new ContactData();
                return oContactData.getCriticalUpdates();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert Contact Us
        public Boolean insertContactUs(ContactBiz oContactBiz)
        {
            try
            {
                ContactData oContactData = new ContactData();
                return oContactData.insertContactUs(oContactBiz);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
