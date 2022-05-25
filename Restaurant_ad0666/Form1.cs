using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_ad0666
{
    public partial class FmLogin : Form
    {
        public static string setValueForText1 = "";
        private List<User> UserList = new List<User>();
        public FmLogin()
        {
            InitializeComponent();
            User user1 = new User(1, "mahmoud", "123456");
            User user2 = new User(2, "ahmad", "12345678");
            User user3 = new User(3, "admin", "1234");
            UserList.Add(user1);
            UserList.Add(user2);
        }

        private void buLogin_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            setValueForText1 = this.txtUser.Text;
            string userName = txtUser.Text;
            string password = txtPassword.Text;
            foreach (User user in UserList)
            {
                if (userName == user.UserName && password == user.Password) { mainScreen.Show(); Hide(); return; }
                MessageBox.Show(" Wrong username or password ");
                Hide();
            }
        }
    }
}
