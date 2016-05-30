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

        }

        public override void CalculateScore(int[] dieValues) {
            
        }
    }
}
