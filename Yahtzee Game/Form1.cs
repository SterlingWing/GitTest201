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
            for (int i = 0; i < 5; i++) {
                checkBoxes[i].Enabled = false;
            }
        }

        public void DisableAndClearCheckBoxes() {

        }

        public void EnableScoreButton(ScoreType combo) {

        }

        public void DisableScoreButton(ScoreType combo) {

        }

        public void CheckCheckBox(int index) {

        }

        public void ShowMessage(string message) {

        }

        public void ShowOKButton() {

        }

        public void StartNewGame() {

        }

        private void buttonRollDice_Click(object sender, EventArgs e) {
            EnableCheckBoxes();
        }
    }

}

