using System;

namespace PL
{
    public class CustomMenu
    {
        private readonly ConsoleList _options;
        private int _selectIndex;
        private string _prompt;

        public CustomMenu(string prompt)
        {
            _prompt = prompt;
            _options = new ConsoleList();
            _selectIndex = 0;
        }

        public CustomMenu Add(string name, Action action)
        {
            _options.Add(name, action);
            return this;
        }

        private void DisplayOptions()
        {
            Console.WriteLine(_prompt);

            for (int i = 0; i < _options.Length; i++)
            {
                string prefix;

                if (i == _selectIndex)
                {
                    prefix = "-> ";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} << {_options[i].Name} >> ");
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

                ConsoleKeyInfo specificKey = Console.ReadKey(true);
                keyPressed = specificKey.Key;

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (_selectIndex != _options.Length - 1)
                    {
                        _selectIndex++;
                    }
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (_selectIndex != 0)
                    {
                        _selectIndex--;
                    }
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    if (_options[_selectIndex].Action == Close)
                    {
                        break;
                    }

                    _options[_selectIndex].Action.Invoke();
                }

            } while (true);

            return _selectIndex;
        }

        public static void Close() => throw new InvalidOperationException("Incorrect passing");
    }
}
