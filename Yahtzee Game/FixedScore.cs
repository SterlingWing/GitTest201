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
            scoreType = selectedScoreType;
        }

        public override void CalculateScore(int[] dieValues) {
            Sort(dieValues);

                for (int i = 0; i < 5; i++) {
                    if (scoreType == ScoreType.SmallStraight) {
                        if (dieValues[i] == dieValues[i + 1] &&
                            dieValues[i + 1] == dieValues[i + 2]) {
                            Points = 30;
                        }
                    } else if (scoreType == ScoreType.LargeStraight) {
                    if (dieValues[i] == dieValues[i + 1] &&
                        dieValues[i + 1] == dieValues[i + 2] &&
                        dieValues[i + 2] == dieValues[i + 3]) {
                        Points = 40;
                    }
                    else {
                        Points = 0;
                    }
                }
                
                //Full House
                if (scoreType == ScoreType.FullHouse) {
                    int repeatValue = 1;
                    int tempValue = 0;

                    for (int j = 0; j < 5; j++) {

                        while (j < 4) {
                            tempValue = dieValues[j + 1];
                        }

                        if (dieValues[j] == tempValue) {
                            repeatValue++;
                        }
                    }
                    if (repeatValue == 5) {
                        Points = 25;
                    }
                    else {
                        Points = 0;
                    }
                }
            }
        }
    }
}
