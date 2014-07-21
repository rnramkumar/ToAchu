

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Easyway.Admin.AddCategory" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>




    <style type="text/css">
        .tdcss
        {
            color: #FFFFFF;
            font-family: Verdana;
            font-size: medium;
            height: 32px;
        }
         .tablecss
        {
            width: 100%;
            border-style: solid;
            border-width: 1px;
            background-color: #003366;
        }
    </style>
    </head>
<body>
<form id="form1" runat="server">

 <table width='100%' cellpadding='1' cellspacing='1'class='tablecss' ><tr><td>
     <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center"  bgcolor="#FFFFFF">
     <tr><td style="background-color:#000084;font-weight:bold;text-align:center" 
             class="tdcss">Manage Category</td>
     </tr>
     <tr><td>&nbsp;</td>
     </tr>
     <tr><td>  <asp:FormView ID="categoryFormView" runat="server" 
        DataSourceID="SqlDataSource1" DefaultMode="Insert" 
         BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
         CellPadding="2" ForeColor="Black" 
             >
        <FooterStyle BackColor="Tan" />
             
        <InsertItemTemplate>
        <br />
            Category/Sub Category Name:
            <asp:TextBox ID="catNameTextBox" runat="server"  MaxLength="50"
                 Text='<%# Bind("categoryname") %>'   />
&nbsp;<asp:RequiredFieldValidator ID="rfvCatName" runat="server" 
                ControlToValidate="catNameTextBox" ErrorMessage="*" 
                ValidationGroup="InsertValidation"></asp:RequiredFieldValidator>
            <br /><br />
        
            Added Category:<asp:DropDownList ID="ddlCat" runat="server"   
                 AppendDataBoundItems="True">
                <asp:ListItem Value="0">Parent...</asp:ListItem>
            </asp:DropDownList>
         
            <br /><br />
              <%--   <tr><td>Status:</td><td>
                 <asp:CheckBox ID="chkStatus" runat="server" />
               &nbsp;</td></tr> --%>
            
 <br /><br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" ValidationGroup="InsertValidation" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" 
                CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
       
        
       
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    </asp:FormView></td></tr>
     <tr><td>  &nbsp;</td></tr>
     <tr><td>
         <asp:GridView ID="gvCatView" runat="server" AutoGenerateColumns="False" 
         DataSourceID="SqlDataSource1" Width="303px" DataKeyNames="categoryid" 
         BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
         CellPadding="3" GridLines="Vertical" >
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            
            <asp:BoundField DataField="categoryname" HeaderText="Category Name" 
                SortExpression="categoryname" />
            <asp:BoundField DataField="parentid" HeaderText="Parentid" 
                SortExpression="parentid" InsertVisible="False"  ReadOnly="True" />
             <asp:CheckBoxField HeaderText="Status" DataField="status" /> <asp:BoundField DataField="statusname" InsertVisible="false"  ReadOnly="true" />
          
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Gainsboro" />
    </asp:GridView></td></tr>
     </table>
      
     </td></tr></table>
  
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:EasywayConnectionString %>" 
            DeleteCommand="pr_delcategory" 
            InsertCommand="pr_inscategory" 
            SelectCommand="pr_selcategory" 
            UpdateCommand="pr_updcategory" DeleteCommandType="StoredProcedure" 
             InsertCommandType="StoredProcedure" 
             ProviderName="<%$ ConnectionStrings:EasywayConnectionString.ProviderName %>" 
             SelectCommandType="StoredProcedure" 
         UpdateCommandType="StoredProcedure" oninserting="SqlDataSource1_Inserting">
            <DeleteParameters>
                <asp:Parameter Name="categoryId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="categoryId" Type="Int32" />
                <asp:Parameter Name="categoryName" Type="String" />
                <asp:Parameter Name="status" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
               
                <asp:Parameter Name="categoryName" Type="String" />
                <asp:Parameter Name="parentid" Type="Int32" />
                
            </InsertParameters>
        </asp:SqlDataSource>
    &nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
             ConnectionString="<%$ ConnectionStrings:EasywayConnectionString %>" 
             SelectCommand="pr_selcategory" SelectCommandType="StoredProcedure">
         </asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;
    </form>
</body>
</html>

