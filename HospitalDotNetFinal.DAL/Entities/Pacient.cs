using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    [Resource("Pacienti")]
    public class Pacient : Identifiable<int>
    {
        [Attr]
        public override int Id { get; set; }
        [Attr]
        public string NumePacient { get; set; }
        [Attr]
        public string CNP { get; set; }
        [Attr]
        public string NumarDeTelefon { get; set; }
        [Attr]
        public int? BoalaId { get; set; }
        [Attr]
        public virtual Boala Boala { get; set; }
        [Attr]
        public int? SpitalId { get; set; }
        [HasOne]
        public virtual Spital Spital { get; set; }

        public ICollection<MedicPacient> MediciPacienti;
    }
}
