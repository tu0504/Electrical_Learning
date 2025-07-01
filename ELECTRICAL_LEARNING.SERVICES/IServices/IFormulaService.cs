using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricalLearning.Repositories.Abstraction;
using ElectricalLearning.Services.Common;
using ElectricalLearning.Services.RequestModel;
using ElectricalLearning.Services.ResponseModel;

namespace ElectricalLearning.Services.IServices
{
    public interface IFormulaService
    {
        Task<Result<PagedResult<FormulaResponse.GetFormulasModel>>> GetFormulas(string? searchTerm, int pageIndex, int pageSize);
        Task<Result<FormulaResponse.GetFormulasModel>> GetById(int id);

        Task<Result> CreateFormula(FormulaRequest.CreateFormulaModel request);
        Task<Result> UpdateFormula(int id, FormulaRequest.UpdateFormulaModel request);
        Task<Result> DeleteFormula(int id);
    }
}
