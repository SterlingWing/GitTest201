using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Yahtzee_Game
{

    /// <summary>
    /// This class represents a single die object which 
    /// is capable of being rolled.
    /// </summary>
    class Die {
        private int faceValue;
        private bool active = true;
        private Label dieLabels;
        private static Random random = new Random();
        private static string rollFileName = Game.defaultPath + "\\basictestrolls.txt";
        private static StreamReader rollFile = new StreamReader(rollFileName);
        private static bool DEBUG = true;

        public Die(Label dieLabels) {
            this.dieLabels = dieLabels;
        }//end Die Constructor

        public int FaceValue {
            get {
                return faceValue;
            }
        }//end FaceValue

        public bool Active {
            get {
                return active;
            }
            set {
                active = value;
            }
        }//end Active

        public void Roll() {
            if (!DEBUG) {
                faceValue = random.Next(1, 7);
                dieLabels.Text = faceValue.ToString();
            } else {
                faceValue = int.Parse(rollFile.ReadLine());
                dieLabels.Text = faceValue.ToString();
                dieLabels.Refresh();
            }
            
        }//end Roll

        public void Load(Label label) {
            this.dieLabels = label;
            if (faceValue == 0) {
                label.Text = string.Empty;
            }
            else {
                label.Text = faceValue.ToString();
            }
        }//end Load


    }//end Die Class
}
