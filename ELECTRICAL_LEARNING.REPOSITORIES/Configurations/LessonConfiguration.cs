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
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            List<Lesson> lessons = new List<Lesson>()
            {
                new Lesson { Id = 1, Title = "Lực - Hai lực cân bằng", ChapterId = 1 },
                new Lesson { Id = 2, Title = "Sự nở vì nhiệt", ChapterId = 2},
                new Lesson { Id = 3, Title = "Sự truyền ánh sáng", ChapterId = 3 },
                new Lesson { Id = 4, Title = "Nguồn âm - Độ to, độ cao của âm", ChapterId = 4 },
                new Lesson { Id = 5, Title = "Dòng điện - nguồn điện", ChapterId = 5 },
                new Lesson { Id = 6, Title = "Lực ma sát", ChapterId = 6 },
                new Lesson { Id = 7, Title = "Nhiệt năng", ChapterId = 7 },
                new Lesson { Id = 8, Title = "Đoạn mạch nối tiếp - Đoạn mạch song song", ChapterId = 8 },
                new Lesson { Id = 9, Title = "Lực điện từ", ChapterId = 9 },
                new Lesson { Id = 10, Title = "Thấu kính hội tụ - Thấu kính phân kì", ChapterId = 10 },
                new Lesson { Id = 11, Title = "Định luật bảo toàn năng lượng", ChapterId = 11 },
                new Lesson { Id = 12, Title = "Lực hấp dẫn - Định luật vạn vật hấp dẫn", ChapterId = 12 },
                new Lesson { Id = 13, Title = "Nội năng và sự biến thiên nội năng", ChapterId = 13 },
                new Lesson { Id = 14, Title = "Công của lực điện - Điện thế. Hiệu điện thế", ChapterId = 14 },
                new Lesson { Id = 15, Title = "Định luật Ôm đối với toàn mạch", ChapterId = 15 },
                new Lesson { Id = 16, Title = "Dòng điện trong các vật liệu", ChapterId = 16 },
                new Lesson { Id = 17, Title = "Từ trường - Lực từ. Cảm ứng từ", ChapterId = 17 },
                new Lesson { Id = 18, Title = "Từ thông. Cảm ứng điện từ", ChapterId = 18 },
                new Lesson { Id = 19, Title = "Khúc xạ ánh sáng", ChapterId = 19 },
                new Lesson { Id = 20, Title = "Dao động điều hòa", ChapterId = 20 },
                new Lesson { Id = 21, Title = "Sóng cơ và sự truyền sóng cơ", ChapterId = 21 },
                new Lesson { Id = 22, Title = "Các mạch điện xoay chiều", ChapterId = 22 },
                new Lesson { Id = 23, Title = "Mạch dao động - Điện từ trường", ChapterId = 23 },
                new Lesson { Id = 24, Title = "Giao thoa ánh sáng", ChapterId = 24 },
                new Lesson { Id = 25, Title = "Hiện tượng quang điện trong", ChapterId = 25 },
                new Lesson { Id = 26, Title = "Tính chất và cấu tạo hạt nhân", ChapterId = 26 },
                new Lesson { Id = 27, Title = "Cấu tạo vũ trụ", ChapterId = 27 },
            };

            builder.HasData(lessons);
        }
    }
}
