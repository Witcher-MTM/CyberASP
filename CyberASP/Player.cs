namespace CyberASP
{
    public class Player
    {
        public int ID { get; private set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public Team Team { get; set; }

        public Player()
        {
            ID = 0;
            NickName = String.Empty; 
            FirstName = String.Empty; 
            SecondName = String.Empty; 
            LastName = String.Empty; 
            Team = new Team();
        }
        public Player(string name, string secondname,string lastname, string nickname , Team team )
        {
            NickName = nickname;
            FirstName = name;
            SecondName = secondname;
            LastName = lastname;
            Team = team;
            ID++;
        }

    }
}
