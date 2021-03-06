﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Yahtzee_Game {

    /// <summary>
    /// Represents a player within the game.
    /// </summary>
    [Serializable]
    class Player {
        private string name;
        private int combinationsToDo = 13;
        private Score[] scores = new Score[19];
        private int grandTotal = 0;
        private bool accessed = false; //Tells the program if player has used their bonus 63 score

        public Player(string name, Label[] scoreTotals) {
            this.name = name;

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

                    case ScoreType.SubTotal: case ScoreType.BonusFor63Plus: case ScoreType.SectionATotal:
                    case ScoreType.YahtzeeBonus: case ScoreType.SectionBTotal: case ScoreType.GrandTotal:
                        scores[(int)scoreCombo] = new BonusOrTotal(scoreTotals[(int)scoreCombo]);
                        break;
                }
            }
        }//end Player Constructor

        public string Name { 
            get {
                return name;
            }
            set {
                name = value;
            }
        }//end Name

        public void ScoreCombination(ScoreType combination, int[] dice) {

            Score score = scores[(int)combination];
            ((Combination)(score)).CalculateScore(dice);
            combinationsToDo--;
            UpdateScoreTotals(score, combination);
            UpdateGrandTotal(score);
        }//end ScoreCombination



        public int GrandTotal {
            get {
                return grandTotal;
            }
            set {
                grandTotal = value;
            }
        }//end GrandTotal

        public bool IsAvailable(ScoreType combination) {
            if (scores[(int)combination].Done == true) {
                return false;
            }
            else {
                return true;
            }
        }//end IsAvailable

        public void ShowScores() {
            foreach (Score i in scores) {
                if (i != null) {
                    i.ShowScore();
                }
            }
        }//end ShowScores

        public bool IsFinished() {
            if (combinationsToDo == 0) {
                return true;
            } else {
                return false;
            }
        }//end IsFinished

        public void Load(Label[] scoreTotals) {
            for (int i = 0; i < scores.Length; i++) {
                scores[i].Load(scoreTotals[i]);
            }
        }//end Load
         
        
         /// <summary>
         /// Updates all the totals on the GUI excluding the GrandTotal value.
         /// </summary>
         /// <param name="score"></param>
         /// <param name="combination"></param>
        private void UpdateScoreTotals(Score score, ScoreType combination) {
            if ((int)combination < 6) {
                scores[6].Points = scores[6].Points + score.Points;
            }
            else if ((int)combination > 8) {
                scores[17].Points = scores[17].Points + score.Points;
            }

            if (scores[6].Points >= 63 && accessed == false) {
                accessed = true;
                scores[7].Points = scores[7].Points + 35;
                scores[8].Points = scores[6].Points + scores[7].Points;
            }
        }//end UpdateScoreTotals

        /// <summary>
        /// Updates the grandTotal variable and updates GrandTotal score to equal grandTotal.
        /// </summary>
        /// <param name="score"></param>
        private void UpdateGrandTotal(Score score) {
            GrandTotal = scores[6].Points + scores[7].Points + scores[16].Points + scores[17].Points;
            scores[18].Points = GrandTotal;


        }//end UpdateGrandTotal
    }//end Player Class
}

