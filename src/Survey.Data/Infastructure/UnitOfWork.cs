using Survey.Core.Interfaces.Infastructure;
using Survey.Data.AppContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Data.Infastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SurveyDbContext _dbContext;

        public UnitOfWork(SurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            var result = await _dbContext.SaveChangesAsync();
          
            return result;
        }
    }
}
