using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class Form1 : Form
    {
        List<StringStringObject> properties = null;
        private int nextId = 0;

        private static string connectionString =
            @"Data Source=(local)\SQLEXPRESS01;Initial Catalog=PropertyRentalAgencyBeta;Integrated Security=True";

        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
            SqlDataAdapter sqlData = new SqlDataAdapter("Select * from Properties", sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            this.Properties.DataSource = dataTable;
            this.properties = dataTable.AsEnumerable()
                .Select(property => new StringStringObject(property[0].ToString(), property[1].ToString())).ToList();
            sqlConnection.Open();
            SqlCommand comm = new SqlCommand("SELECT MAX(item_id) FROM ItemsAtProperty", sqlConnection);
            Int32 count = (Int32) comm .ExecuteScalar();
            this.nextId = count + 1;
        }

        private void ItemsAtProperty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Properties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fillItemsTable();
        }

        private void fillItemsTable()
        {
            String id = this.Properties.SelectedRows[0].Cells[0].Value.ToString();
            SqlDataAdapter sqlData =
                new SqlDataAdapter("Select * from ItemsAtProperty where property_id = " + id, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            this.ItemsAtProperty.DataSource = dataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void addItemToPropertyButton_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm();
            itemForm.ComboBoxStrings = this.properties;
            itemForm.Property = this.ItemsAtProperty.SelectedCells[1].Value.ToString();
            itemForm.ShowDialog();

            DialogResult dialogResult = itemForm.DialogResult;
            if (dialogResult == DialogResult.OK)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string format =
                    "insert ItemsAtProperty values({4}, {0}, '{1}', {2}, '{3}')";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from ItemsAtProperty", connection);
                sqlDataAdapter.InsertCommand = new SqlCommand(
                    
                    string.Format(format, itemForm.Property, itemForm.ItemName, itemForm.Value, itemForm.Description,
                        this.nextId++), connection);
                sqlDataAdapter.InsertCommand.Connection = connection;
                connection.Open();
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                fillItemsTable();
            };
        }

        private void updateItemAtPropertyButton_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm();
            itemForm.ComboBoxStrings = this.properties;
            itemForm.ItemId = this.ItemsAtProperty.SelectedCells[0].Value.ToString();
            itemForm.Property = this.ItemsAtProperty.SelectedCells[1].Value.ToString();
            itemForm.ItemName = this.ItemsAtProperty.SelectedCells[2].Value.ToString();
            itemForm.Value = Int32.Parse(this.ItemsAtProperty.SelectedCells[3].Value.ToString());
            itemForm.Description = this.ItemsAtProperty.SelectedCells[4].Value.ToString();
            itemForm.ShowDialog();
            DialogResult dialogResult = itemForm.DialogResult;
            if (dialogResult == DialogResult.OK)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string format =
                    "update ItemsAtProperty set property_id={0}, name='{1}', value={2}, description='{3}' where item_id={4}";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from ItemsAtProperty", connection);
                sqlDataAdapter.UpdateCommand = new SqlCommand(
                    
                    string.Format(format, itemForm.Property, itemForm.ItemName, itemForm.Value, itemForm.Description,
                        itemForm.ItemId), connection);
                sqlDataAdapter.UpdateCommand.Connection = connection;
                connection.Open();
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                fillItemsTable();

            }
        }

        private void removeItemAtPropertyButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string format =
                "delete from ItemsAtProperty where item_id={0}";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from ItemsAtProperty", connection);
            sqlDataAdapter.DeleteCommand = new SqlCommand(
                    
                string.Format(format, this.ItemsAtProperty.SelectedCells[0].Value.ToString()), connection);
            sqlDataAdapter.DeleteCommand.Connection = connection;
            connection.Open();
            sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
            fillItemsTable();

        }
    }
}