<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageType.aspx.cs" Inherits="EasyWay.Admin.ManageType" %>

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
             class="tdcss">Manage Attribute Type</td>
     </tr>
     <tr><td>&nbsp;</td>
     </tr>
     <tr><td>  <asp:FormView ID="categoryFormView" runat="server" 
        DataSourceID="SqlDataSource1" DefaultMode="Insert" 
         BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
         CellPadding="2" ForeColor="Black" DataKeyNames="attributetypeid" >
        <FooterStyle BackColor="Tan" />
             
        <InsertItemTemplate>
            attributetypename:
            <asp:TextBox ID="attributetypenameTextBox" runat="server" Text='<%# Bind("attributetypename") %>' />
            <asp:RequiredFieldValidator ID="rfvattName" runat="server" 
                ControlToValidate="attributetypenameTextBox" ErrorMessage="*" 
                ValidationGroup="InsertValidation"></asp:RequiredFieldValidator>
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" ValidationGroup="InsertValidation" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" 
                CommandName="Cancel" Text="Cancel"  />
        </InsertItemTemplate>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    </asp:FormView></td></tr>
     <tr><td>  &nbsp;</td></tr>
     <tr><td>
         <asp:GridView ID="gvTypeView" runat="server" AutoGenerateColumns="False" 
         DataSourceID="SqlDataSource1" Width="303px" DataKeyNames="attributetypeid" 
         BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
         CellPadding="3" GridLines="Vertical" >
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
              
            <asp:BoundField DataField="attributetypeName" HeaderText="Type Name" />
             <asp:CheckBoxField HeaderText="Status" DataField="status" /> 
            <asp:BoundField DataField="statusname" InsertVisible="false"  ReadOnly="true" />
          
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
            InsertCommand="pr_insattributetype" 
            SelectCommand="pr_selattributetype" 
            UpdateCommand="pr_updattributetype"
           UpdateCommandType="StoredProcedure"
             InsertCommandType="StoredProcedure" 
             SelectCommandType="StoredProcedure" >
            <UpdateParameters>
                <asp:Parameter Name="attributetypeid" Type="Int32" />
                <asp:Parameter Name="attributetypeName" Type="String" />
                <asp:Parameter Name="status" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="attributetypeName" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    &nbsp;&nbsp;
    </form>
</body>
</html>

