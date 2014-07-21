<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nigol.aspx.cs" Inherits="Easyway.Admin.nigol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 516px;
        }
        .style2
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table cellpadding="0" cellspacing="0" class="style2">
            <tr>
                <td>
                    Header<br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" 
                        BorderStyle="Solid" BorderWidth="1px" 
            DisplayRememberMe="False" Font-Names="Verdana" Font-Size="10pt" LoginButtonText="Submit" 
            onauthenticate="Login1_Authenticate" Width="100%">
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" 
                ForeColor="#FFFFFF" />
        </asp:Login>

                </td>
            </tr>
            <tr>
                <td>
                    Footer</td>
            </tr>
        </table>
       
    
            
    </div>
    </form>
</body>
</html>
