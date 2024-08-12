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

        database.AddPlayer(new Player(0, "Den", 00, false));
        database.AddPlayer(new Player(1, "Serg", 11, false));
        database.AddPlayer(new Player(2, "Alex", 22, false));
        database.AddPlayer(new Player(3, "Petr", 33, false));
        database.AddPlayer(new Player(4, "Anna", 44, false));
        database.AddPlayer(new Player(5, "Ket", 55, false));
        database.AddPlayer(new Player(6, "Oner", 66, false));
        database.AddPlayer(new Player(7, "Akira", 77, false));

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
                    database.AddPlayer(database.CreatePlaer());
                    break;
                case CommandExit:
                    isRun = false;
                    break;
                case CommandShowAll:
                    database.ShowAllPlayerData();
                    break;
                case CommandDelete:
                    database.DeletePlayer(database.GetPlaerId());
                    break;
                case CommandBan:
                    database.BanPlayer(database.GetPlaerId());
                    break;
                case CommandUnban:
                    database.UnbanPlayer(database.GetPlaerId());
                    break;
                case CommandShow:
                    database.ShowPlayerData(database.GetPlaerId());
                    break;
            }
        }
    }
}

class Database
{
    private List<Player> _players;

    public Database()
    {
        _players = new List<Player>();
    }

    public int GetPlaerId()
    {
        int id = GetIntFromConsole("Id № ");
        int idFind = -1;

        for (int i = 0; i < _players.Count; i++)
        {
            if (_players[i].Id == id)
                idFind = i;
        }

        if (idFind < 0)
            Console.WriteLine("Incorrect Id: ");

        return idFind;
    }

    public void AddPlayer(Player playerData)
    {
        _players.Add(playerData);
    }

    public Player CreatePlaer()
    {
        int id = GetIntFromConsole("Inpout Id: ");
        string name = GetStringFromConsole("Inpout Name: ");
        int level = GetIntFromConsole("Inpout level: ");
        bool isBan = GetBoolFromConsole("Inpout ban (true/false): ");

        Player player = new Player(id, name, level, isBan);
        return player;
    }

    public void DeletePlayer(int indexOfPosition)
    {
        if (indexOfPosition < 0 || indexOfPosition >= _players.Count())
            Console.WriteLine("Error lenght database");
        else
            _players.RemoveAt(indexOfPosition);
    }

    public void ShowPlayerData(int indexOfPosition)
    {
        if (indexOfPosition < 0 || indexOfPosition >= _players.Count())
            Console.WriteLine("Error lenght database");
        else
            _players[indexOfPosition].ShowData();
    }

    public void ShowAllPlayerData()
    {
        foreach (var player in _players)
            player.ShowData();
    }

    public void BanPlayer(int indexOfPosition)
    {
        if (indexOfPosition < 0 || indexOfPosition >= _players.Count())
            Console.WriteLine("Error lenght database");
        else
            _players[indexOfPosition].Ban();
    }

    public void UnbanPlayer(int indexOfPosition)
    {
        if (indexOfPosition < 0 || indexOfPosition >= _players.Count())
            Console.WriteLine("Error lenght database");
        else
            _players[indexOfPosition].Unban();
    }

    private int GetIntFromConsole(string text = "")
    {
        int digitToOut;
        Console.Write(text + " ");

        while (int.TryParse(Console.ReadLine(), out digitToOut) == false)
            Console.Write(text + " ");

        return digitToOut;
    }

    private string GetStringFromConsole(string text = "")
    {
        Console.Write(text + " ");
        string stringFromConsole = Console.ReadLine();
        return stringFromConsole;
    }

    private bool GetBoolFromConsole(string text = "")
    {
        Console.Write(text + " ");
        bool isOut;

        while (bool.TryParse(Console.ReadLine(), out isOut) == false)
        { }

        return isOut;
    }
}

class Player
{
    public int Id { get; private set; }
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