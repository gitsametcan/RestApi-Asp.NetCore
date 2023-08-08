using BackendWorks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaskController : ControllerBase
    {
        private readonly DaskContext _daskContext;

        public DaskController(DaskContext daskContext)
        {
            _daskContext = daskContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dask>>> GetTraffic()
        {
            if (_daskContext.DaskPolicy == null)
            {
                return NotFound();
            }
            return await _daskContext.DaskPolicy.ToListAsync();
        }
    }
}
