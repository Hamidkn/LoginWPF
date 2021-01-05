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
using LoginDataLayer;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace LoginWPF.LoginWindow
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool IsEdit = false;
        private bool IsActive = false;
        private LoginWindow _loginwindow;

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
                    if (datset.LoginRepository.Get(log => log.UserName == txtusername.Text && log.PassWord == txtpassword.Text).Any())
                    { 
                        Application.Current.MainWindow.Show();
                        
                    }
                    else if (datset.SignupRepository.Get(s => s.Username == txtusername.Text && s.Password ==txtpassword.Text).Any())
                    {
                        Application.Current.MainWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("This username is not valid. \n" +
                                        "For signing up use signup form!");
                    }
                }
            }
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            using (Repository db = new Repository())
            {
                SignUp newlistSignUp = new SignUp();
                newlistSignUp.FullName = txtFullname.Text;
                newlistSignUp.Email = txtemail.Text;
                newlistSignUp.Username = txtusernamesignup.Text;
                newlistSignUp.Password = txtpasswordsignup.Text;
                newlistSignUp.LoginId +=1 ;
                db.SignupRepository.Insert(newlistSignUp);
                db.Save();
                MessageBox.Show("The user is added successfully.");
                Clear();
            }
        }

        private void Clear()
        {
            txtFullname.Clear();
            txtemail.Clear();
            txtusernamesignup.Clear();
            txtpasswordsignup.Clear();
        }
    }
}
