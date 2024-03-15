namespace Race.Lib;

public class Liquid
{
    private string _name;
    private int _maxSpeed;
    private int _position;

    public Liquid(string name, int maxSpeed)
    {
        _name = name;
        _maxSpeed = maxSpeed;
    }

    public void Move()
    {
        _position += RNG.Range(_maxSpeed, 1);
    }

    public void MoveBack()
    {
        _position--;
    }

    public void Reset()
    {
        _position = 0;
    }

    public static bool operator !(Liquid? liquid) => liquid == null;
}