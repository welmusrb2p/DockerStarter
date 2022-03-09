using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Data.Configuration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.NameAR).IsRequired(true);

            builder.Property(a => a.NameAR).HasMaxLength(250);

            builder.Property(a => a.NameEN).IsRequired(true);

            builder.Property(a => a.NameEN).HasMaxLength(250);

            builder.HasQueryFilter(a => a.IsActive);

           

            builder.HasData(
              new Answer
              {
                  Id = 1,
                  NameAR = "غير راضي",
                  NameEN = "not satisfied",
                  IsActive = true,
                  QuesionId=1 
              }, new Answer
              {
                  Id = 2,
                  NameAR = "راضي إلى حد ما",
                  NameEN = "somewhat satisfied",
                  IsActive = true,
                  QuesionId = 1
              }, new Answer
              {
                  Id = 3,
                  NameAR = "راضي جدا",
                  NameEN = "satisfied",
                  IsActive = true,
                  QuesionId = 1
              },

              new Answer
              {
                  Id = 4,
                  NameAR = "غير راضي",
                  NameEN = "not satisfied",
                  IsActive = true,
                  QuesionId = 2
              }, new Answer
              {
                  Id = 5,
                  NameAR = "راضي إلى حد ما",
                  NameEN = "somewhat satisfied",
                  IsActive = true,
                  QuesionId = 2
              }, new Answer
              {
                  Id = 6,
                  NameAR = "راضي جدا",
                  NameEN = "satisfied",
                  IsActive = true,
                  QuesionId = 2
              }
          );
        }
    }
}
