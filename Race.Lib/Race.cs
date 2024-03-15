namespace Race.Lib;

public class Race
{
    private int _id;
    private List<Liquid> _liquids = [];
    private Track _track;
    private Liquid _winner;

    public void ConductRace()
    {
        while (!GetWinner())
        {

        }
    }
    
    public Liquid GetWinner() => _winner;
}