using HospitalDotNetFinal.DAL.Entities;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
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
    public class MediciController : JsonApiController<Medic>
    {

        public MediciController(
            IJsonApiOptions jsonOptions,
            ILoggerFactory loggerFactory,
            IResourceService<Medic, int> resourceService
            /*IGetAllService<Boala, int> getAllService*/
        ) : base(jsonOptions, loggerFactory, resourceService)
        {

        }
    }
}
