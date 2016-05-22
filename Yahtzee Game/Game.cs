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
        private Die[] dice;
        private int playersFinished;
        private int numRolls;
        private Form1 form;
        private Label[] dieLabels;

        public Game(Form1 form) {
            //
        }
        public void NextTurn() {
            //
        }
        public void RollDice() {
            //if (numRolls == 0) {
            //    //labelMessage.Text = "Roll 1";
            //}
            //else if (numRolls == 1) {
            //    //labelMessage.Text = "Roll 2 or choose a combination to score";
            //}
            //else if (numRolls == 2) {
            //    //labelMessage.Text = "Roll 3 or choose a combination to score";
            //}
            //else if (numRolls == 3) {
            //    //labelMessage.Text = "Choose a combination to score";
            //}
            //else{
            //    //labelMessage.Text = "Your turn has ended - click OK"
            //    //Enable OK button
            //}
            //numRolls++;
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
