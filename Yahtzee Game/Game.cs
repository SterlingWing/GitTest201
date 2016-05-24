using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Yahtzee_Game {

    public enum ScoreType {
        Ones, Twos, Threes, Fours, Fives, Sixes,
        SubTotal, BonusFor63Plus, SectionATotal,
        ThreeOfAKind, FourOfAKind, FullHouse,
        SmallStraight, LargeStraight, Chance, Yahtzee,
        YahtzeeBonus, SectionBTotal, GrandTotal
    }

    class Game {
        private BindingList<Player> players;
        private int currentPlayerIndex;
        private Player currentPlayer;
        private Die[] dice;
        private int playersFinished;
        private int numRolls;
        private Form1 form;
        private Label[] dieLabels;



        public Game(Form1 form) {
            dice = new Die[5];
            form = new Form1();
            dieLabels = new Label[5];
            players = new BindingList<Player>();
            for (int i = 0; i < 7; i++){
                //players.Add();
            }

            //form.playerSetCount.Value;
            
            
        }
        public void NextTurn() {
            //updates currentPlyer and currentPlayerIndex to be the next player to play their turn
            //updates the GUI so that this player can start their turn.
            //This method involves setting GUI to change player's name and display their corresponding scores etc.
        }
        public void RollDice() {

            for (int i = 0; i < 6; i++) {
                if (dice[i].Active == true) {
                        dice[i].Roll();
                }
            }

            if (numRolls == 0){
                string firstRoll = "roll 1";
                form.ShowMessage(firstRoll);
            }
            if (numRolls == 1 || numRolls == 2) {
                string secondAndThirdRoll = ("Roll" + numRolls + 1 + "or choose a combination to score");
                form.ShowMessage(secondAndThirdRoll);
            }

            if (numRolls == 3) {
                string afterThirdRoll = "Choose a combination to score";
                form.ShowMessage(afterThirdRoll);
            }
            else {
                string endTurn = "Your turn has ended - click OK";
                form.ShowMessage(endTurn);
                //form.ShowOKButton();
            }
            numRolls++;
        }
        public void HoldDie(int dice) {
            for (int i = 0; dice < 6;)
            {
                //this.dice[dice].active = true;
                //  if (dice.activated == true) {
                //  
                //
                // Try to use above method in RollDice();
                //

        }
        }
        public void ReleaseDie(int dice) {
            //AS ABOVE, although make die inactive instead
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
