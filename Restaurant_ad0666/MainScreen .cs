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
    public partial class MainScreen : Form
    {
        private string setValueForText1;

        public MainScreen(string setValueForText1)
        {
            InitializeComponent(); 
              this.setValueForText1 = setValueForText1;
        
        }

      

        private void MainScreen_Load(object sender, EventArgs e)
        {
            HomeScreen homeScreen = new HomeScreen();
            FmLogin frm1;
            homeScreen.TopLevel = false;
            homeScreen.AutoScroll = true;
            homeScreen.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(homeScreen);
            homeScreen.FormBorderStyle = FormBorderStyle.None;
            this.label1.Text = setValueForText1;
            homeScreen.Show();
        }

       

        private void homeButton(object sender, EventArgs e)
        {
            this.pnMain.Controls.Clear();
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.TopLevel = false;
            homeScreen.AutoScroll = true;
            homeScreen.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(homeScreen);
            homeScreen.FormBorderStyle = FormBorderStyle.None;

            homeScreen.Show();
        }

        private void curdButton(object sender, EventArgs e)
        {
            FrmCurd curdScreen = new FrmCurd();
            this.pnMain.Controls.Clear();
            curdScreen.TopLevel = false;
            curdScreen.AutoScroll = true;
            curdScreen.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(curdScreen);
            curdScreen.FormBorderStyle = FormBorderStyle.None;

            curdScreen.Show();
        }
    }
}
