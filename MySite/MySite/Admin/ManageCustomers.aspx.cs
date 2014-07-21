using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

using EasyWay.BusinessLayer;
using BusinessObjects;

namespace EasyWay.Admin
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Customer oCustomer = new Customer();
                    DataSet dsCustomer = new DataSet();

                    dsCustomer = oCustomer.getAllCustomers();

                    

                        ViewCustomers(dsCustomer);
                    

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void ViewCustomers(DataSet dsCustomers)
        {
            StringBuilder strBuild = new StringBuilder();

            strBuild.Append("<table widtd='100%' border='0' cellpadding='5' cellspacing='3' id='data_sortable'>");
            strBuild.Append("<tr><td>Customer Name</td><td>Email</td><td>Signedup Date</td><td>SuperAdmin</td><td colspan='2'>Status</td></tr>");

            if (dsCustomers != null && dsCustomers.Tables.Count > 0 && dsCustomers.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsCustomers.Tables[0].Rows)
                {
                    strBuild.Append("<tr>");

                    strBuild.Append("<td>" + dr["name"].ToString() + "</td>");

                    strBuild.Append("<td>" + dr["email"].ToString() + "</td>");
                    
                    strBuild.Append("<td>" + Easyway.HelperFunction.FormatDate(dr["createddate"].ToString(), "dd-MMM-yyyy") + "</td>");
                    strBuild.Append("<td>" + dr["issuperadmin"] + "</td>");
                    string custId = dr["customerid"].ToString();
                    strBuild.Append("<td colspan='2'><div id='divCust" + custId + "'><a href='javascript:void(0)' datalist_id='" + custId + "' onclick='javascript:fnChngeCustomerStatus(this)'>" + dr["status"].ToString() + "</a></div></td></tr>");

                }
            }
            else
            {
                strBuild.Append("<tr><td colspan='6'>No records found</td></tr>");

            }

            divCustomers.InnerHtml = strBuild.ToString();
        }

    }
}