namespace Race.Lib;

public class Race
{
    private int _id;
    private List<Liquid> _liquids;
    private List<int> _traps = [];
    private List<Liquid> _finished = [];
    private Track _track;
    private int _participants;

    public Race(List<Liquid> liquids, Track track)
    {
        _liquids = liquids;
        _track = track;
    }

    public void ConductRace()
    {
        _participants = _liquids.Count;
        
        _traps.Clear();
        for (var i = 0; i < RNG.Range(5, 1); i++)
            _traps.Add(RNG.Range(_track.Length, 0));

        var liquidsToRemove = new List<Liquid>();
        while (_finished.Count < _participants)
        {
            foreach (var liquid in _liquids)
            {
                liquid.Move();
                if (_traps.Contains(liquid.Position))
                    liquid.MoveBack();

                if (liquid.Position < _track.Length) continue;
                liquidsToRemove.Add(liquid);
                _finished.Add(liquid);
            }

            foreach (var liquid in liquidsToRemove)
                _liquids.Remove(liquid);

            liquidsToRemove.Clear();
        }
    }

    public List<Liquid> GetFinishedLiquids() => _finished;
}