using Microsoft.EntityFrameworkCore;
using Survey.Core.Entities;
using Survey.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Data.AppContext
{
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext()
        { }
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SurveyReply> SurveyReplies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new QuestionConfiguration());
            builder.ApplyConfiguration(new AnswerConfiguration());
            builder.ApplyConfiguration(new SurveyConfiguration());
        }
    }
}
