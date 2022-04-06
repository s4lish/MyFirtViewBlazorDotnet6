using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlazorAll.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _sp;
        public SuperHeroController(ISuperHeroService sp)
        {
            _sp = sp;
        }



        //[HttpGet("all")]
        //[Authorize(Roles ="Admin")]
        //public async Task<ActionResult<List<SuperHero>>> alllist()
        //{
        //    return Ok(await _sp.GetAll());
        //}

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PagedList<SuperHero>>> Get([FromQuery] SuperHeroParametes SuperHeroParametes)
        {
            var heros = await _sp.GetInfo(SuperHeroParametes);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(heros.MetaData));
            return Ok(heros);
        }
    }
}
