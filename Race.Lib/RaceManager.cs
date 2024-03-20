using System.Threading.Channels;

namespace Race.Lib;

public class RaceManager
{
    private Race? _currentRace;
    
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

    public void BeginRace(Track track, Liquid liquid)
    {
        _currentRace = new Race(_liquids, track);
        _currentRace.ConductRace();
    }
    

    public IEnumerable<string> GetTopThree() =>
        _currentRace!.GetFinishedLiquids().Select(liquid => liquid.Name).Take(3);

    public IEnumerable<Liquid> GetLiquids() => _liquids;
    public IEnumerable<Track> GetTracks() => _tracks;
}