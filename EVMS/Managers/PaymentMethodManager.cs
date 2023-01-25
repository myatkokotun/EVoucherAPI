using EVMS.Helpers;
using EVMS.Models;
using EVMS.Repositroies;
using EVMS.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EVMS.Managers
{
    public class PaymentMethodManager
    {
        public async Task<List<TbPaymentMethod>> PMList(int page = 1, int pageSize = 10)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                PaymentMethodRepository pmrepo = new PaymentMethodRepository(ctx);
                List<TbPaymentMethod> _pmlist = await pmrepo.GetDataSet().ToListAsync();
                return _pmlist;
            }
        }

        public async Task<TbPaymentMethod> UpSertPayMethod(TbPaymentMethod paymethod)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                PaymentMethodRepository pmrepo = new PaymentMethodRepository(ctx);
                TbPaymentMethod updatedEntity = null;
                if (paymethod.Id == 0)
                {
                    updatedEntity = await pmrepo.Add(paymethod);
                }
                else
                {
                    updatedEntity = await pmrepo.update(paymethod);
                }
                return updatedEntity;
            }
        }

        public async Task<TbPaymentMethod> DetailPayMethod(int ID)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                PaymentMethodRepository pmrepo = new PaymentMethodRepository(ctx);
                TbPaymentMethod result = await pmrepo.GetDataSet().Where(a => a.Id == ID).FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<string> DeletePayMethod(int ID)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                PaymentMethodRepository pmrepo = new PaymentMethodRepository(ctx);
                TbPaymentMethod result = await pmrepo.GetDataSet().Where(a => a.Id == ID).FirstOrDefaultAsync();
                if (result != null)
                {
                    pmrepo.Remove(result);
                    return "Success";
                }
                return "Fail";
            }
        }
    }
}
