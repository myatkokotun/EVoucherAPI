using EVMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EVMS.Repositroies
{
    public abstract class DataRepositoryBase<T> where T : class, new()
    {
        protected abstract T AddEntity(EvoucherContext entityContext, T entity);
        protected abstract T UpdateEntity(EvoucherContext entityContext, T entity);
        protected abstract IQueryable<T> GetQueryable();
        protected abstract T RemoveEntity(EvoucherContext entityContext, T entity);


        public async Task<T> Add(T entity)
        {
            using (EvoucherContext entityContext = new EvoucherContext())
            {
                T addedEntity = AddEntity(entityContext, entity);
                await entityContext.SaveChangesAsync();
                return addedEntity;
            }
        }

        public async Task<T> update(T entity)
        {
            using (EvoucherContext entityContext = new EvoucherContext())
            {
                T upentity = UpdateEntity(entityContext, entity);
                await entityContext.SaveChangesAsync();
                return upentity;
            }
        }

        public IQueryable<T> GetDataSet()
        {
            return GetQueryable().AsQueryable().AsNoTracking();
        }

        public async Task<T> Remove(T entity)
        {
            using (EvoucherContext entityContext = new EvoucherContext())
            {
                T reventity = RemoveEntity(entityContext, entity);
                await entityContext.SaveChangesAsync();
                return reventity;
            }
        }

    }
}
