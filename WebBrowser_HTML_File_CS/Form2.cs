using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser_HTML_File_CS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
                if (File.Exists("UGUID")) return;
                File.Create("UGUID");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 vimeohome = new Form1();
            Form2 vimeologin = new Form2();

            var constring = ConfigurationManager.ConnectionStrings["vimeocs"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("select * from tblUser where Username='" + textBox1 + "' and Password='" + textBox2 + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                //MessageBox.Show(i + "Data Found");
                this.Hide();
                vimeohome.Show();
            }
            else
            {
                MessageBox.Show("An error occured ! No Record Found ! Try Again");
            }
        }
    }
}
