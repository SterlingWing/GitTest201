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

                int[] uniqueDieValues = dieValues.Distinct().ToArray();

                if (uniqueDieValues.Length <= 2) {
                    Points = 0;
                }
                else if (uniqueDieValues.Length == 3) {
                    if (uniqueDieValues[0] == uniqueDieValues[1] - 1 && uniqueDieValues[1] == uniqueDieValues[2] - 1) {
                        Points = 30;
                    } else {
                        Points = 0;
                    }
                }
                else if (uniqueDieValues.Length == 4) {
                    if (uniqueDieValues[0] == uniqueDieValues[1] - 1 && uniqueDieValues[1] == uniqueDieValues[2] - 1 ||
                        uniqueDieValues[1] == uniqueDieValues[2] - 1 && uniqueDieValues[2] == uniqueDieValues[3] - 1) {
                        Points = 30;
                    } else {
                        Points = 0;
                    }
                }
                else if (uniqueDieValues.Length == 5) {
                    Points = 30;
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

            else if (scoreType == ScoreType.LargeStraight) {
                int[] uniqueDieValues = dieValues.Distinct().ToArray();
                if (((uniqueDieValues[0] == 1 &&
                      uniqueDieValues[1] == 2 &&
                      uniqueDieValues[2] == 3 &&
                      uniqueDieValues[3] == 4) ||

                      uniqueDieValues[0] == 2 &&
                      uniqueDieValues[1] == 3 &&
                      uniqueDieValues[2] == 4 &&
                      uniqueDieValues[3] == 5)) {
                            Points = 40;
                        } else {
                            Points = 0;
                        }
                }



            else if (scoreType == ScoreType.FullHouse) {
                int duplicateValues = dieValues.Distinct().Count();
                if (duplicateValues < 3) {
                    Points = 25;
                } else {
                    Points = 0;
                }
            }
          }
    }
}
