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
    public class Submissionconfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            List<Submission> submissions = new List<Submission>()
            {
                new Submission { Id = 1, ExerciseId = 1, AccountId = 2, Answer = "Có hai lực tác dụng lên quyển sách: trọng lực hướng xuống và lực nâng của mặt bàn hướng lên. Hai lực này có cùng độ lớn, cùng phương, ngược chiều nên là hai lực cân bằng. Vì sách nằm yên nên tổng hợp lực tác dụng bằng 0.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 2, ExerciseId = 2, AccountId = 2, Answer = "Khi đun nóng, các phân tử chuyển động mạnh hơn, làm tăng khoảng cách giữa chúng nên vật nở ra. Ví dụ: dây điện chùng xuống vào buổi trưa do bị nở vì nhiệt.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 3, ExerciseId = 3, AccountId = 2, Answer = "Vì vật phát ra ánh sáng hoặc phản xạ ánh sáng từ nguồn sáng. Ánh sáng phải truyền đến mắt ta theo đường thẳng trong môi trường trong suốt.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 4, ExerciseId = 4, AccountId = 2, Answer = "Nguồn âm là vật dao động tạo ra âm thanh. Độ to phụ thuộc biên độ dao động, độ cao phụ thuộc tần số dao động.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 5, ExerciseId = 5, AccountId = 2, Answer = "Đèn sáng chứng tỏ có dòng điện chạy trong mạch. Dòng điện là dòng chuyển dời có hướng của các electron tự do, chạy từ cực âm sang cực dương ngoài mạch.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 6, ExerciseId = 6, AccountId = 2, Answer = "Lực ma sát trượt xuất hiện khi vật trượt, ma sát nghỉ khi vật chịu lực nhưng chưa trượt. Ví dụ: kéo rương nặng trên sàn (trượt), bàn nằm yên dù bị đẩy nhẹ (nghỉ).", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 7, ExerciseId = 7, AccountId = 2, Answer = "Nhiệt năng là tổng động năng của các phân tử. Có thể thay đổi qua thực hiện công hoặc truyền nhiệt. Ví dụ: cọ xát hai tay tạo nhiệt.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 8, ExerciseId = 8, AccountId = 2, Answer = "Nối tiếp: cùng dòng, điện áp chia nhỏ, đèn yếu hơn. Song song: mỗi nhánh cùng điện áp, sáng hơn. Song song được dùng phổ biến hơn.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 9, ExerciseId = 9, AccountId = 2, Answer = "Lực điện từ là lực giữa các điện tích chuyển động. Ứng dụng: động cơ điện, loa, máy biến áp, chuông điện.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 10, ExerciseId = 10, AccountId = 2, Answer = "Thấu kính hội tụ: ảnh thật/ngược/lớn hơn; phân kì: ảnh ảo/cùng chiều/nhỏ hơn. Hội tụ: máy ảnh, kính lúp; phân kì: kính cận.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 11, ExerciseId = 11, AccountId = 2, Answer = "Tổng năng lượng không đổi trong một hệ cô lập. Ví dụ: con lắc chuyển từ thế năng sang động năng và ngược lại.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 12, ExerciseId = 12, AccountId = 2, Answer = "Trọng lực là lực hút của Trái Đất. F = G*(m1*m2)/r^2, với G là hằng số hấp dẫn, m là khối lượng, r là khoảng cách.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 13, ExerciseId = 13, AccountId = 2, Answer = "Nội năng là tổng động năng và thế năng vi mô. Thay đổi bằng truyền nhiệt hoặc thực hiện công. Ví dụ: đun nước, nén khí.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 14, ExerciseId = 14, AccountId = 2, Answer = "A = qU, với A là công, q là điện tích, U là hiệu điện thế. Công lực điện tỉ lệ thuận với U và q.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 15, ExerciseId = 15, AccountId = 2, Answer = "I = E / (R + r), với I là cường độ dòng điện, E là suất điện động, R là điện trở ngoài, r là điện trở trong nguồn.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 16, ExerciseId = 16, AccountId = 2, Answer = "Dẫn điện: kim loại (đồng, nhôm), dùng làm dây dẫn. Cách điện: nhựa, sứ, dùng bọc cách điện.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 17, ExerciseId = 17, AccountId = 2, Answer = "Từ trường là vùng không gian có lực từ. Lực từ vuông góc với dòng điện và từ trường. Nam châm hút sắt vì tạo từ trường mạnh.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 18, ExerciseId = 18, AccountId = 2, Answer = "Là hiện tượng xuất hiện dòng điện cảm ứng khi từ thông qua mạch kín biến đổi. Điều kiện: thay đổi từ trường qua mạch kín.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 19, ExerciseId = 19, AccountId = 2, Answer = "Là sự đổi hướng truyền ánh sáng khi truyền qua mặt phân cách hai môi trường. Định luật: sin(i)/sin(r) = n2/n1.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 20, ExerciseId = 20, AccountId = 2, Answer = "Dao động điều hòa có li độ: x = A cos(ωt + φ). Đặc điểm: tuần hoàn, biên độ không đổi, tần số xác định.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 21, ExerciseId = 21, AccountId = 2, Answer = "Sóng cơ là dao động lan truyền trong môi trường vật chất. Không truyền được trong chân không. Ví dụ: sóng âm trong không khí.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 22, ExerciseId = 22, AccountId = 2, Answer = "Gồm nguồn xoay chiều, điện trở, cuộn cảm, tụ điện. Nguyên lý: dòng điện thay đổi tuần hoàn theo thời gian.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 23, ExerciseId = 23, AccountId = 2, Answer = "Gồm cuộn cảm L và tụ điện C. Năng lượng dao động giữa điện trường và từ trường, tạo dao động điện từ.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 24, ExerciseId = 24, AccountId = 2, Answer = "Là sự tăng cường hay triệt tiêu ánh sáng khi chồng lấp hai sóng đồng bộ. Ứng dụng: đo bước sóng, kỹ thuật quang.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 25, ExerciseId = 25, AccountId = 2, Answer = "Hiện tượng chất bán dẫn tạo dòng điện khi được chiếu sáng. Ứng dụng: pin mặt trời, cảm biến ánh sáng.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 26, ExerciseId = 26, AccountId = 2, Answer = "Hạt nhân gồm proton và neutron. Đồng vị là nguyên tử cùng số proton khác neutron. Phản ứng hạt nhân: phân hạch, nhiệt hạch.", CreatedAt = DateTimeOffset.UtcNow },
                new Submission { Id = 27, ExerciseId = 27, AccountId = 2, Answer = "Vũ trụ gồm thiên hà, sao, hành tinh, vật chất tối. Mô hình hiện đại cho thấy vũ trụ đang giãn nở từ vụ nổ Big Bang.", CreatedAt = DateTimeOffset.UtcNow }
            };
            builder.HasData(submissions);
        }
    }
}
