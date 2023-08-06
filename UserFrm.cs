using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalGroup7
{
    public partial class UserFrm : Form
    {
        public UserMedical UserMedical { get; set; }
        MedicalAppointmentProvider appointmentProvider;

        public UserFrm()
        {
            InitializeComponent();
            appointmentProvider = new MedicalAppointmentProvider();
        }

        private void UserFrm_Load(object sender, EventArgs e)
        {
            lblName.Text = UserMedical.FirtName;
            lblEmail.Text = UserMedical.Email;
            lblFirstName.Text = UserMedical.FirtName;
            lblLastName.Text = UserMedical.LastName;
            LoadMedicals();
        }

        private void LoadMedicals()
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Houston tenemos un problema... error: {ex.Message}", "Oooops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewAppointmentFrm newAppointment = new NewAppointmentFrm();
            newAppointment.UserMedical = UserMedical;
            newAppointment.Show();
        }

        private void LoadData()
        {
            var medicals = appointmentProvider.GetMedicalAppointmentByUserID(UserMedical.UserID);
            dgAppointment.DataSource = medicals.Select(m => new { m.Descripcion, m.FechaCita, m.Especialidad, m.Clinica, m.Direccion}).OrderByDescending(m => m.FechaCita).ToList();
            dgAppointment.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Houston tenemos un problema... error: {ex.Message}", "Oooops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
