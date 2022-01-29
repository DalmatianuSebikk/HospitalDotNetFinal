using HospitalDotNetFinal.BLL.Interfaces;
using HospitalDotNetFinal.BLL.Managers;
using HospitalDotNetFinal.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.Controllers.Medici
{
    [Route("api/medici/{medicId}")]
    [ApiController]
    public class MediciPacientiController : ControllerBase
    {
        private readonly IMediciPacientiManager _medicipacientiManager;

        public MediciPacientiController(IMediciPacientiManager medicipacientiManager)
        {
            _medicipacientiManager = medicipacientiManager;
        }


        /*[HttpGet("")]
        public Task<IActionResult> GetMediciPacienti()
        {

        }*/
        [HttpPost("/{pacientId}")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddPacientToMedic([FromRoute] int medicId, [FromQuery] int pacientId)
        {
            MedicPacient medicPacient = new MedicPacient(
                pacientId,
                medicId);
            await _medicipacientiManager.CreateMedicPacient(medicPacient);

            return NoContent();
        }

        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> TransferPacientToMedic([FromRoute] int medicId, [FromQuery] int newMedicId, [FromQuery] int pacientId)
        {
            var medicPacient = await _medicipacientiManager.GetMedicPacient(medicId, pacientId);
            medicPacient.MedicId = newMedicId;
            await _medicipacientiManager.UpdateMedicPacient(medicPacient);

            return NoContent();
        }

        [HttpDelete]
        [Authorize("Admin")]
        public async Task<IActionResult> DeletePacientToMedic([FromRoute] int medicId, [FromQuery] int pacientId)
        {
            var medicPacient = await _medicipacientiManager.GetMedicPacient(medicId, pacientId);
            await _medicipacientiManager.DeleteMedicPacient(medicPacient);

            return NoContent();
        }

    }
}
