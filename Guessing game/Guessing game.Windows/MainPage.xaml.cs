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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Guessing_game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private int radius;
        private int counter = 0;
        private int count = 0;
        private int click = 0;
        private int number;
        private bool button1WasClicked = false;
        private bool textChanged = false;
        private string numberrange;

        private void input_TextChanged(object sender, RoutedEventArgs e)
        {
            textChanged = true;
        }
        private void Howtoplay_Click(object sender, RoutedEventArgs e)
        {
            instructions.Text = "1 - Choose level of difficulty - easy/medium/hard.\n2 - Enter a value for what you think is the correct radius.\n3 - Click 'Check Answer' to see if your quess is correct.\n4 - 5 Attempts to get correct answer.";

        }
        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            textChanged = false;
            text.Text = "";
            Random random = new Random();
            radius = random.Next(1, 20);
            numberrange = "(1, 20)?";
            button1WasClicked = true;
            double pi = Math.PI;
            double area = Math.Pow(radius, 2);
            double circlearea = pi * area;
            circlearea = Math.Round(circlearea, 2);
            text.Text = "Circle area is " + circlearea + "\nWhat is the radius " + numberrange;
            answer.Text = "";
            counter = 0;

        }
        private void Med_Click(object sender, RoutedEventArgs e)
        {
            textChanged = false;
            text.Text = "";
            Random random = new Random();
            radius = random.Next(1, 50);
            numberrange = "(1, 50)?";
            button1WasClicked = true;
            double pi = Math.PI;
            double area = Math.Pow(radius, 2);
            double circlearea = pi * area;
            circlearea = Math.Round(circlearea, 2);
            text.Text = "Circle area is " + circlearea + "\nWhat is the radius " + numberrange;
            answer.Text = "";
            counter = 0;
        }
        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            textChanged = false;
            text.Text = "";
            Random random = new Random();
            radius = random.Next(1, 100);
            numberrange = "(1, 100)?";
            button1WasClicked = true;
            double pi = Math.PI;
            double area = Math.Pow(radius, 2);
            double circlearea = pi * area;
            circlearea = Math.Round(circlearea, 2);
            text.Text = "Circle area is " + circlearea + "\nWhat is the radius " + numberrange;
            answer.Text = "";
            counter = 0;
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            if (textChanged)
            {
                number = Int32.Parse(input.Text);
                textChanged = false;

            }
            else
            {
                answer.Text = "Please choose level of difficulty to play.";
            }
            textChanged = false;
            if (button1WasClicked)
            {
                counter++;
                if ((counter >= 5) && (number != radius))
                {
                    answer.Text = "Game over: Attempts exceeded\nThe radius is " + radius;
                    input.Text = "";
                }
                else
                {
                    if (number == radius)
                    {
                        answer.Text = "Well done! You are correct. \nThe radius is " + radius + "\nNumber of attempts " + counter + " \nChoose difficulty level to play again.";
                        button1WasClicked = false;
                        count++;

                    }
                    else if (number > radius)
                    {
                        answer.Text = "Wrong, Guess again.\nYour value is too large";
                    }
                    else if (number < radius)
                    {
                        answer.Text = "Wrong, Guess again.\nYour value is too small";
                    }

                    input.Text = "";
                }
            }
            else
            {
                click++;
                if (click >= 1)
                {
                    answer.Text = "Please choose level of difficulty to play.";
                    input.Text = "";
                }
            }
        }
    }
}