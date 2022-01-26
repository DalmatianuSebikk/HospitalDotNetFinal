using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    public class Pacient
    {
        public int Id { get; set; }
        public string NumePacient { get; set; }
        public string CNP { get; set; }
        public string NumarDeTelefon { get; set; }
        public int? BoalaId { get; set; }
        public virtual Boala Boala { get; set; }
        public int? SpitalId { get; set; }
        public virtual Spital Spital { get; set; }

        public ICollection<MedicPacient> MediciPacienti;
    }
}
