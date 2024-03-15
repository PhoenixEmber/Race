namespace Race.Lib;

public static class RNG
{
    private static Random _rng = new Random();

    public static int Range(int upper, int lower) => _rng.Next(lower, upper);
}