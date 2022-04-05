using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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



        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            return Ok(await _sp.GetAll());
        }
    }
}
