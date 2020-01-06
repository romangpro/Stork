using Application.Interfaces;
using Application.Sports;
using Domain.Sports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1/[controller]")] //{version:apiVersion}
    public class LeaguesController : ControllerBase
    {
        private readonly ILogger<LeaguesController> _logger;
        private readonly ILeagueRepository _leagueRepo;
        private readonly ILeagueService _leagueService;

        public LeaguesController(ILogger<LeaguesController> logger, ILeagueRepository leagueRepo, ILeagueService leagueService)
        {
            _logger = logger;
            _leagueRepo = leagueRepo;
            _leagueService = leagueService;
        }

        [HttpGet("Echo/{num}")]
        public IActionResult Echo(int num)
        {
            System.Threading.Thread.Sleep(1000);
            return Ok(new { Name = "Echo", Num = num });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _leagueService.GetAllAsync();
            return result == null || result.Count == 0 ? (IActionResult)NoContent() : Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(uint id)
        {
            var result = await _leagueService.GetAsync(id);
            return result == null ? (IActionResult)NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateLeagueCommand cmd)
        {
            var isValid = ModelState.IsValid;
            var dto = await _leagueService.CreateLeague(cmd);
            return dto == null ? (IActionResult)BadRequest() : Created(new Uri("a"), dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]uint id, [FromBody]UpdateLeagueCommand cmd)
        {
            var isValid = ModelState.IsValid;
            var league = _leagueService.UpdateLeague(id, cmd);
            //var result = await _leagueRepo.GetAsync(id);
            //if (result == null)
            //    return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]uint id)
        {
            //var league = _leagueService.UpdateLeague(id, cmd);
            //var result = await _leagueRepo.GetAsync(id);
            //if (result == null)
            //    return NotFound();
            return NoContent(); //either return nocontent
        }

        [HttpGet("dict")]
        public Dictionary<int, string> Dict()
        {
            var d = new Dictionary<int, string>() { [1] = "one" };
            return d;
        }



        //public async Task<IActionResult> Get()
        //{
        //    var users = await _context.Users
        //        .Include(u => u.Posts)
        //        .ToArrayAsync();

        //    var response = users.Select(u => new
        //    {
        //        firstName = u.FirstName,
        //        lastName = u.LastName,
        //        posts = u.Posts.Select(p => p.Content)
        //    });

        //    return Ok(response);
    }
}
