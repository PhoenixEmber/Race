using Race.Lib;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Race.Console;

public static class Program
{
    private static readonly RaceManager RaceManager = new();

    public static void Main()
    {
        DisplayGameTitle();
        var trackSelection = new SelectionPrompt<Track>().Title("Select a track")
            .PageSize(5).AddChoices(RaceManager.GetTracks())
            .UseConverter(track => $"{track.Name} length {track.Length}");

        var selectedTrack = AnsiConsole.Prompt(trackSelection);

        var liquidSelection = new SelectionPrompt<Liquid>().Title("Select a liquid").PageSize(5)
            .AddChoices(RaceManager.GetLiquids()).UseConverter(liquid => $"{liquid.Name}, top speed {liquid.MaxSpeed}");

        var selectedLiquid = AnsiConsole.Prompt(liquidSelection);

        AnsiConsole.MarkupLine("[green]Balance: $100[/]");
        AnsiConsole.Ask<int>($"How much would you like to bet on {selectedLiquid.Name}:");
        AnsiConsole.Clear();

        DisplayGameTitle();

        RaceManager.BeginRace(selectedTrack, selectedLiquid);

        var topThree = RaceManager.GetTopThree().Select(liquid => new Text($"{liquid}\n", new Style(Color.GreenYellow)).Centered())
            .ToList();
        var panel = new Panel(new Rows(topThree))
        {
            Header = new PanelHeader("[yellow1]Top Three[/]", Justify.Center),
            Border = BoxBorder.Rounded,
            Width = 80
        };

        AnsiConsole.Write(panel);

        AnsiConsole.Ask<string>("");
    }

    private static void DisplayGameTitle()
    {
        AnsiConsole.Write(
            new FigletText("Liquid Race")
                .Centered()
                .Color(Color.Red));
    }
}