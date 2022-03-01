namespace CyberASP
{
    public class Team
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public List<Player> Players { get; set; }
        public Team()
        {
            ID = 0; 
            Name = string.Empty;
            Players = new List<Player>();
            Created = DateTime.MinValue;
        }
        public Team(string name , DateTime created)
        {
            Name = name;
            Created = created;
        }
        public void AddPLayer(Player player)
        {
            Players.Add(player);
        }
    }
}
