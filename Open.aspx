<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Open.aspx.cs" Inherits="image.Open" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID ="Image1" runat="server" ImageUrl="" Width ="128" Height="128"/>
            <br/>
            <asp:Image ID ="Image2" runat="server" ImageUrl=""/>
            <br/>
            <asp:Label ID="Lable1" runat="server" Text=""/>
        </div>
    </form>
</body>
</html>
