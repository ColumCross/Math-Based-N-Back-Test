using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Based_N_Back_Test
{
    class Equation
    {
        /*
         * Equation Class
first number 
- random 0-9
second number 
- random number that is smaller than the first number
- does not make a double digit number when added
- between 0 and either the first number or 9-the first number
operator (either + or -)
correct answer
id


    */

        // Variables, or whatever you call them.
        public int firstNumber { get; set; }
        public int secondNumber { get; set; }
        public Operator sign { get; set; }
        public int id { get; set; }
        public int correctAnswer { get; set; }

        /// <summary>
        /// Constructor will take no parameters, will make the first number, then the operator.
        /// Then will construct the second number. If the operator is addition, then the second number is between 0 and
        /// the first. If the operator is subtraction, then the second number is between 0 and 9-the first.
        /// </summary>
        public Equation() {
            Random die = new Random();
            firstNumber = die.Next(10);
            sign = new Operator();
            if(sign.isAddition) {
                int upperbound = 9 - firstNumber;
                secondNumber = die.Next(upperbound);
                correctAnswer = firstNumber + secondNumber;
            } else {
                secondNumber = die.Next(firstNumber);
                correctAnswer = firstNumber - secondNumber;
            }
        }

        public override string ToString() {
            return firstNumber + sign.ToString() + secondNumber;
        }
        
    }
}
