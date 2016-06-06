using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    class CountingCombination : Combination{
        private int dieValue;

        public CountingCombination(ScoreType selectedScoreType, Label temp2) : base(temp2) {
            dieValue = (int)selectedScoreType + 1;
        }

        public override void CalculateScore(int[] diceValues) {
            int dieCount = 0;
            for (int i = 0; i < 5; i++) {
                if (diceValues[i] == dieValue) {
                    dieCount++;
                }
            }
            Points = dieCount * dieValue;
        }
    }
}
