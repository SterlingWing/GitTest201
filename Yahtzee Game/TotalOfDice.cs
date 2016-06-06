using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee_Game {
    class TotalOfDice : Combination {
        private int numberOfOneKind;

        public TotalOfDice(ScoreType scoreType, Label temp2) : base(temp2) {
            if (scoreType == ScoreType.ThreeOfAKind) {
                numberOfOneKind = 3;
            }

            if (scoreType == ScoreType.FourOfAKind) {
                numberOfOneKind = 4;
            }

            if (scoreType == ScoreType.Chance) {
                numberOfOneKind = 0;
            }
        }

        public override void CalculateScore(int[] dieValues) {
            Sort(dieValues);

                if (numberOfOneKind == 3) {
                int duplicateValues = dieValues.Distinct().Count();

                if (duplicateValues <= 3) {
                    Points = dieValues.Sum();
                }
                else {
                    Points = 0;
                }

            } else if (numberOfOneKind == 4) {
                int duplicateValues = dieValues.Distinct().Count();
                if (duplicateValues <= 2) {
                    Points = dieValues.Sum();
                }
                else {
                    Points = 0;
                }

            } else if (numberOfOneKind == 0) {
                        Points = dieValues.Sum();
                    }
                }
        }
    }
