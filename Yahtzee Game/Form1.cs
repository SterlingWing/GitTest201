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
        Label[] dice = new Label[5];
        Button[] scoreButtons = new Button[(int)ScoreType.Yahtzee + 1];
        Button[] scoreTotals = new Button[(int)ScoreType.GrandTotal + 1];
        CheckBox[] checkBoxes = new CheckBox[5];
        Game game;

        public Form1() {
            InitializeComponent();
        }

        private void InitialiseLabelsAndButtons() {
           
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

