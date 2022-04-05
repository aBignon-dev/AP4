using System;
using Xamarin.Forms;

namespace AP4test.Views.NavBar
{
    public partial class InviterShell : Shell
    {
        public InviterShell()
        {
            InitializeComponent();
        }

        public void DeconnexionClickedAsync(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}