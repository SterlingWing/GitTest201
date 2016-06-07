using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {

    /// <summary>
    /// Represents a single scoring combination (ScoreType) in a yahtzee game. 
    /// </summary>
    abstract class Score {
        private int points;
        private Label label;
        protected bool done = false;

        public Score(Label label) {
            this.label = label;
        }//end Score Constructor

        public int Points {
            get {
                return points;
            }
            set {
                points = value;
                done = true;
            }
        }//end Points

        public bool Done {
            get {
                return done;
            }
            set {
                done = value;
            }
        }//Done

        public void ShowScore() {
            if (done) {
                label.Text = points.ToString();
            } else {
                label.Text = "";
            }
        }//end ShowScore

        public void Load(Label label) {
            this.label = label;
        } //end Load
    }//end Score Class
}
