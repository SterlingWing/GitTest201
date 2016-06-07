using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {

    /// <summary>
    /// The form used to house the yahtzee game.
    /// </summary>
    public partial class Form1 : Form {
        Label[] dice = new Label[5];
        Button[] scoreButtons = new Button[(int)ScoreType.Yahtzee + 1];
        Label[] scoreTotals = new Label[(int)ScoreType.GrandTotal + 1];
        CheckBox[] checkBoxes = new CheckBox[5];
        Game game;

        public decimal playerCount = 1;

        public Form1() {
            InitializeComponent();
            InitialiseLabelsAndButtons();
        }//end Form1 Constructor


        private void InitialiseLabelsAndButtons() {

            dice[0] = die1;
            dice[1] = die2;
            dice[2] = die3;
            dice[3] = die4;
            dice[4] = die5;

            scoreTotals[(int)ScoreType.Ones] = scoreLabel1;
            scoreTotals[(int)ScoreType.Twos] = scoreLabel2;
            scoreTotals[(int)ScoreType.Threes] = scoreLabel3;
            scoreTotals[(int)ScoreType.Fours] = scoreLabel4;
            scoreTotals[(int)ScoreType.Fives] = scoreLabel5;
            scoreTotals[(int)ScoreType.Sixes] = scoreLabel6;
            scoreTotals[(int)ScoreType.ThreeOfAKind] = scoreLabel7;
            scoreTotals[(int)ScoreType.FourOfAKind] = scoreLabel8;
            scoreTotals[(int)ScoreType.FullHouse] = scoreLabel9;
            scoreTotals[(int)ScoreType.SmallStraight] = scoreLabel10;
            scoreTotals[(int)ScoreType.LargeStraight] = scoreLabel11;
            scoreTotals[(int)ScoreType.Chance] = scoreLabel12;
            scoreTotals[(int)ScoreType.Yahtzee] = scoreLabel13;
            scoreTotals[(int)ScoreType.SubTotal] = labelSubScore;
            scoreTotals[(int)ScoreType.BonusFor63Plus] = labelBonus63Score;
            scoreTotals[(int)ScoreType.YahtzeeBonus] = labelBonusYatzeeScore;
            scoreTotals[(int)ScoreType.SectionATotal] = labelUpperScore;
            scoreTotals[(int)ScoreType.SectionBTotal] = labelLowerScore;
            scoreTotals[(int)ScoreType.GrandTotal] = labelGrandScore;

            scoreButtons[(int)ScoreType.Ones] = button1;
            scoreButtons[(int)ScoreType.Twos] = button2;
            scoreButtons[(int)ScoreType.Threes] = button3;
            scoreButtons[(int)ScoreType.Fours] = button4;
            scoreButtons[(int)ScoreType.Fives] = button5;
            scoreButtons[(int)ScoreType.Sixes] = button6;
            scoreButtons[(int)ScoreType.ThreeOfAKind] = button7;
            scoreButtons[(int)ScoreType.FourOfAKind] = button8;
            scoreButtons[(int)ScoreType.FullHouse] = button9;
            scoreButtons[(int)ScoreType.SmallStraight] = button10;
            scoreButtons[(int)ScoreType.LargeStraight] = button11;
            scoreButtons[(int)ScoreType.Chance] = button12;
            scoreButtons[(int)ScoreType.Yahtzee] = button13;

            checkBoxes[0] = checkBoxDie1;
            checkBoxes[1] = checkBoxDie2;
            checkBoxes[2] = checkBoxDie3;
            checkBoxes[3] = checkBoxDie4;
            checkBoxes[4] = checkBoxDie5;

            button1.Click += new EventHandler(ButtonClick);
            button2.Click += new EventHandler(ButtonClick);
            button3.Click += new EventHandler(ButtonClick);
            button4.Click += new EventHandler(ButtonClick);
            button5.Click += new EventHandler(ButtonClick);
            button6.Click += new EventHandler(ButtonClick);
            button7.Click += new EventHandler(ButtonClick);
            button8.Click += new EventHandler(ButtonClick);
            button9.Click += new EventHandler(ButtonClick);
            button10.Click += new EventHandler(ButtonClick);
            button11.Click += new EventHandler(ButtonClick);
            button12.Click += new EventHandler(ButtonClick);
            button13.Click += new EventHandler(ButtonClick);

        }//end InitialiseLablsAndButtons

        public Label[] GetDice() {
            return dice;
        }//end GetDice

        public Label[] GetScoresTotals() {
            return scoreTotals;
        }//end GetScoreTotals

        public void ShowPlayerName(string name) {
            labelPlayer.Text = name;
        }//end ShowPlayerName

        public void EnableRollButton() {
            buttonRollDice.Enabled = true;
        }//end EnableRollButton

        public void DisableRollButton() {
            buttonRollDice.Enabled = false;
        }//end DisableRollButton

        public void EnableCheckBoxes() {
            for (int i = 0; i < 5; i++)
            {
                checkBoxes[i].Enabled = true;
            }
        }//end EnableCheckBoxes

        public void DisableAndClearCheckBoxes() {
            for (int i = 0; i < 5; i++)
            {
                checkBoxes[i].Enabled = false;
            }
            for (int i = 0; i < 5; i++)
            {
                checkBoxes[i].Checked = false;
            }
        }//end DisableAndClearCheckBoxes

        public void EnableScoreButton(ScoreType combination) {
            scoreButtons[(int)combination].Enabled = true;
        }//end EnableScoreButton

        public void DisableScoreButton(ScoreType combination) {
            scoreButtons[(int)combination].Enabled = false;
        }//end DisableScoreButton

        public void CheckCheckBox(int index) {
            checkBoxes[index].Checked = true;
        }//end CheckCheckBox

        public void ShowMessage(string message) {
            labelMessage.Text = message;
        }//end ShowMessage

        public void ShowOKButton() {
            buttonOk.Visible = true;
        }//end ShowOKButton

        public void StartNewGame() {
            game = new Game(this);
            EnableRollButton();
            labelMessage.Visible = true;
            labelPlayer.Visible = true;
            for (int i = 0; i < 5; i++) {
                dice[i].Text = "";
            }
        }//end StartNewGame

        private void buttonRollDice_Click(object sender, EventArgs e) {
            game.RollDice();
            EnableAllScoreButtons();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            StartNewGame();
            buttonOk.Visible = false;
            saveToolStripMenuItem.Enabled = true;
            loadToolStripMenuItem.Enabled = false;
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            game.NextTurn();
            buttonOk.Visible = false;
        }

        private void checkBoxDie1_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxDie1.Checked == true) {
                game.HoldDie(0);
            }
            if (checkBoxDie1.Checked == false) {
                game.ReleaseDie(0);
            }
        }

        private void checkBoxDie2_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxDie2.Checked == true) {
                game.HoldDie(1);
            }
            if (checkBoxDie2.Checked == false) {
                game.ReleaseDie(1);
            }
        }

        private void checkBoxDie3_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxDie3.Checked == true) {
                game.HoldDie(2);
            }
            if (checkBoxDie3.Checked == false) {
                game.ReleaseDie(2);
            }
        }

        private void checkBoxDie4_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxDie4.Checked == true) {
                game.HoldDie(3);
            }
            if (checkBoxDie4.Checked == false) {
                game.ReleaseDie(3);
            }
        }

        private void checkBoxDie5_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxDie5.Checked == true) {
                game.HoldDie(4);
            }
            if (checkBoxDie5.Checked == false) {
                game.ReleaseDie(4);
            }
        }

        /*private void button1_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.Ones);
            gridPlayerBoard.Refresh();
        }

        private void button2_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.Twos);
            gridPlayerBoard.Refresh();
        }

        private void button3_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.Threes);
            gridPlayerBoard.Refresh();
        }

        private void button4_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.Fours);
            gridPlayerBoard.Refresh();
        }

        private void button5_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.Fives);
            gridPlayerBoard.Refresh();
        }

        private void button6_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.Sixes);
            gridPlayerBoard.Refresh();
        }

        private void button7_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.ThreeOfAKind);
            gridPlayerBoard.Refresh();
        }

        private void button8_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.FourOfAKind);
            gridPlayerBoard.Refresh();
        }

        private void button9_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.FullHouse);
            gridPlayerBoard.Refresh();
        }

        private void button10_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.SmallStraight);
            gridPlayerBoard.Refresh();
        }

        private void button11_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.LargeStraight);
            gridPlayerBoard.Refresh();
        }

        private void button12_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.Chance);
            gridPlayerBoard.Refresh();
        }

        private void button13_Click(object sender, EventArgs e) {
            game.ScoreCombination(ScoreType.Yahtzee);
            gridPlayerBoard.Refresh();
        }*/

        private void ButtonClick(object sender, EventArgs e) {
            switch ((sender as Button).Name) {
                case "button1":
                    game.ScoreCombination(ScoreType.Ones);
                    break;
                case "button2":
                    game.ScoreCombination(ScoreType.Twos);
                    break;
                case "button3":
                    game.ScoreCombination(ScoreType.Threes);
                    break;
                case "button4":
                    game.ScoreCombination(ScoreType.Fours);
                    break;
                case "button5":
                    game.ScoreCombination(ScoreType.Fives);
                    break;
                case "button6":
                    game.ScoreCombination(ScoreType.Sixes);
                    break;
                case "button7":
                    game.ScoreCombination(ScoreType.ThreeOfAKind);
                    break;
                case "button8":
                    game.ScoreCombination(ScoreType.FourOfAKind);
                    break;
                case "button9":
                    game.ScoreCombination(ScoreType.FullHouse);
                    break;
                case "button10":
                    game.ScoreCombination(ScoreType.SmallStraight);
                    break;
                case "button11":
                    game.ScoreCombination(ScoreType.LargeStraight);
                    break;
                case "button12":
                    game.ScoreCombination(ScoreType.Chance);
                    break;
                case "button13":
                    game.ScoreCombination(ScoreType.Yahtzee);
                    break;
            }
            gridPlayerBoard.Refresh();
        }


        /// <summary>
        /// Enables all score buttons on the Form.
        /// </summary>
        private void EnableAllScoreButtons() {
            for (ScoreType scoreCombo = ScoreType.Ones; scoreCombo <= ScoreType.Yahtzee; scoreCombo++) {
                if ((int)scoreCombo < 6 || (int)scoreCombo > 8) {
                    EnableScoreButton(scoreCombo);
                }
            }
        }

        private void playerSetCount_ValueChanged(object sender, EventArgs e) {
            playerCount = playerSetCount.Value;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            game.Save();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            game = Game.Load(this);
            playerBindingSource.DataSource = game.players;
            gridPlayerBoard.Refresh();
        }
    }
}

