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
            if (selectedScoreType == ScoreType.Ones) {
                dieValue = 1;
            } else if (selectedScoreType == ScoreType.Twos) {
                dieValue = 2;
            } else if (selectedScoreType == ScoreType.Threes) {
                dieValue = 3;
            } else if (selectedScoreType == ScoreType.Fours) {
                dieValue = 4;
            } else if (selectedScoreType == ScoreType.Fives) {
                dieValue = 5;
            } else if (selectedScoreType == ScoreType.Sixes) {
                dieValue = 6;
            }
        }

        public override void CalculateScore(int[] diceValues) {
            int dieCount = 0;
            for (int i = 0; i < 6; i++) {
                if (diceValues[i] == dieValue) {
                    dieCount++;
                }
            }
            Points = dieCount * dieValue;
        }
    }
}
