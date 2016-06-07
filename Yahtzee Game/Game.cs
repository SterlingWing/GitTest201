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
        private int numRolls = 1;
        private Form1 form;
        private Label[] dieLabels;
        private const int resetPlayerIndex = 0;
        private string[] labelMessages = { "Roll 1",
                                           "Choose a combination to score",
                                           "Your turn has ended - click OK" };



        public Game(Form1 form) {
            dice = new Die[5];
            this.form = form;
            dieLabels = form.GetDice();

            for (int i = 0; i < 5; i++) {
                dice[i] = new Die(dieLabels[i]);
            }

            players = new BindingList<Player>();
            for (int i = 0; i < 6 /*form.PlayerSetCountReturn()*/; i++) {
                players.Add(new Player(("player " + (i + 1)), form.GetScoresTotals()));
            }

            form.ShowPlayerName("Player 1");
            form.ShowMessage("Roll 1");

            currentPlayerIndex = 0;
            currentPlayer = players[currentPlayerIndex];

            form.playerBindingSource.DataSource = players;


        }
        public void NextTurn() {
            form.ShowMessage(labelMessages[0]);
            currentPlayerIndex++;
            if (currentPlayerIndex == players.Count) {
                currentPlayerIndex = 0;
            }
            numRolls = 1;
            form.DisableAndClearCheckBoxes();
            form.EnableCheckBoxes();
            form.EnableRollButton();
            form.ShowPlayerName("Player " + (currentPlayerIndex + 1));
            currentPlayer = players[currentPlayerIndex];
            currentPlayer.ShowScores();

        }
        public void RollDice() {
            for (int i = 0; i < 5; i++) {
                if (dice[i].Active == true) {
                    dice[i].Roll();
                }
            }

            if (numRolls == 1 || numRolls == 2) {
                string secondAndThirdRoll = ("Roll " + (numRolls + 1) + " or choose a combination to score");
                form.ShowMessage(secondAndThirdRoll);
            }

            else if (numRolls == 3) {
                form.ShowMessage(labelMessages[1]);
            }
            else {
                form.ShowMessage(labelMessages[2]);
                form.ShowOKButton();
            }
            numRolls++;

            if (numRolls == 4) {
                form.DisableRollButton();
            }

        }
        public void HoldDie(int index) {
            dice[index].Active = false;
        }
        public void ReleaseDie(int index) {
            dice[index].Active = true;
        }
        public void ScoreCombination(ScoreType combination) {
            if (currentPlayer.IsAvailable(combination) == true) {
                int[] dieValuesArray;
                dieValuesArray = intDiceArray(combination);
                currentPlayer.ScoreCombination(combination, dieValuesArray);
                form.ShowOKButton();
                form.ShowMessage("Your turn has ended - click OK");
                currentPlayer.ShowScores();
            }
        }

        public static void Load(Form1 form) {
            //Needs to be implemented
        }
        public void Save() {
            //Needs to be implemented
        }

        public int[] intDiceArray(ScoreType combination) {
            int[] dieValuesArray = new int[5];

            for (int i = 0; i < 5; i++) {
                dieValuesArray[i] = dice[i].FaceValue;
            }

            return dieValuesArray;
        }
    }
}

