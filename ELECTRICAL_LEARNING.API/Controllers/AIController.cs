using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace ElectricalLearning.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly IAIService _aiService;

        public AIController(IAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("analyze-circuit")]
        public async Task<IActionResult> AnalyzeCircuit([FromBody] CircuitModelRequest.CircuitTextRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Description))
                return BadRequest("Description cannot be empty.");

            var result = await _aiService.GetCircuitJsonFromDescriptionAsync(request.Description);

            // Format JSON dễ đọc
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(result);
            var formattedJson = JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return Content(formattedJson, "application/json");
        }
    }
}
