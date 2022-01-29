using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    [Resource("Orase")]
    public class Oras : Identifiable<int>
    {
        [Attr]
        public override int Id { get; set; }
        [Attr]
        public string NumeOras { get; set; }
        [Attr]
        public int LocuitoriOras { get; set; }
        public int SpitalId { get; set; }
        public virtual Spital Spital { get; set; }
    }
}
