using EVMS.Managers;
using EVMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EVMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EVoucherController : ControllerBase
    {

        EVoucherManager evmanager = new EVoucherManager();

        [HttpGet]
        public async Task<IActionResult> GetEVoucherList(int page = 1, int pageSize = 10, string? FilterName="ALL", string? Keyword="ALL")
        {
            var evlist = await evmanager.EVList(page, pageSize, FilterName, Keyword);
            return Ok(evlist);
        }

        [HttpGet]
        public async Task<IActionResult> GetEVoucherObj(int ID)
        {
            TbEvoucher obj = await evmanager.DetailEVoucher(ID);
            if (obj == null) return BadRequest();
            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> UpSertEVoucher(TbEvoucher evoucher)
        {
            TbEvoucher obj = await evmanager.UpSertEVoucher(evoucher);
            if (obj == null) return NotFound();
            return Ok(obj);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEVoucher(int ID)
        {
            string status = await evmanager.DeleteEVoucher(ID);
            return Ok(status);
        }
    }
}
