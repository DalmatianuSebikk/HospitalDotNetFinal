using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    public class Oras
    {
        public int Id { get; set; }
        public string NumeOras { get; set; }
        public int LocuitoriOras { get; set; }
        public virtual Spital Spital { get; set; }
    }
}
