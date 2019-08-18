using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cycle_Race
{
    public class Cyclists
    {
        public int startingPosition { get; set; }
        public int raceTrackLength { get; set; }
        public string name { get; set; }
        public PictureBox cycle { get; set; }
        public bool winner = false;
        public Random random = new Random();

        // Begin's the race
        public bool startRace()
        {
            // get's the random movement speed
            int movement = random.Next(1, 8);

            // Current position of the cycle
            Point point = cycle.Location;
            // New Position of the cycle
            point.X += movement;
            // Update the position of the cycle
            cycle.Location = point;

            // Checks if cycle has reached the winning line
            if (point.X >= raceTrackLength)
                return true;
            else
                return false;
        }

        // Move all the cycles to starting position
        public void TakeStartPosition()
        {
            cycle.Left = startingPosition;
        }
    }
}
