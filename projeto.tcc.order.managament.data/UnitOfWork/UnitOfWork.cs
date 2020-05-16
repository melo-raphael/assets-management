using projeto.tcc.order.managament.data.Context;
using projeto.tcc.order.managament.domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveEntitiesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
