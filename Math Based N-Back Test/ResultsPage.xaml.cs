﻿using System;
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
    public sealed partial class ResultsPage : Page {
        public ResultsPage(int numCorrect, int numWrong) {
            this.InitializeComponent();
            resultsBox.Text = "You got " + numCorrect + " correct and " + numWrong + " wrong.";

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Window.Current.Content = new StartScreen();
        }
    }
}
