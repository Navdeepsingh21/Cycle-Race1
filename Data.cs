using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle_Race
{
    abstract class Data
    {
        // Variables holding live data
        public static BetPlacer[] bettor = new BetPlacer[3];
        public static Cyclists[] cyclist = new Cyclists[4];
        public static string winningCyclist;
        public static Random random = new Random();
        public static string[] bettors = new string[3] { "Nick", "Nicolas", "Creamie" };          // bettors name
        public static int player1 = 0, player2 = 0, player3 = 0;
        public static bool betPlaced;
    }
}
