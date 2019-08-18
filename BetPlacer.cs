using System.Windows.Forms;

namespace Cycle_Race
{
    public class BetPlacer
    {
        public Bet bet;
        public int cash { get; set; }
        public RadioButton btnRadio { get; set; }
        public Label label { get; set; }
        public int amount { get; set; }
        public string name { get; set; }

        // Updates the labels for radio button
        public void UpdateLabels()
        {
            btnRadio.Text = name + " has $" + cash;
        }

        // Clear's all the previous bets and labels
        public void ClearBet()
        {
            bet = null;
            label.Text = name + " hasn't placed a bet!";
        }

        // Place the bet
        public bool PlaceBet(int betAmount, string winningCyclist)
        {
            this.bet = new Bet() { amount = betAmount, betPlacer = this, cyclist = winningCyclist };
            // Only proceeds if the bid amount is less than or equal to the cash bidder is holding
            if (betAmount <= cash)
            {
                label.Text = this.name + " bets $" + betAmount + " on " + winningCyclist;
                this.UpdateLabels();
                return true;
            }
            else
            {
                // If the amount is more than player holds, give warning pop up message
                MessageBox.Show(name + " does not have enough money to cover the bet.");
                return false;
            }
        }

        // Transfer the amount winning amount to bidder's account
        public void Collect(string winner)
        {
            if (bet != null)
            {
                cash += bet.Payout(winner);
            }
            ClearBet();
            UpdateLabels();
        }
    }
}
