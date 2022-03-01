namespace CyberASP
{
    public class LastGame
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
      
        public LastGame()
        {
            ID = 0;
            Name = string.Empty;
            Date = DateTime.MinValue;
        }
        public LastGame(string name , DateTime date)
        {
            Name = name;
            Date = date;
            ID++;
        }
    }
}
