using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle_Race
{
    public class Bet
    {
        public int amount { get; set; }
        private int winningMultiplier = 2;          // This value holds the value for how much does player win( money wil double)
        public string cyclist { get; set; }
        public BetPlacer betPlacer = new BetPlacer();

        // Set's default labels
        public string GetDescription()
        {
            if (amount == 0)
                return betPlacer.name + " hasn't placed a bet.";
            else
                return betPlacer.name + " placed bet of $" + amount + " on " + cyclist;
        }

        // Calculate the winning or losing amount
        public int Payout(string winner)
        {
            if (winner == cyclist)
                return amount * winningMultiplier;
            else
                return (0 - amount);
        }
    }
}
