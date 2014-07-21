<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Easyway._Default" %>
<%@ Register src="usercontrols/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="usercontrols/Footer.ascx" tagname="Footer" tagprefix="uc2" %>
<%@ Register src="usercontrols/BannerAd.ascx" tagname="BannerAd" tagprefix="uc3" %>
<%@ Register src="usercontrols/ListProducts.ascx" tagname="ListProducts" tagprefix="uc4" %>

<%@ Register src="usercontrols/BannerCarousel.ascx" tagname="BannerCarousel" tagprefix="uc5" %>

<%@ Register src="usercontrols/TopMenu.ascx" tagname="TopMenu" tagprefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title>Easy Way 2 Buy</title>
   
</head>
<body>
<form name="home" id="home" runat="server">
  <div id="top_header">
    <uc1:Header ID="Header1" runat="server" />
    </div>
 <uc6:TopMenu ID="TopMenu1" runat="server" />
 
<br />

 <table cellspacing="10" border="0" style="width:100%">
            <tr>
                <td valign="top" colspan="3" style="text-align:center" >
                
                    <uc5:BannerCarousel ID="BannerCarousel1" runat="server" />
                </td>
                
            </tr>
            <tr>
                <td valign="top" style="width:15%;text-align:left;vertical-align:top">
                 
                    <uc3:BannerAd ID="LeftBannerAd" runat="server" />
                    
                  
                </td>
              
                <td valign="top" style="width:70%">
                   
                        <div id="divListProduct" runat="server"> 
                                           <uc4:ListProducts ID="ListProducts1" runat="server" />
                            
                         
                            
                        </div>
                  
                </td>
                <td style="width:15%;text-align:right;vertical-align:top">
                    <uc3:BannerAd ID="RightBannerAd" runat="server" />
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="3" style="text-align:center">
                 
                    <uc3:BannerAd ID="BottomBannerAd" runat="server" />
                    
                  
                </td>
              
            </tr>
        </table>
        <div id='Footer'><uc2:Footer ID="Footer1" runat="server" />    
</div>

 <div id='divCriticalUpdates'></div>

     </form>   
     </body>
     </html>
<script type="text/javascript">
//		$(document).ready(function() {
//			$("a#easyView").fancybox(); 
//			});
			
//			loadCriticalUpdates();

		</script>	
