using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
