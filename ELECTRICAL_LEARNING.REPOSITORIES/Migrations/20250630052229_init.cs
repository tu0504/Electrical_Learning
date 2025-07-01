using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectricalLearning.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AIRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIRequest_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapter_Grade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CircuitModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    ChapterId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircuitModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircuitModel_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CircuitModel_Chapter_ChapterId",
                        column: x => x.ChapterId,
                        principalTable: "Chapter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CircuitModel_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exercise_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Expression = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CircuitModelId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formula_CircuitModel_CircuitModelId",
                        column: x => x.CircuitModelId,
                        principalTable: "CircuitModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submission_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submission_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsDeleted", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 671, DateTimeKind.Unspecified).AddTicks(5743), new TimeSpan(0, 0, 0, 0, 0)), "teacher@gmail.com", "Nguyễn Văn A", false, "$2a$11$S1fGBbrZW7mihDufKu/9IOA9nitCS9Gz511FALG2Pe5Qk0jDjJWK.", "Teacher", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 808, DateTimeKind.Unspecified).AddTicks(8774), new TimeSpan(0, 0, 0, 0, 0)), "student@gmail.com", "Trần Thị B", false, "$2a$11$4ZqeabqVOs4mUBkxXWTHF.VZGu43EPtCaHSfwG3JIDQvvPcRstky6", "Student", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 943, DateTimeKind.Unspecified).AddTicks(7864), new TimeSpan(0, 0, 0, 0, 0)), "admin@gmail.com", "Lê Văn C", false, "$2a$11$MuvM24R4cSfrbYfFHU0MP.i.MGCxpUJWEMirKdWJU6I1JldEvXT1e", "Admin", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, 6 },
                    { 2, false, 7 },
                    { 3, false, 8 },
                    { 4, false, 9 },
                    { 5, false, 10 },
                    { 6, false, 11 },
                    { 7, false, 12 }
                });

            migrationBuilder.InsertData(
                table: "AIRequest",
                columns: new[] { "Id", "AccountId", "CreatedAt", "ImageUrl", "IsDeleted", "Status", "UpdatedAt" },
                values: new object[] { 1, 2, new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(1235), new TimeSpan(0, 0, 0, 0, 0)), "https://example.com/image1.png", false, "Pending", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Chapter",
                columns: new[] { "Id", "GradeId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, false, "Cơ học" },
                    { 2, 1, false, "Nhiệt học" },
                    { 3, 2, false, "Quang học" },
                    { 4, 2, false, "Âm học" },
                    { 5, 2, false, "Điện học" },
                    { 6, 3, false, "Cơ học" },
                    { 7, 3, false, "Nhiệt học" },
                    { 8, 4, false, "Điện học" },
                    { 9, 4, false, "Điện từ học" },
                    { 10, 4, false, "Quang học" },
                    { 11, 4, false, "Sự bảo toàn và chuyển hóa năng lượng" },
                    { 12, 5, false, "Cơ học" },
                    { 13, 5, false, "Nhiệt học" },
                    { 14, 6, false, "Điện tích. Điện trường" },
                    { 15, 6, false, "Dòng điện không đổi" },
                    { 16, 6, false, "Dòng điện trong các môi trường" },
                    { 17, 6, false, "Từ trường" },
                    { 18, 6, false, "Cảm ứng điện từ" },
                    { 19, 6, false, "Quang học" },
                    { 20, 7, false, "Dao động cơ" },
                    { 21, 7, false, "Sóng cơ và sóng âm" },
                    { 22, 7, false, "Dòng điện xoay chiều" },
                    { 23, 7, false, "Dao động và sóng điện từ" },
                    { 24, 7, false, "Sóng ánh sáng" },
                    { 25, 7, false, "Lượng từ ánh sáng" },
                    { 26, 7, false, "Hạt nhân nguyên tử" },
                    { 27, 7, false, "Từ vi mô đến vĩ mô" }
                });

            migrationBuilder.InsertData(
                table: "Lesson",
                columns: new[] { "Id", "ChapterId", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, false, "Lực - Hai lực cân bằng" },
                    { 2, 2, false, "Sự nở vì nhiệt" },
                    { 3, 3, false, "Sự truyền ánh sáng" },
                    { 4, 4, false, "Nguồn âm - Độ to, độ cao của âm" },
                    { 5, 5, false, "Dòng điện - nguồn điện" },
                    { 6, 6, false, "Lực ma sát" },
                    { 7, 7, false, "Nhiệt năng" },
                    { 8, 8, false, "Đoạn mạch nối tiếp - Đoạn mạch song song" },
                    { 9, 9, false, "Lực điện từ" },
                    { 10, 10, false, "Thấu kính hội tụ - Thấu kính phân kì" },
                    { 11, 11, false, "Định luật bảo toàn năng lượng" },
                    { 12, 12, false, "Lực hấp dẫn - Định luật vạn vật hấp dẫn" },
                    { 13, 13, false, "Nội năng và sự biến thiên nội năng" },
                    { 14, 14, false, "Công của lực điện - Điện thế. Hiệu điện thế" },
                    { 15, 15, false, "Định luật Ôm đối với toàn mạch" },
                    { 16, 16, false, "Dòng điện trong các vật liệu" },
                    { 17, 17, false, "Từ trường - Lực từ. Cảm ứng từ" },
                    { 18, 18, false, "Từ thông. Cảm ứng điện từ" },
                    { 19, 19, false, "Khúc xạ ánh sáng" },
                    { 20, 20, false, "Dao động điều hòa" },
                    { 21, 21, false, "Sóng cơ và sự truyền sóng cơ" },
                    { 22, 22, false, "Các mạch điện xoay chiều" },
                    { 23, 23, false, "Mạch dao động - Điện từ trường" },
                    { 24, 24, false, "Giao thoa ánh sáng" },
                    { 25, 25, false, "Hiện tượng quang điện trong" },
                    { 26, 26, false, "Tính chất và cấu tạo hạt nhân" },
                    { 27, 27, false, "Cấu tạo vũ trụ" }
                });

            migrationBuilder.InsertData(
                table: "CircuitModel",
                columns: new[] { "Id", "AccountId", "ChapterId", "CreatedAt", "IsDeleted", "JsonData", "LessonId", "Name", "UpdatedAt" },
                values: new object[] { 1, 1, null, new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(3813), new TimeSpan(0, 0, 0, 0, 0)), false, "{\"resistor\": 100, \"voltage\": 5}", 1, "Mạch mẫu 1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "AccountId", "IsDeleted", "LessonId", "Title" },
                values: new object[,]
                {
                    { 1, null, false, 1, "Một quyển sách nằm yên trên mặt bàn nằm ngang. Hãy xác định các lực tác dụng lên quyển sách, nêu độ lớn và phương chiều của từng lực. Hai lực này có phải là hai lực cân bằng không? Vì sao?" },
                    { 2, null, false, 2, "Tại sao khi đun nóng thì các chất rắn, lỏng, khí đều nở ra? Hãy nêu một ví dụ minh họa sự nở vì nhiệt trong đời sống." },
                    { 3, null, false, 3, "Giải thích tại sao ta nhìn thấy một vật? Nêu điều kiện để ánh sáng truyền được từ vật đến mắt ta." },
                    { 4, null, false, 4, "Thế nào là nguồn âm? Âm phát ra to hay nhỏ phụ thuộc vào yếu tố nào? Độ cao phụ thuộc vào gì?" },
                    { 5, null, false, 5, "Khi nối một bóng đèn vào hai cực của pin thì có hiện tượng gì xảy ra? Dòng điện là gì và nó chạy theo chiều nào trong mạch?" },
                    { 6, null, false, 6, "Lực ma sát trượt và ma sát nghỉ khác nhau thế nào? Nêu ví dụ minh họa mỗi loại lực ma sát." },
                    { 7, null, false, 7, "Nhiệt năng là gì? Có mấy cách làm thay đổi nhiệt năng của một vật? Cho ví dụ." },
                    { 8, null, false, 8, "Cho hai bóng đèn mắc nối tiếp và song song vào nguồn điện. Hãy nêu sự khác nhau về độ sáng và ứng dụng của mỗi cách mắc." },
                    { 9, null, false, 9, "Lực điện từ là gì? Nêu ứng dụng của lực điện từ trong đời sống hàng ngày." },
                    { 10, null, false, 10, "So sánh ảnh tạo bởi thấu kính hội tụ và thấu kính phân kì. Nêu ứng dụng của từng loại thấu kính." },
                    { 11, null, false, 11, "Phát biểu định luật bảo toàn năng lượng. Nêu ví dụ minh họa." },
                    { 12, null, false, 12, "Thế nào là trọng lực? Nêu biểu thức định luật vạn vật hấp dẫn và ý nghĩa các đại lượng." },
                    { 13, null, false, 13, "Nội năng là gì? Trình bày hai cách làm thay đổi nội năng của một vật. Cho ví dụ." },
                    { 14, null, false, 14, "Công của lực điện được tính như thế nào? Nêu mối liên hệ giữa công, hiệu điện thế và điện tích." },
                    { 15, null, false, 15, "Phát biểu định luật Ôm cho toàn mạch. Viết công thức và giải thích các đại lượng." },
                    { 16, null, false, 16, "Nêu sự khác nhau giữa vật liệu dẫn điện và cách điện. Ứng dụng của từng loại." },
                    { 17, null, false, 17, "Từ trường là gì? Lực từ tác dụng lên dòng điện có đặc điểm gì? Giải thích hiện tượng nam châm hút sắt." },
                    { 18, null, false, 18, "Hiện tượng cảm ứng điện từ là gì? Nêu điều kiện xuất hiện dòng điện cảm ứng." },
                    { 19, null, false, 19, "Khúc xạ ánh sáng là gì? Vẽ hình minh họa và nêu định luật khúc xạ ánh sáng." },
                    { 20, null, false, 20, "Dao động điều hòa là gì? Nêu đặc điểm và công thức xác định li độ của dao động điều hòa." },
                    { 21, null, false, 21, "Sóng cơ là gì? Sóng cơ truyền trong môi trường nào? Nêu ví dụ thực tế." },
                    { 22, null, false, 22, "Nêu cấu tạo và nguyên lý hoạt động của mạch điện xoay chiều đơn giản." },
                    { 23, null, false, 23, "Mạch dao động gồm những phần tử nào? Trình bày sự biến đổi qua lại giữa điện trường và từ trường." },
                    { 24, null, false, 24, "Giao thoa ánh sáng là gì? Nêu điều kiện và ứng dụng trong thực tế." },
                    { 25, null, false, 25, "Hiện tượng quang điện trong là gì? Ứng dụng của nó trong các thiết bị điện tử." },
                    { 26, null, false, 26, "Tính chất của hạt nhân nguyên tử là gì? Nêu khái niệm đồng vị và phản ứng hạt nhân." },
                    { 27, null, false, 27, "Trình bày cấu tạo của vũ trụ theo mô hình hiện đại. Nêu các thành phần chính." }
                });

            migrationBuilder.InsertData(
                table: "Formula",
                columns: new[] { "Id", "CircuitModelId", "Description", "Expression", "IsDeleted", "Name" },
                values: new object[] { 1, 1, "Cường độ dòng điện chạy qua dây dẫn tỉ lệ thuận với hiệu điện thế đặt vào hai đầu dây và tỉ lệ nghịch với điện trở của dây.", "I = U / R", false, "Định luật Ôm" });

            migrationBuilder.InsertData(
                table: "Submission",
                columns: new[] { "Id", "AccountId", "Answer", "CreatedAt", "ExerciseId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2, "Có hai lực tác dụng lên quyển sách: trọng lực hướng xuống và lực nâng của mặt bàn hướng lên. Hai lực này có cùng độ lớn, cùng phương, ngược chiều nên là hai lực cân bằng. Vì sách nằm yên nên tổng hợp lực tác dụng bằng 0.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8043), new TimeSpan(0, 0, 0, 0, 0)), 1, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, 2, "Khi đun nóng, các phân tử chuyển động mạnh hơn, làm tăng khoảng cách giữa chúng nên vật nở ra. Ví dụ: dây điện chùng xuống vào buổi trưa do bị nở vì nhiệt.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8055), new TimeSpan(0, 0, 0, 0, 0)), 2, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, 2, "Vì vật phát ra ánh sáng hoặc phản xạ ánh sáng từ nguồn sáng. Ánh sáng phải truyền đến mắt ta theo đường thẳng trong môi trường trong suốt.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8056), new TimeSpan(0, 0, 0, 0, 0)), 3, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, 2, "Nguồn âm là vật dao động tạo ra âm thanh. Độ to phụ thuộc biên độ dao động, độ cao phụ thuộc tần số dao động.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8058), new TimeSpan(0, 0, 0, 0, 0)), 4, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, 2, "Đèn sáng chứng tỏ có dòng điện chạy trong mạch. Dòng điện là dòng chuyển dời có hướng của các electron tự do, chạy từ cực âm sang cực dương ngoài mạch.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8059), new TimeSpan(0, 0, 0, 0, 0)), 5, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, 2, "Lực ma sát trượt xuất hiện khi vật trượt, ma sát nghỉ khi vật chịu lực nhưng chưa trượt. Ví dụ: kéo rương nặng trên sàn (trượt), bàn nằm yên dù bị đẩy nhẹ (nghỉ).", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8062), new TimeSpan(0, 0, 0, 0, 0)), 6, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, 2, "Nhiệt năng là tổng động năng của các phân tử. Có thể thay đổi qua thực hiện công hoặc truyền nhiệt. Ví dụ: cọ xát hai tay tạo nhiệt.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8064), new TimeSpan(0, 0, 0, 0, 0)), 7, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, 2, "Nối tiếp: cùng dòng, điện áp chia nhỏ, đèn yếu hơn. Song song: mỗi nhánh cùng điện áp, sáng hơn. Song song được dùng phổ biến hơn.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8065), new TimeSpan(0, 0, 0, 0, 0)), 8, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, 2, "Lực điện từ là lực giữa các điện tích chuyển động. Ứng dụng: động cơ điện, loa, máy biến áp, chuông điện.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8067), new TimeSpan(0, 0, 0, 0, 0)), 9, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, 2, "Thấu kính hội tụ: ảnh thật/ngược/lớn hơn; phân kì: ảnh ảo/cùng chiều/nhỏ hơn. Hội tụ: máy ảnh, kính lúp; phân kì: kính cận.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8069), new TimeSpan(0, 0, 0, 0, 0)), 10, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, 2, "Tổng năng lượng không đổi trong một hệ cô lập. Ví dụ: con lắc chuyển từ thế năng sang động năng và ngược lại.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8071), new TimeSpan(0, 0, 0, 0, 0)), 11, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 12, 2, "Trọng lực là lực hút của Trái Đất. F = G*(m1*m2)/r^2, với G là hằng số hấp dẫn, m là khối lượng, r là khoảng cách.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8072), new TimeSpan(0, 0, 0, 0, 0)), 12, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 13, 2, "Nội năng là tổng động năng và thế năng vi mô. Thay đổi bằng truyền nhiệt hoặc thực hiện công. Ví dụ: đun nước, nén khí.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8073), new TimeSpan(0, 0, 0, 0, 0)), 13, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 14, 2, "A = qU, với A là công, q là điện tích, U là hiệu điện thế. Công lực điện tỉ lệ thuận với U và q.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8074), new TimeSpan(0, 0, 0, 0, 0)), 14, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 15, 2, "I = E / (R + r), với I là cường độ dòng điện, E là suất điện động, R là điện trở ngoài, r là điện trở trong nguồn.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8076), new TimeSpan(0, 0, 0, 0, 0)), 15, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 16, 2, "Dẫn điện: kim loại (đồng, nhôm), dùng làm dây dẫn. Cách điện: nhựa, sứ, dùng bọc cách điện.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8077), new TimeSpan(0, 0, 0, 0, 0)), 16, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 17, 2, "Từ trường là vùng không gian có lực từ. Lực từ vuông góc với dòng điện và từ trường. Nam châm hút sắt vì tạo từ trường mạnh.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8078), new TimeSpan(0, 0, 0, 0, 0)), 17, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 18, 2, "Là hiện tượng xuất hiện dòng điện cảm ứng khi từ thông qua mạch kín biến đổi. Điều kiện: thay đổi từ trường qua mạch kín.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8079), new TimeSpan(0, 0, 0, 0, 0)), 18, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 19, 2, "Là sự đổi hướng truyền ánh sáng khi truyền qua mặt phân cách hai môi trường. Định luật: sin(i)/sin(r) = n2/n1.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8080), new TimeSpan(0, 0, 0, 0, 0)), 19, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 20, 2, "Dao động điều hòa có li độ: x = A cos(ωt + φ). Đặc điểm: tuần hoàn, biên độ không đổi, tần số xác định.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8081), new TimeSpan(0, 0, 0, 0, 0)), 20, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 21, 2, "Sóng cơ là dao động lan truyền trong môi trường vật chất. Không truyền được trong chân không. Ví dụ: sóng âm trong không khí.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8083), new TimeSpan(0, 0, 0, 0, 0)), 21, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 22, 2, "Gồm nguồn xoay chiều, điện trở, cuộn cảm, tụ điện. Nguyên lý: dòng điện thay đổi tuần hoàn theo thời gian.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8084), new TimeSpan(0, 0, 0, 0, 0)), 22, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 23, 2, "Gồm cuộn cảm L và tụ điện C. Năng lượng dao động giữa điện trường và từ trường, tạo dao động điện từ.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8085), new TimeSpan(0, 0, 0, 0, 0)), 23, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 24, 2, "Là sự tăng cường hay triệt tiêu ánh sáng khi chồng lấp hai sóng đồng bộ. Ứng dụng: đo bước sóng, kỹ thuật quang.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8086), new TimeSpan(0, 0, 0, 0, 0)), 24, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 25, 2, "Hiện tượng chất bán dẫn tạo dòng điện khi được chiếu sáng. Ứng dụng: pin mặt trời, cảm biến ánh sáng.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8087), new TimeSpan(0, 0, 0, 0, 0)), 25, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 26, 2, "Hạt nhân gồm proton và neutron. Đồng vị là nguyên tử cùng số proton khác neutron. Phản ứng hạt nhân: phân hạch, nhiệt hạch.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8102), new TimeSpan(0, 0, 0, 0, 0)), 26, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 27, 2, "Vũ trụ gồm thiên hà, sao, hành tinh, vật chất tối. Mô hình hiện đại cho thấy vũ trụ đang giãn nở từ vụ nổ Big Bang.", new DateTimeOffset(new DateTime(2025, 6, 30, 5, 22, 28, 944, DateTimeKind.Unspecified).AddTicks(8104), new TimeSpan(0, 0, 0, 0, 0)), 27, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AIRequest_AccountId",
                table: "AIRequest",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_GradeId",
                table: "Chapter",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_CircuitModel_AccountId",
                table: "CircuitModel",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CircuitModel_ChapterId",
                table: "CircuitModel",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_CircuitModel_LessonId",
                table: "CircuitModel",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_AccountId",
                table: "Exercise",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_LessonId",
                table: "Exercise",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Formula_CircuitModelId",
                table: "Formula",
                column: "CircuitModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ChapterId",
                table: "Lesson",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_AccountId",
                table: "Submission",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_ExerciseId",
                table: "Submission",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AIRequest");

            migrationBuilder.DropTable(
                name: "Formula");

            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropTable(
                name: "CircuitModel");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Chapter");

            migrationBuilder.DropTable(
                name: "Grade");
        }
    }
}
