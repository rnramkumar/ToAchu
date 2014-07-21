<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CboStatus.ascx.cs" Inherits="EasyWay.Admin.CboStatus" EnableViewState="true" %>

<div>


    <asp:DropDownList ID="ddlStatus" runat="server" >
    </asp:DropDownList><asp:RequiredFieldValidator ID="rfvddlStatus" runat="server" ErrorMessage="*" ControlToValidate="ddlStatus" InitialValue="0"></asp:RequiredFieldValidator>


</div>