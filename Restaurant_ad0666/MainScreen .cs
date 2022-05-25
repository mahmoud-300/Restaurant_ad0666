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
        public MainScreen()
        {
            InitializeComponent(); 
            
        
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
          
            homeScreen.Show();
        }

        private void pnNavigation_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
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

    

        private void button2_Click(object sender, EventArgs e)
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
