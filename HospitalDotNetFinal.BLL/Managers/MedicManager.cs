using HospitalDotNetFinal.BLL.Interfaces;
using HospitalDotNetFinal.DAL.Entities;
using HospitalDotNetFinal.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.BLL.Managers
{
    public class MedicManager : IMedicManager
    {
        private readonly IMedicRepository _medicRepo;

        public MedicManager(IMedicRepository medicRepo)
        {
            _medicRepo = medicRepo;
        }
        public async Task CreateMedic(Medic medic)
        {
            await _medicRepo.Create(medic);
        }

        public async Task DeleteMedic(int id)
        {
            await _medicRepo.Delete(id);
        }

        public async Task<List<Medic>> GetAllMedici()
        {
            var medici = await _medicRepo.GetMedics();

            return medici;
        }

        public Task<List<Medic>> ModifyMedic()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMedic(Medic medic)
        {
            await _medicRepo.Update(medic);
        }
    }
}
