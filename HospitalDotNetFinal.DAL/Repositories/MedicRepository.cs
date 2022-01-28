using HospitalDotNetFinal.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Repositories
{
    public class MedicRepository : IMedicRepository
    {
        private readonly AppDbContext _context;

        public MedicRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Medic medic)
        {
            await _context.Medici.AddAsync(medic);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Medic medic)
        {
            _context.Medici.Remove(medic);
            await _context.SaveChangesAsync();
        }

        public async Task<Medic> GetById(int id)
        {
            var medic = await _context.Medici.FindAsync(id);
            return medic;
        }

        public async Task<List<Medic>> GetMedics()
        {
            var boli = await(await GetQuery()).ToListAsync();
            return boli;
        }

        public async Task<IQueryable<Medic>> GetQuery()
        {

            /*var query = from m in _context.Medici
                        join mp in _context.MediciPacienti on m.Id equals mp.MedicId
                        join p in _context.Pacienti on  mp.PacientId equals p.Id
                        select new { d, s }*/

            var query = _context.Medici.Include(medic => medic.Spital).Include(medic => medic.MediciPacienti).ThenInclude(mp => mp.Pacient).AsQueryable();
            return query;
        }

        public async Task Update(Medic medic)
        {
            _context.Medici.Update(medic);
            await _context.SaveChangesAsync();
        }
    }
}
