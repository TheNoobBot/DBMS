namespace RealEstate
{
    public class OneToNQueries
    {
        
        public string connectionString { get; set; }
        public string masterName { get; set; }
        public string slaveName { get; set; }
        public string name { get; set; }
        
        public string selectMaster { get; set; }
        public string selectSlave { get; set; }
        public string maxSlaveId { get; set; }
        public string getSlaveByMasterId { get; set; }
        public int getSlaveByMasterIdParams { get; set; }
        public string insertSlave { get; set; }
        public int insertSlaveParams { get; set; }
        public string updateSlave { get; set; }
        public int updateSlaveParams { get; set; }
        public string deleteSlave { get; set; }
        public int deleteSlaveParams { get; set; }
        
        
        public int masterFriendlyName { get; set; }

    }
}