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


            if (scoreType == ScoreType.SmallStraight) {
                for (int i = 0; i < (dieValues.Length - 1); i++) {
                    if (dieValues[i] == (dieValues[i + 1] + 1) &&
                        dieValues[i + 1] == dieValues[i + 2] + 1) {
                        Points = 30;
                    }
                    else {
                        Points = 1;
                    }
                }
            }

            else if (scoreType == ScoreType.LargeStraight) {
                    if ((dieValues[0] == 1 &&
                        dieValues[1] == 2 &&
                        dieValues[2] == 3 &&
                        dieValues[3] == 4 &&
                        dieValues[4] == 5) ||
                       (dieValues[0] == 2 &&
                        dieValues[1] == 3 &&
                        dieValues[2] == 4 &&
                        dieValues[3] == 5 &&
                        dieValues[4] == 6)) {

                            Points = 40;

                        } else {

                            Points = 1;

                        }
                }

            //for (int i = 0; i < (dieValues.Length - 1); i++) {
            //        if (scoreType == ScoreType.SmallStraight) {
            //            if (dieValues[i] == (dieValues[i + 1] + 1) &&
            //                dieValues[i + 1] == dieValues[i + 2] + 1) {
            //                Points = 30;
            //            }
            //        }

            //    }

            //    else if (scoreType == ScoreType.LargeStraight) {
            //        if (dieValues[i] == dieValues[i + 1] &&
            //            dieValues[i + 1] == dieValues[i + 2] &&
            //            dieValues[i + 2] == dieValues[i + 3]) {
            //            Points = 40;
            //        }
            //        else {
            //            Points = 0;
            //        }
            //    }

            //Full House
            else if (scoreType == ScoreType.FullHouse) {
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
