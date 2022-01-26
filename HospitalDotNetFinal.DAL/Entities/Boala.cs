using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalDotNetFinal.DAL.Entities
{
    [Resource("boli")]
    public class Boala : Identifiable<int>
    {
        [Attr]
        public override int Id { get; set; } // BoalaId -> nu va trebui noi sa i spunem ca este PK ul
        [Attr]
        public string NumeBoala { get; set; }
        [Attr]
        public string Gravitate{ get; set; }
        [HasOne]
        public virtual Pacient Pacient { get; set; }
    }
}
