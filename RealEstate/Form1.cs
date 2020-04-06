using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RealEstate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 1800;
            this.Height = 700;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadFromXml();
        }

        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private void loadFromXml()
        {
            XmlDocument document = new XmlDocument();
            document.Load("configuration.xml");
            var xmlNodeList = document.SelectNodes("root/oneToN");
            foreach (XmlNode node in xmlNodeList)
            {
                OneToNQueries oneToNQueries = new OneToNQueries();
                oneToNQueries.connectionString =
                    node.SelectSingleNode("connection").InnerText;
                oneToNQueries.masterName = node.SelectSingleNode("master/name").InnerText;
                oneToNQueries.name =
                    node.SelectSingleNode("name").InnerText;
                oneToNQueries.masterName = node.SelectSingleNode("master/name").InnerText;
                oneToNQueries.masterFriendlyName = Int32.Parse(node
                    .SelectSingleNode("master/friendlyName").InnerText);
                oneToNQueries.selectMaster = node.SelectSingleNode("master/select/query")
                    .InnerText;

                oneToNQueries.slaveName = node.SelectSingleNode("slave/name").InnerText;
                oneToNQueries.selectSlave =
                    node.SelectSingleNode("slave/select/query").InnerText;
                oneToNQueries.maxSlaveId = node.SelectSingleNode("slave/maxId/query").InnerText;
                oneToNQueries.getSlaveByMasterId = node
                    .SelectSingleNode("slave/getByMaster/query").InnerText;
                oneToNQueries.getSlaveByMasterIdParams = Int32.Parse(node
                    .SelectSingleNode("slave/getByMaster/parameters").InnerText);
                oneToNQueries.insertSlave =
                    node.SelectSingleNode("slave/insert/query").InnerText;
                oneToNQueries.insertSlaveParams = Int32.Parse(node
                    .SelectSingleNode("slave/insert/parameters").InnerText);
                oneToNQueries.updateSlave =
                    node.SelectSingleNode("slave/update/query").InnerText;
                oneToNQueries.updateSlaveParams = Int32.Parse(node
                    .SelectSingleNode("slave/update/parameters").InnerText);
                oneToNQueries.deleteSlave =
                    node.SelectSingleNode("slave/delete/query").InnerText;
                oneToNQueries.deleteSlaveParams = Int32.Parse(node
                    .SelectSingleNode("slave/delete/parameters").InnerText);
                
                OneToNTab oneToNTab = new OneToNTab(oneToNQueries);
                this.tabs.TabPages.Add(oneToNTab);
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}