using HospitalDotNetFinal.BLL.Interfaces;
using HospitalDotNetFinal.DAL;
using HospitalDotNetFinal.DAL.Entities;
using HospitalDotNetFinal.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Configuration;
using Microsoft.Extensions.Logging;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Authorization;

namespace HospitalDotNetFinal.Controllers
{
    [Route("api/boli/")]
    [ApiController]
    public class BoliController : ControllerBase /*JsonApiController<Boala>*/
    {
        /*private readonly AppDbContext _context; // baza de date adusa in proiectul nostru, clasa reprezentativa*/
        private readonly IBoalaRepository _boalaRepo;
        private readonly IBoalaManager _boalaManager;
        public BoliController(
            IBoalaRepository boalaRepo, 
            IBoalaManager boalaManager
            /* IJsonApiOptions jsonOptions,
             ILoggerFactory loggerFactory,
             IResourceService<Boala, int> resourceService*/
            /*IGetAllService<Boala, int> getAllService*/
            ) /*: base(jsonOptions, loggerFactory, resourceService)*/
        {
            _boalaRepo = boalaRepo;
            _boalaManager = boalaManager;
        }

        [HttpPost] // ca sa fie RESTful
        [Authorize("Admin")]
        public async Task<IActionResult> AddBoala([FromBody] Boala boala)
        {
            if (string.IsNullOrEmpty(boala.Gravitate) && string.IsNullOrEmpty(boala.NumeBoala))
            {
                return BadRequest("Fie campul Gravitate, fie campul NumeBoala este null.");
            }

            /*await _context.Boli.AddAsync(boala);
            await _context.SaveChangesAsync();*/

            await _boalaManager.CreateBoala(boala);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetModify()
        {
            var list = await _boalaManager.ModifyBoala();
            return Ok(list);
        }

        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateBoli([FromBody] Boala boala)
        {
            await _boalaManager.UpdateBoala(boala);

            return Ok(boala);
        }

        [HttpDelete("{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteBoala([FromRoute] int id)
        {
            await _boalaManager.DeleteBoala(id);

            return NoContent();
        }

        /*[HttpPost]
        public async Task<IActionResult> addBoala([FromBody] Boala boala)
        {
            // apelez boalaManager
            try
            {
                await _boalaManager.CreateBoala(boala);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest($"A aparut o eroare.: {ex}");
            }
        }*/
    }

    
}
