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
            User user1 = new User(1, "admin", "123456");
           
            UserList.Add(user1);
           
        }

        private void buLogin_Click(object sender, EventArgs e)
        {  setValueForText1 = this.txtUser.Text;
            MainScreen mainScreen = new MainScreen(setValueForText1);
          
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
