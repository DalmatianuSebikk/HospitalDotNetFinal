using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Entities
{
    public class Medic : Identifiable<int>
    {
        [Attr]
        public override int Id { get; set; }
        [Attr]
        public string NumeMedic { get; set; }
        [Attr]
        public string SpecializareMedic { get; set; }
        [Attr]
        public string NumarDeTelefon { get; set; }
        [Attr]
        public int SpitalId { get; set; }
        [HasOne]
        public virtual Spital Spital { get; set; }

        /*[HasManyThrough(nameof(MedicPacient))] // ma duce automat prin tabelul asociativ 
        public ICollection<Pacient> Pacienti { get; set; }*/
        public ICollection<MedicPacient> MediciPacienti { get; set; }


    }
}
