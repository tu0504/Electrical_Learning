using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace ElectricalLearning.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetGrades(string? searchTerm, int pageIndex = 1, int pageSize = 10)
        {
            var result = await _gradeService.GetGrades(searchTerm, pageIndex, pageSize);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _gradeService.GetById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GradeRequest.CreateGradeModel request)
        {
            var result = await _gradeService.CreateGrade(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] GradeRequest.UpdateGradeModel request)
        {
            var result = await _gradeService.UpdateGrade(id, request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _gradeService.DeleteGrade(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
