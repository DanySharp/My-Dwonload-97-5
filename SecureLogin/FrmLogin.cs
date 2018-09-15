using System;
using System.Windows.Forms;
using System.IO;
using AesSec;
namespace SecureLogin
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmReg ds = new FrmReg();
            ds.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            if (usertxt.Text.Length < 3 || passtxt.Text.Length < 3)
            {
                MessageBox.Show("user or pass no valid ");
            }
            
            else
            {
                string dir = usertxt.Text;
                if (!Directory.Exists(@"\db" + dir))
                    MessageBox.Show("user not found","eror");
                else
                {
                    var sr = new StreamReader(@"\db" + dir + @"\database.ls");
                    string ecuser = sr.ReadLine();
                    string ecpass = sr.ReadLine();
                    sr.Close();
                    

                    string decuser = Cryptograph.Decrp(ecuser);
                    string decpass = Cryptograph.Decrp(ecpass);

                    if (decuser == usertxt.Text && decpass == passtxt.Text)
                    {
                        sr.Dispose();
                        this.Hide();
                        MainFrm sd = new MainFrm();
                        sd.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Eroor user or pass!");
                    }
                }

               

            }
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
