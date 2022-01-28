using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    [Resource("spitale")]
    public class Spital : Identifiable<int>
    {
        [Attr]
        public override int Id { get; set; }
        [Attr]
        public string NumeSpital { get; set; }
        [Attr]
        public int? OrasId { get; set; }
        [HasOne]
        public virtual Oras Oras { get; set; }
        public ICollection<Medic> Medici { get; set; }
        public ICollection<Pacient> Pacienti { get; set; }
        
    }
}
