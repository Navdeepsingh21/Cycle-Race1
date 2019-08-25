using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace Cycle_Race
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            // Setting defalt data for Gambler
            Data.bettor[0] = new BetPlacer() { cash = 50, label = player1Bet, btnRadio = nick_radio, name = Data.bettors[0] };
            Data.bettor[1] = new BetPlacer() { cash = 50, label = player2Bet, btnRadio = nicolas_radio, name = Data.bettors[1] };
            Data.bettor[2] = new BetPlacer() { cash = 50, label = player3Bet, btnRadio = creamie_radio, name = Data.bettors[2] };

            // Setting default data for cyclists
            Data.cyclist[0] = new Cyclists() { name = "black", cycle = cycleBlack, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleBlack.Left };
            Data.cyclist[1] = new Cyclists() { name = "green", cycle = cycleBlue, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleBlue.Left };
            Data.cyclist[2] = new Cyclists() { name = "red", cycle = cycleRed, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleRed.Left };
            Data.cyclist[3] = new Cyclists() { name = "yellow", cycle = cycleYellow, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleYellow.Left };

            // Updating labels for default text on startup
            Data.bettor[0].UpdateLabels();
            Data.bettor[1].UpdateLabels();
            Data.bettor[2].UpdateLabels();


            // Adding Cyclists into combobox
            this.cyclists.FormattingEnabled = true;
            this.cyclists.Items.AddRange(new object[] {
                "black",
                "green",
                "red",
                "yellow"
            });
        }

        // Updating position of cycles every tick
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.cyclist.Length; i++)
            {
                Data.cyclist[Data.random.Next(0, 4)].startRace();
                if (Data.cyclist[i].startRace())
                {
                    // Stopping the timer once first cycle hits the finish line
                    timer.Stop();
                    // Disabling the timer
                    timer.Enabled = false;
                    // Displaying messagebox with winning cyclists
                    MessageBox.Show(Data.cyclist[i].name + " has won the race.");
                    Data.winningCyclist = Data.cyclist[i].name;
                    i = Data.cyclist.Length;
                    // Re-Enabling the begin race button once the race finishes
                    beginRace.Enabled = true;
                    // Updating cash for all cyclists
                    for (int j = 0; j < Data.bettor.Length; j++)
                    {
                        Data.bettor[j].Collect(Data.winningCyclist);
                    }

                    // Moving all cycles to start position
                    for (int k = 0; k < Data.cyclist.Length; k++)
                    {
                        Data.cyclist[k].TakeStartPosition();
                    }

                    // Resetting betting
                    Data.player1 = 0;
                    Data.player2 = 0;
                    Data.player3 = 0;
                    Data.betPlaced = false;
                }
            }
        }

        // BEGINING THE RACE
        private void BeginRace_Click(object sender, EventArgs e)
        {
            // Makes sure the cycles are on start position
            for (int j = 0; j < Data.cyclist.Length; j++)
            {
                Data.cyclist[j].TakeStartPosition();
            }
            // Disables start button to avoid start spamming
            beginRace.Enabled = false;
            // Start's the timer
            timer.Start();
        }

        // Place Bet
        private void PlaceBet_Click(object sender, EventArgs e)
        {
            // Checks which gambler is selected
            if (currentBetter.Text == Data.bettors[0])
            {
                // If it's first gambler: Checks if he has already placed a bet
                if (Data.player1 == 0)
                {
                    Data.betPlaced = Data.bettor[0].PlaceBet(Convert.ToInt16(bettingAmount.Value), cyclists.Text.ToString());
                    if (Data.betPlaced)
                    {
                        Data.player1 = 1;
                    }
                    else
                    {
                        MessageBox.Show(Data.bettors[0] + " has already placed a bet");
                    }
                }
            }
            else if (currentBetter.Text == Data.bettors[1])
            {
                // If it's second gambler: Checks if he has already placed a bet
                if (Data.player2 == 0)
                {
                    Data.betPlaced = Data.bettor[1].PlaceBet(Convert.ToInt16(bettingAmount.Value), cyclists.Text.ToString());
                    if (Data.betPlaced)
                    {
                        Data.player2 = 1;
                    }
                    else
                    {
                        MessageBox.Show(Data.bettors[1] + " has already placed a bet");

                    }
                }
            }
            else if (currentBetter.Text == Data.bettors[2])
            {
                // If it's third gambler: Checks if he has already placed a bet
                if (Data.player3 == 0)
                {
                    Data.betPlaced = Data.bettor[2].PlaceBet(Convert.ToInt16(bettingAmount.Value), cyclists.Text.ToString());
                    if (Data.betPlaced)
                    {
                        Data.player3 = 1;
                    }
                    else
                    {
                        MessageBox.Show(Data.bettors[2] + " has already placed a bet");
                    }
                }
            }
        }

        private void CycleBlack_Click(object sender, EventArgs e)
        {

        }

        // SETTING RADIO BUTTONS FOR WHICH GAMBLER IS SELECTED : START
        private void CreaamieRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (creamie_radio.Enabled)
                currentBetter.Text = Data.bettors[2];
        }

        private void NicolasRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (nicolas_radio.Enabled)
                currentBetter.Text = Data.bettors[1];
        }

        private void NickRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (nick_radio.Enabled)
                currentBetter.Text = Data.bettors[0];
        }
        // SETTING RADIO BUTTONS FOR WHICH GAMBLER IS SELECTED : END
    }
}
