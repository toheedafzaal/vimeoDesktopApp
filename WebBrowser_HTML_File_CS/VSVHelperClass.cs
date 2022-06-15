using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebBrowser_HTML_File_CS
{
    public static class VSVHelperClass
    {
        public static bool checkcredentials(string USERNAME, string PASSWORD)
        {
            //var constring = ConfigurationManager.ConnectionStrings["vimeocs"].ConnectionString;
            //SqlConnection con = new SqlConnection(constring);
            //string uname = USERNAME;
            //string pass = PASSWORD;
            //SqlCommand cmd = new SqlCommand("insert into tblUser values('" + uname + "','" + pass + "')", con);
            //con.Open();
            //int i = cmd.ExecuteNonQuery();

            //con.Close();

            //if (i != 0)
            //{
            //    MessageBox.Show(i + "Data Saved");
            //    return true;
            //}
            //else
            //{
            //    MessageBox.Show("Data is not saved");
            //    return false;
            //}
            string fileName = @"C:\Temp\Vimeo.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            StreamWriter txt = File.CreateText(fileName);
            //StreamWriter txt = new StreamWriter(fileName);
            txt.Write(USERNAME);
            txt.Write("-");
            txt.Write(PASSWORD);
            txt.Close();
            return true;
            //string message = "Successfully Loged In !";
            //string fail = "Invalid Credentials";
            //if (USERNAME == "adeel" && PASSWORD == "adeel123")
            //{
            //    MessageBox.Show(message);
            //    return true;
            //}
            //else
            //{
            //    MessageBox.Show(fail);
            //    return false;
            //}

        }
    }
}
