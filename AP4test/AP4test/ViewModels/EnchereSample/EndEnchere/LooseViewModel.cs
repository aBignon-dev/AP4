using System;
using System.Windows.Input;
using AP4test.ViewModels.EnchereSample.Config;
using Xamarin.Forms;

namespace AP4test.ViewModels.EnchereSample.EndEnchere
{
    public class LooseViewModel : BaseVueModele
    {
        public LooseViewModel()
        {
            Title = LooseLang.Title;
            NotWonText = LooseLang.NotWonText;
            RipText = LooseLang.RIPText;
            ButtonSuivantText = LooseLang.ButtonSuivantText;
        }

        public string NotWonText { get; }

        public string RipText { get; }
        public string ButtonSuivantText { get; }

        public ICommand ButtonSuivant => new Command(RedirectToBase);

        async void RedirectToBase()
        {
            await Shell.Current.GoToAsync($"Accueil");
        }
    }
}