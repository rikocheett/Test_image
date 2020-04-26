using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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