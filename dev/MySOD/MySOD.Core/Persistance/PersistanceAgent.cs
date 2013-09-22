namespace MySOD.Core.Persistance
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class PersistanceAgent<TEntity> where TEntity : class
    {
        private readonly SODContext context = new SODContext();

        public PersistanceAgent(PersistanceEntity entity)
        {
            this.Entity = entity;
            this.DataSet = this.context.Set<TEntity>();
            this.Entity.EntityInserted += this.OnEntityInserted;
            this.Entity.EntityRemoved += this.OnEntityRemoved;
        }

        protected DbSet<TEntity> DataSet { get; set; }

        protected PersistanceEntity Entity { get; set; }

        public IEnumerable<TEntity> Get()
        {
            return this.DataSet.ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DataSet.Where(predicate).ToList();
        }

        private void OnEntityInserted(object sender, PersistanceEventArgs e)
        {
            this.DataSet.Add((TEntity)e.Entity);
            this.SaveChanges();
        }

        private void OnEntityRemoved(object sender, PersistanceEventArgs e)
        {
            this.DataSet.Remove((TEntity)e.Entity);
            this.SaveChanges();
        }

        private void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
