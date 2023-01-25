using EVMS.Helpers;
using EVMS.Models;
using EVMS.Repositroies;
using EVMS.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Data;
using System.Web;

namespace EVMS.Managers
{
    public class EVoucherManager
    {
        public async Task<PagedListModel<TbEvoucher>> EVList(int page = 1, int pageSize = 10, string? FilterName = "ALL", string? Keyword = "ALL")
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                EVoucherRepository evrepo = new EVoucherRepository(ctx);
                IQueryable<TbEvoucher> _evlist = evrepo.GetDataSet();
                if (FilterName == "Title" && Keyword != null && Keyword != "")
                {
                    _evlist = _evlist.Where(a => a.Title.Contains(Keyword));
                }
                if (FilterName == "Phone" && Keyword != null && Keyword != "")
                {
                    _evlist = _evlist.Where(a => a.MyselfPhone.Contains(Keyword) || a.OtherPhone.Contains(Keyword));
                }
                #region paging
                var totalCount = _evlist.Select(c => c.Id).Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                var result = _evlist.Skip(pageSize * (page - 1))
                                     .Take(pageSize);
                PagedListModel<TbEvoucher> model = new PagedListModel<TbEvoucher>()
                {
                    TotalCount = totalCount,
                    TotalPages = totalPages,
                    prevLink = "",
                    nextLink = "",
                    Results = result.ToList(),
                };
                #endregion
                return model;
            }
        }

        public async Task<TbEvoucher> UpSertEVoucher(TbEvoucher evoucher)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                EVoucherRepository evrepo = new EVoucherRepository(ctx);
                TbEvoucher updatedEntity = null;
                evoucher.Accesstime = MyExtension.getLocalTime(DateTime.UtcNow);
                if (evoucher.Id == 0)
                {
                    updatedEntity = await evrepo.Add(evoucher);
                    if (updatedEntity != null)
                    {
                        string phoneno = "";
                        if (updatedEntity.BuyType == "only me usage")
                        {
                            phoneno = updatedEntity.MyselfPhone;
                        }
                        else
                        {
                            phoneno = updatedEntity.OtherPhone;
                        }
                        var url = $"api/PromoCodeContorller/UpSertPromoCode?EVid={updatedEntity.Id}&Phone={phoneno}";
                        var result = await APIRequest<string>.Get(url);
                    }
                }
                else
                {
                    updatedEntity = await evrepo.update(evoucher);
                }
                return updatedEntity;
            }
        }

        public async Task<TbEvoucher> DetailEVoucher(int ID)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                EVoucherRepository evrepo = new EVoucherRepository(ctx);
                TbEvoucher result = await evrepo.GetDataSet().Where(a => a.Id == ID).FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<string> DeleteEVoucher(int ID)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                EVoucherRepository evrepo = new EVoucherRepository(ctx);
                TbEvoucher result = await evrepo.GetDataSet().Where(a => a.Id == ID).FirstOrDefaultAsync();
                if (result != null)
                {
                    evrepo.Remove(result);
                    return "Success";
                }
                return "Fail";
            }
        }
    }
}
