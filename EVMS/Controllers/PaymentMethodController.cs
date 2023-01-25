using EVMS.Managers;
using EVMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PaymentMethodController : ControllerBase
    {
        PaymentMethodManager pmmgr = new PaymentMethodManager();

        [HttpGet]
        public async Task<IActionResult> GetPayMethodList()
        {
            var pmlist = await pmmgr.PMList();
            return Ok(pmlist);
        }

        [HttpGet]
        public async Task<IActionResult> GetPayMethodObj(int ID)
        {
            TbPaymentMethod obj = await pmmgr.DetailPayMethod(ID);
            if (obj == null) return BadRequest();
            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> UpSertPayMethod(TbPaymentMethod paymethod)
        {
            TbPaymentMethod obj = await pmmgr.UpSertPayMethod(paymethod);
            if (obj == null) return NotFound();
            return Ok(obj);
        }

        [HttpGet]
        public async Task<IActionResult> DeletePayMethod(int ID)
        {
            string status = await pmmgr.DeletePayMethod(ID);
            return Ok(status);
        }
    }
}
