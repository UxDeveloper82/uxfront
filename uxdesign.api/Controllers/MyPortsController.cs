using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uxdesign.api.Data;

namespace uxdesign.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyPortsController : ControllerBase
    {
        private readonly DataContext _context;

        public MyPortsController(DataContext context)
        {
            _context = context;
        }
        // GET api/myports
        [HttpGet]
        public async Task<IActionResult> GetPorts()
        {
            var myports = await _context.MyPorts.ToListAsync();
            return Ok(myports);

        }
        // GET api/myports/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPort(int id)
        {
            var myport = await _context.MyPorts.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(myport);
        }
    }
}