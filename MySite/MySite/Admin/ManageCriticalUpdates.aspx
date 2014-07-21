<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCriticalUpdates.aspx.cs" Inherits="Easyway.Admin.ManageCriticalUpdates" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Manage Critical Updates</title>
    <script type="text/javascript" language="JavaScript" src="/includes/calendar/calendar_us.js"></script>
    <script type="text/javascript" src="/includes/js/easyway.js"></script>
	<link  rel="stylesheet" href="/includes/calendar/calendar.css" />
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
         <table width='100%' cellpadding='1' cellspacing='1' class='tablecss' ><tr><td>
      <table border="0" cellpadding="0" cellspacing="0" style="text-align:center;width:100%;background-color:#FFFFFF">
     <tr><td style="background-color:#000084 ;font-weight:bold;text-align:center" 
             class="tdcss">Manage Critical Updates</td>
     </tr>
     <tr><td>&nbsp;</td>
     </tr>
     <tr><td>  
         <asp:FormView ID="criticalUpdateFormView" runat="server" 
        DataSourceID="SqlDataSource1" DefaultMode="Insert" 
         BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
         CellPadding="2" ForeColor="Black" DataKeyNames="criticalId">
        <FooterStyle BackColor="Tan" />
       
             
        <InsertItemTemplate>
            criticalMessage:
            <asp:TextBox ID="txtMessage" TextMode="MultiLine" Columns="50" Rows="8" runat="server" onkeydown="limitText(this,'span1','2000');"
                 onkeyup="limitText(this,'span1','2000');" Text='<%# Bind("criticalMessage") %>'  />
              <span id='span1'>0</span>characters used&nbsp;<strong><small>(Max:2000 characters)</small></strong>
                <asp:RequiredFieldValidator id="rfvMessage" Display="Dynamic" 
                                        ControlToValidate="txtMessage" ErrorMessage="*" ValidationGroup="InsertValidation" runat="server"/>
        <br />
            effectiveDate:<asp:TextBox runat="server" id="txtStartDate" Text='<%# Bind("effectiveDate") %>'  />
                                    &nbsp;<asp:RequiredFieldValidator id="rfvStartDate" Display="Dynamic" 
                                        ControlToValidate="txtStartDate" ErrorMessage="*" ValidationGroup="InsertValidation" runat="server"/>
                                        <script language="JavaScript" type="text/javascript">
	new tcal ({
		// form name
		'formname': 'form1',
		// input name
		'controlname': 'criticalUpdateFormView$txtStartDate'
		
	});

	</script>
            <br />
            expiryDate:<asp:TextBox ID="txtExpiryDate" runat="server" Text='<%# Bind("expiryDate") %>' />
            <asp:RequiredFieldValidator id="rfvExpiryDate" Display="Dynamic" ValidationGroup="InsertValidation" 
                                        ControlToValidate="txtExpiryDate" ErrorMessage="*" runat="server"/>
            <br />
            <script language="JavaScript" type="text/javascript">
	new tcal ({
		// form name
		'formname': 'form1',
		// input name
		'controlname': 'criticalUpdateFormView$txtExpiryDate'
		
	});

	</script>
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
         <asp:GridView ID="gvCriticalUpdateView" runat="server" AutoGenerateColumns="False" 
         DataSourceID="SqlDataSource1" Width="303px" DataKeyNames="criticalId" 
         BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
         CellPadding="3" GridLines="Vertical">
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="criticalId" HeaderText="criticalId" 
                SortExpression="criticalId" InsertVisible="False" ReadOnly="True" Visible="false" />
            <asp:BoundField DataField="criticalMessage" HeaderText="Critical Message" 
                SortExpression="criticalMessage" />
            <asp:BoundField DataField="effectiveDate" HeaderText="Effective Date" 
                SortExpression="effectiveDate" ApplyFormatInEditMode="True" 
                DataFormatString="{0:d}"  />
            <asp:BoundField DataField="expiryDate" HeaderText="Expiry Date" 
                SortExpression="expiryDate" ApplyFormatInEditMode="True" 
                DataFormatString="{0:d}" />
          
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
            DeleteCommand="pr_delCriticalUpdate" 
            InsertCommand="pr_insCriticalUpdate" 
            SelectCommand="pr_selCriticalUpdates" 
            UpdateCommand="pr_updCriticalUpdate" 
            DeleteCommandType="StoredProcedure" 
             InsertCommandType="StoredProcedure" 
             ProviderName="<%$ ConnectionStrings:EasywayConnectionString.ProviderName %>" 
             SelectCommandType="StoredProcedure" UpdateCommandType="StoredProcedure">
            <DeleteParameters>
                <asp:Parameter Name="criticalId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="criticalId" Type="Int32" />
                <asp:Parameter Name="criticalMessage" Type="String" />
                <asp:Parameter Name="effectiveDate" Type="String"  />
                <asp:Parameter Name="expiryDate" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="criticalMessage" Type="String" />
                <asp:Parameter Name="effectiveDate" Type="String" />
                <asp:Parameter Name="expiryDate" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    &nbsp;
        
    </form>
</body>
</html>
