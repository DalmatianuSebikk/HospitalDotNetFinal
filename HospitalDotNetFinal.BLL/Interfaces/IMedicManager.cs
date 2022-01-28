using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.BLL.Interfaces
{
    public interface IMedicManager
    {
        Task<List<Medic>> ModifyMedic();
        Task<List<Medic>> GetAllMedici();
        Task CreateMedic(Medic medic);
        Task UpdateMedic(Medic medic);
        Task DeleteMedic(Medic medic);
    }
}
