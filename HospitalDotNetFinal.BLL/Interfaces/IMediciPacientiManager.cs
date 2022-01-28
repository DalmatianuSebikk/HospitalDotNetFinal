using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.BLL.Interfaces
{
    public interface IMediciPacientiManager
    {
        Task<MedicPacient> GetMedicPacient(int idMedic, int idPacient);
        Task CreateMedicPacient(MedicPacient medicPacient);
        Task UpdateMedicPacient(MedicPacient medicPacient);
        Task DeleteMedicPacient(MedicPacient medicPacient);
    }
}
