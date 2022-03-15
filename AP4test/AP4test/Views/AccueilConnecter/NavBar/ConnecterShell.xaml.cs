using System;
using AP4test.Models;
using AP4test.Views.EnchereSample.ListEnchere;
using Xamarin.Forms;

namespace AP4test.Views.AccueilConnecter.NavBar
{
    public partial class ConnecterShell : Shell
    {
        public ConnecterShell()
        {
            Routing.RegisterRoute(nameof(ListEnchereSampleView),typeof(ListEnchereSampleView));
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
