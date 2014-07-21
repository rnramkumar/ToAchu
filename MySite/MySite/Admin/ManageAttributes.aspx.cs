using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyWay.Admin
{
    public partial class ManageAttributes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource3_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            TextBox txtAttName = (TextBox)attributeFormView.FindControl("attributenameTextBox");
            TextBox txtAttDesc = (TextBox)attributeFormView.FindControl("attributedescTextBox");
            e.Command.Parameters["@attributeName"].Value = txtAttName.Text;
            e.Command.Parameters["@attributedesc"].Value = txtAttDesc.Text;
            e.Command.Parameters["@typeid"].Value = ddlTypes.SelectedItem.Value;
         
        }
    }
}