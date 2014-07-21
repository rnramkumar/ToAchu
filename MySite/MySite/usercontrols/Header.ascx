<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Easyway.usercontrols.Header" %>
 <script type="text/javascript" src="/includes/js/easyway.js"></script>
    	<!-- Add jQuery library -->
	<script type="text/javascript" src="/includes/js/jquery-1.10.1.min.js"></script>
 	<link rel="stylesheet" type="text/css" href="/includes/css/easyway.css" />
  <script src="/includes/js/jquery-1.6.js" type="text/javascript"></script> 
  <link rel="stylesheet" href="/includes/css/overlay.css" type="text/css" />
    <script src="/includes/js/modal.js" type="text/javascript"></script>

<style type="text/css">
    #mmenu ul{
        padding: 0;
        list-style: none;
    }
    #mmenu ul li{
        float: left;
        width: 100px;
        text-align: center;
    }
    #mmenu ul li a{
        display: block;
        padding: 5px 10px;
        color: #000;
        background: yellow;
        text-decoration: none;
    }
    #mmenu ul li a:hover{
        color: #000;
        background: yellow;
    }
    #mmenu ul li ul{
        display: none;
    }
    #mmenu ul li:hover ul{
        display: block; /* display the dropdown */
    }
    .auto-style1
    {
        font-size: xx-large;
    }
</style>

  <table border="0" width="100%">

    <tr><td <span ><span class="auto-style1">Tapovana Organic</span></span><br />
        </td><td colspan="2"><div id="divLogin" runat="server"> </div></td></tr> 
    
    <tr><td colspan="3" align="center">&nbsp;<asp:TextBox ID="txtSearch" runat="server" MaxLength="50" Width="188px"></asp:TextBox>
&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search &gt;&gt;" 
            onclick="btnSearch_Click" />
        </td><td></td></tr>

    </table>
    <input type="hidden" name="hdnSearch" id="hdnSearch" runat="server" />
 
