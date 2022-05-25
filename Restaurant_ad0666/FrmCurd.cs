using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_ad0666
{
    public partial class FrmCurd : Form
    {
        string connectionSttring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Hp\Desktop\university\second\Visual Programming\Restaurant_ad0666\Restaurant_ad0666\Database_ layer\Database_res.accdb";
        OleDbConnection accessDatabaseConnection = null;
        //MS Access Database Connection String

        public FrmCurd()
        {
            accessDatabaseConnection = new OleDbConnection(connectionSttring);

            InitializeComponent();
            string query = "SELECT * From Table1";
            using (OleDbConnection conn = new OleDbConnection(connectionSttring))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            using (OleDbCommand insertCommand = new OleDbCommand("INSERT INTO TABLE1 ([orderNo],[order],[price]) VALUES (@orderNo,@order,@price)", accessDatabaseConnection))
            {

                if (accessDatabaseConnection.State != ConnectionState.Open)
                {
                    accessDatabaseConnection.Open();
                }


                insertCommand.Parameters.AddWithValue("@orderNo", Convert.ToInt32(txtNO.Text));
                insertCommand.Parameters.AddWithValue("@order", txtOrder.Text);
                insertCommand.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                insertCommand.ExecuteNonQuery();
                MessageBox.Show("data added successefully");
                OleDbCommand refreshCmd = new OleDbCommand("SELECT * FROM TABLE1", accessDatabaseConnection);
                DataTable dt = new DataTable();
                dt.Load(refreshCmd.ExecuteReader());
                dataGridView1.DataSource = dt;
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["orderNo"].DisplayIndex = 0;
                dataGridView1.Columns["order"].DisplayIndex = 1;
                dataGridView1.Columns["price"].DisplayIndex = 2;
                //ok

            }

        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbCommand updateCommand = new OleDbCommand("UPDATE TABLE1 SET [orderNo] = ?, [order] = ?,[price] = ? WHERE [ID] = ?", accessDatabaseConnection))
                {
                    if (accessDatabaseConnection.State != ConnectionState.Open)
                    {
                        accessDatabaseConnection.Open();
                    }

                    updateCommand.Parameters.AddWithValue("@orderNo", Convert.ToInt32(txtNO.Text));
                    updateCommand.Parameters.AddWithValue("@order", txtOrder.Text);
                    updateCommand.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                    updateCommand.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells[0].Value);

                    updateCommand.ExecuteNonQuery();
                    MessageBox.Show("data updated successefully");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void del_Button(object sender, EventArgs e)
        {
       
            try {
                
                using (OleDbCommand deleteCommand = new OleDbCommand("DELETE FROM TABLE1 WHERE [ID] = ?", accessDatabaseConnection))
                {
                    if (accessDatabaseConnection.State != ConnectionState.Open)
                    {
                        accessDatabaseConnection.Open();
                    }
                   
                      deleteCommand.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells[0].Value);

                    deleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Data deleted successfully");
                }

            }  catch (Exception ex) { MessageBox.Show(ex.Message); }
           


        }
    }
}

