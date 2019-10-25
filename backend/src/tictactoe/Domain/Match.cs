using System;
using System.Collections.Generic;
using System.Linq;

namespace tictactoe.Domain 
{
    public class Match    
    {
        public FieldState?[,] Fields { get; private set; }        //Feldstatus abfragen(wurde schon gesetzt)   
        public bool IsFinished => _fieldList.All(p => p != null) || IsWon; //Wann das Spiel zuende ist  
        public bool IsWon => GetIsWon(out var fieldState); //man kann nur gewinnen wenn felder geetzt wurden        
        public Player Winner => GetWinner(); //Wer gewonnen hat ider der Gewinner   
        public bool ReadyToStart => PlayerO != null && PlayerX != null;   //Spieler kann ein Feld setzen (rady to start)
        public Guid Id { get; private set; }  //jedes feld wird einer "Nummer" zugewiesen
        public Player PlayerX { get; private set; } // es gibt einen player namens: X
        public Player PlayerO { get; private set; } // es gibt einen Play namens: O

        private List<FieldState?> _fieldList; // ? (kann es nicht übersetzen) 

        public Match() //Veröffentlicht ein Match damit ein spieler joinen kann 
        {
            Id = Guid.NewGuid(); //Erstellt ein neues Spielfeld (Weil ein neues match veröffentlicht wurde)
            _fieldList = new List<FieldState?>();//Das neue Spielfeld bekommt auch neue Felder zugewiesen
            Fields = new FieldState?[3, 3]; //Bestimmt die neue Feldgröße 
        }

        public bool TryCreatePlayer(out Player player) //Erstellt einen Spieler
        {
            if (PlayerX == null) 
            {
                PlayerX = new Player(FieldState.X); //Fragt ab ob es ein neuen Spieler gibt
                player = PlayerX; //Wenn ja = X
                return true; 
            }
            if (PlayerO == null)//?ö
            {
                PlayerO = new Player(FieldState.O);//Fragt ab ob es einen weiteren Spieler gibt     
                player = PlayerO;//Wenn ja = O
                return true;
            }
            player = null;//Wenn es keinen Spieler gibt 
            return false;// Dann Fehlermeldung  
        }

        private bool GetIsWon(out FieldState? winningState) //Prüft ob es einen Gewinner gibt 
        {
            FieldState? rowWinnerState = GetRowWinner();// Vertikal oder Horizontal
            FieldState? colWinnerState = GetColumnWinner();//Vertikal oder Horizontal
            FieldState? diagonalWinningState = GetDiagonalWinner(); //Diagonale Winnreihe ist möglich 
            if (rowWinnerState != null)
            {
                winningState = rowWinnerState;    // Folgende .. Alle möglichen Gewinnerreihen können aúsgeführt werden
                return true;
            }
            if (colWinnerState != null)
            {
                winningState = colWinnerState;       
                return true;
            }
            if (diagonalWinningState != null)
            {
                winningState = diagonalWinningState;
                return true;
            }
            winningState = null;
            return false;
        }

        private Player GetWinner()     //Was bedeutet privat in dem zusammenhang?
        {
            FieldState? rowWinnerState = GetRowWinner();
            FieldState? colWinnerState = GetColumnWinner();
            FieldState? diagonalWinningState = GetDiagonalWinner();
            if(rowWinnerState != null)
            {
                return StateToPlayer(rowWinnerState);
            }
            if (colWinnerState != null)
            {
                return StateToPlayer(colWinnerState);
            }
            if (diagonalWinningState != null)
            {
                return StateToPlayer(diagonalWinningState);
            }
            return null;
        }

        private Player StateToPlayer(FieldState? state)    //StateToPlayer? 
        {
            if(state == null)
            {
                return null;
            }
            if (state == FieldState.X)
            {
                return PlayerX;
            }
            if (state == FieldState.O)
            {
                return PlayerO;
            }
            return null;
        }

        private FieldState? GetDiagonalWinner() //Diagonalwinner Definition (Wann tritt dies ein)
        {
            var firstState = Fields[0, 0];
            if (firstState != null && Fields[1, 1] == firstState && Fields[2, 2] == firstState)
            {
                return firstState;
            }

            var secondState = Fields[0, 2];
            if (secondState != null && Fields[1, 1] == secondState && Fields[2, 0] == secondState)
            {
                return secondState;
            }

            return null;
        }

        private FieldState? GetColumnWinner()
        {
            for (int x = 0; x < 3; x++)
            {
                var firstState = Fields[x, 0];
                if (firstState != null && Fields[x, 1] == firstState && Fields[x, 2] == firstState)
                {
                    return firstState;
                }
            }

            return null;
        }

        private FieldState? GetRowWinner()
        {
            for (int y = 0; y < 3; y++)
            {
                var firstState = Fields[0, y];
                if (firstState != null && Fields[1, y] == firstState && Fields[2, y] == firstState)
                {
                    return firstState;
                }
            }
            return null;
        }
    }
}
