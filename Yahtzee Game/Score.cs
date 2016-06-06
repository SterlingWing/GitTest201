﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    abstract class Score {
        private int points;
        private Label label;
        protected bool done = true;

        public Score(Label label) {
            this.label = label;
        }

        public int Points {
            get {
                return points;
            }
            set {
                points = value;
                done = true;
            }
        }

        public bool Done {
            get {
                return done;
            }
            set {
                done = value;
            }
        }

        public void ShowScore() {
            if (done) {
                label.Text = points.ToString();
            } else {
                label.Text = "";
            }
        }

        public void Load(Label label) {

        }
    }
}
