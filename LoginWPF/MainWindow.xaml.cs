using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginWindow.LoginWindow _loginWindow;

        public MainWindow()
        {
            InitializeComponent();
            _loginWindow = new LoginWindow.LoginWindow();
            DataContext = _loginWindow;
            this.Hide();
            _loginWindow.Show();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _loginWindow.Hide();
        }
    }
}
