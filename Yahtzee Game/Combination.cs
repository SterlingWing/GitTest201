using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    abstract class Combination : Score {
        protected bool isYahtzee;
        protected int yahtzeeNumber;

        public Combination(Label label) : base(label){

        }

        public abstract void CalculateScore(int[] diceValues);

        public void Sort(int[] values) {
            Array.Sort(values);
        }

        public bool IsYahtzee {
            get {
                return isYahtzee;
            }
            set {
                isYahtzee = value;
            }
        }

        public int YahtzeeNumber {
            get {
                return yahtzeeNumber;
            }
            set {
                yahtzeeNumber = value;
            } 
        }

        public void CheckForYahtzee(int[] temp) {

        }
    }
}
