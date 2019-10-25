using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tictactoe.Domain
{
    public class Player
    {
        public Guid Id { get; private set; }
        public FieldState State { get; private set; }

        public Player(FieldState state)
        {
            Id = Guid.NewGuid();
            State = state;
        }
    }
}
