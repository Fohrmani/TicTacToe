using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tictactoe.Application;
using tictactoe.Domain;

namespace tictactoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchFacade _facade;

        public MatchesController(IMatchFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Match>> Get()
        {
            return Ok(_facade.GetMatches());
        }

        [HttpGet("{id}")]
        public ActionResult<Match> Get(Guid id)
        {
            Match match = _facade.GetMatch(id);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }

        [HttpDelete("{id}")]
        public ActionResult<Match> Delete(Guid id)
        {
            _facade.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}/rows/{rowIndex}/columns/{columnIndex}")]
        public ActionResult<FieldState?> GetRowField(Guid id, int rowIndex, int columnIndex)
        {
            return Ok(_facade.GetMatch(id).Fields[rowIndex, columnIndex]);
        }

        [HttpPatch("{id}/rows/{rowIndex}/columns/{columnIndex}")]
        public ActionResult<FieldState?> PatchRowField(Guid id, int rowIndex, int columnIndex, [FromBody]FieldState? state)
        {
            return Ok(_facade.SetFieldState(id, rowIndex, columnIndex, state));
        }

        [HttpPost]
        public ActionResult<Match> Post()
        {
            Match match = _facade.CreateNewMatch();
            return Created($"/api/matches/{match.Id}", match);
        }

        [HttpPost("{id}/player")]
        public ActionResult<Match> PostPlayer(Guid id)
        {
            var match = _facade.GetMatch(id);
            if(match == null)
            {
                return NotFound();
            }
            if(match.TryCreatePlayer(out var player))
            {
                return Created($"/api/matches/player/{player.State.ToString()}", player);
            }
            return Conflict();
        }
    }
}
