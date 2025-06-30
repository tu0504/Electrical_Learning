using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricalLearning.Repositories.Abstraction;
using ElectricalLearning.Services.IServices;
using ElectricalLearning.Repositories.Entities;
using ElectricalLearning.Repositories;
using ElectricalLearning.Services.Common;
using ElectricalLearning.Services.RequestModel;
using ElectricalLearning.Services.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace ElectricalLearning.Services.Implementations
{
    public class FormulaService : IFormulaService
    {
        private readonly IBaseRepository<Formula, int> _formulaRepository;

        public FormulaService(IBaseRepository<Formula, int> formulaRepository)
        {
            _formulaRepository = formulaRepository;
        }

        public async Task<Result> CreateFormula(FormulaRequest.CreateFormulaModel request)
        {
            var formula = new Formula
            {
                Name = request.Name,
                Expression = request.Expression,
                Description = request.Description,
                CircuitModelId = request.CircuitModelId,
            };
            await _formulaRepository.Add(formula);
            await _formulaRepository.SaveChangesAsync();

            return Result.Success("Tạo công thức mới thành công");
        }

        public async Task<Result> DeleteFormula(int id)
        {
            var formula = await _formulaRepository.GetById(id);
            if (formula == null || formula.IsDeleted)
                return Result.Failure("Công thức không tồn tại", 404);
            formula.IsDeleted = true;
            await _formulaRepository.Update(formula);
            await _formulaRepository.SaveChangesAsync();

            return Result.Success("Xóa công thức thành công");
        }

        public async Task<Result<FormulaResponse.GetFormulasModel>> GetById(int id)
        {
            var raw = await _formulaRepository.GetById(id);
            if (raw == null || raw.IsDeleted) throw new Exception("Không tìm thấy công thức");

            var result = new FormulaResponse.GetFormulasModel(
                    raw.Id,
                    raw.Name,
                    raw.Expression,
                    raw.Description,
                    raw.CircuitModelId
                );
            return Result<FormulaResponse.GetFormulasModel>.Success(result, "Lấy công thức thành công");
        }

        public async Task<Result<PagedResult<FormulaResponse.GetFormulasModel>>> GetFormulas(string? searchTerm, int pageIndex, int pageSize)
        {
            var raw = _formulaRepository.GetAll();
            raw = raw.AsNoTracking();
            raw = raw.Where(x => !x.IsDeleted);
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var cleanSearchTerm = searchTerm.Trim().ToLower();
                raw = raw.Where(x => x.Name.ToLower().Contains(cleanSearchTerm));
            }

            var query = raw.Select(x => new FormulaResponse.GetFormulasModel(
                x.Id,
                x.Name,
                x.Expression,
                x.Description,
                x.CircuitModelId
                ));

            var pagedResult = await PagedResult<FormulaResponse.GetFormulasModel>.CreateAsync(query, pageIndex, pageSize);

            var result = Result<PagedResult<FormulaResponse.GetFormulasModel>>.Success(pagedResult, "Lấy danh sách công thức thành công");
            return result;
        }

        public async Task<Result> UpdateFormula(int id, FormulaRequest.UpdateFormulaModel request)
        {
            var formula = await _formulaRepository.GetById(id);
            if (formula == null || formula.IsDeleted)
                return Result.Failure("Công thức không tồn tại", 404);

            formula.Name = request.Name ?? formula.Name;
            formula.Expression = request.Expression;
            formula.Description = request.Description;
            formula.CircuitModelId = request.CircuitModelId;

            await _formulaRepository.Update(formula);
            await _formulaRepository.SaveChangesAsync();

            return Result.Success("Cập nhật công thức thành công");
        }
    }
}
