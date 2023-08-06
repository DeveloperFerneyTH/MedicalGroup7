using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Providers;
using System;
using System.Windows.Forms;

namespace MedicalGroup7
{
    public partial class LoginFrm : Form
    {
        UserProvider provider;
        public LoginFrm()
        {
            InitializeComponent();
            provider = new UserProvider();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Length == 0 || txtPassword.Text.Length == 0)
                {
                    lblMsg.Text = "Oye por fa llena los campos";
                }
                else
                {
                    UserMedical userMedical = provider.Login(txtEmail.Text, txtPassword.Text);
                    if (userMedical == null)
                    {
                        lblMsg.Text = "Datos erroneos, quizas debes se te fue un dedo mal";
                    }
                    else
                    {                        
                        UserFrm userFrm = new UserFrm();
                        userFrm.UserMedical = userMedical;
                        userFrm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Houston tenemos un problema... error: {ex.Message}", "Oooops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
