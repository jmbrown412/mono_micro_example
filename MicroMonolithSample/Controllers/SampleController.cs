using APIModels;
using Microsoft.AspNetCore.Mvc;
using OrchestrationService;

namespace MicroMonolithSample.Controllers
{
    [Route("api/samples")]
    [ApiController]
    public class SampleController : ControllerBase
    {

        private readonly IOrchestrator _orchestrator;

        public SampleController(IOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        [HttpPost]
        public ActionResult Post(CreateMemberRequest req)
        {
            var createdSeller = _orchestrator.AddMember(req);
            return Ok(createdSeller);
        }
    }
}
