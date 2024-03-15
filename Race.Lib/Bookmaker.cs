namespace Race.Lib;

public class Bookmaker
{
    private readonly List<Bet> _bets = [];

    public void AddBet(Player player, Liquid liquid, int money)
    {
        if (player.GetMoney() < money)
        {
            Console.WriteLine($"not enough money {player.GetMoney()} you tried to bet {money}");
            return;
        }

        _bets.Add(new Bet(player, liquid, money));
        player.SubtractMoney(money);
    }
}