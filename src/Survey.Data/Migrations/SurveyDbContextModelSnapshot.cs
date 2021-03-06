// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Survey.Data.AppContext;

namespace Survey.Data.Migrations
{
    [DbContext(typeof(SurveyDbContext))]
    partial class SurveyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Survey.Core.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NameAR")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NameEN")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("QuesionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuesionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            NameAR = "غير راضي",
                            NameEN = "not satisfied",
                            QuesionId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            NameAR = "راضي إلى حد ما",
                            NameEN = "somewhat satisfied",
                            QuesionId = 1
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            NameAR = "راضي جدا",
                            NameEN = "satisfied",
                            QuesionId = 1
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            NameAR = "غير راضي",
                            NameEN = "not satisfied",
                            QuesionId = 2
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            NameAR = "راضي إلى حد ما",
                            NameEN = "somewhat satisfied",
                            QuesionId = 2
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            NameAR = "راضي جدا",
                            NameEN = "satisfied",
                            QuesionId = 2
                        });
                });

            modelBuilder.Entity("Survey.Core.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NameAR")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NameEN")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            NameAR = "مامدى رضاك عن سرعة إستجابة الموافقات",
                            NameEN = "You are satisfied for speed of approvals response"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            NameAR = "مامدى موافقتك على تغير مزود خدمة التأمين ( بوبا) مع المحافظة على مستوى الخدمة والغطاء التأميني الموحد",
                            NameEN = "You are agree to change (Buba) and keep the service level as it is "
                        });
                });

            modelBuilder.Entity("Survey.Core.Entities.SurveyReply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("SurveyReplies");
                });

            modelBuilder.Entity("Survey.Core.Entities.Answer", b =>
                {
                    b.HasOne("Survey.Core.Entities.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuesionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survey.Core.Entities.SurveyReply", b =>
                {
                    b.HasOne("Survey.Core.Entities.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Survey.Core.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Survey.Core.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
