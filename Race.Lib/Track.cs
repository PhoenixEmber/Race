namespace Race.Lib;

public class Track
{
    public string Name { get; private set; }
    public int Length { get; private set; }

    public Track(string name, int length)
    {
        Name = name;
        Length = length;
    }
}