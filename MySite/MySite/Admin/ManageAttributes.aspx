<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAttributes.aspx.cs" Inherits="EasyWay.Admin.ManageAttributes" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
        .auto-style2
        {
            width: 126px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        &nbsp; &nbsp;<br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
        
        <asp:Label ID="lblTypes" runat="server" Text="Label">Attribute Types:</asp:Label> </td>
                <td><asp:DropDownList ID="ddlTypes" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="attributetypename" DataValueField="attributetypeid">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    </asp:DropDownList>  <asp:RequiredFieldValidator ID="rfvddlType" runat="server" 
                ControlToValidate="ddlTypes" ErrorMessage="*" 
                ValidationGroup="InsertValidation" InitialValue="0"></asp:RequiredFieldValidator>  

                
                </td>
            </tr>
            <tr>
                <td colspan="2"><b>Add Attributes</b></td>
            </tr>
            <tr>
                <td colspan="2">  <asp:FormView ID="attributeFormView" runat="server" 
        DataSourceID="SqlDataSource3" DefaultMode="Insert" 
         BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
         DataKeyNames="attributeid" CellPadding="2" ForeColor="Black" >
                    
                    <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    
                    <InsertItemTemplate>
                        attributename:
                        <asp:TextBox ID="attributenameTextBox" runat="server" Text='<%# Bind("attributename") %>' />
                        <asp:RequiredFieldValidator ID="rfvAttName" runat="server" 
                ControlToValidate="attributenameTextBox" ErrorMessage="*" 
                ValidationGroup="InsertValidation"></asp:RequiredFieldValidator>
                        <br />
                        attributedesc:
                        <asp:TextBox ID="attributedescTextBox" runat="server" Text='<%# Bind("attributedesc") %>' />
                        <br />
                   <br /><br />
                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" ValidationGroup="InsertValidation" />
                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                                           
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <EditRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    </asp:FormView></td>
            </tr>
            <tr>
                <td colspan="2">  &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">  <b>Manage Attributes</b></td>
            </tr>
            <tr>
                <td colspan="2">  <asp:GridView ID="gvView" runat="server" AutoGenerateColumns="False" 
         DataSourceID="SqlDataSource1" Width="303px" DataKeyNames="attributeid" 
         BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
         CellPadding="3" GridLines="Vertical" >
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            
            <asp:CommandField ShowEditButton="True" />
            
            
            <asp:BoundField DataField="attributename" HeaderText="attributename" SortExpression="attributename"  />
            <asp:BoundField DataField="attributedesc" HeaderText="attributedesc" SortExpression="attributedesc" />
             <asp:CheckBoxField HeaderText="Status" DataField="status" /> 
            <asp:BoundField DataField="statusname" InsertVisible="false"  ReadOnly="true" />
          <asp:BoundField DataField="createddate" InsertVisible="false"  ReadOnly="true"  HeaderText="createddate" SortExpression="createddate" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="Gainsboro" />
    </asp:GridView></td>
            </tr>
            <tr>
                <td colspan="2">    
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EasywayConnectionString %>" 
                            UpdateCommand="pr_updattributes" UpdateCommandType="StoredProcedure" SelectCommand="pr_selattributesbyType" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlTypes" Name="attributetypeid" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="attributeid" Type="Int32" />
                            <asp:Parameter Name="attributeName" Type="String" />
                            <asp:Parameter Name="attributedesc" Type="String" />
                            <asp:Parameter Name="status" Type="Boolean" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:EasywayConnectionString %>" SelectCommand="pr_selattributetype" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                &nbsp;<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:EasywayConnectionString %>" SelectCommand="pr_selattributes" SelectCommandType="StoredProcedure" InsertCommand="pr_insattributes" InsertCommandType="StoredProcedure" OnInserting="SqlDataSource3_Inserting">
                        <InsertParameters>
                            <asp:Parameter Name="attributeName" Type="String" />
                            <asp:Parameter Name="attributedesc" Type="String" />
                            <asp:Parameter Name="typeid" Type="Int32" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
