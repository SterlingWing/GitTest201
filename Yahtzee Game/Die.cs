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
        private StreamReader rollFile;
        private static bool DEBUG;

        public Die(Label dieLabels) {
            this.dieLabels = dieLabels;
        }

        public int FaceValue {
            get {
                return faceValue;
            }
        }

        public bool Active {
            get {
                return active;
            }
            set {
                active = value;
            }
        }

        public void Roll() {
            faceValue = random.Next(1, 7);
            dieLabels.Text = faceValue.ToString();
        }

        public void Load(Label label) {
            //Body to be implemented
        }

    }
}
