using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SawaSupermarket
{
    public partial class RealApp : Form
    {
       

        public RealApp()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "S86rqadDNuJLMKcMe9cflS4d4RQO5O1d3L5qp0TX",
            BasePath = "https://sawa-3df11-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Title = "select File";

            
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image file = new Bitmap(open.FileName);



            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            byte[] a = ms.GetBuffer();
            string output = Convert.ToBase64String(a);
            var data = new File
            {
                pdf = output
            };
            SetResponse set = await client.SetAsync("Image/" , data);
            File resulut = set.ResultAs<File>();
            MessageBox.Show("Successfully registered!");

        }

        
    }
}
