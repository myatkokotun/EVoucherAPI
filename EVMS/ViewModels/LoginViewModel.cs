using EVMS.Models;

namespace EVMS.ViewModels
{
    public class LoginViewModel
    {
        public TbCmsuser? CmsUser { get; set; }
        public string? JwtAuth { get; set; }
    }
}
