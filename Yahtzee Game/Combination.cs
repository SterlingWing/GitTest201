using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {

    /// <summary>
    /// An abstract subclass of Score which represents a single die combination.
    /// </summary>
    abstract class Combination : Score {
        protected bool isYahtzee;
        protected int yahtzeeNumber;

        public Combination(Label label) : base(label){

        }//end Combination Constructor

        public abstract void CalculateScore(int[] diceValues);

        public void Sort(int[] values) {
            Array.Sort(values);
        }//end Sort

        public bool IsYahtzee {
            get {
                return isYahtzee;
            }
            set {
                isYahtzee = value;
            }
        }//end IsYahtzee

        public int YahtzeeNumber {
            get {
                return yahtzeeNumber;
            }
            set {
                yahtzeeNumber = value;
            } 
        }//end YahtzeeNumber

        public void CheckForYahtzee(int[] temp) {

        }//end CheckForYahtzee
    }
}
