﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendWorks.Security;

namespace BackendWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Token token = TokenHandler.CreateToken(_configuration);
            return Ok(token);
        }
    }
}
