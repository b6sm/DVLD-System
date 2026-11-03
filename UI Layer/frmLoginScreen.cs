using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Guna.UI2.WinForms;
using Busnise_Layer;
using System.Security.Cryptography;


namespace My_DVLD
{
    public partial class frmLoginScreen : frmBaseForm
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }
        byte Trials = 0;
        ClsUserContent _User;
        private bool _FindUser()
        {
            _User = ClsUserContent.GetUserDataByUsernameAndPassword(tbxUsername.Text, tbxPassword.Text);
            if(_User!=null)
            {
                string filePath = Path.Combine(Application.UserAppDataPath, "remember.txt");
                string TrialsFilePath = Path.Combine(Application.UserAppDataPath, "Trials.txt");
                File.Delete(TrialsFilePath);
                if (chkRememberMe.Checked)
                {
                    string encryptedPass = ClsGlobal.EncryptData(tbxPassword.Text);
                    string[] Credentials = { tbxUsername.Text, encryptedPass };
                    File.WriteAllLines(filePath, Credentials);
                    
                }
                else
                {
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                return true;
            }
            else
            {
                

                string filePath = Path.Combine(Application.UserAppDataPath, "remember.txt");
                if (File.Exists(filePath)) File.Delete(filePath);
                return false;
            }
        }

        private bool _HasTrials()
        {
            bool Result = false;
            string TrialsFilePath = Path.Combine(Application.UserAppDataPath, "Trials.txt");
            string[] Items = new string[2];
            Trials++;
            Items[0] = Trials.ToString("0");
            if (Trials < 3)
            {
                
                Items[1] = DateTime.Now.ToString();
                Result = true;
            }
            else
            {

                Items[1] = DateTime.Now.AddSeconds(15).ToString();
                Counter = 15;
                lbTime.Text = Counter.ToString("0")+" S";
                timer1.Start();
                lbTime.Visible = true;
                lbTrialMessage.Visible = true;
                tbxPassword.Enabled = false;
                tbxUsername.Enabled = false;
                btnLogIn.Enabled = false;
                chkRememberMe.Enabled = false;
                Result = false;

            }
            File.WriteAllLines(TrialsFilePath, Items);
            return Result;
        }

        private void _LogIn()
        {
            if (!_FindUser())
            {
                
                MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(!_HasTrials())
                {

                }
                return;
            }

            if (_User.IsActive == false)
            {
                string filePath = Path.Combine(Application.UserAppDataPath, "remember.txt");
                if (File.Exists(filePath)) File.Delete(filePath);
                MessageBox.Show("Your account is currently inactive. Please contact the system administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClsGlobal.CurrentUser = _User;
            Form frm = new Form1();
            this.Visible = false;
            if (frm.ShowDialog() != DialogResult.OK)
            {
                this.Close();
                return;
            }
            this.Visible = true;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            _LogIn();            
        }

        private void _TooglePasswordVisibility(Guna2TextBox textBox)
        {
            if (char.IsWhiteSpace(textBox.PasswordChar) || textBox.PasswordChar == '\0')
            {
                textBox.PasswordChar = '●';
                textBox.IconRight = Properties.Resources.icons8_closed_eye_24;

            }
            else
            {
                textBox.PasswordChar = '\0';
                textBox.IconRight = Properties.Resources.icons8_eye_24;

            }
        }


        private void tbxPassword_IconRightClick(object sender, EventArgs e)
        {
            _TooglePasswordVisibility((Guna2TextBox)sender);
        }

        private void _LoadLastSavedLogin()
        {
            string RememberMeFilePath = Path.Combine(Application.UserAppDataPath, "remember.txt");
            if (File.Exists(RememberMeFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(RememberMeFilePath);

                    if (lines.Length >= 2)
                    {
                        tbxUsername.Text = lines[0];
                        tbxPassword.Text = ClsGlobal.DecryptData(lines[1]);
                        chkRememberMe.Checked = true;
                    }
                }
                catch
                {
                    File.Delete(RememberMeFilePath);
                }
            }
        }

        private  void _LoadTrails()
        {
            string TrialsFilePath = Path.Combine(Application.UserAppDataPath, "Trials.txt");
            if (File.Exists(TrialsFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(TrialsFilePath);

                    if (lines.Length >= 2)
                    {
                        if (DateTime.TryParse(lines[1], out DateTime Dateresult))
                        {
                            if(Dateresult>DateTime.Now)
                            {
                                Counter = Convert.ToByte(Dateresult.Subtract(DateTime.Now).Seconds);
                                timer1.Start();
                                lbTime.Text = Counter.ToString("0") + " S";
                                
                                lbTime.Visible = true;
                                lbTrialMessage.Visible = true;
                                
                                //Counter = Convert.ToByte(DateTime.Now-Dateresult);
                            }
                            else
                            {
                                File.Delete(TrialsFilePath);
                                return;
                            }
                        }

                        if (byte.TryParse(lines[0],out byte result)&&result>=3)
                        {
                            Trials = result;
                            tbxPassword.Enabled = false;
                            tbxUsername.Enabled = false;
                            btnLogIn.Enabled = false;
                            chkRememberMe.Enabled = false;

                        }
                        
                        
                       
                    }
                }
                catch
                {
                    File.Delete(TrialsFilePath);
                }
            }
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            _LoadLastSavedLogin();
            _LoadTrails();
            tbxUsername.Select();

        }

        private void tbxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                e.SuppressKeyPress = true;
                tbxPassword.Select();
            }
        }


        private void tbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _LogIn();
            }
        }
        byte Counter = 15;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string TrialsFilePath = Path.Combine(Application.UserAppDataPath, "Trials.txt");

            if (Counter==0)
            {
                timer1.Stop();
                btnLogIn.Enabled = true;
                lbTrialMessage.Visible = false;
                lbTime.Visible = false;
                tbxPassword.Enabled = true;
                tbxUsername.Enabled = true;
                chkRememberMe.Enabled = true;

                Trials = 0;
                File.Delete(TrialsFilePath);
                return;
            }
            lbTime.Text = Counter.ToString("0") + " S";
            Counter--;

        }
    }
}
