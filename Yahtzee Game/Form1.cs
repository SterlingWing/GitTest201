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
    public partial class Form1 : Form {
        private Label[] dice;
        private Button[] scoreButtons;
        private Label[] scoreTotals;
        private CheckBox[] checkBoxes;

        public Form1() {
            InitializeComponent();
        }

        private void InitialiseLabelsAndButtons() {
            Label[] dice = { die1, die2, die3, die4, die5 };
            Button[] scoreButtons = {button1, button2, button3, button4, button5, button6,
                                    button7, button8, button9, button10, button11, button12, button13};
            Label[] scoreTotals = {scoreLabel1, scoreLabel2, scoreLabel3, scoreLabel4, scoreLabel5, scoreLabel6,
                                   scoreLabel7, scoreLabel8, scoreLabel9, scoreLabel10, scoreLabel11, scoreLabel12,
                                    scoreLabel13, labelBonus63Score, labelBonusYatzeeScore, labelUpperScore, labelLowerScore,
                                    labelSubScore};
            CheckBox[] checkBoxes = { checkBoxDie1, checkBoxDie2, checkBoxDie3, checkBoxDie4, checkBoxDie5 };
            //Needs game variable
        }

        public Label[] GetDice() {
            return dice;
        }

        public Label[] GetScoresTotals() {
            return scoreTotals;
        }

        public void ShowPlayerName(string name) {
            labelPlayer.Text = name;
        }

        public void EnableRollButton() {
            buttonRollDice.Enabled = true;
        }

        public void DisableRollButton() {
            buttonRollDice.Enabled = false;
        }

        public void EnableCheckBoxes() {
            checkBoxDie1.Enabled = true;
            checkBoxDie2.Enabled = true;
            checkBoxDie3.Enabled = true;
            checkBoxDie4.Enabled = true;
            checkBoxDie5.Enabled = true;
        }

        public void DisableAndClearCheckBoxes() {
            checkBoxDie1.Enabled = false;
            checkBoxDie2.Enabled = false;
            checkBoxDie3.Enabled = false;
            checkBoxDie4.Enabled = false;
            checkBoxDie5.Enabled = false;

            checkBoxDie1.Checked = false;
            checkBoxDie2.Checked = false;
            checkBoxDie3.Checked = false;
            checkBoxDie4.Checked = false;
            checkBoxDie5.Checked = false;
        }

        public void EnableScoreButton(ScoreType combo) {
            //wait until more information on ScoreType combo
        }

        public void DisableScoreButton(ScoreType combo) {
            //wait until more information on ScoreType combo
        }

        public void CheckCheckBox(int index) {
            checkBoxes[index].Checked = true;
        }

        public void ShowMessage(string message) {
            labelMessage.Text = message;
        }

        public void ShowOKButton() {
            //Enter code from part C
        }

        public void StartNewGame() {
            //game = new Game();
        }

        private void buttonRollDice_Click(object sender, EventArgs e) {
            EnableCheckBoxes();
        }
    }

}

