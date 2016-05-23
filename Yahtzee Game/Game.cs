using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {

    public enum ScoreType {
        Ones, Twos, Threes, Fours, Fives, Sixes,
        SubTotal, BonusFor63Plus, SectionATotal,
        ThreeOfAKind, FourOfAKind, FullHouse,
        SmallStraight, LargeStraight, Chance, Yahtzee,
        YahtzeeBonus, SectionBTotal, GrandTotal
    }

    class Game {
        private Player[] players;
        private int currentPlayerIndex;
        private Player currentPlayer;
        private int playersFinished;
        private int numRolls;
        private Form1 form;
        private Label[] dieLabels;

        private Die[] dice = new Die[5];

        public Game(Form1 form) {
            
        }
        public void NextTurn() {
            //
        }
        public void RollDice() {

            //     for (int i = 0; i < 6; i++) {
            //        if (dice[i] == Die.active) {
            //            Die.Roll();
            //       }
            //   }

            if (numRolls == 0){
                //labelMessage.Text = "Roll 1";
                //Need to link Form1
            }
            if (numRolls == 1 || numRolls == 2) {
                //labelMessage.Text = "Roll" + numRolls + 1 + "or choose a combination to score";
            }

            if (numRolls == 3) {
                //labelMessage.Text = "Choose a combination to score";
            }
            else {
                //labelMessage.Text = "Your turn has ended - click OK"
                //Enable OK button
            }
            numRolls++;
        }
        public void HoldDie(int dice) {
            //
        }
        public void ReleaseDie(int dice) {
            //
        }
        public void ScoreCombination(ScoreType combination) {
            //Waiting for subclasses of score to be implemented
            form.ShowOKButton();
        }
        public static void Load(Form1 form) {
            //Needs to be implemented
        }
        public void Save() {
            //Needs to be implemented
        }
    }
}
