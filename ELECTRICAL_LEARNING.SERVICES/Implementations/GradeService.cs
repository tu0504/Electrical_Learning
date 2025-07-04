﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectricalLearning.Repositories.Abstraction;
using ElectricalLearning.Repositories.Entities;
using ElectricalLearning.Services.Common;
using ElectricalLearning.Services.IServices;
using ElectricalLearning.Services.RequestModel;
using ElectricalLearning.Services.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace ElectricalLearning.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly IBaseRepository<Grade, int> _gradeRepository;
        public GradeService(IBaseRepository<Grade, int> gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<Result> CreateGrade(GradeRequest.CreateGradeModel request)
        {
            var grade = new Grade
            {
                Name = request.Name,
            };
            await _gradeRepository.Add(grade);
            await _gradeRepository.SaveChangesAsync();

            return Result.Success("Tạo khối mới thành công");
        }

        public async Task<Result> DeleteGrade(int id)
        {
            var grade = await _gradeRepository.GetById(id);
            if (grade == null || grade.IsDeleted)
                return Result.Failure("Khối không tồn tại", 404);
            grade.IsDeleted = true;
            await _gradeRepository.Update(grade);
            await _gradeRepository.SaveChangesAsync();

            return Result.Success("Xóa khối thành công");
        }

        public async Task<Result<GradeResponse.GetGradesModel>> GetById(int id)
        {
            var raw = await _gradeRepository.GetAll()
                .Include(x => x.Chapters)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (raw == null) throw new Exception("Không tìm thấy khối");

            var result = new GradeResponse.GetGradesModel(
                raw.Id,
                raw.Name,
                raw.Chapters.Select(c => new GradeResponse.ChapterModel(
                    c.Id,
                    c.Name,
                    c.GradeId
                )).ToList()
            );

            return Result<GradeResponse.GetGradesModel>.Success(result, "Lấy khối thành công");
        }

        public async Task<Result<PagedResult<GradeResponse.GetGradesModel>>> GetGrades(string? searchTerm, int pageIndex, int pageSize)
        {
            var raw = _gradeRepository.GetAll()
                .Include(x => x.Chapters)
                .AsNoTracking()
                .Where(x => !x.IsDeleted);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var cleanSearchTerm = searchTerm.Trim().ToLower();
                raw = raw.Where(x => x.Name.ToString().Contains(cleanSearchTerm));
            }

            var query = raw.Select(x => new GradeResponse.GetGradesModel(
                x.Id,
                x.Name,
                x.Chapters.Select(c => new GradeResponse.ChapterModel(
                    c.Id,
                    c.Name,
                    c.GradeId
                )).ToList()
            ));

            var pagedResult = await PagedResult<GradeResponse.GetGradesModel>.CreateAsync(query, pageIndex, pageSize);

            return Result<PagedResult<GradeResponse.GetGradesModel>>.Success(pagedResult, "Lấy danh sách khối thành công");
        }

        public async Task<Result> UpdateGrade(int id, GradeRequest.UpdateGradeModel request)
        {
            var grade = await _gradeRepository.GetById(id);
            if (grade == null || grade.IsDeleted)
                return Result.Failure("Khối không tồn tại", 404);

            grade.Name = request.Name;

            await _gradeRepository.Update(grade);
            await _gradeRepository.SaveChangesAsync();

            return Result.Success("Cập nhật khối thành công");
        }
    }
}
