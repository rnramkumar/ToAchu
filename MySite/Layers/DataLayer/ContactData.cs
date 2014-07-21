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
  public  class ContactData
    {
      public ContactData()
      {
      }

      public DataSet getCriticalUpdates()
      {
          CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
          DataSet dsCritical = null;
          try
          {
              dsCritical = new DataSet();
              dsCritical = objCoreDataLayer.ExecuteDataSet("pr_getCriticalUpdates", new object[] { });

          }
          catch (Exception e)
          {
              throw e;
          }

          return dsCritical;
      }

      public Boolean insertContactUs(ContactBiz oContactBiz)
      {
          CDL.CoreDataLayer objCoreDataLayer = new CDL.CoreDataLayer();
          Boolean flag = false;
          try
          {

              string strRetValue = string.Empty;

              strRetValue = objCoreDataLayer.ExecuteScalar("pr_insContactUs", new object[] { oContactBiz.ContactName, oContactBiz.Email, oContactBiz.Subject, oContactBiz.Comments, oContactBiz.IsContact, oContactBiz.FeedbackType }, true);

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
