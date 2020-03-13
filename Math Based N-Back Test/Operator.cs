using System;

namespace Math_Based_N_Back_Test {
    internal class Operator {
        private string asString;
        public bool isAddition { get; set; }

        public Operator() {
            Random coin = new Random();
            int toss = coin.Next(2);
            if (toss == 0) { // The coin is "heads" and addition is selected.
                asString = " + ";
                isAddition = true;
            } else { // The coin is "tails" and subtraction is selected.
                asString = " - ";
                isAddition = false;
            }
        }

        public override string ToString() {
            return asString;
        }
    }
}