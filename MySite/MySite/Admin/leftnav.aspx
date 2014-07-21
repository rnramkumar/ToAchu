<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leftnav.aspx.cs" Inherits="Easyway.Admin.leftnav" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            background-color: #003366;
            font-family:Verdana;
            color:#ffffff;
            font-size:small;
            font-weight:bold;
        }
        .style2
        {
            font-family: Verdana;
            font-size: small;
        }
        .style3
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
  
    </form>
    <table cellpadding="1" cellspacing="1" class="style3">
        <tr>
            <td>
  
<table border="0" cellspacing="2" cellpadding="2" style="text-align:center;background-color:#FFFFFF;width:100%"  >
  <tr> 
    <td class="style1" > 
        Category </td>
  </tr>
  <tr> 
    <td class="style2" > <a href="AddCategory.aspx" target="mainFrame">
        Manage Category</a></td>
  </tr>
    <tr> 
    <td class="style1" > 
        Attribute Type / Data </td>
  </tr>
  <tr> 
    <td class="style2" > <a href="ManageType.aspx" target="mainFrame">
        Manage Type</a></td>
  </tr>
    <tr> 
    <td class="style2" > <a href="ManageAttributes.aspx" target="mainFrame">
        Manage Data</a></td>
  </tr>
  <tr> 
    <td class="style1">Products</td>
  </tr>
  <tr> 
    <td class="style2"><a href="AddProduct.aspx" target="mainFrame">Add Product</a></td>
  </tr>
  <tr> 
    <td class="style2"><a href="ManageProducts.aspx" target="mainFrame">Manage Products</a></td>
  </tr>
      <tr> 
    <td class="style1">Critical Updates</td>
  </tr>
  <tr> 
    <td class="style2"><a href="ManageCriticalUpdates.aspx" target="mainFrame">Manage Critical Updates</a></td>
  </tr>

   <tr> 
    <td class="style1">Banner Management</td>
  </tr>
    <tr> 
    <td class="style2"><a href="ManageBanners.aspx" target="mainFrame">Add Banner</a></td>
  </tr>
   <tr> 
    <td class="style2"><a href="ViewBanners.aspx" target="mainFrame">View Banners</a></td>
  </tr>
   <tr> 
    <td class="style1">Customer Management</td>
  </tr>
   <tr> 
    <td class="style2"><a href="ManageCustomers.aspx" target="mainFrame"> Manage Customers</a></td>
  </tr>
</table>

            </td>
        </tr>
    </table>
</body>
</html>
