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
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            List<Chapter> chapters = new List<Chapter>() {
                new Chapter { Id = 1, Name = "Cơ học", GradeId = 1 },
                new Chapter { Id = 2, Name = "Nhiệt học", GradeId = 1 },
                new Chapter { Id = 3, Name = "Quang học", GradeId = 2 },
                new Chapter { Id = 4, Name = "Âm học", GradeId = 2 },
                new Chapter { Id = 5, Name = "Điện học", GradeId = 2 },
                new Chapter { Id = 6, Name = "Cơ học", GradeId = 3 },
                new Chapter { Id = 7, Name = "Nhiệt học", GradeId = 3 },
                new Chapter { Id = 8, Name = "Điện học", GradeId = 4 },
                new Chapter { Id = 9, Name = "Điện từ học", GradeId = 4 },
                new Chapter { Id = 10, Name = "Quang học", GradeId = 4 },
                new Chapter { Id = 11, Name = "Sự bảo toàn và chuyển hóa năng lượng", GradeId = 4 },
                new Chapter { Id = 12, Name = "Cơ học", GradeId = 5 },
                new Chapter { Id = 13, Name = "Nhiệt học", GradeId = 5 },
                new Chapter { Id = 14, Name = "Điện tích. Điện trường", GradeId = 6 },
                new Chapter { Id = 15, Name = "Dòng điện không đổi", GradeId = 6 },
                new Chapter { Id = 16, Name = "Dòng điện trong các môi trường", GradeId = 6 },
                new Chapter { Id = 17, Name = "Từ trường", GradeId = 6 },
                new Chapter { Id = 18, Name = "Cảm ứng điện từ", GradeId = 6 },
                new Chapter { Id = 19, Name = "Quang học", GradeId = 6 },
                new Chapter { Id = 20, Name = "Dao động cơ", GradeId = 7 },
                new Chapter { Id = 21, Name = "Sóng cơ và sóng âm", GradeId = 7 },
                new Chapter { Id = 22, Name = "Dòng điện xoay chiều", GradeId = 7 },
                new Chapter { Id = 23, Name = "Dao động và sóng điện từ", GradeId = 7 },
                new Chapter { Id = 24, Name = "Sóng ánh sáng", GradeId = 7 },
                new Chapter { Id = 25, Name = "Lượng từ ánh sáng", GradeId = 7 },
                new Chapter { Id = 26, Name = "Hạt nhân nguyên tử", GradeId = 7 },
                new Chapter { Id = 27, Name = "Từ vi mô đến vĩ mô", GradeId = 7 },
            };

            builder.HasData(chapters);
        }
    }
}
