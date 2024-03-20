using Race.Lib;
using Spectre.Console;

namespace Race.Console;

public static class Program
{
    private static readonly RaceManager RaceManager = new();
    private static bool _isRunning = true;
    public static void Main()
    {
        do
        {
            AnsiConsole.Clear();
            DisplayGameTitle();
            var trackSelection = new SelectionPrompt<Track>().Title("Select a track")
                .PageSize(5).AddChoices(RaceManager.GetTracks())
                .UseConverter(track => $"{track.Name} length {track.Length}");

            var selectedTrack = AnsiConsole.Prompt(trackSelection);

            var liquidSelection = new SelectionPrompt<Liquid>().Title("Select a liquid").PageSize(5)
                .AddChoices(RaceManager.GetLiquids()).UseConverter(liquid => $"{liquid.Name}, top speed {liquid.MaxSpeed}");

            var selectedLiquid = AnsiConsole.Prompt(liquidSelection);
            AnsiConsole.Clear();

            DisplayGameTitle();

            RaceManager.BeginRace(selectedTrack, selectedLiquid);

            var topThree = RaceManager.GetTopThree().Select(liquid => new Text($"{liquid}\n", new Style(Color.GreenYellow)).Centered())
                .ToList();
            var panel = new Panel(new Rows(topThree))
            {
                Header = new PanelHeader("[yellow1]Top Three[/]", Justify.Center),
                Border = BoxBorder.Rounded,
                Width = 200
            };

            AnsiConsole.Write(panel);

           var result = AnsiConsole.Ask<string>("type exit to exit else enter to play again");
           if (result.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
           {
               _isRunning = false;
           }
        } while (_isRunning);

    }

    private static void DisplayGameTitle()
    {
        AnsiConsole.Write(
            new FigletText("Liquid Race")
                .Centered()
                .Color(Color.Red));
    }
}