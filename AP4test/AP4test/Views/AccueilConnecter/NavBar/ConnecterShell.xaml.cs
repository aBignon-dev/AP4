using System;
using AP4test.Models;
using AP4test.Views.AccueilDeconnecter.Inscription;
using AP4test.Views.EnchereSample.EnchereFlash;
using AP4test.Views.EnchereSample.EnchereSample;
using AP4test.Views.EnchereSample.EndEnchere;
using AP4test.Views.EnchereSample.ListEnchere;
using Xamarin.Forms;

namespace AP4test.Views.AccueilConnecter.NavBar
{
    public partial class ConnecterShell : Shell
    {
        public ConnecterShell()
        {
            Routing.RegisterRoute(nameof(ListEnchereSampleView),typeof(ListEnchereSampleView));
            Routing.RegisterRoute(nameof(WinView),typeof(WinView));
            Routing.RegisterRoute(nameof(LooseView),typeof(LooseView));
            Routing.RegisterRoute(nameof(EnchereFlashView),typeof(EnchereFlashView));
            Routing.RegisterRoute(nameof(EnchereSampleView),typeof(EnchereSampleView));
            Routing.RegisterRoute(nameof(InscriptionView),typeof(InscriptionView));
            InitializeComponent();
        }
        /// <summary>
        /// Disconnect the current user + quit the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void DeconnexionClickedAsync(object sender, EventArgs e)
        {
            await User.DeleteAllSqlite();
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
