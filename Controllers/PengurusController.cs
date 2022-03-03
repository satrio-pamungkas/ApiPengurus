using Microsoft.AspNetCore.Mvc;
using ApiPengurus.Repositories;
using ApiPengurus.Models;
using System.Text.Json;

namespace ApiPengurus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PengurusController : Controller
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
                pengurus.modifieddate = DateTime.Now;

                _pengurusRepository.AddPengurus(pengurus);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("hasil")]
        public ActionResult<Pengurus> Show([FromBody]JsonElement payload)
        {
            var nim = payload.GetProperty("nim").GetString();
            var data = _pengurusRepository.GetPengurusSingleRecord(nim);

            if (data != null)
            {
                return data;
            }

            var schema = new Error
            {
                traceId = nim,
                title = "Not Found",
                message = $"NIM {nim} belum terdaftar dalam kepengurusan KOMPETEGRAM 2022",
                status = 404
            };

            Response.StatusCode = StatusCodes.Status404NotFound;

            return new JsonResult(schema);

        }
        
    }
}
