using BackendWorks.Models;
using BackendWorks.NonTable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BackendWorks.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TrafficController : ControllerBase
    {
        private readonly TrafficContext _trafficContext;

        public TrafficController(TrafficContext trafficContext)
        {
            _trafficContext = trafficContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<List<TrafficIO>>>> GetTraffic()
        {
            if (_trafficContext.Traffic == null)
            {
                return NotFound();
            }

            List<Traffic> trfc = await _trafficContext.Traffic.ToListAsync();
            List<TrafficIO> trafs = new List<TrafficIO>();
            foreach (Traffic traffic in trfc)
            {

                TrafficIO trafficIO = new TrafficIO();
                trafs.Add(trafficIO.Yarat(traffic, _trafficContext));

            }
            

            return Ok(trafs);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Traffic>> PostFirstItem(TrafficIO trafficIO)
        {
            Policy policy = trafficIO.PolicyObj;

            var existingProduct = _trafficContext.Policy.FirstOrDefault(p => p.Id == policy.Id);

            if (existingProduct == null)
            {
                _trafficContext.Policy.Add(policy);
                await _trafficContext.SaveChangesAsync();
            }

            Traffic traffic = new Traffic();
            traffic.PlakaKodu = trafficIO.PlakaKodu;
            traffic.PolicyId = trafficIO.PolicyId;
            traffic.PlakaIlKodu = trafficIO.PlakaIlKodu;

            _trafficContext.Traffic.Add(traffic);
            await _trafficContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Traffic), new { Id = traffic.PolicyId }, traffic);
        }
    }
}
