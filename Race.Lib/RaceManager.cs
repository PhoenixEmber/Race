namespace Race.Lib;

public class RaceManager
{
    private Bookmaker _bookmaker = new();

    private readonly List<Liquid> _liquids =
    [
        new Liquid("Lava", 5),
        new Liquid("Water", 7),
        new Liquid("Slime", 3),
        new Liquid("Milk", 4)
    ];

    private readonly List<Track> _tracks =
    [
        new Track("Track 1", 10),
        new Track("Track 2", 20),
        new Track("Track 3", 25),
        new Track("Track 4", 40)
    ];

    public IEnumerable<Liquid> BeginRace(Track track, Liquid liquid)
    {
        var race = new Race(_liquids, track);
        race.ConductRace();

        
        
        return race.GetFinishedLiquids();
    }
    
    public IEnumerable<Liquid> GetLiquids() => _liquids;
    public IEnumerable<Track> GetTracks() => _tracks;
    
}