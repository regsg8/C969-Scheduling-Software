using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace RegGarrettSchedulingSoftware
{
    public partial class Login : Form
    {
        private string wrongPassword = "Incorrect Username or Password.";
        private string noUsername = "Please enter your username.";
        private string noPassword = "Please enter your password.";
        public Login()
        {
            InitializeComponent();
            checkRegion();
        }

        private void checkRegion()
        {
            RegionInfo regionInfo = new RegionInfo(CultureInfo.CurrentCulture.Name);
            if (regionInfo.TwoLetterISORegionName == "RU")
            {
                titleLabel.Text = "Программа Планирования";
                usernameLabel.Text = "Имя Пользователя";
                passwordLabel.Text = "Пароль";
                loginButton.Text = "Войти";
                wrongPassword = "Неправильное имя пользователя или пароль.";
                noPassword = "Пожалуйста, введите свой пароль.";
                noUsername = "Пожалуйста, введите ваше имя пользователя.";
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameInput.Text == "") 
            {
                MessageBox.Show(noUsername);
            }
            else if (passwordInput.Text == "") 
            {
                MessageBox.Show(noPassword);
            }
            else {
                if (DB.login(usernameInput.Text.ToString(), passwordInput.Text.ToString()))
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Close();
                } 
                else MessageBox.Show(wrongPassword);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
