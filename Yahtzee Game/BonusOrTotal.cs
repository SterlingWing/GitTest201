using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {

    /// <summary>
    /// Represents either the bonuses, sub-total or total score of a section.
    /// </summary>
    class BonusOrTotal : Score {
        public BonusOrTotal(Label scoreTotals) : base(scoreTotals) {

        }//end BonusOrTotal Constructor
    }//end BonusOrTotal Class
}
