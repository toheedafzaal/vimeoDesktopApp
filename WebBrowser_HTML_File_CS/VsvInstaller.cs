using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WebBrowser_HTML_File_CS
{
    [RunInstaller(true)]
    public partial class VsvInstaller : System.Configuration.Install.Installer
    {
        public VsvInstaller()
        {
            InitializeComponent();
        }
        public override void Install(IDictionary stateSaver)
        {
            
            string response = Context.Parameters["USERNAME"];//string text = "adeel/PASSWORD=adeel123";
            char[] delimiterChars = { '/','=' };
            string[] words = response.Split(delimiterChars);
            string username = "";
            string password = "";
            username = words[0];
            password = words[2];
            //MessageBox.Show(response);
            //MessageBox.Show(username);
            //MessageBox.Show(password);


            bool check = VSVHelperClass.checkcredentials(username,password);
            if (!check)
            {
                throw new Exception();
                
            }
            else
            {
                base.Install(stateSaver);
            }
        }
    }
}
