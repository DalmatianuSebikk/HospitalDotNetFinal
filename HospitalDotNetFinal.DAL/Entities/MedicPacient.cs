using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    public class MedicPacient
    {
        public int Id { get; set; }
        public int MedicId { get; set; }
        public int PacientId { get; set; }

        public virtual Medic Medic { get; set; }
        public virtual Pacient Pacient { get; set; }

    }
}
