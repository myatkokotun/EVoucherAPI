using EVMS.Models;

namespace EVMS.Repositroies
{
    public class CMSUserRepository : DataRepositoryBase<TbCmsuser>
    {
        public EvoucherContext _context;
        public CMSUserRepository(EvoucherContext context)
        {
            _context = context;
        }
        protected override TbCmsuser AddEntity(EvoucherContext entityContext, TbCmsuser entity)
        {
            return entityContext.TbCmsusers.Add(entity).Entity;
        }


        protected override IQueryable<TbCmsuser> GetQueryable()
        {
            return _context.TbCmsusers;
        }

        protected override TbCmsuser RemoveEntity(EvoucherContext entityContext, TbCmsuser entity)
        {
            return entityContext.TbCmsusers.Remove(entity).Entity;
        }

        protected override TbCmsuser UpdateEntity(EvoucherContext entityContext, TbCmsuser entity)
        {
            return entityContext.TbCmsusers.Update(entity).Entity;
        }
    }
}
