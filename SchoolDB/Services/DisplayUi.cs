using SchoolDB.Models;
using Spectre.Console;
using static SchoolDB.Options.MenuText;

namespace SchoolDB.Services;

public static class DisplayUi
{
    public static MenuChoice DisplaySingleChoiceMenu(string title,
        Dictionary<string, MenuChoice> choices)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .MoreChoicesText("Move up and down to reveal more options")
                .AddChoices(choices.Select(s => s.Key)));

        return choices[choice];
    }

    public static List<string> DisplayMultiChoiceMenu(string title,
        Dictionary<string, MenuChoice> choices)
    {
        var multipleChoices = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle an option, " + 
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(choices.Select(s => s.Key)));

        return multipleChoices;
    }
}