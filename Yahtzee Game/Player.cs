﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    class Player {
        private string name;
        private int combinationsToDo;
        private Score[] scores = new Score[19];
        private int grandTotal;

        public Player(string name, Score score) {
            this.Name = name;
            //grandTotal = score;
            
            for (ScoreType scoreCombo = ScoreType.Ones; scoreCombo <= ScoreType.GrandTotal; scoreCombo++) {
                switch (scoreCombo) {
                    case ScoreType.Ones: case ScoreType.Twos: case ScoreType.Threes: case ScoreType.Fours:
                    case ScoreType.Fives: case ScoreType.Sixes:

                        break;
                        

                }
            }
        }

        public string Name { 
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        public void ScoreCombination(ScoreType combination, int[] dice) {
        }

        public int GrandTotal {
            get {
                return grandTotal;
            }
            set {
                grandTotal = value;
            }
        }

        public bool IsAvailable(ScoreType combination) {
            return true;
        }

        public void ShowScores() {

        }

        public bool IsFinished() {
            if (combinationsToDo == 0) {
                return true;
            } else {
                return false;
            }

        }

        public void Load(Label[] temp) {

        }
    }
}
