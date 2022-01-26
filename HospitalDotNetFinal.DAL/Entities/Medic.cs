using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    public class Medic
    {
        public int Id { get; set; }
        public string NumeMedic { get; set; }
        public string SpecializareMedic { get; set; }
        public string NumarDeTelefon { get; set; }
        public int SpitalId { get; set; }
        public virtual Spital Spital { get; set; }

        public ICollection<MedicPacient> MediciPacienti;


    }
}
