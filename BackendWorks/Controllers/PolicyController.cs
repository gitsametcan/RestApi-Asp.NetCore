using BackendWorks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {

        private readonly PolicyContext _policyContext;

        public PolicyController(PolicyContext policyContext)
        {
            _policyContext = policyContext;
        }

        
    }
}
