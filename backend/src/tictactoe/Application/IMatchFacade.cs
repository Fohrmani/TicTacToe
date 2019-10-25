using System;
using System.Collections.Generic;
using tictactoe.Domain;

namespace tictactoe.Application
{
    public interface IMatchFacade
    {
        IEnumerable<Match> GetMatches();
        Match GetMatch(Guid id);
        Match CreateNewMatch();
        void Delete(Guid id);
        Match SetFieldState(Guid id, int rowIndex, int columnIndex, FieldState? state);
    }
}