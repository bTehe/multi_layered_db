using System;

namespace PL
{
    public class MenuItem
    {
        public MenuItem(string name, Action action, int index)
        {
            Name = name;
            Action = action;
            Index = index;
        }

        public string Name { get; set; }
        public Action Action { get; set; }
        public int Index { get; }
    }
}
