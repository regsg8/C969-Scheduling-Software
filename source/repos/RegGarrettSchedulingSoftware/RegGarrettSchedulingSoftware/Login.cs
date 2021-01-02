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

namespace RegGarrettSchedulingSoftware
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            checkRegion();
        }

        private string wrongPassword = "Incorrect Username or Password.";
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
            }
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            
        }

        // errorLabel.Text = wrongPassword;
        // Неправильное имя пользователя или пароль.
        //Нет аккаунта?
        //Регистрация
        //Выход
    }
}
