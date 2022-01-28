using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.BLL.Interfaces
{
    public interface IPacientManager
    {
        Task<List<Pacient>> ModifyPacient();
        Task<List<Pacient>> GetAllPacienti();
        Task CreatePacient(Pacient pacient);
        Task UpdatePacient(Pacient pacient);
        Task DeletePacient(Pacient pacient);
    }
}
