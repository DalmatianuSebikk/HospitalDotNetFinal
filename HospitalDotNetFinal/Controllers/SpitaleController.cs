using HospitalDotNetFinal.DAL.Entities;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpitaleController : JsonApiController<Spital>
    {
        private IAuthenticationService _authService;

        [ActivatorUtilitiesConstructor]
        public SpitaleController(
            IAuthenticationService authService,
             IJsonApiOptions jsonOptions,
             ILoggerFactory loggerFactory,
             IResourceService<Spital, int> resourceService)
            : base(jsonOptions, loggerFactory, resourceService)
        {
            _authService = authService;
        }

        
        /*[HttpGet("/{id}")]
        [Authorize("Admin")]
        public override Task<IActionResult> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            return base.GetAsync(id, cancellationToken);
        }
        
        [HttpGet]
        [Authorize("Admin")]
        public override Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            return base.GetAsync(cancellationToken);
        }*/

    }
}
