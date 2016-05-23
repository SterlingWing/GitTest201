using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    abstract class Score {
        private int points;
        private Label label;
        protected bool done;

        public Score(Label label) {

        }

        public int Points {
            get {
                return points;
            }
            set {
                points = value;
            }
        }

        public bool Done {
            get {
                return done;
            }
        }

        public void ShowScore() {
            if (done) {
                label.Text = Convert.ToString(points);
            } else {
                label.Text = null;
            }

        }

        public void Load(Label label) {

        }
    }
}
