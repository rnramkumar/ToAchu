<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="Easyway.ViewProducts" %>
<%@ Register src="usercontrols/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="usercontrols/Footer.ascx" tagname="Footer" tagprefix="uc2" %>
<%@ Register src="usercontrols/Reviews.ascx" tagname="Reviews" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title>Easy Way 2 Buy</title>
  	
<style>
.jqzoom{

	text-decoration:none;
	float:left;
}
ul#thumblist{display:block;}
ul#thumblist li{float:left;margin-right:2px;list-style:none;}
ul#thumblist li a{display:block;border:1px solid #CCC;}
ul#thumblist li a.zoomThumbActive{
    border:1px solid red;
}
</style>
   
</head>
<body>
 <form name="AddItemToCart" id='AddItemToCart' runat="server">
  <div id="top_header">
    <uc1:Header ID="Header1" runat="server" />
    
      	<script src="/includes/js/jquery.jqzoom-core.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/includes/css/jquery.jqzoom.css" type="text/css" />
    
	
    </div>

 
<br />

 <table cellspacing="10" border="0" style="width:100%">
            <tr>
                <td valign="top" colspan="3" style="text-align:center" >
                

                </td>
                
            </tr>
            <tr>
                <td valign="top" style="width:15%;text-align:left;vertical-align:top">
                 

                    
                  
                </td>
              
                <td valign="top" style="width:70%">
                   
       
                    <div id='divProductView' runat="server"></div>

                    <uc1:Reviews ID="Reviews1" runat="server" />
                  
                </td>
                <td style="width:15%;text-align:right;vertical-align:top">

                </td>
            </tr>
            <tr>
                <td valign="top" colspan="3" style="text-align:center">
                 

                    
                  
                </td>
              
            </tr>
        </table>
        <div id='Footer'><uc2:Footer ID="Footer1" runat="server" />    
</div>


</form>

     </body>
     </html>

<script type="text/javascript">

$(document).ready(function() {
	$('.jqzoom').jqzoom({
            zoomType: 'standard',
            lens:true,
            preloadImages: false,
            alwaysOn:false
        });
	
});


</script>
