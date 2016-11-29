using System.Collections.Generic;

namespace Patterns_Design.Behavioral.UnitOfWork
{
    public class DbSet<TEntity> where TEntity : class
    {
        private List<TEntity> src;
        public DbSet(List<TEntity> src){
            this.src = src;
        }
    }
}