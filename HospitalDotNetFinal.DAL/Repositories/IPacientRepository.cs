using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Repositories
{
    public interface IPacientRepository
    {
        Task<List<Pacient>> GetPacienti();
        Task<Pacient> GetById(int id);
        Task Create(Pacient pacient);
        Task Update(Pacient pacient);
        Task Delete(int id);

        Task<IQueryable<Pacient>> GetQuery();
    }
}
