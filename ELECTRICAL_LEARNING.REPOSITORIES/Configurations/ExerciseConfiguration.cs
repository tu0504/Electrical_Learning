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
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            List<Exercise> exercises = new List<Exercise>() {
                new Exercise { Id = 1, LessonId = 1, Title = "Một quyển sách nằm yên trên mặt bàn nằm ngang. Hãy xác định các lực tác dụng lên quyển sách, nêu độ lớn và phương chiều của từng lực. Hai lực này có phải là hai lực cân bằng không? Vì sao?" },
                new Exercise { Id = 2, LessonId = 2, Title = "Tại sao khi đun nóng thì các chất rắn, lỏng, khí đều nở ra? Hãy nêu một ví dụ minh họa sự nở vì nhiệt trong đời sống." },
                new Exercise { Id = 3, LessonId = 3, Title = "Giải thích tại sao ta nhìn thấy một vật? Nêu điều kiện để ánh sáng truyền được từ vật đến mắt ta." },
                new Exercise { Id = 4, LessonId = 4, Title = "Thế nào là nguồn âm? Âm phát ra to hay nhỏ phụ thuộc vào yếu tố nào? Độ cao phụ thuộc vào gì?" },
                new Exercise { Id = 5, LessonId = 5, Title = "Khi nối một bóng đèn vào hai cực của pin thì có hiện tượng gì xảy ra? Dòng điện là gì và nó chạy theo chiều nào trong mạch?" },
                new Exercise { Id = 6, LessonId = 6, Title = "Lực ma sát trượt và ma sát nghỉ khác nhau thế nào? Nêu ví dụ minh họa mỗi loại lực ma sát." },
                new Exercise { Id = 7, LessonId = 7, Title = "Nhiệt năng là gì? Có mấy cách làm thay đổi nhiệt năng của một vật? Cho ví dụ." },
                new Exercise { Id = 8, LessonId = 8, Title = "Cho hai bóng đèn mắc nối tiếp và song song vào nguồn điện. Hãy nêu sự khác nhau về độ sáng và ứng dụng của mỗi cách mắc." },
                new Exercise { Id = 9, LessonId = 9, Title = "Lực điện từ là gì? Nêu ứng dụng của lực điện từ trong đời sống hàng ngày." },
                new Exercise { Id = 10, LessonId = 10, Title = "So sánh ảnh tạo bởi thấu kính hội tụ và thấu kính phân kì. Nêu ứng dụng của từng loại thấu kính." },
                new Exercise { Id = 11, LessonId = 11, Title = "Phát biểu định luật bảo toàn năng lượng. Nêu ví dụ minh họa." },
                new Exercise { Id = 12, LessonId = 12, Title = "Thế nào là trọng lực? Nêu biểu thức định luật vạn vật hấp dẫn và ý nghĩa các đại lượng." },
                new Exercise { Id = 13, LessonId = 13, Title = "Nội năng là gì? Trình bày hai cách làm thay đổi nội năng của một vật. Cho ví dụ." },
                new Exercise { Id = 14, LessonId = 14, Title = "Công của lực điện được tính như thế nào? Nêu mối liên hệ giữa công, hiệu điện thế và điện tích." },
                new Exercise { Id = 15, LessonId = 15, Title = "Phát biểu định luật Ôm cho toàn mạch. Viết công thức và giải thích các đại lượng." },
                new Exercise { Id = 16, LessonId = 16, Title = "Nêu sự khác nhau giữa vật liệu dẫn điện và cách điện. Ứng dụng của từng loại." },
                new Exercise { Id = 17, LessonId = 17, Title = "Từ trường là gì? Lực từ tác dụng lên dòng điện có đặc điểm gì? Giải thích hiện tượng nam châm hút sắt." },
                new Exercise { Id = 18, LessonId = 18, Title = "Hiện tượng cảm ứng điện từ là gì? Nêu điều kiện xuất hiện dòng điện cảm ứng." },
                new Exercise { Id = 19, LessonId = 19, Title = "Khúc xạ ánh sáng là gì? Vẽ hình minh họa và nêu định luật khúc xạ ánh sáng." },
                new Exercise { Id = 20, LessonId = 20, Title = "Dao động điều hòa là gì? Nêu đặc điểm và công thức xác định li độ của dao động điều hòa." },
                new Exercise { Id = 21, LessonId = 21, Title = "Sóng cơ là gì? Sóng cơ truyền trong môi trường nào? Nêu ví dụ thực tế." },
                new Exercise { Id = 22, LessonId = 22, Title = "Nêu cấu tạo và nguyên lý hoạt động của mạch điện xoay chiều đơn giản." },
                new Exercise { Id = 23, LessonId = 23, Title = "Mạch dao động gồm những phần tử nào? Trình bày sự biến đổi qua lại giữa điện trường và từ trường." },
                new Exercise { Id = 24, LessonId = 24, Title = "Giao thoa ánh sáng là gì? Nêu điều kiện và ứng dụng trong thực tế." },
                new Exercise { Id = 25, LessonId = 25, Title = "Hiện tượng quang điện trong là gì? Ứng dụng của nó trong các thiết bị điện tử." },
                new Exercise { Id = 26, LessonId = 26, Title = "Tính chất của hạt nhân nguyên tử là gì? Nêu khái niệm đồng vị và phản ứng hạt nhân." },
                new Exercise { Id = 27, LessonId = 27, Title = "Trình bày cấu tạo của vũ trụ theo mô hình hiện đại. Nêu các thành phần chính." }
            };
            builder.HasData(exercises);
        }
    }
}
