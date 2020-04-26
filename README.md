# Тестовое задание
ASP.NET
Сделать сайт, состоящий из двух веб страниц (с точки зрения пользователя). 1 страница позволяет открыть изображение с диска компьютера и ввести длинный текст описания изображения. На этой странице есть кнопка «отправить». По нажатию кнопки отправить пользователь перенаправляется на вторую страницу, на которой он видит изображение в двух вариантах: 128х128 пикселей и в оригинальном виде, а также описание изображения.

#### Решал через Web forms:
#### Создал две формы Default и Open
### Разметка Default.aspx:
```
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
```


### Программная часть Default.aspx.cs:
```
using System;
using System.IO;

namespace image
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {



            //Смотрит есть ли файл.
            if (FileUpload1.HasFile)
            {
                //Выбирает место для сохранения файла.
                String savePath = Server.MapPath("~/");
                // Запоминает имя файла.
                String fileName = FileUpload1.FileName;
                //К пути прибавляем имя файла.
                savePath += fileName;
                //Сохраняет изображение и его имя на сервере.
                FileUpload1.SaveAs(savePath);
                String PathFile = Server.MapPath("~/App_Data/fileName.txt");
                File.WriteAllText(PathFile, fileName);
                //Сохроняем в переменную описание.
                String saveText = Request["Input1"];
                //Записываем описание в файл.
                String dataFile = Server.MapPath("~/App_Data/data.txt");
                File.WriteAllText(dataFile, saveText);
                //Переход на страницу вывода картинки
                Server.Transfer("Open.aspx", true);

            }
            //Если файла нет
            else
            {
                Label1.Text = "Вы не выбрали изображение!";
            }

        }
    }
}
```
### Разметка Open.aspx
```
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
```


### Программная часть Open.aspx.cs:
```
using System;
using System.IO;

namespace image
{
    public partial class Open : System.Web.UI.Page
    {
        public string fileName;
        public string dataFile;
        public string description;
        public string imagePath;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Получаем пути файлов с данными
            fileName = Server.MapPath("~/App_data/fileName.txt");
            dataFile = Server.MapPath("~/App_data/data.txt");
            //Читаем данные из файлов и сохраняем
            description = File.ReadAllText(dataFile);
            imagePath = "~/" + File.ReadAllText(fileName);
            //"Ставим" данные на свои места в разметку
            Lable1.Text = description;
            Image1.ImageUrl = imagePath;
            Image2.ImageUrl = imagePath;
        }
    }
}
```
