using HospitalDotNetFinal.BLL.Interfaces;
using HospitalDotNetFinal.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.Controllers
{
    [Route("api/pacienti")]
    [ApiController]
    public class PacientiController : ControllerBase
    {
        private readonly IPacientManager _pacientManager;

        public PacientiController(IPacientManager pacientManager)
        {
            _pacientManager = pacientManager;
        }

        
        [HttpGet]
        /*[Authorize("Admin")]*/
        public async Task<IActionResult> GetPacienti()
        {
            var pacienti = await _pacientManager.GetAllPacienti();
            return Ok(pacienti);
        }

        // pacienti/id [fromRoute] sau vreau pacienti/?id=1 [fromQuery]
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetPacientById([FromRoute] int id)
        {
            var pacient = await _pacientManager.GetById(id);
            return Ok(pacient);
        }

        [HttpPost]

        [Authorize("Admin")]
        public async Task<IActionResult> PostPacient([FromBody] Pacient pacient)
        {
            await _pacientManager.CreatePacient(pacient);

            return NoContent();
        }
        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdatePacient([FromBody] Pacient pacient)
        {
            await _pacientManager.UpdatePacient(pacient);
            return NoContent();
        }
        

        [HttpDelete("{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeletePacient([FromRoute] int id)
        {
            await _pacientManager.DeletePacient(id);
            return NoContent();
        }
    }
}
