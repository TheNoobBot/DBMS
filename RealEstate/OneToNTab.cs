using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace RealEstate
{
    public class OneToNTab : TabPage
    {
        List<StringStringObject> friendlyMaster = null;
        private int nextId = 0;

        Label masterLabel = new Label();
        Label slaveLabel = new Label();

        DataGridView masterGridView = new DataGridView();
        DataGridView slaveGridView = new DataGridView();

        Button addToMaster = new Button();
        Button removeSlave = new Button();
        Button updateSlave = new Button();

        private OneToNQueries oneToNQueries;

        private string connectionString;
        private SqlConnection sqlConnection;

        public OneToNTab(OneToNQueries oneToNQueries)
        {
            this.connectionString = oneToNQueries.connectionString;
            this.sqlConnection = new SqlConnection(connectionString);
            this.Text = oneToNQueries.name;
            this.oneToNQueries = oneToNQueries;
            masterLabel.Text = oneToNQueries.masterName;
            slaveLabel.Text = oneToNQueries.slaveName;

            masterLabel.Top = 25;
            masterLabel.Left = 50;
            masterLabel.Height = 25;
            masterLabel.Width = 150;

            masterGridView.Top = 90;
            masterGridView.Left = 50;
            masterGridView.Height = 400;
            masterGridView.Width = 800;
            masterGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            masterGridView.ReadOnly = true;
            masterGridView.SelectionChanged += (sender, args) => fillSlaveTable();

            slaveLabel.Top = 25;
            slaveLabel.Left = 975;
            slaveLabel.Height = 25;
            slaveLabel.Width = 150;

            slaveGridView.Top = 90;
            slaveGridView.Left = 975;
            slaveGridView.Height = 400;
            slaveGridView.Width = 700;
            slaveGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            slaveGridView.ReadOnly = true;

            addToMaster.Top = 550;
            addToMaster.Left = 50;
            addToMaster.Height = 30;
            addToMaster.Width = 150;
            addToMaster.Text = "Add";
            addToMaster.Click += addToMasterMethod;

            updateSlave.Top = 550;
            updateSlave.Left = 975;
            updateSlave.Height = 30;
            updateSlave.Width = 150;
            updateSlave.Text = "Update";
            updateSlave.Click += updateSlaveMethod;

            removeSlave.Top = 550;
            removeSlave.Left = 1150;
            removeSlave.Height = 30;
            removeSlave.Width = 150;
            removeSlave.Text = "Remove";
            removeSlave.Click += removeSlaveMethod;

            SqlDataAdapter sqlData = new SqlDataAdapter(oneToNQueries.selectMaster, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            this.masterGridView.DataSource = dataTable;
            this.friendlyMaster = dataTable.AsEnumerable()
                .Select(property => new StringStringObject(property[0].ToString(),
                    property[oneToNQueries.masterFriendlyName].ToString())).ToList();
            sqlConnection.Open();
            SqlCommand comm = new SqlCommand(oneToNQueries.maxSlaveId, sqlConnection);
            object result = comm.ExecuteScalar();
            Int32 count;
            try
            {
                count = (Int32) result;
            }
            catch
            {
                count = 0;
            }

            this.nextId = count + 1;

            this.Controls.Add(masterLabel);
            this.Controls.Add(slaveLabel);
            this.Controls.Add(masterGridView);
            this.Controls.Add(slaveGridView);
            this.Controls.Add(addToMaster);
            this.Controls.Add(updateSlave);
            this.Controls.Add(removeSlave);
        }

        private void fillSlaveTable()
        {
            List<String> stringList = new List<string>();
            for (int index = 0; index < oneToNQueries.getSlaveByMasterIdParams; index++)
            {
                stringList.Add(this.masterGridView.SelectedRows[0].Cells[index].Value.ToString());
            }

            var query = string.Format(this.oneToNQueries.getSlaveByMasterId, stringList.ToArray());

            SqlDataAdapter sqlData =
                new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            this.slaveGridView.DataSource = dataTable;
        }

        // private void addToMasterMethod(object sender, EventArgs e)
        // {
        //     List<FormItem> formItems = new List<FormItem>();
        //     for (int i = 0; i < oneToNQueries.insertSlaveParams; i++)
        //     {
        //         if (i != 1)
        //         {
        //             Label label = new Label();
        //             label.Text = slaveGridView.Columns[i].Name;
        //             TextBox textBox = new TextBox();
        //             if (i == 0)
        //             {
        //                 textBox.ReadOnly = true;
        //             }
        //
        //             formItems.Add(new FormItem(label, textBox));
        //         }
        //     }
        //
        //     ComboBox comboBox = new ComboBox();
        //     comboBox.DisplayMember = "String2";
        //     this.friendlyMaster.ForEach(stringString =>
        //         comboBox.Items.Add(stringString));
        //     string master = this.masterGridView.SelectedCells[0].Value.ToString();
        //     this.friendlyMaster.ForEach(stringString =>
        //     {
        //         if (stringString.String1 == master)
        //             comboBox.SelectedItem = stringString;
        //     });
        //     Label masterLabel = new Label();
        //     masterLabel.Text = slaveGridView.Columns[1].Name;
        //     ItemForm itemForm = new ItemForm(formItems, masterLabel, comboBox);
        //     itemForm.ShowDialog();
        //
        //     DialogResult dialogResult = itemForm.DialogResult;
        //     if (dialogResult == DialogResult.OK)
        //     {
        //         SqlConnection connection = new SqlConnection(connectionString);
        //         string format =
        //             oneToNQueries.insertSlave;
        //
        //         SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(oneToNQueries.selectSlave, connection);
        //         List<string> strings = new List<string>();
        //         this.nextId++;
        //         strings.Add(nextId.ToString());
        //         strings.Add(((StringStringObject) comboBox.SelectedItem).String1);
        //
        //         for (int i = 1; i < oneToNQueries.insertSlaveParams - 1; i++)
        //         {
        //             strings.Add(formItems[i].textBox.Text);
        //         }
        //
        //         sqlDataAdapter.InsertCommand = new SqlCommand(
        //             string.Format(format, strings.ToArray()), connection);
        //         sqlDataAdapter.InsertCommand.Connection = connection;
        //         connection.Open();
        //         sqlDataAdapter.InsertCommand.ExecuteNonQuery();
        //         fillSlaveTable();
        //     }
        // }

        private void addToMasterMethod(object sender, EventArgs e)
        {
            List<FormItem> formItems = new List<FormItem>();
            string masterId = "none";
            for (int i = 0; i < oneToNQueries.insertSlaveParams; i++)
            {
                Label label = new Label();
                label.Text = slaveGridView.Columns[i].Name;
                TextBox textBox = new TextBox();
                if (i == 0)
                {
                    textBox.ReadOnly = true;
                }
                else if (i == 1)
                {
                    string master = this.masterGridView.SelectedCells[0].Value.ToString();
                    this.friendlyMaster.ForEach(stringString =>
                    {
                        if (stringString.String1 == master)
                        {
                            textBox.Text = stringString.String2;
                            masterId = stringString.String1;
                        }
                    });
                    textBox.ReadOnly = true;
                }

                formItems.Add(new FormItem(label, textBox));
            }

            ItemForm itemForm = new ItemForm(formItems);
            itemForm.ShowDialog();

            DialogResult dialogResult = itemForm.DialogResult;
            if (dialogResult == DialogResult.OK)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string format =
                    oneToNQueries.insertSlave;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(oneToNQueries.selectSlave, connection);
                List<string> strings = new List<string>();
                this.nextId++;
                strings.Add(nextId.ToString());
                strings.Add(masterId);
                for (int i = 2; i < oneToNQueries.insertSlaveParams; i++)
                {
                    strings.Add(formItems[i].textBox.Text);
                }

                sqlDataAdapter.InsertCommand = new SqlCommand(
                    string.Format(format, strings.ToArray()), connection);
                sqlDataAdapter.InsertCommand.Connection = connection;
                connection.Open();
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                fillSlaveTable();
            }
        }

        private void updateSlaveMethod(object sender, EventArgs e)
        {
            List<FormItem> formItems = new List<FormItem>();
            string masterId = "none";
            for (int i = 0; i < oneToNQueries.insertSlaveParams; i++)
            {
                Label label = new Label();
                label.Text = slaveGridView.Columns[i].Name;
                TextBox textBox = new TextBox();
                textBox.Text = slaveGridView.SelectedCells[i].Value.ToString();
                if (i == 0)
                {
                    textBox.ReadOnly = true;
                }
                else if (i == 1)
                {
                    string master = this.masterGridView.SelectedCells[0].Value.ToString();
                    this.friendlyMaster.ForEach(stringString =>
                    {
                        if (stringString.String1 == master)
                        {
                            textBox.Text = stringString.String2;
                            masterId = stringString.String1;
                        }
                    });
                    textBox.ReadOnly = true;
                }

                formItems.Add(new FormItem(label, textBox));
            }

            ItemForm itemForm = new ItemForm(formItems);
            itemForm.ShowDialog();

            DialogResult dialogResult = itemForm.DialogResult;
            if (dialogResult == DialogResult.OK)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string format =
                    oneToNQueries.updateSlave;

                List<string> strings = new List<string>();
                for (int i = 0; i < oneToNQueries.insertSlaveParams; i++)
                {
                    if (i != 1)
                    {
                        strings.Add(formItems[i].textBox.Text);
                    }
                    else
                    {
                        strings.Add(masterId);
                    }
                }

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(oneToNQueries.selectSlave, connection);
                sqlDataAdapter.UpdateCommand = new SqlCommand(
                    string.Format(format, strings.ToArray()), connection);
                sqlDataAdapter.UpdateCommand.Connection = connection;
                connection.Open();
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                fillSlaveTable();
            }
        }

        private void removeSlaveMethod(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string format = oneToNQueries.deleteSlave;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(oneToNQueries.selectSlave, connection);
            sqlDataAdapter.DeleteCommand = new SqlCommand(
                string.Format(format, slaveGridView.SelectedCells[0].Value), connection);
            sqlDataAdapter.DeleteCommand.Connection = connection;
            connection.Open();
            sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
            fillSlaveTable();
        }
    }
}