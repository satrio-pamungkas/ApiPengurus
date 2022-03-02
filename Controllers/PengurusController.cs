using Microsoft.AspNetCore.Mvc;
using ApiPengurus.Repositories;
using ApiPengurus.Models;
using ApiPengurus.Data;

namespace ApiPengurus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PengurusController : ControllerBase
    {
        private readonly IPengurusRepository _pengurusRepository = null!;
        public PengurusController(IPengurusRepository pengurusRepository)
        {
            _pengurusRepository = pengurusRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pengurus pengurus)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                pengurus.id = obj.ToString();
                pengurus.createddate = DateTime.Now;

                _pengurusRepository.AddPengurus(pengurus);
                return Ok();
            }

            return BadRequest();
        }
    }
}
