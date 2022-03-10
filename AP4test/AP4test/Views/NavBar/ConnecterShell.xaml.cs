using System;
using AP4test.Models;
using Xamarin.Forms;

namespace AP4test.Views.NavBar
{
    public partial class ConnecterShell : Shell
    {
        public ConnecterShell(User user)
        {
            InitializeComponent();
        }
        public void DeconnexionClickedAsync(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
