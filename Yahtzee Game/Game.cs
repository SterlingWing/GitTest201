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
        private int numRolls = 0;
        private int currentRoll = 1;
        private Form1 form;
        private Label[] dieLabels;



        public Game(Form1 form) {
            dice = new Die[5];
            this.form = form;
            dieLabels = form.GetDice();

           for (int i = 0; i < 5; i++)
           {
               dice[i] = new Die(dieLabels[i]);
           }

            players = new BindingList<Player>();
            for (int i = 0; i < 7; i++) {
                //players.Add(new Player("player" + i, ));
            }

        }
        public void NextTurn() {
            for (int i = 0; i < players.Count; i++) {
                form.ShowPlayerName("player" + i);
                currentPlayerIndex = i;
                currentPlayer = players[i];
                form.EnableCheckBoxes();
                //player.showScores();
            }
            
            //updates currentPlyer and currentPlayerIndex to be the next player to play their turn
            //updates the GUI so that this player can start their turn.
            //This method involves setting GUI to change player's name and display their corresponding scores etc.

        }
        public void RollDice() {

            for (int i = 0; i < 5; i++) {
                if (dice[i].Active == true) {
                        dice[i].Roll();
                }
            }

            if (numRolls == 0) {
                string firstRoll = "roll 1";
                form.ShowMessage(firstRoll);
            }
            else if (numRolls == 1 || numRolls == 2) {
                string secondAndThirdRoll = ("Roll " + currentRoll + " or choose a combination to score");
                form.ShowMessage(secondAndThirdRoll);
            }

            else if (numRolls == 3) {
                string afterThirdRoll = "Choose a combination to score";
                form.ShowMessage(afterThirdRoll);
            }
            else {
                string endTurn = "Your turn has ended - click OK";
                form.ShowMessage(endTurn);
                form.ShowOKButton();
            }
            numRolls++;
            currentRoll++;
        }
        public void HoldDie(int index) {
            dice[index].Active = false;
        }
        public void ReleaseDie(int index) {
            dice[index].Active = true;
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
