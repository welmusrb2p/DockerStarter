using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Data.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.NameAR).IsRequired(true);

            builder.Property(a => a.NameAR).HasMaxLength(250);

            builder.Property(a => a.NameEN).IsRequired(true);

            builder.Property(a => a.NameEN).HasMaxLength(250);

            builder.HasQueryFilter(a => a.IsActive);

            builder.HasMany(a => a.Answers)
               .WithOne()
               .HasForeignKey(a => a.QuesionId);

            builder.HasData(
              new Question
              {
                  Id = 1,
                  NameAR = "مامدى رضاك عن سرعة إستجابة الموافقات",
                  NameEN = "You are satisfied for speed of approvals response",
                  IsActive = true,
              },
               new Question
               {
                   Id = 2,
                   NameAR = "مامدى موافقتك على تغير مزود خدمة التأمين ( بوبا) مع المحافظة على مستوى الخدمة والغطاء التأميني الموحد",
                   NameEN = "You are agree to change (Buba) and keep the service level as it is ",
                   IsActive = true,
               });
        }
    }
}
