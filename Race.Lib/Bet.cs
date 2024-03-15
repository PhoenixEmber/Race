namespace Race.Lib;

public class Bet
{
    private int _money;
    private Player _player;
    private Liquid _liquid;

    public Bet(Player player, Liquid liquid, int money)
    {
        _player = player;
        _liquid = liquid;
        _money = money;
    }
}