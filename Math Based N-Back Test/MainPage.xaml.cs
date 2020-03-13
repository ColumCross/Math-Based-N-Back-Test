using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Math_Based_N_Back_Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        private Queue<Equation> questions;
        private int nback;
        private int correct = 0;
        private int incorrect = 0;
        private int currentCorrectAnswer = -1;
        private int trials;
        private Color correctColor;
        private Color wrongColor;

        public MainPage(int nback, int trials) {
            this.InitializeComponent();
            questions = new Queue<Equation>();
            
            this.nback = nback;
            this.trials = trials;

            correctColor = Color.FromArgb(255, 0, 255, 51);
            wrongColor = Color.FromArgb(255, 255, 0, 0);
        }

        
        private void NextQuestion() {
            AnswerBox.Text = "";
            Equation currentQuestion = new Equation();
            QuestionBox.Text = currentQuestion.ToString();
                        
            //Grab the nth question from the back of the list and get it's answer.
            if(questions.Count >= nback) {
                currentCorrectAnswer = questions.Dequeue().correctAnswer;
            }

            questions.Enqueue(currentQuestion);
        }

        void Grid_KeyUp(object sender, KeyRoutedEventArgs e) {
            if (currentCorrectAnswer == -1) {
                NextQuestion();
                return;
            }
            char[] MyChar = { 'N', 'u', 'm', 'b', 'e','r' };
            string key = e.Key.ToString().TrimStart(MyChar);
            AnswerBox.Text = key;
            CalculateAnswer(key);
        }


        private async void CalculateAnswer(string key) {

            int num;
            try {
                num = int.Parse(key);
            } catch (FormatException) {
                num = 20;
            }
            if (num == currentCorrectAnswer) {
                AnswerBox.Foreground = new SolidColorBrush(correctColor);
                correct++;
            } else {
                AnswerBox.Foreground = new SolidColorBrush(wrongColor);
                incorrect++;
            }

            if (correct + incorrect < trials) {
                await Task.Delay(300);
                NextQuestion();
            } else {
                Window.Current.Content = new ResultsPage(correct, incorrect);
            }
            
        }

    }
}
