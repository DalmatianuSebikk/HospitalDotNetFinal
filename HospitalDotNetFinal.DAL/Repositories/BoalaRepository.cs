using HospitalDotNetFinal.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Repositories
{
    
    public class BoalaRepository : IBoalaRepository
    {
        private readonly AppDbContext _context;

        public BoalaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Boala boala)
        {
            await _context.Boli.AddAsync(boala);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Boala boala)
        {
            _context.Boli.Remove(boala);
            await _context.SaveChangesAsync();
        }
        public async Task<IQueryable<Boala>> GetQuery()
        {
            var query = _context.Boli.AsQueryable();
            return query;
        }

        public async Task<List<Boala>> GetAll()
        {
            
            var boli = await (await GetQuery()).ToListAsync(); // ????? (altfel nu mergea)
            return boli;
        }

        public async Task<Boala> GetById(int id)
        {
            var boala = await _context.Boli.FindAsync(id);
            return boala;
        }

        public async Task Update(Boala boala)
        {
            _context.Boli.Update(boala);
            await _context.SaveChangesAsync();
        }
    }
}
