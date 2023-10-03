using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace facade
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string secretColor;

        [ObservableProperty]
        private string currentGuess;

        public ObservableCollection<ColorGuess> Guesses { get; set; }

        //public string SecretColor { get; set; }

        public MainPageViewModel()
        {
            secretColor = "FACADE";
            currentGuess = "";

            Guesses = new ObservableCollection<ColorGuess>();

       

        }


        [RelayCommand]
        void AddLetter(string letter)
        {
            if (CurrentGuess.Length < 6)
            {
                CurrentGuess += letter;
            }
        }



        [RelayCommand]
        void RemoveLetter()
        {
            if (CurrentGuess.Length > 0)
            {
                CurrentGuess = CurrentGuess.Remove(CurrentGuess.Length - 1, 1);
            };
        }

        [RelayCommand]
        void Guess()
        {
            // if correct, then go to game over (DidWin=true)
            if(CurrentGuess == SecretColor)
            {
                Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={true}");
            }
            else if(CurrentGuess != SecretColor && Guesses.Count < 5)
            {
                Guesses.Add(new ColorGuess(CurrentGuess));
            }
            else
            {
                Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={false}");
            } 
              
            // else if this is the 6th guess (and it's wrong)
            // then go to game over (DidWin=false)


            // Add this guess to the Guesses
            

        }


    }
}