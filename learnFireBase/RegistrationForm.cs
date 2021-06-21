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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "S86rqadDNuJLMKcMe9cflS4d4RQO5O1d3L5qp0TX",
            BasePath = "https://sawa-3df11-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void RegistrationForm_Load(object sender, EventArgs e)
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

      

        private void regBtn_Click_1(object sender, EventArgs e)
        {
            #region Condition
            if (string.IsNullOrWhiteSpace(UsernameTbox.Text) &&
               string.IsNullOrWhiteSpace(passTbox.Text) &&

               string.IsNullOrWhiteSpace(NicTbox.Text))
            {
                MessageBox.Show("Please Fill All The Fields");
                return;
            }
            #endregion

            MyUser user = new MyUser()
            {
                Username = UsernameTbox.Text,
                Password = passTbox.Text,
                NICno = NicTbox.Text
            };

            SetResponse set = client.Set(@"Users/" + UsernameTbox.Text, user);

            MessageBox.Show("Successfully registered!");
        }

        private void label6_Click(object sender, EventArgs e)
        {
             new LoginForm().Show();
            this.Hide();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                passTbox.PasswordChar = '\0';
                ComPassword.PasswordChar = '\0';
            }
            else
            {
                passTbox.PasswordChar = '•';
                ComPassword.PasswordChar = '•';
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            UsernameTbox.Text = "";
            passTbox.Text = "";
            ComPassword.Text = "";
            NicTbox.Text = "";
        }
    }
}
