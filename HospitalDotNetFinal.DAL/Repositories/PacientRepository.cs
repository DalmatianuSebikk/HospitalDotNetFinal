using HospitalDotNetFinal.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Repositories
{
    public class PacientRepository : IPacientRepository
    {
        private readonly AppDbContext _context;

        public PacientRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Pacient pacient)
        {
            await _context.Pacienti.AddAsync(pacient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var pacient = await _context.Pacienti.FirstOrDefaultAsync(pacient => pacient.Id == id);
            //var mediciPacienti = await _context.MediciPacienti.FirstOrDefaultAsync(mediciPacienti => mediciPacienti.PacientId == id);

            // _context.MediciPacienti.Remove(mediciPacienti);
            _context.Pacienti.Remove(pacient);
            await _context.SaveChangesAsync();
        }

        public async Task<Pacient> GetById(int id)
        {
            var pacient = await _context.Pacienti.Include(pacient => pacient.Boala).FirstOrDefaultAsync(pacient => pacient.Id == id);
            return pacient;
        }

        public async Task<List<Pacient>> GetPacienti()
        {
            var pacienti = await(await GetQuery()).ToListAsync();
            return pacienti;
        }

        public async Task<IQueryable<Pacient>> GetQuery()
        {
            var query = _context.Pacienti.Include(pacient => pacient.Boala).Include(pacient => pacient.Spital).AsQueryable();
            return query;
        }

        public async Task Update(Pacient pacient)
        {
            /*var pacient = await _context.Pacienti.FirstOrDefaultAsync(pacient => pacient.Id == id);*/
            _context.Pacienti.Update(pacient);
            await _context.SaveChangesAsync();
        }
    }
}
