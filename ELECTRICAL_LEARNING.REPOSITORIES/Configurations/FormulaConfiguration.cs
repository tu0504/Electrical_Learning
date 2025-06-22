using ElectricalLearning.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalLearning.Repositories.Configurations
{
    public class FormulaConfiguration : IEntityTypeConfiguration<Formula>
    {
        public void Configure(EntityTypeBuilder<Formula> builder)
        {
            List<Formula> formulas = new List<Formula>
            {
                new Formula
                {
                    Id = 1,
                    Name = "Định luật Ôm",
                    Expression = "I = U / R",
                    Description = "Cường độ dòng điện chạy qua dây dẫn tỉ lệ thuận với hiệu điện thế đặt vào hai đầu dây và tỉ lệ nghịch với điện trở của dây.",
                    CircuitModelId = 1
                }
            };

            builder.HasData(formulas);
        }
    }
}
