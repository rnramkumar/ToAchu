<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="Easyway.Admin.ManageProducts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Manage Products</title>
    <script type="text/javascript" src="../includes/js/easyway.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
	<script type="text/javascript">
		!window.jQuery && document.write('<script src="../admin/includes/js/jquery-1.4.3.min.js"><\/script>');
	</script>
	<script type="text/javascript" src="../includes/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
	<script type="text/javascript" src="../includes/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
	<link rel="stylesheet" type="text/css" href="../includes/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
 	<link rel="stylesheet" type="text/css" href="../includes/css/fancystyle.css" />
 		
</head>
<body>
    <form id="form1" runat="server">
    <div id="divLoading"></div>
    <div id="divProdList" runat="server">
    
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
		$(document).ready(function() {
			$("a#example1").fancybox(); 
				
			});

		</script>	
			