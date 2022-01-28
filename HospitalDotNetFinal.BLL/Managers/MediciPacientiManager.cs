using HospitalDotNetFinal.BLL.Interfaces;
using HospitalDotNetFinal.DAL.Entities;
using HospitalDotNetFinal.DAL.Repositories;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.BLL.Managers
{
    public class MediciPacientiManager : IMediciPacientiManager
    {
        private readonly IMediciPacientiRepository _mediciPacientiRepo;

        public MediciPacientiManager(IMediciPacientiRepository mediciPacientiRepo)
        {
            _mediciPacientiRepo = mediciPacientiRepo;
        }

        public async Task CreateMedicPacient(MedicPacient medicPacient)
        {
            await _mediciPacientiRepo.Create(medicPacient);
        }

        public async Task DeleteMedicPacient(MedicPacient medicPacient)
        {
            await _mediciPacientiRepo.Delete(medicPacient);
        }

        public async Task<MedicPacient> GetMedicPacient(int idMedic, int idPacient)
        {
            
            return await _mediciPacientiRepo.GetMediciPacienti(idMedic, idPacient);
        }

        public async Task UpdateMedicPacient(MedicPacient medicPacient)
        {
            await _mediciPacientiRepo.Update(medicPacient);
        }
    }
}
