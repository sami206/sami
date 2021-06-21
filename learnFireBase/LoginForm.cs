using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace SawaSupermarket
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "S86rqadDNuJLMKcMe9cflS4d4RQO5O1d3L5qp0TX",
            BasePath = "https://sawa-3df11-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void LoginForm_Load(object sender, EventArgs e)
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

        
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            #region Condition
            if (string.IsNullOrWhiteSpace(UsernameTbox.Text) &&
               string.IsNullOrWhiteSpace(passTbox.Text))
            {
                MessageBox.Show("Please Fill All The Fields");
                return;
            }
            #endregion

            FirebaseResponse res = client.Get(@"Users/" + UsernameTbox.Text);
            MyUser ResUser = res.ResultAs<MyUser>();// database result

            MyUser CurUser = new MyUser() // USER GIVEN INFO
            {
                Username = UsernameTbox.Text,
                Password = passTbox.Text
            };

            if (MyUser.IsEqual(ResUser, CurUser))
            {
                RealApp real = new RealApp();
                real.ShowDialog();
            }

            else
            {
                MyUser.ShowError();
            }
        }

        private void regBtn_Click_1(object sender, EventArgs e)
        {
            new RegistrationForm().Show();
            this.Hide();
            
        }

        private void X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                passTbox.PasswordChar = '\0';

            }
            else
            {
                passTbox.PasswordChar = '•';

            }
        }

        private void LoginBtn_Click_1(object sender, EventArgs e)
        {

            FirebaseResponse res = client.Get(@"Users/" + UsernameTbox.Text);
            MyUser ResUser = res.ResultAs<MyUser>();// database result

            MyUser CurUser = new MyUser() // USER GIVEN INFO
            {
                Username = UsernameTbox.Text,
                Password = passTbox.Text
            };

            if (MyUser.IsEqual(ResUser, CurUser))
            {
                new RealApp().Show();
                this.Hide();
            }

            else
            {
                MyUser.ShowError();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsernameTbox.Text = "";
            passTbox.Text = "";

        }
    }
}
