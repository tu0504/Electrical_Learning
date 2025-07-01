using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace ElectricalLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? searchTerm, int pageIndex = 1, int pageSize = 10)
        {
            var result = await _exerciseService.GetExercises(searchTerm, pageIndex, pageSize);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _exerciseService.GetById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExerciseRequest.CreateExerciseModel model)
        {
            var result = await _exerciseService.CreateExercise(model);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExerciseRequest.UpdateExerciseModel model)
        {
            var result = await _exerciseService.UpdateExercise(id, model);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _exerciseService.DeleteExercise(id);
            return StatusCode(result.StatusCode, result);
        }
    }

}
