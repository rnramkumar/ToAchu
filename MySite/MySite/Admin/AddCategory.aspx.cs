using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Easyway.Admin
{
    public partial class AddCategory : System.Web.UI.Page
    {
        DataTable dtcategory = new DataTable();
        DataColumn dc = new DataColumn("catId");
        DataColumn dc1 = new DataColumn("catName");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DropDownList ddlcat = (DropDownList)categoryFormView.FindControl("ddlCat");

                SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
                SqlDataSource1.SelectCommand = "pr_selcategory";
                DataView view = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);

                DataTable table = view.ToTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(table);
                dtcategory.Columns.Add(dc);
                dtcategory.Columns.Add(dc1);
               
                foreach (DataRow dr in ds.Tables[0].Select("parentId=0"))
                {

                    DataRow drCat = dtcategory.NewRow();
                    drCat["catId"] = dr["categoryid"].ToString();
                    drCat["catName"] = dr["categoryName"].ToString();
                    dtcategory.Rows.Add(drCat);
                    displayChild(dr["categoryid"].ToString(), ds);
                }

                ddlcat.DataSource = dtcategory;
                ddlcat.DataTextField = "catName";
                ddlcat.DataValueField = "catId";
                ddlcat.DataBind();
            }
            
        }

        private void displayChild(string catId, DataSet ds)
        {

            foreach (DataRow dr in ds.Tables[0].Select("parentid=" + catId))
            {
                int seqNo = getSeqNo(dr["categoryid"].ToString(), ds);
                String strText = "";
                for (int i = 1; i < seqNo; i++)
                {
                    strText += "---";
                }
                strText += dr["categoryname"].ToString();

                DataRow drCat = dtcategory.NewRow();
                drCat["catId"] = dr["categoryid"].ToString();
                drCat["catName"] = strText;
                dtcategory.Rows.Add(drCat);

                displayChild(dr["categoryid"].ToString(), ds);
            }



        }

        private int getSeqNo(string catId, DataSet ds)
        {
            int childHierNo = 0;
            int menuId = 0;
            do
            {
                DataRow[] dr = ds.Tables[0].Select("categoryId ='" + catId + "'");
                if (dr.Length > 0)
                {
                    catId = dr[0]["parentid"].ToString();
                    menuId = Convert.ToInt32(dr[0]["parentid"].ToString());
                    childHierNo++;
                }
            }
            while (menuId != 0);

            return childHierNo;
        }


      
        protected void SqlDataSource1_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            TextBox txtCatName = (TextBox)categoryFormView.FindControl("catNameTextBox");
            DropDownList ddl = (DropDownList)categoryFormView.FindControl("ddlCat");
            //CheckBox chkStatus = (CheckBox)categoryFormView.FindControl("chkStatus");
            //SqlParameter param = new SqlParameter("parentId", ddl.SelectedItem.Value);
           //SqlParameter param1 = new SqlParameter("categoryName", txtCatName.Text);
            
          //  SqlDataSource1.InsertParameters["categoryId"].DefaultValue = ddl.SelectedItem.Value;
            //SqlDataSource1.InsertParameters["categoryName"].DefaultValue = txtCatName.Text;

            //SqlDataSource1.InsertParameters["parentId"].DefaultValue = ddl.SelectedItem.Value;
            //SqlDataSource1.Insert();
           // e.Command.Parameters.Add(param1);
            //e.Command.Parameters.Add(param);
            //SqlDataSource1.Insert();
            e.Command.Parameters["@categoryName"].Value = txtCatName.Text;
            e.Command.Parameters["@parentId"].Value = Convert.ToInt32(ddl.SelectedItem.Value);
            //int istatus=0;
            //if(chkStatus.Checked)
             //   istatus=1;

            //e.Command.Parameters["@status"].Value = istatus;
        }

        

       

        
    }
}
