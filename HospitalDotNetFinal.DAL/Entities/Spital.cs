using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    public class Spital
    {
        public int Id { get; set; }
        public string NumeSpital { get; set; }
        public int? OrasId { get; set; }
        public virtual Oras Oras { get; set; }
        public ICollection<Medic> Medici { get; set; }
        public ICollection<Pacient> Pacienti { get; set; }
        
    }
}
