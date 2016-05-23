using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    class FixedScore : Combination {

        private ScoreType scoreType;

        public FixedScore(ScoreType scoreType, Label scoreLabel) : base(scoreLabel) {

        }

        public override void CalculateScore(int[] dieValues) {
            Array.Sort(dieValues);

            //Implement from Part D
        }
    }
}
