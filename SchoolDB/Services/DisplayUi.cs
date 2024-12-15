using SchoolDB.Options;
using Spectre.Console;

namespace SchoolDB.Services;

public static class DisplayUi
{
    // Display single choice menu. Can handle both a dictionary and a list.
    public static object DisplaySingleChoiceMenu<T>(string title, T choices)
    {
        if (choices is Dictionary<string, MenuText.MenuChoice> dictChoices)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText("Move up and down to reveal more options")
                    .AddChoices(dictChoices.Keys));

            return dictChoices[choice];
        }

        if (choices is List<string> listChoices)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText("Move up and down to reveal more options")
                    .AddChoices(listChoices));
            
            return choice;
        }

        throw new ArgumentException("Invalid choice type provided.");
    }


    // Display multi choice menu.
    public static List<string> DisplayMultiChoiceMenu(string title,
        Dictionary<string, MenuText.MenuChoice> choices)
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