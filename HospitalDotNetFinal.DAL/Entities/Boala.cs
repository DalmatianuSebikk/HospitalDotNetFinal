using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    public class Boala
    {
        public int Id { get; set; } // BoalaId -> nu va trebui noi sa i spunem ca este PK ul
        public string NumeBoala { get; set; }
        public string Gravitate{ get; set; }
        public virtual Pacient Pacient { get; set; }
    }
}
