using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace HangMan
{
    /// <summary>
    /// Interaction logic for StartMenuHangManGame.xaml
    /// </summary>
    public partial class StartMenuHangManGame : Page
    {
        public StartMenuHangManGame()
        {
            InitializeComponent();
        }

        private void Startscherm_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HangManPlayGame());
        }

        private void Afsluiten_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
