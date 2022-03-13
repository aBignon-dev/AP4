using System;
using System.Threading.Tasks;
using AP4test.Models;
using Xamarin.Forms;

namespace AP4test.Views.NavBar
{
    public partial class ConnecterShell : Shell
    {
        public ConnecterShell()
        {
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
