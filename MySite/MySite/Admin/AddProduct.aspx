<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Easyway.Admin.AddProduct" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Products</title>
    <script type="text/javascript" language="JavaScript" src="../admin/includes/calendar/calendar_us.js"></script>
	<link  rel="stylesheet" href="../admin/includes/calendar/calendar.css" />
	<script type="text/javascript" src="../admin/includes/js/easyway.js"></script>
<script type="text/javascript">
function addFileUploadBox()
{
    if (!document.getElementById || !document.createElement)
        return false;
		
    var uploadArea = document.getElementById ("pnlBox");
	
    if (!uploadArea)
        return;

    var newLine = document.createElement ("br");
    uploadArea.appendChild (newLine);
	
    var newUploadBox = document.createElement ("input");
	
    // Set up the new input for file uploads
    newUploadBox.type = "file";
    newUploadBox.size = "20";
	
    // The new box needs a name and an ID
    if (!addFileUploadBox.lastAssignedId)
        addFileUploadBox.lastAssignedId = 100;
	    
    newUploadBox.setAttribute ("id", "dynamic" + addFileUploadBox.lastAssignedId);
    newUploadBox.setAttribute ("name", "dynamic:" + addFileUploadBox.lastAssignedId);
    uploadArea.appendChild (newUploadBox);
    addFileUploadBox.lastAssignedId++;
}

function toggleOffer(obj)
{
    if(obj.checked)
    {
    
        document.getElementById("divSale").style.display='block';
    }
    else
    {
        document.getElementById("divSale").style.display='none';
        }
}
</script>

    <style type="text/css">
        .auto-style1
        {
            width: 177px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    
    <table width="100%" cellpadding="2" cellspacing="2" border="0">
   <tr><td colspan="2" align="center">Add Product</td></tr>
   <tr><td  colspan="2"><b>General</b></td></tr>
   <tr><td class="auto-style1">Product Name:</td><td><input type="text" name="txtProdName" id="txtProdName" maxlength="100"  runat="server"  />
                <asp:RequiredFieldValidator ID="rfvProdName" runat="server" 
                    ControlToValidate="txtProdName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td></tr>
               <tr><td class="auto-style1">Product Code:</td><td><input type="text" name="txtProdCode" id="txtProdCode" maxlength="25"  runat="server"  />
                  </td></tr>

    <tr><td class="auto-style1">Product Short Desc:</td><td>
    <%-- <textarea id="txtShortDesc" name="txtShortDesc" cols="40" rows="5" runat="server" 
    onkeydown="limitText(this,'span1','250');" onkeyup="limitText(this,'span1','250');">
</textarea>--%><strong></strong>
<cc1:Editor ID="txtShortDesc"  runat="server" Height="100px" width="50%" onkeydown="limitText(this,'span1','250');" onkeyup="limitText(this,'span1','250');" />
<span id='span1'>0</span>characters used&nbsp;<strong><small>(Max:200 characters)<asp:ToolkitScriptManager 
            ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        </small></strong></td></tr>
     <tr><td class="auto-style1">Product Long Desc:</td><td>
         <%-- <textarea id="txtLongDesc" name="txtLongDesc" cols="40" rows="10" runat="server" 
        onkeydown="limitText(this,'span2','500');" onkeyup="limitText(this,'span2','500');"></textarea>--%>
        <cc1:Editor ID="txtLongDesc" runat="server"  Height="100px" width="50%" /><span id='span2'>0</span> characters used&nbsp;<strong><small>(Max:
                            8000 characters)
         </small></strong></td></tr>
     <tr><td class="auto-style1">Status:</td><td>
               <asp:DropDownList ID="ddlStatus" runat="server" Width="200px">
               <asp:ListItem Value="0">--Select--</asp:ListItem>
               <asp:ListItem Value="1">New</asp:ListItem>
               <asp:ListItem Value="2">Deleted</asp:ListItem>
               <asp:ListItem Value="3">Archive</asp:ListItem>
               <asp:ListItem Value="4">Expired</asp:ListItem>
               </asp:DropDownList>
               </td></tr>
     <tr><td class="auto-style1">Category:</td><td>
               <asp:ListBox ID="lstCategory" SelectionMode="Multiple" runat="server" Width="200px">
               </asp:ListBox>
                <asp:RequiredFieldValidator ID="rfvCat" runat="server" 
                    ControlToValidate="lstCategory" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                </td></tr>
     <tr><td class="auto-style1">Brand Name:</td><td>
               <asp:DropDownList ID="ddlBrand" runat="server" Width="200px">
               </asp:DropDownList>
                </td></tr>
     <tr><td colspan="2"><b>Images</b></td></tr>
     <tr><td class="auto-style1">Upload Product Image:</td><td>
               <input id="File1" type="file" runat="server" size="20" /> &nbsp;
               <div id="pnlBox"></div>
               <input id="AddFile" type="button" value="Add file" onclick="addFileUploadBox()" />
                <br />
         
                <div id='divImgView' runat="server"></div> 
               &nbsp;<asp:CustomValidator ID="uploadValidator" runat="server" 
                   ControlToValidate="File1" onservervalidate="uploadValidator_ServerValidate" 
                   ValidateEmptyText="True">*</asp:CustomValidator>
               </td></tr>
     <tr><td class="auto-style1">&nbsp;</td><td>
               &nbsp;</td></tr>
     <tr><td class="auto-style1"><b>Pricing</b></td><td>
               &nbsp;</td></tr>
     <tr><td class="auto-style1">Market Price</td><td>
               <input type="text" name="txtMarketPrice" id="txtMarketPrice" maxlength="5" 
                  runat="server"  />&nbsp; (Price Suggested by manufacturer)</td></tr>
     <tr><td class="auto-style1">Price:</td><td>
               <input type="text" name="txtPrice" id="txtPrice" maxlength="5" 
                  runat="server"  /><asp:RequiredFieldValidator ID="rfvPrice" runat="server" 
                    ControlToValidate="txtPrice" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td></tr>
     <tr><td class="auto-style1">&nbsp;</td><td>
               &nbsp;<input type="checkbox" id="chkSale" name="chkSale" onclick="javascript:toggleOffer(this)" runat="server"/>Product on Sale
                <div id="divSale" style="display:none">
                    <asp:RadioButtonList ID="radSale" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="S">Sale Price</asp:ListItem>
                    <asp:ListItem Value="P">Percent Off</asp:ListItem>
                    </asp:RadioButtonList>            
                          <input type="text" name="txtOffer" id="txtOffer" maxlength="3" 
                    runat="server"  />           
                </div>
                </td></tr>
        <%--  <tr><td>Price Promotion:</td><td>
               <input type="text" name="txtPricePromo" id="txtPricePromo" maxlength="3" 
                  runat="server"  /></td></tr>
     <tr><td>Effective From</td><td>
               <input type="text" name="txtEffective" id="txtEffective" readonly="readonly"
                   
                   runat="server"  /> <script language="JavaScript" type="text/javascript">
                   var effec_date_selected = f_tcalGenerDate(new Date());
	new tcal ({
		// form name
		'formname': 'form1',
		// input name
		'controlname': 'txtEffective'
		
	});

	</script>
               </td></tr>
     <tr><td>Effective To:</td><td>
               <input type="text" name="txtExpiry" id="txtExpiry" readonly="readonly" 
                   runat="server"  />  <script language="JavaScript" type="text/javascript">
                   
                   
	new tcal ({
		// form name
		'formname': 'form1',
		// input name
		'controlname': 'txtExpiry'
		
	});

	</script>
               </td></tr> --%>
     <tr><td class="auto-style1">isHot Flag</td><td>
               <asp:CheckBox ID="chkHot" runat="server" Text="Hot" />&nbsp;<input type="text" name="txtHotText" id="txtHotText" runat="server" maxlength="100" />
               </td></tr>
        <tr>
            <td colspan="2"><b>Attributes</b></td>
        </tr>
     <tr><td class="auto-style1">No.of qty in cart</td><td>
               <input type="text" ID="txtQty" name="txtQty" runat="server" MaxLength="2" style="Width:25px">5</input>
                <asp:RequiredFieldValidator ID="rfvQtyCart" runat="server" 
                    ControlToValidate="txtQty" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="Min 1 and Maximum value should not exceed 25" MaximumValue="25" MinimumValue="1"></asp:RangeValidator>
               </td></tr>
     <tr><td class="auto-style1">Display text</td><td>
               <input type="text" name="txtDisplayText" id="txtDisplayText" runat="server" maxlength="10" style="width: 50px" value="Qty" />
                <asp:RequiredFieldValidator ID="rfvDispText" runat="server" 
                    ControlToValidate="txtDisplayText" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td></tr>
     <tr><td class="auto-style1">&nbsp;</td><td>
               <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
&nbsp;&nbsp;<input type="button" id="btnBack" name="btnBack" title="Back" value="Back" onclick="javascript:history.back();" runat="server" /> </td></tr>
   </table>
   
  <input type="hidden" name="hdnUpdate" id="hdnUpdate" runat="server" />
  <input type="hidden" name="hdnImg" id="hdnImg" runat="server" />
  <input type="hidden" name="hdnFileName" id="hdnFileName" runat="server" />
    </form>
</body>
</html>
