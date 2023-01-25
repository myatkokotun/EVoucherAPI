using EVMS.Models;

namespace EVMS.Repositroies
{
    public class PaymentMethodRepository : DataRepositoryBase<TbPaymentMethod>
    {
        public EvoucherContext _context;
        public PaymentMethodRepository(EvoucherContext context)
        {
            _context = context;
        }
        protected override TbPaymentMethod AddEntity(EvoucherContext entityContext, TbPaymentMethod entity)
        {
            return entityContext.TbPaymentMethods.Add(entity).Entity;
        }


        protected override IQueryable<TbPaymentMethod> GetQueryable()
        {
            return _context.TbPaymentMethods;
        }

        protected override TbPaymentMethod RemoveEntity(EvoucherContext entityContext, TbPaymentMethod entity)
        {
            return entityContext.TbPaymentMethods.Remove(entity).Entity;
        }

        protected override TbPaymentMethod UpdateEntity(EvoucherContext entityContext, TbPaymentMethod entity)
        {
            return entityContext.TbPaymentMethods.Update(entity).Entity;
        }
    }
}
