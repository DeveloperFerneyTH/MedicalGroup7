using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalGroup7.Core.Domain
{
    public class UserMedical
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
    }
}
