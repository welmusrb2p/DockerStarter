using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAR = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAR = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    QuesionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuesionId",
                        column: x => x.QuesionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyReplies_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SurveyReplies_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "IsActive", "NameAR", "NameEN" },
                values: new object[] { 1, true, "مامدى رضاك عن سرعة إستجابة الموافقات", "You are satisfied for speed of approvals response" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "IsActive", "NameAR", "NameEN" },
                values: new object[] { 2, true, "مامدى موافقتك على تغير مزود خدمة التأمين ( بوبا) مع المحافظة على مستوى الخدمة والغطاء التأميني الموحد", "You are agree to change (Buba) and keep the service level as it is " });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "IsActive", "NameAR", "NameEN", "QuesionId" },
                values: new object[,]
                {
                    { 1, true, "غير راضي", "not satisfied", 1 },
                    { 2, true, "راضي إلى حد ما", "somewhat satisfied", 1 },
                    { 3, true, "راضي جدا", "satisfied", 1 },
                    { 4, true, "غير راضي", "not satisfied", 2 },
                    { 5, true, "راضي إلى حد ما", "somewhat satisfied", 2 },
                    { 6, true, "راضي جدا", "satisfied", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuesionId",
                table: "Answers",
                column: "QuesionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyReplies_AnswerId",
                table: "SurveyReplies",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyReplies_QuestionId",
                table: "SurveyReplies",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyReplies");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
