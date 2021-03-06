using HospitalDotNetFinal.BLL.Interfaces;
using HospitalDotNetFinal.DAL.Entities;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.Controllers
{
    [Route("api/medici")]
    [ApiController]
    public class MediciController : ControllerBase
    {
        private readonly IMedicManager _medicManager;

        public MediciController(IMedicManager medicManager)
        {
            _medicManager = medicManager;
        }

        /*public MediciController(
            IJsonApiOptions jsonOptions,
            ILoggerFactory loggerFactory,
            IResourceService<Medic, int> resourceService
            *//*IGetAllService<Boala, int> getAllService*//*
        ) : base(jsonOptions, loggerFactory, resourceService)
        {

        }*/

        [HttpGet]
        public async Task<IActionResult> GetMedici()
        {
            var list = await _medicManager.GetAllMedici();

            return Ok(list);
        }

        [HttpPost]
        [Authorize("Admin")]
        public async Task<IActionResult> PostMedic([FromBody] Medic medic)
        {
            if (string.IsNullOrEmpty(medic.NumeMedic) && string.IsNullOrEmpty(medic.NumarDeTelefon))
            {
                return BadRequest("Fie campul NumeMedic, fie campul NumarDeTelefon este null.");
            }

            await _medicManager.CreateMedic(medic);
            return NoContent();
        }

        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateMedic([FromBody] Medic medic)
        {

            await _medicManager.UpdateMedic(medic);
            return Ok(medic);
        }

        [HttpDelete("{id}")]

        [Authorize("Admin")]
        public async Task<IActionResult> DeleteMedic([FromRoute] int id)
        {
            await _medicManager.DeleteMedic(id);
            return NoContent();
        }


    }
}
