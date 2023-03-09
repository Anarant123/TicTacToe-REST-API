using TicTacToe.Models.db;

namespace TicTacToe
{
    public static class StatusGame
    {
        public static void status_check(Game game)
        {
            bool flag = false;

            if (game._1 == game._2 && game._2 == game._3 ||
                    game._4 == game._5 && game._5 == game._6 ||
                    game._7 == game._8 && game._8 == game._9 ||
                    game._1 == game._4 && game._5 == game._7 ||
                    game._2 == game._5 && game._5 == game._8 ||
                    game._3 == game._6 && game._6 == game._9 ||
                    game._1 == game._5 && game._5 == game._9 ||
                    game._3 == game._5 && game._5 == game._7)
            {
                flag = true;
                game.Winner = game.LustMove;
            }
            else if (game.CountOfMoves == 9 && flag == false)
                game.Winner = "Tie";
        }
    }
}
