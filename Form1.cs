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

            Data.bettor[0] = new BetPlacer() { cash = 50, label = player1Bet, btnRadio = radioButton1, name = Data.bettors[0] };
            Data.bettor[1] = new BetPlacer() { cash = 50, label = player2Bet, btnRadio = radioButton2, name = Data.bettors[1] };
            Data.bettor[2] = new BetPlacer() { cash = 50, label = player3Bet, btnRadio = radioButton3, name = Data.bettors[2] };

            Data.cyclist[0] = new Cyclists() { name = "Julian ALAPHILIPPE", cycle = cycleBlack, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleBlack.Left };
            Data.cyclist[1] = new Cyclists() { name = "Egan Arley BERNAL GÓMEZ", cycle = cycleBlue, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleBlue.Left };
            Data.cyclist[2] = new Cyclists() { name = "Jakob FUGLSANG", cycle = cycleRed, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleRed.Left };
            Data.cyclist[3] = new Cyclists() { name = "Primož ROGLIČ", cycle = cycleYellow, raceTrackLength = raceTrack.Width - cycleBlack.Width, startingPosition = cycleYellow.Left };

            Data.bettor[0].UpdateLabels();
            Data.bettor[1].UpdateLabels();
            Data.bettor[2].UpdateLabels();

            this.cyclists.FormattingEnabled = true;
            this.cyclists.Items.AddRange(new object[] {
                "Julian ALAPHILIPPE",
                "Egan Arley BERNAL GÓMEZ",
                "Jakob FUGLSANG",
                "Primož ROGLIČ"
            });
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.cyclist.Length; i++)
            {
                Data.cyclist[Data.random.Next(0, 4)].startRace();
                if (Data.cyclist[i].startRace())
                {
                    timer.Stop();
                    timer.Enabled = false;
                    MessageBox.Show(Data.cyclist[i].name + " has won the race.");
                    Data.winningCyclist = Data.cyclist[i].name;
                    i = Data.cyclist.Length;
                    beginRace.Enabled = true;
                    for (int j = 0; j < Data.bettor.Length; j++)
                    {
                        Data.bettor[j].Collect(Data.winningCyclist);
                    }
                    for (int k = 0; k < Data.cyclist.Length; k++)
                    {
                        Data.cyclist[k].TakeStartPosition();
                    }
                    Data.player1 = 0;
                    Data.player2 = 0;
                    Data.player3 = 0;
                    Data.betPlaced = false;
                }
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Enabled)
                currentBetter.Text = Data.bettors[0];
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Enabled)
                currentBetter.Text = Data.bettors[1];
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Enabled)
                currentBetter.Text = Data.bettors[2];
        }

        private void BeginRace_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < Data.cyclist.Length; j++)
            {
                Data.cyclist[j].TakeStartPosition();
            }
            beginRace.Enabled = false;
            timer.Start();
        }

        private void PlaceBet_Click(object sender, EventArgs e)
        {
            if (currentBetter.Text == Data.bettors[0])
            {
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
    }
}
