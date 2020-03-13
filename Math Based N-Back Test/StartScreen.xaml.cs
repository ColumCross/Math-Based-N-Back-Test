using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Math_Based_N_Back_Test {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartScreen : Page {
        public StartScreen() {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                int nback = int.Parse(nbackInput.Text);
                int trials = int.Parse(trialsInput.Text);
                if (nback < 1 || trials < 1) throw new FormatException();
                Window.Current.Content = new MainPage(nback, trials);
            } catch(Exception f) {
                ActionFailed(f);
            }
            
        }

        private async void ActionFailed(Exception e) {
            nbackInput.Text = "";
            trialsInput.Text = "";
            ContentDialog msg = new ContentDialog {
                Title = "Invalid Input",
                Content = "Enter only whole numbers ",
                CloseButtonText = "Ok"
            };
            if (e.GetType().IsAssignableFrom(typeof(FormatException))) { // Check if the error is a format error.
                msg.Content += "greater than 0.";
            } else if (e.GetType().IsAssignableFrom(typeof(OverflowException))) { // Check if the error is from too big a number.
                msg.Content += "less than 2,147,483,647.";
            } else { // "Handle" any other errors.
                ContentDialog totalFailure = new ContentDialog {
                    Title = "Unhandled Error",
                    Content = "I have experienced an unhandled error. I will now terminate in order to report this error. I am so sorry.",
                    CloseButtonText = "Goodbye"
                };
                await totalFailure.ShowAsync();
                throw e;
            }
            ContentDialogResult result = await msg.ShowAsync();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e) {
            //TODO: Make this non-blocking
            //TODO: Think of better instructions.
            ContentDialog instructions = new ContentDialog {
                Title = "Instructions",
                Content = "The N-Back Test is a test of Working Memory. Participants will be presented with and answer a series of simple, single digit math questions. The twist is, the question the participant answers is not the same as the question currently on screen. The question they will answer is the question N before the question on the screen. \n\nBegin by setting the N-back and the amount of trials as any whole number greater than 0. When the test begins, press any key to start until the 'X' disappears. Once the 'X' is gone begin answering the questions in the order you saw them by pressing the number key corresponding to their answer.",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await instructions.ShowAsync();
        }
    }
}
