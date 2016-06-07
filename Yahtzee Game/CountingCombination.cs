using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {

    /// <summary>
    /// Represents scoring combinations that count the number of a single die value.
    /// Includes: Scoring combinations in Upper Section
    /// </summary>
    [Serializable]
    class CountingCombination : Combination{
        private int dieValue;

        public CountingCombination(ScoreType selectedScoreType, Label label) : base(label) {
            dieValue = (int)selectedScoreType + 1;
        }//end CountingCombination Constructor

        public override void CalculateScore(int[] diceValues) {
            int dieCount = 0;
            for (int i = 0; i < 5; i++) {
                if (diceValues[i] == dieValue) {
                    dieCount++;
                }
            }
            Points = dieCount * dieValue;
        }//end CalculateScore
    }//end CountingCombination Class
}
