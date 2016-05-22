using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //private Label[] dieLabels;

        public Game() {
            /*
            * Game(Form1) is the constructor which will initialize all instance variables of Game in
            * preparation for a game to begin in the correct state. [Recall from Part B that this constructor
            * is called from StartNewGame() of Form1.]
            */
        }
        public void NextTurn() {

        }
        public void HoldDice() {

        }
        public void HoldDie(int dice) {

        }
        public void ReleaseDie(int dice) {

        }
        public void ScoreCombination(ScoreType combination) {

        }
        public static void Load(Form1 form) {
            //Needs to be implemented
        }
        public void Save() {
            //Needs to be implemented
        }
    }
}
