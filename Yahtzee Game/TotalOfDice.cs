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
            //Use Part D to complete
        }

        public override void CalculateScore(int[] temp) {
            
        }
    }
}
