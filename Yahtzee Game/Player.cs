using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Yahtzee_Game {
    class Player {
        private string name;
        private int combinationsToDo = 13;
        private Score[] scores = new Score[18];
        private int grandTotal;

        


        public Player(string name, Label[] scoreTotals) {
            this.name = name;
            //this.grandTotal;

            for (ScoreType scoreCombo = ScoreType.Ones; scoreCombo <= ScoreType.GrandTotal; scoreCombo++) {
                switch (scoreCombo) {
                    case ScoreType.Ones: case ScoreType.Twos: case ScoreType.Threes: case ScoreType.Fours:
                    case ScoreType.Fives: case ScoreType.Sixes:
                        scores[(int)scoreCombo] = new CountingCombination(scoreCombo, scoreTotals[(int)scoreCombo]);
                        break;

                    case ScoreType.SmallStraight: case ScoreType.LargeStraight: case ScoreType.FullHouse:
                    case ScoreType.Yahtzee:
                        scores[(int)scoreCombo] = new FixedScore(scoreCombo, scoreTotals[(int)scoreCombo]);
                        break;

                    case ScoreType.ThreeOfAKind: case ScoreType.FourOfAKind: case ScoreType.Chance:
                        scores[(int)scoreCombo] = new TotalOfDice(scoreCombo, scoreTotals[(int)scoreCombo]);
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
            //scores[(int)combination].CountingCombination.CalculateScore(dice);
            //(scores[(int)combination]).
            Score score = scores[(int)combination];

            ((Combination)(score)).CalculateScore(dice);
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
            foreach (Score i in scores) {
                if (i != null) {
                    i.ShowScore();
                }
            }
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

        public BindingList<Player> players {
            get {
                return players;
            }
        }
    }
}
