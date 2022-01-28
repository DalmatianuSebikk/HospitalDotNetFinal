using HospitalDotNetFinal.BLL.Interfaces;
using HospitalDotNetFinal.DAL.Entities;
using HospitalDotNetFinal.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.BLL.Managers
{
    public class BoalaManager : IBoalaManager
    {
        private readonly IBoalaRepository _boalaRepo;

        public BoalaManager(IBoalaRepository boalaRepo)
        {
            _boalaRepo = boalaRepo;
        }
        public async Task<List<Boala>> ModifyBoala()
        {
            var boli = await _boalaRepo.GetAll();
            /*var list = new List<string>();

            foreach (var boala in boli)
            {
                list.Add($"Id: {boala.Id}, NumeBoala: {boala.NumeBoala}, Gravitate: {boala.Gravitate}");
            }*/

            
            return boli;
        }

        public async Task CreateBoala(Boala boala)
        {
            await _boalaRepo.Create(boala);
        }

        public async Task DeleteBoala(Boala boala)
        {
            await _boalaRepo.Delete(boala);
        }

        public async Task UpdateBoala(Boala boala)
        {
            await _boalaRepo.Update(boala);
        }

        public async Task<List<Boala>> GetAllBoli()
        {
            return await _boalaRepo.GetAll();
            // daca am nevoie de filtrari, initial le voi face in repository, dupa care le voi implementa si in BoalaManager / IBoalaManager
        }
    }
}
