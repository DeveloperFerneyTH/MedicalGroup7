using MedicalGroup7.Core.Domain;
using MedicalGroup7.Core.Providers;
using MedicalGroup7.Utils;
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
    public partial class NewAppointmentFrm : Form
    {
        public UserMedical UserMedical { get; set; }
        MedicalAppointmentProvider appointmentProvider;
        MedicalSpecialtyProvider specialtyProvider;
        PlaceProvider placeProvider;

        public NewAppointmentFrm()
        {
            InitializeComponent();
            appointmentProvider = new MedicalAppointmentProvider();
            specialtyProvider = new MedicalSpecialtyProvider();
            placeProvider = new PlaceProvider();
        }

        private void NewAppointmentFrm_Load(object sender, EventArgs e)
        {
            try
            {
                var specialties = specialtyProvider.GetSpecialties();
                var places = placeProvider.GetPlaces();
                ControlsUtils.LoadComboBox(cbSpecialty, specialties.OrderBy(s => s.Name).ToList(), "Name", "ID");
                ControlsUtils.LoadComboBox(cbPlace, places.OrderBy(p => p.Name).ToList(), "Name", "ID");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Houston tenemos un problema... error: {ex.Message}", "Oooops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                MedicalAppointmentVw appointmentVw = new MedicalAppointmentVw()
                {                    
                    Descripcion = txtDescription.Text,
                    MedicalSpID = (int)cbSpecialty.SelectedValue,
                    FechaCita = dtpMedicalDate.Value,
                    PlaceID = (int)cbPlace.SelectedValue,
                    UserID = UserMedical.UserID,
                };

                appointmentProvider.InsertMedicalAppointment(appointmentVw);
                if(MessageBox.Show("Cita medica agendada!!", "Agendada", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Houston tenemos un problema... error: {ex.Message}", "Oooops", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }
    }
}
