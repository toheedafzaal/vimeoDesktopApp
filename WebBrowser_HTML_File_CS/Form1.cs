using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Configuration;
using AltoHttp;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace WebBrowser_HTML_File_CS
{
    [ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //getVideoIds();

            //var videoids = getVideoIds();//ids[0]
            //object [] vids = { "590305554", "36319428", "95212995", "67423133", "131484417" };
            //List<string> vids = videoids.ConvertAll<string>(x => x.ToString());
            //UpdateVersion();
            //login();
           
            this.webBrowser1.ObjectForScripting = this;
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("WebBrowser_HTML_File_CS.HTML.htm"));
            //webBrowser1.Document.InvokeScript("getids");
            webBrowser1.DocumentText = reader.ReadToEnd();

        }

        public void login()
        {
            string response = "";
            string fileName = @"C:\Temp\Vimeo.txt";
            using (StreamReader sr = File.OpenText(fileName))
            {
                response = sr.ReadLine();
            }
            //MessageBox.Show(response);
            char[] delimiterChars = { '-' };
            //string text = "adeel-adeel123";
            string[] words = response.Split(delimiterChars);
            string username = words[0];
            string password = words[1];
            var constring = ConfigurationManager.ConnectionStrings["vimeocs"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            //SqlCommand cmd = new SqlCommand("insert into tblUser values('" + username + "','" + password + "')", con);
            con.Open();
            //int i = cmd.ExecuteNonQuery();

            //login
            SqlCommand cmd = new SqlCommand("select * from tblUser where Username='" + username + "' and Password='" + password + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                //MessageBox.Show("You are Successfully Logged In.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dr.Close();
                cmd = new SqlCommand("insert into tblUser values('" + username + "','" + password + "')", con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Acount is Creadted ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

      
        public string getVideoIds()
        {
            //var constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbVimeo;User ID=sa;Password=sa";
            var constring = ConfigurationManager.ConnectionStrings["vimeocs"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand selectvideoids = new SqlCommand("Select VideoId from tblVideos", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader selectedVids = selectvideoids.ExecuteReader();
            dt.Load(selectedVids);
            con.Close();
            dataGridView1.DataSource = dt;
            var ids = new List<int>();
            //var ids = new object();
            foreach (DataRow row in dt.Rows)
            {
                ids.Add(Convert.ToInt32(row["VideoId"]));
            }
            List<string> videoids = ids.ConvertAll<string>(x => x.ToString());
            //String.Join(", ", videoids);
            var idssss = String.Join(", ", videoids);
            //Console.WriteLine(String.Join(", ", videoids));
            //var videoids = dt.Rows;
            //string[] videoids = new string[] { "590305554", "36319428", "95212995", "67423133", "131484417" };
            //int[] videoids = { 590305554, 36319428, 95212995, 67423133, 131484417 };
            //string test = "1323";
            return idssss;
        }

        //HttpDownloader httpDownloader;
        //public void UpdateVersion()
        //{
        //    ////https://drive.google.com/uc?export=download&id=1Q7MB6smDEFd-PzpqK-3cC2_fAZc4yaXF
        //    /////https://drive.google.com/file/d/1DPzYfNO-ug5eh7SKuXtbDVogqkCGTZpq/view?usp=sharing
        //    ////https://drive.google.com/file/d/1DPzYfNO-ug5eh7SKuXtbDVogqkCGTZpq/view?usp=sharing
        //    /////https://docs.google.com/document/d/19nr8pzQvXsWPDGbYiHoXJAqWcCRrNhRGnO0HRi_dNtY/edit?usp=sharing
        //    ///https://docs.google.com/document/d/132QlgmDbNVpQL5mMseRoO3PPiS8Ah8Kx/edit?usp=sharing&ouid=102542924182281619636&rtpof=true&sd=true
        //    string fileName = @"C:\Temp\VimeoUpdatedVersionn.docx";
        //    if (File.Exists(fileName))
        //    {
        //        File.Delete(fileName);
        //    }
        //    var url = "https://drive.google.com/uc?export=download&id=132QlgmDbNVpQL5mMseRoO3PPiS8Ah8Kx";
        //    //https://drive.google.com/file/d/1YKYGiO_83-9Tdh6N1ytUFf1daGDl_zFM/view?usp=sharing
            
        //    WebClient mywebClient = new WebClient();
        //    mywebClient.DownloadFile(url, fileName);
        //    Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
        //    object miss = System.Reflection.Missing.Value;
        //    object path = @"C:\Temp\VimeoUpdatedVersionn.docx";
        //    object readOnly = true;
        //    Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss,
        //                ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
        //    string totaltext = "";      //the whole document
        //    for (int i = 0; i < docs.Paragraphs.Count; i++)
        //    {
        //        //Determine the beginning of an entire paragraph and intercept the table name
        //        //Get the column name
        //        //......
        //        totaltext += docs.Paragraphs[i + 1].Range.Text.ToString();
        //    }
        //    docs.Close();
        //    word.Quit();
        //    //MessageBox.Show(totaltext);
        //    if (totaltext != null)
        //    {
                
        //        MessageBox.Show("A new Version Of Vimeo Vsv is Available.Press Ok To Update The Application.", "VimeoVSV Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        var srtupurl = "https://drive.google.com/uc?export=download&id=1u4jfX_LeSNLnAF9HXxlYLhwJTTeJajij";
        //        string fileNamee = @"C:\Temp\Setup.msi";
        //        WebClient mywebClientt = new WebClient();
        //        mywebClientt.DownloadFile(srtupurl, fileNamee);
        //    }
            
        //}
    }
}
