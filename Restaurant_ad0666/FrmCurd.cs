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
        string connectionSttring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Hp\Documents\Database_res.accdb";
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
                

                insertCommand.Parameters.AddWithValue("@orderNo", Convert.ToInt32(txtNO.Text) );
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
                

            }

        }

        private void update_Click(object sender, EventArgs e)
        {

            if (accessDatabaseConnection.State != ConnectionState.Open)
            {
                accessDatabaseConnection.Open();
            }
            OleDbCommand updateCmd = new OleDbCommand("UPDATE TABLE1 SET orderNo = @orderNo, order=@order, price=@price WHERE orderNo = @orderNo", accessDatabaseConnection);
            updateCmd.Parameters.AddWithValue("@orderNo", Convert.ToInt32(txtNO.Text));
            updateCmd.Parameters.AddWithValue("@order", txtOrder.Text);
            updateCmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
           
            updateCmd.ExecuteNonQuery();
            MessageBox.Show("Data updated successfully");
            OleDbCommand refreshCmd = new OleDbCommand("SELECT * FROM TABLE1", accessDatabaseConnection);
            DataTable dt = new DataTable();
            dt.Load(refreshCmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["orderNo"].DisplayIndex = 0;
            dataGridView1.Columns["order"].DisplayIndex = 1;
            dataGridView1.Columns["price"].DisplayIndex = 2;
        }

        private void del_Button(object sender, EventArgs e)
        {
            string query = "Delete From Student Where Id=@id";
            OleDbCommand updat = new OleDbCommand(query, accessDatabaseConnection);
            updat.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            accessDatabaseConnection.Open();
            updat.ExecuteNonQuery();
            accessDatabaseConnection.Close();
            
        }

    }
    }

