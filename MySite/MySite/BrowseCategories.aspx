<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowseCategories.aspx.cs" Inherits="Easyway.BrowseCategories"  %>

<%@ Register src="usercontrols/ListProducts.ascx" tagname="ListProducts" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Easyway2buy.com - Browse Categories</title>

  	

</head>
<body>
    <form id="form1" runat="server">
   
    <uc1:ListProducts ID="ListProducts1" runat="server" />
   
    </form>
</body>
</html>
