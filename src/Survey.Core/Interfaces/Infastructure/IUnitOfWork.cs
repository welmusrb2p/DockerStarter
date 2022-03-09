﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Interfaces.Infastructure
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
