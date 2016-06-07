using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace Yahtzee_Game {

    public enum ScoreType {
        Ones, Twos, Threes, Fours, Fives, Sixes,
        SubTotal, BonusFor63Plus, SectionATotal,
        ThreeOfAKind, FourOfAKind, FullHouse,
        SmallStraight, LargeStraight, Chance, Yahtzee,
        YahtzeeBonus, SectionBTotal, GrandTotal
    }

    /// <summary>
    /// Represents a Yahtzee game
    /// </summary>
    class Game {
        public static string defaultPath = Environment.CurrentDirectory;
        private static string savedGameFile = defaultPath + "\\YahtzeeGame.dat";
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
                                           "Your turn has ended - click OK",
                                           "Game has ended, check final scores"};

        public Game(Form1 form) {
            dice = new Die[5];
            this.form = form;
            dieLabels = form.GetDice();

            for (int i = 0; i < 5; i++) {
                dice[i] = new Die(dieLabels[i]);
            }

            players = new BindingList<Player>();
            for (int i = 0; i < form.playerCount; i++) {
                players.Add(new Player(("player " + (i + 1)), form.GetScoresTotals()));
            }

            for (ScoreType scoreCombo = ScoreType.Ones; scoreCombo <= ScoreType.Yahtzee; scoreCombo++) {
                if ((int)scoreCombo < 6 || (int)scoreCombo > 8) {
                    form.DisableScoreButton(scoreCombo);
                }
            }

            form.ShowPlayerName("Player 1");
            form.ShowMessage("Roll 1");

            currentPlayerIndex = 0;
            currentPlayer = players[currentPlayerIndex];
            currentPlayer.ShowScores();
            

            form.playerBindingSource.DataSource = players;

            PlayersFinished();
        }//end Game Constructor

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
            form.DisableAndClearCheckBoxes();
        }//end NextTurn

        public void RollDice() {
            form.EnableCheckBoxes();
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
        }//end RollDice

        public void HoldDie(int index) {
            dice[index].Active = false;
        }//end HoldDie

        public void ReleaseDie(int index) {
            dice[index].Active = true;
        }//end ReleaseDie

        public void ScoreCombination(ScoreType combination) {
            if (currentPlayer.IsAvailable(combination) == true) {
                int[] dieValuesArray;
                dieValuesArray = IntDiceArray(combination);
                currentPlayer.ScoreCombination(combination, dieValuesArray);
                form.ShowOKButton();
                form.ShowMessage("Your turn has ended - click OK");
                currentPlayer.ShowScores();
                form.DisableRollButton();
                DisableAllScoreButtons();
                EndGame();
            }
        }//end ScoreCombination
        
        public static void Load(Form1 form) {
            //Needs to be implemented
        }//end Load

        public void Save() {
            //Needs to be implemented
        }//end Save

        /// <summary>
        /// Moves the die facevalues from an array of Die (dice) 
        /// to an array of int (dieValuesArray).
        /// </summary>
        /// <param name="combination"></param>
        /// <returns>dieValuesArray</returns>
        public int[] IntDiceArray(ScoreType combination) {
            int[] dieValuesArray = new int[5];

            for (int i = 0; i < 5; i++) {
                dieValuesArray[i] = dice[i].FaceValue;
            }

            return dieValuesArray;
        }//end IntDiceArray

        /// <summary>
        /// Tallies the number of players that have finished the game.
        /// </summary>
        public void PlayersFinished() {
            if (currentPlayer.IsFinished() == true) {
                playersFinished++;
            }
        }//end PlayersFinished

        /// <summary>
        /// Ends the game for all players playing.
        /// </summary>
        public void EndGame() {
            PlayersFinished();
            if (playersFinished == form.playerCount) {
                if (form.playerCount == 1) {
                    form.ShowMessage(labelMessages[3]);
                    form.DisableRollButton();
                    if (MessageBox.Show("Would you like to start a new game", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        form.StartNewGame();
                    }
                    else {
                    }
                }
            else if (playersFinished == form.playerCount) { 
                if (form.playerCount >= 2) {
                    form.ShowMessage(labelMessages[3]);
                    form.DisableRollButton();
                    if (MessageBox.Show("Would you like to start a new game", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        form.StartNewGame();
                    }
                    else {
                    }
                    }
                }
            }
        }//end EndGame

        /// <summary>
        /// Disables all score buttons on the GUI.
        /// </summary>
        public void DisableAllScoreButtons() {
            for (ScoreType scoreCombo = ScoreType.Ones; scoreCombo <= ScoreType.Yahtzee; scoreCombo++) {
                if ((int)scoreCombo < 6 || (int)scoreCombo > 8) {
                    form.DisableScoreButton(scoreCombo);
                }
            }
        }//end DisableAllScoreButtons
    }//end Game Class.
}

