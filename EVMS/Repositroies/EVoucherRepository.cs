using EVMS.Models;

namespace EVMS.Repositroies
{
    public class EVoucherRepository:DataRepositoryBase<TbEvoucher>
    {
        public EvoucherContext _context;
        public EVoucherRepository(EvoucherContext context)
        {
            _context = context;
        }
        protected override TbEvoucher AddEntity(EvoucherContext entityContext, TbEvoucher entity)
        {
            return entityContext.TbEvouchers.Add(entity).Entity;
        }


        protected override IQueryable<TbEvoucher> GetQueryable()
        {
            return _context.TbEvouchers;
        }

        protected override TbEvoucher RemoveEntity(EvoucherContext entityContext, TbEvoucher entity)
        {
            return entityContext.TbEvouchers.Remove(entity).Entity;
        }

        protected override TbEvoucher UpdateEntity(EvoucherContext entityContext, TbEvoucher entity)
        {
            return entityContext.TbEvouchers.Update(entity).Entity;
        }
    }
}
