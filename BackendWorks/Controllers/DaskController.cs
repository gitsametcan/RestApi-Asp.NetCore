using BackendWorks.Models;
using BackendWorks.NonTable;
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
        public async Task<ActionResult<IEnumerable<List<DaskIO>>>> GetTraffic()
        {
            if (_daskContext.Dask == null)
            {
                return NotFound();
            }

            List<Dask> dasks = await _daskContext.Dask.ToListAsync();
            List<DaskIO> daskIOs = new List<DaskIO>();
            foreach (Dask dask in dasks)
            {

                DaskIO daskIO = new DaskIO();
                daskIOs.Add(daskIO.Yarat(dask, _daskContext));

            }


            return Ok(daskIOs);
        }

        [HttpGet("getByDaskId/{id}")]
        public async Task<ActionResult<DaskIO>> GetDaskIOItem(int id)
        {
            if (_daskContext.Dask == null)
            {
                return NotFound();
            }

            Dask dask = await _daskContext.Dask.FindAsync(id);

            DaskIO daskIO = new DaskIO();

            return daskIO.Yarat(dask, _daskContext);
        }

        
    }
}
