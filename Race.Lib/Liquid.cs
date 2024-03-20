namespace Race.Lib;

public class Liquid
{
    public string Name { get; private set; }
    public int Position { get; private set; }
    public int MaxSpeed { get; private set; }

    public Liquid(string name, int maxSpeed)
    {
        Name = name;
        MaxSpeed = maxSpeed;
    }

    public void Move()
    {
        Position += RNG.Range(MaxSpeed, 1);
    }

    public void MoveBack()
    {
        Position -= RNG.Range(3, 1);
    }

    public void Reset()
    {
        Position = 0;
    }


    public static bool operator !(Liquid? liquid) => liquid == null;
}