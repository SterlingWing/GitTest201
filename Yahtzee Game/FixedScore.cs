using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {

    /// <summary>
    /// Represents all scoring combinations that have a fixed number as their score.
    /// Includes: Small Straight, Large Straight, Full House and Yahtzee
    /// </summary>
    [Serializable]
    class FixedScore : Combination {
        private ScoreType scoreType;

        public FixedScore(ScoreType selectedScoreType, Label temp) : base(temp) {
            scoreType = selectedScoreType;
        }//end FixedScore Constructor

        public override void CalculateScore(int[] dieValues) {
            Sort(dieValues); // sort dieValues array to be in ascending order

            //Large Straight
            if (scoreType == ScoreType.LargeStraight) {

                int[] uniqueDieValues = dieValues.Distinct().ToArray(); // remove duplicate dievalues and place in uniqueDieValues array

                //Will search through uniqueDieValues array for dievalues 1,2,3,4,5 or 2,3,4,5,6
                if (uniqueDieValues.Length == 5) {
                    if (((uniqueDieValues[0] == 1 &&
                          uniqueDieValues[1] == 2 &&
                          uniqueDieValues[2] == 3 &&
                          uniqueDieValues[3] == 4 &&
                          uniqueDieValues[4] == 5) ||

                          uniqueDieValues[0] == 2 &&
                          uniqueDieValues[1] == 3 &&
                          uniqueDieValues[2] == 4 &&
                          uniqueDieValues[3] == 5 &&
                          uniqueDieValues[4] == 6)) {
                        Points = 40;
                    } else {
                        Points = 0;
                    }
                } else {
                    Points = 0;
                }

                    //Small Straight
                } else if (scoreType == ScoreType.SmallStraight) {
                int[] uniqueDieValues = dieValues.Distinct().ToArray(); // remove duplicate dievalues and place in uniqueDieValues array

                //Will search through uniqueDieValues array for dievalues 1,2,3,4 or 2,3,4,5 or 3,4,5,6
                if (uniqueDieValues.Length >= 4) {
                    if (((uniqueDieValues[0] == 1 &&
                          uniqueDieValues[1] == 2 &&
                          uniqueDieValues[2] == 3 &&
                          uniqueDieValues[3] == 4) ||

                          uniqueDieValues[0] == 2 &&
                          uniqueDieValues[1] == 3 &&
                          uniqueDieValues[2] == 4 &&
                          uniqueDieValues[3] == 5) ||

                          uniqueDieValues[0] == 3 &&
                          uniqueDieValues[1] == 4 &&
                          uniqueDieValues[2] == 5 &&
                          uniqueDieValues[3] == 6) {
                        Points = 30;
                    } else {
                        Points = 0;
                    }
                } else {
                    Points = 0;
                }

            //Full House
            } else if (scoreType == ScoreType.FullHouse) {
                int duplicateValues = dieValues.Distinct().Count();
                if (duplicateValues < 3) {
                    Points = 25;
                } else {
                    Points = 0;
                }

            //Yahtzee
            } else if (scoreType == ScoreType.Yahtzee) {
                int duplicateValues = dieValues.Distinct().Count();

                if (duplicateValues == 1) {
                    Points = 50;
                } else {
                    Points = 0;
                }
            }
          }//end CalculateScore
    }//end FixedScore Class
}
