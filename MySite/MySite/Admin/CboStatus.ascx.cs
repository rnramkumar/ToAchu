using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessObjects;
using EasyWay.BusinessLayer; 

namespace EasyWay.Admin
{
    public partial class CboStatus : System.Web.UI.UserControl
    {
        
        public String GetDdlStatusValue
        {

            get { return ddlStatus.SelectedItem.Value; }
         }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dsStatus = new DataSet();
                Products oProd = new Products();
                dsStatus = oProd.getStatus();
                if (dsStatus != null && dsStatus.Tables[0].Rows.Count > 0)
                {
                    ddlStatus.DataSource = dsStatus.Tables[0];
                    ddlStatus.DataTextField = "statusname";
                    ddlStatus.DataValueField = "statusid";
                    ddlStatus.DataBind();

                    
                }
                ddlStatus.Items.Insert(0,new ListItem("--Select--", "0"));
            }
        }

        
    }
}