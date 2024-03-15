namespace Race.Lib;

public class Player
{
    private string _name;
    private int _money;

    public Player(string name, int money)
    {
        _name = name;
        _money = money;
    }

    public void SubtractMoney(int amount)
    {
        _money -= amount;
    }

    public int GetMoney()
    {
        return _money;
    }
}