using EVMS.Helpers;
using EVMS.Models;
using EVMS.Repositroies;
using EVMS.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EVMS.Managers
{
    public class CMSUserManager
    {
        public async Task<TbCmsuser> UpSertCMSUser(TbCmsuser cmsuser)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                CMSUserRepository userrepo = new CMSUserRepository(ctx);
                TbCmsuser updatedEntity = null;
                cmsuser.Accesstime = MyExtension.getLocalTime(DateTime.UtcNow);
                if (cmsuser.Id == 0)
                {
                    updatedEntity = await userrepo.Add(cmsuser);
                }
                else
                {
                    updatedEntity = await userrepo.update(cmsuser);
                }
                return updatedEntity;
            }
        }

        public async Task<TbCmsuser> DetailUser(int ID)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                CMSUserRepository userrepo = new CMSUserRepository(ctx);
                TbCmsuser result = await userrepo.GetDataSet().Where(a => a.Id == ID).FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<TbCmsuser> GetUser(TbCmsuser user)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                CMSUserRepository userrepo = new CMSUserRepository(ctx);
                TbCmsuser result = await userrepo.GetDataSet().Where(a => a.Username == user.Username && a.Password == user.Password).FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<PagedListModel<TbCmsuser>> UserList(int page = 1, int pageSize = 10)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                CMSUserRepository userrepo = new CMSUserRepository(ctx);
                IQueryable<TbCmsuser> _userlist = userrepo.GetDataSet();
                #region paging
                var totalCount = _userlist.Select(c => c.Id).Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                var result = _userlist.Skip(pageSize * (page - 1))
                                     .Take(pageSize);
                PagedListModel<TbCmsuser> model = new PagedListModel<TbCmsuser>()
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

        public async Task<string> DeleteUser(int ID)
        {
            using (EvoucherContext ctx = new EvoucherContext())
            {
                CMSUserRepository userrepo = new CMSUserRepository(ctx);
                TbCmsuser result = await userrepo.GetDataSet().Where(a => a.Id == ID).FirstOrDefaultAsync();
                if (result != null)
                {
                    userrepo.Remove(result);
                    return "Success";
                }
                return "Fail";
            }
        }
    }
}
