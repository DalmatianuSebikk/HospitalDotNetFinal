using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Repositories
{
    public class MediciPacientiRepository : IMediciPacientiRepository
    {
        private readonly AppDbContext _context;

        public MediciPacientiRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(MedicPacient medicPacient)
        {
            await _context.MediciPacienti.AddAsync(medicPacient);
            /*var medic = await _context.Medici.FindAsync(medicPacient.MedicId);
            medic.MediciPacienti.Add(medicPacient);
            _context.Medici.Update(medic);

            var pacient = await _context.Pacienti.FindAsync(medicPacient.PacientId);
            pacient.MediciPacienti.Add(medicPacient);
            _context.Pacienti.Update(pacient);*/

            await _context.SaveChangesAsync();
        }

        public async Task Delete(MedicPacient medicPacient)
        {
            _context.MediciPacienti.Remove(medicPacient);
            await _context.SaveChangesAsync();

        }

        public async Task<MedicPacient> GetMediciPacienti(int idMedic, int idPacient)
        {
            var medic = _context.MediciPacienti.Where(medicPacient => medicPacient.MedicId == idMedic && medicPacient.PacientId == idPacient).Take(1).First();
            return medic;
        }

        public async Task Update(MedicPacient medicPacient)
        {
            _context.MediciPacienti.Update(medicPacient);
            await _context.SaveChangesAsync();
        }
    }
}
