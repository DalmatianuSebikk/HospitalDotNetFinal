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
    public class PacientManager : IPacientManager
    {
        private readonly IPacientRepository _pacientRepo;

        public PacientManager(IPacientRepository pacientRepo)
        {
            _pacientRepo = pacientRepo;
        }

        public async Task CreatePacient(Pacient pacient)
        {
            await _pacientRepo.Create(pacient);
        }

        public async Task DeletePacient(int id)
        {
            await _pacientRepo.Delete(id);
        }

        public async Task<List<Pacient>> GetAllPacienti()
        {
            var pacienti = await _pacientRepo.GetPacienti();

            return pacienti;
        }

        public async Task<Pacient> GetById(int id)
        {
            var pacient = await _pacientRepo.GetById(id);

            return pacient;
        }
        public Task<List<Pacient>> ModifyPacient()
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePacient(Pacient pacient)
        {
            await _pacientRepo.Update(pacient);
        }
    }
}
