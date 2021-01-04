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
using System.Windows.Shapes;
using Login.DataLayer.UnitOfWork;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace LoginWPF.LoginWindow
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool IsEdit = false;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (Repository datset = new Repository())
            {
                if (IsEdit)
                {
                    var result = datset.LoginRepository.Get().First();
                    result.UserName = txtusername.Text;
                    result.PassWord = txtpassword.Text;
                    datset.LoginRepository.Update(result);
                    datset.Save();
                    System.Windows.Application.Current.Shutdown();
                }
                else
                {
                    if (datset.LoginRepository.Get(l => l.UserName == txtusername.Text && l.PassWord == txtpassword.Text).Any())
                    {
                        DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("This username is not valid. \n" +
                                        "For signing up use signup form");
                    }
                }
            }
        }
    }
}
