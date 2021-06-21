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
using System.Drawing.Imaging;

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

        private void RealApp_Load_1(object sender, EventArgs e)
        {
            {
                try
                {
                    client = new FireSharp.FirebaseClient(ifc);
                }

                catch
                {
                    MessageBox.Show("No Internet or Connection Problem");
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            open.Title = "select File";

            
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image pdf = new Bitmap(open.FileName);
                pictureBox1.Image = pdf.GetThumbnailImage(350, 200, null, new IntPtr());

                    
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
            byte[] a = ms.GetBuffer();
            string output = Convert.ToBase64String(a);
            var data = new File
            {
                pdf = output
            };
            SetResponse response = await client.SetAsync("Image/", data);
           // File resulut = set.ResultAs<File>();
            MessageBox.Show("Successfully registered!");

        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
