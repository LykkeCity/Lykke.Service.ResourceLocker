using Common.Log;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Common.Log;
using Lykke.Service.ResourceLocker.Core.Services;
using System;
using Lykke.Service.ResourceLocker.Core.Domain;

namespace Lykke.Service.ResourceLocker.Controllers
{
    [Route("api/lock")]
    public class LockController : Controller
    {
        private readonly ILog _log;
        private readonly IResourceLockService _resourceLockService;
        public LockController(
            [NotNull] ILogFactory logFactory,
            [NotNull] IResourceLockService resourceLockService)
        {
            _log = logFactory.CreateLog(this);
            _resourceLockService = resourceLockService;
        }

        /// <summary>
        /// Lock resource
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("lockresource")]
        [SwaggerOperation("LockResource")]
        public async Task<IActionResult> LockResource([FromBody] LockedResourceRequest request)
        {
            try
            {
                return Ok(await _resourceLockService.Block(request));
            }
            catch(Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Release resource
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("releaseresource")]
        [SwaggerOperation("ReleaseResource")]
        public async Task<IActionResult> ReleaseResource([FromBody] ReleaseResourceRequest request)
        {
            try
            {
                return Ok(await _resourceLockService.Release(request));
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }
    }
}
