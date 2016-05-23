using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    class CountingCombination : Combination{
        private int dieValue;

        public CountingCombination(ScoreType combination, Label temp2) : base(temp2) {
            //Needs to be implemented from Part D
        }

        public override void CalculateScore(int[] diceValues) {
            int dieCount = 0;
            int score;

            for (int i = 0; i < 6; i++) {
                if (diceValues[i] == dieValue) {
                    dieCount++;
                }
            }

            score = dieCount * dieValue;
        }
    }
}
