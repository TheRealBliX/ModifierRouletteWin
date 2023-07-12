using System;
namespace ModifierRoulette
{
    public class Menu
    {
        private int SelectedIndex;
        private List<string?> Options;
        private string Prompt;

        public Menu(string _Prompt, List<string?> _Options)
        {
            Prompt = _Prompt;
            Options = _Options;
            SelectedIndex = 0;
        }

        public void DisplayOptions()
        {
            Console.WriteLine(Prompt);

            for (int i = 0; i < Options.Count; i++)
            {
                string? currentOption = Options[i];
                if (i == SelectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"<<{currentOption}>>");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Count - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Count)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}


