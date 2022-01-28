using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Repositories
{
    public interface IMedicRepository
    {
        Task<List<Medic>> GetMedics();
        Task<Medic> GetById(int id);
        Task Create(Medic medic);
        Task Update(Medic medic);
        Task Delete(Medic medic);

        Task<IQueryable<Medic>> GetQuery();

    }
}
