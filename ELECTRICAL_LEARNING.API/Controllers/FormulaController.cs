using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace ElectricalLearning.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FormulaController : Controller
    {
        private readonly IFormulaService _formulaService;

        public FormulaController(IFormulaService formulaService)
        {
            _formulaService = formulaService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetFormulas (string? searchTerm, int pageIndex = 1, int pageSize = 10)
        {
            var result = await _formulaService.GetFormulas(searchTerm, pageIndex, pageSize);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _formulaService.GetById(id);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FormulaRequest.CreateFormulaModel request)
        {
            var result = await _formulaService.CreateFormula(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] FormulaRequest.UpdateFormulaModel formulaRequest)
        {
            var result = await _formulaService.UpdateFormula(id, formulaRequest);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _formulaService.DeleteFormula(id);
            return StatusCode(result.StatusCode, result);
        }        
    }
}
