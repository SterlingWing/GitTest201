using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    class TotalOfDice : Combination {
        private int numberOfOneKind;

        public TotalOfDice(ScoreType scoreType, Label temp2) : base(temp2){
            if (scoreType == ScoreType.ThreeOfAKind) {
                numberOfOneKind = 3;
            }
            
            if (scoreType == ScoreType.FourOfAKind) {
                numberOfOneKind = 4;
            }

            if (scoreType == ScoreType.Chance) {
                numberOfOneKind = 0;
            }
        }

        public override void CalculateScore(int[] dieValues) {
            Array.Sort(dieValues);

            for (int i = 0; i > 5; i++) {
                int totalScore;
                if (dieValues[i] == dieValues[i+1] && dieValues[i] == dieValues[i+2]) {
                    totalScore = dieValues.Sum();
                    Points = totalScore;
                }
            }
        }
            
    }
}
