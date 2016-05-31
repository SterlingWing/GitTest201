using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    class FixedScore : Combination {
        private ScoreType scoreType;

        public FixedScore(ScoreType selectedScoreType, Label temp) : base(temp) {

        }

        public override void CalculateScore(int[] dieValues) {
            Array.Sort(dieValues);

            //Small Straight
            for (int i = 0; i < 6; i++) {
                if (dieValues[i] == dieValues[i+1] &&
                    dieValues[i+1] == dieValues[i+2]) {
                    Points = 30;
                }

                //Large Straight
                if (dieValues[i] == dieValues[i+1] &&
                    dieValues[i+1] == dieValues[i+2] &&
                    dieValues[i+2] == dieValues[i+3]) {
                    Points = 40;
                } else {
                    Points = 0;
                }

                //Full House

            }
        }
    }
}
