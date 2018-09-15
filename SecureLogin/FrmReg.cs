using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AesSec;

namespace SecureLogin
{
    public partial class FrmReg : Form
    {
        public FrmReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usertxt.Text.Length <3 || passtxt.Text.Length < 3 )
            {
                MessageBox.Show("insert valid data ");
            }
            else
            {
                string dir = usertxt.Text;
                Directory.CreateDirectory(@"db" + dir);

                var Osw = new StreamWriter(@"db" + dir + @"\database.ls");

                string encrypuser = Cryptograph.crypt(usertxt.Text);
                string encryptpass = Cryptograph.crypt(passtxt.Text);

                Osw.WriteLine(encrypuser);
                Osw.WriteLine(encryptpass);
                Osw.Dispose();
                Osw.Close();
               

                MessageBox.Show("User  created",usertxt.Text);

                this.Close();
                this.Dispose();
                Application.Restart();
              //  FrmLogin sd = new FrmLogin();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usertxt.Text = "";
            passtxt.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmReg.ActiveForm.Hide();
            FrmLogin sd = new FrmLogin();
            sd.ShowDialog();
        }
    }
}
