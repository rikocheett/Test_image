<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="image.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Выберите изображение:"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" Height="20px" style="margin-bottom: 4px" />
            <br/>
            <asp:Label ID="Label2" runat="server" Text="Введите описание:"></asp:Label>
            <asp:TextBox ID="Input1" runat="server"/>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Отправить" Width="100px" onclick="Button1_Click" />
        </div>
    </form>
</body>
</html>
