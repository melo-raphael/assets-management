using Microsoft.EntityFrameworkCore;
using projeto.tcc.order.managament.data.Context;
using projeto.tcc.order.managament.data.Queries;
using projeto.tcc.order.managament.domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto.tcc.order.managament.data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly ApplicationDbContext _appDbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();

        }

        public void Add(TEntity obj)
        {
            _appDbContext.Add(obj);
        }


    }
}
