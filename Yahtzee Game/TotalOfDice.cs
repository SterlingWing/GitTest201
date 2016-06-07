using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {

    /// <summary>
    /// Represents all scoring combinations where the score is 
    /// the total of the dice face values.
    /// Includes: 3 of a Kind, 4 of a Kind and Chance.
    /// </summary>
    [Serializable]
    class TotalOfDice : Combination {
        private int numberOfOneKind;

        public TotalOfDice(ScoreType scoreType, Label label) : base(label) {
            if (scoreType == ScoreType.ThreeOfAKind) {
                numberOfOneKind = 3;
            }

            if (scoreType == ScoreType.FourOfAKind) {
                numberOfOneKind = 4;
            }

            if (scoreType == ScoreType.Chance) {
                numberOfOneKind = 0;
            }
        }//end TotalOfDice Constructor

        public override void CalculateScore(int[] dieValues) {
            Sort(dieValues);

            if (numberOfOneKind == 3) {
                int duplicateValues = dieValues.Distinct().Count();

                if (duplicateValues <= 3) {
                    Points = dieValues.Sum();
                    }
                 else {
                     Points = 0;
                 }

            } else if (numberOfOneKind == 4) {
                int duplicateValues = dieValues.Distinct().Count();
                if (duplicateValues <= 2) {
                    Points = dieValues.Sum();
                }
                else {
                    Points = 0;
                }

            } else if (numberOfOneKind == 0) {
                        Points = dieValues.Sum();
                }
        }//end CalculateScore
    }//end TotalOfDice Class
}
