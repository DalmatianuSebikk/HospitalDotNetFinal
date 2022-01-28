using HospitalDotNetFinal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.BLL.Interfaces
{
    public interface ITokenHelper
    {
        // metode prin care creem access tokenuri
        Task<string> CreateAccessToken(User _User);
    }
}
