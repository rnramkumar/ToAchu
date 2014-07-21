<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mainpage.aspx.cs" Inherits="Easyway.Admin.Mainpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<title>EasyWay : : Admin</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
</head>
<frameset rows="90,*" frameborder="NO" border="0" framespacing="0"> 
  <frame name="topFrame" scrolling="NO" noresize src="top.aspx">
  <frameset cols="200,*" frameborder="NO" border="0" framespacing="0" rows="*"> 
    <frame name="leftFrame" scrolling="AUTO" noresize src="leftnav.aspx">
    <frame name="mainFrame" src="right.aspx">
  </frameset>
</frameset>
<noframes>
<body bgcolor="#FFFFFF" text="#000000">
</body>
</noframes> 
</html>
