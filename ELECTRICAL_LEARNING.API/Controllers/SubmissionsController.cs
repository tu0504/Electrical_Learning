using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace ElectricalLearning.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionsController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        // GET: api/submissions?searchTerm=&pageIndex=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? searchTerm, int pageIndex = 1, int pageSize = 10)
        {
            var result = await _submissionService.GetSubmissions(searchTerm, pageIndex, pageSize);
            return StatusCode(result.StatusCode, result);
        }

        // GET: api/submissions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _submissionService.GetById(id);
            return StatusCode(result.StatusCode, result);
        }

        // POST: api/submissions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubmissionRequest.CreateSubmissionModel model)
        {
            var result = await _submissionService.CreateSubmission(model);
            return StatusCode(result.StatusCode, result);
        }

        // PUT: api/submissions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubmissionRequest.UpdateSubmissionModel model)
        {
            var result = await _submissionService.UpdateSubmission(id, model);
            return StatusCode(result.StatusCode, result);
        }

        // DELETE: api/submissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _submissionService.DeleteSubmission(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
