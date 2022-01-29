using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Repositories
{
    public interface IBoalaRepository
    {
        Task<List<Boala>> GetAll();
        Task<Boala> GetById(int id);
        Task Create(Boala boala);
        Task Update(Boala boala);
        Task Delete(int id);
        Task<IQueryable<Boala>> GetQuery();

    }
}
