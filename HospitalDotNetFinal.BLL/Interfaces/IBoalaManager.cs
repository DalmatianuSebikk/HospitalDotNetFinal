﻿using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.BLL.Interfaces
{
    public interface IBoalaManager
    {
        Task<List<string>> ModifyBoala();
        Task<List<Boala>> GetAllBoli();
        Task CreateBoala (Boala boala);
        Task UpdateBoala (Boala boala);
        Task DeleteBoala (Boala boala);

    }
}
