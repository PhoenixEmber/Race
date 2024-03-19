using Race.Lib;
using Spectre.Console;

namespace Race.Console;

public static class Program
{
    

    public static void Main()
    {
        var racemanager = new RaceManager();

        var trackSelection = new SelectionPrompt<Track>().Title("Select a track")
            .PageSize(5).AddChoices(racemanager.GetTracks()).UseConverter(track => track.Name);

        var selectedTrack = AnsiConsole.Prompt(trackSelection);

        var liquidSelection = new SelectionPrompt<Liquid>().Title("Select a liquid").PageSize(5)
            .AddChoices(racemanager.GetLiquids()).UseConverter(liquid => liquid.Name);

        var selectedLiquid = AnsiConsole.Prompt(liquidSelection);
        
        AnsiConsole.MarkupLine("[green]Balance: $100[/]");
        AnsiConsole.Ask<int>($"How much would you like to bet on {selectedLiquid.Name}:");

        var liquids = racemanager.BeginRace(selectedTrack, selectedLiquid);
        foreach (var liquid in liquids)
        {
            System.Console.WriteLine(liquid.Name);
        }
    }
}