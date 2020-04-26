using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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