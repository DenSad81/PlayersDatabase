using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        const string CommandAdd = "1";
        const string CommandDelete = "2";
        const string CommandBan = "4";
        const string CommandUnban = "5";
        const string CommandShow = "6";
        const string CommandShowAll = "7";
        const string CommandExit = "8";
        Database database = new Database();
        bool isRun = true;

        database.AddPlayer(new Player(0, "Den", 00));
        database.AddPlayer(new Player(1, "Serg", 11));
        database.AddPlayer(new Player(2, "Alex", 22));
        database.AddPlayer(new Player(3, "Petr", 33));
        database.AddPlayer(new Player(4, "Anna", 44));
        database.AddPlayer(new Player(5, "Ket", 55));
        database.AddPlayer(new Player(6, "Oner", 66));
        database.AddPlayer(new Player(7, "Akira", 77));

        Console.WriteLine($"Menu: {CommandAdd}-Add;");
        Console.WriteLine($"      {CommandDelete}-Delete;");
        Console.WriteLine($"      {CommandBan}-Ban;");
        Console.WriteLine($"      {CommandUnban}-Unban;");
        Console.WriteLine($"      {CommandShow}-Show data;");
        Console.WriteLine($"      {CommandShowAll}-Show all data;");
        Console.WriteLine($"      {CommandExit}-Exit;");

        while (isRun)
        {
            Console.Write("Your shois: ");
            string choise = Console.ReadLine();

            switch (choise)
            {
                case CommandAdd:
                    database.AddPlayer(Player.CreatePlaer());
                    break;

                case CommandExit:
                    isRun = false;
                    break;

                case CommandShowAll:
                    database.ShowAllPlayersData();
                    break;

                case CommandDelete:
                    database.DeletePlayer();
                    break;

                case CommandBan:
                    database.BanPlayer();
                    break;

                case CommandUnban:
                    database.UnbanPlayer();
                    break;

                case CommandShow:
                    database.ShowPlayerData();
                    break;
            }
        }
    }

    public static int ReadInt(string text = "")
    {
        int digitToOut;
        Console.Write(text + " ");

        while (int.TryParse(Console.ReadLine(), out digitToOut) == false)
            Console.Write(text + " ");

        return digitToOut;
    }

    public static string ReadString(string text = "")
    {
        Console.Write(text + " ");
        string stringFromConsole = Console.ReadLine();
        return stringFromConsole;
    }

    public static bool ReadBool(string text = "")
    {
        Console.Write(text + " ");
        bool isOut;

        while (bool.TryParse(Console.ReadLine(), out isOut) == false)
        { }

        return isOut;
    }
}

class Database
{
    private List<Player> _players;

    public Database()
    {
        _players = new List<Player>();
    }

    public void AddPlayer(Player newPlayer)
    {
        foreach (var player in _players)
        {
            if (player.Id == newPlayer.Id)
            {
                Console.WriteLine("Player with this Id is present");
                return;
            }
        }

        _players.Add(newPlayer);
    }

    public void DeletePlayer()
    {
        Player player;

        if (TryGetPlayer(out player) == false)
            return;

        for (int i = 0; i < _players.Count; i++)
        {
            if (player.Id == _players[i].Id)
            {
                _players.RemoveAt(i);
                return;
            }
        }
    }

    public void ShowAllPlayersData()
    {
        foreach (var player in _players)
            player.ShowData();
    }

    public void ShowPlayerData()
    {
        Player player;

        if (TryGetPlayer(out player) == false)
            return;

        player.ShowData();
    }

    public void BanPlayer()
    {
        Player player;

        if (TryGetPlayer(out player) == false)
            return;

        player.Ban();
    }

    public void UnbanPlayer()
    {
        Player player;

        if (TryGetPlayer(out player) == false)
            return;

        player.Unban();
    }

    private bool TryGetPlayer(out Player player)
    {
        player = null;
        int plaerIndexOfPosition = GetPlaerIndexOfPosition();

        if (plaerIndexOfPosition < 0)
            return false;

        player = _players[plaerIndexOfPosition];
        return true;
    }

    private int GetPlaerIndexOfPosition()
    {
        int id = Program.ReadInt("Id № ");
        int indexOfPosition = -1;

        for (int i = 0; i < _players.Count; i++)
        {
            if (_players[i].Id == id)
                indexOfPosition = i;
        }

        if (indexOfPosition < 0)
            Console.WriteLine("Incorrect Id: ");

        return indexOfPosition;
    }
}

class Player
{
    private string _name;
    private int _level;
    private bool _isBan;

    public Player(int id = 0, string name = "no name", int level = 0, bool isBan = false)
    {
        Id = id;
        _name = name;
        _level = level;
        _isBan = isBan;
    }

    public static Player CreatePlaer()
    {
        int id = Program.ReadInt("Inpout Id: ");
        string name = Program.ReadString("Inpout Name: ");
        int level = Program.ReadInt("Inpout level: ");
        bool isBan = Program.ReadBool("Inpout ban (true/false): ");

        return new Player(id, name, level, isBan);
    }

    public int Id { get; private set; }

    public void ShowData()
    {
        Console.WriteLine($"{Id}  {_name}  {_level}  {_isBan}");
    }

    public void Ban()
    {
        _isBan = true;
    }

    public void Unban()
    {
        _isBan = false;
    }
}