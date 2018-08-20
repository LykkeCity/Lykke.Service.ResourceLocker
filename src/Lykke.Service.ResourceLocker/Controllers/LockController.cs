using Common.Log;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Common.Log;
using Lykke.Service.ResourceLocker.Core.Services;

namespace Lykke.Service.ResourceLocker.Controllers
{
    [Route("api/lock")]
    public class LockController : Controller
    {
        private readonly ILog _log;
        public LockController(
            //[NotNull] ILogFactory logFactory,
        IResourceLockService resourceLockService)
        {
            //_log = logFactory.CreateLog(this);
        }

        /// <summary>
        /// Lock resource
        /// </summary>
        /// <param name="request"></param>
        /// <response code="200"></response>
        /// <response code="404"></response>
        /// <response code="501"></response>
        [HttpPost]
        [SwaggerOperation("LockResources")]
        public async Task<IActionResult> LockResource()
        {
            return Ok();
        }
    }
}
