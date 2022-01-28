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
    [Route("api/[controller]")]
    [ApiController]
    public class OraseController : JsonApiController<Oras>
    {
        public OraseController(
             IJsonApiOptions jsonOptions,
             ILoggerFactory loggerFactory,
             IResourceService<Oras, int> resourceService)
            : base(jsonOptions, loggerFactory, resourceService)
        {

        }
    }
}
