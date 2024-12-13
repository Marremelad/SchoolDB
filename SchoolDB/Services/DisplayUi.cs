using SchoolDB.Options;
using Spectre.Console;

namespace SchoolDB.Services;

public static class DisplayMenu
{
    public static MenuText.MenuChoice Display(string title, Dictionary<string, MenuText.MenuChoice> choices)
    {
        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose an option.")
                    .PageSize(10)
                    .MoreChoicesText("Move up and down to reveal more options")
                    .AddChoices(choices.Select(s => s.Key)));

            return choices[choice];
        }
    }
}