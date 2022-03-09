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
    public class SurveyConfiguration : IEntityTypeConfiguration<SurveyReply>
    {
        public void Configure(EntityTypeBuilder<SurveyReply> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");

            builder.HasOne(a => a.Question)
            .WithMany()
            .HasForeignKey(a => a.QuestionId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Answer)
           .WithMany()
           .HasForeignKey(a => a.AnswerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
