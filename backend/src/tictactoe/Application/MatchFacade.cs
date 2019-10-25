using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tictactoe.Domain;

namespace tictactoe.Application
{
    public class MatchFacade : IMatchFacade
    {
        private Dictionary<Guid, Match> _matches;

        public MatchFacade()
        {
            _matches = new Dictionary<Guid, Match>();
        }

        public Match CreateNewMatch()
        {
            Match match = new Match();
            _matches.Add(match.Id, match);
            return match;
        }

        public void Delete(Guid id)
        {
            if (_matches.ContainsKey(id))
            {
                _matches.Remove(id);
            }
        }

        public Match GetMatch(Guid id)
        {
            if(_matches.ContainsKey(id))
            {
                return _matches[id];
            }
            return null;
        }

        public IEnumerable<Match> GetMatches()
        {
            return _matches.Values.ToList();
        }

        public Match SetFieldState(Guid id, int rowIndex, int columnIndex, FieldState? state)
        {
            var match = GetMatch(id);
            if(match == null)
            {
                return null;
            }
            match.Fields[rowIndex, columnIndex] = state;
            return match;
        }
    }
}
