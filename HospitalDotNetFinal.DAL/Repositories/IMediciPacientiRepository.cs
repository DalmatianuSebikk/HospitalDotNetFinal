using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Repositories
{
    public interface IMediciPacientiRepository
    {
        Task<MedicPacient> GetMediciPacienti(int idMedic, int idPacient);
        Task Create(MedicPacient medicPacient);
        Task Update(MedicPacient medicPacient);
        Task Delete(MedicPacient medicPacient);

    }
}
