using System;

namespace MedicalGroup7.Core.Domain
{
    public class MedicalAppointmentVw
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCita { get; set; } = DateTime.Now;
        public int? UserID { get; set; }
        public int MedicalSpID { get; set; }
        public int PlaceID { get; set; }
        public string Especialidad { get; set; }
        public string Clinica { get; set; }
        public string Direccion { get; set; }
    }
}
