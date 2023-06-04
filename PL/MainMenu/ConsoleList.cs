using System;
using System.Collections.Generic;

namespace PL
{
    public class ConsoleList
    {
        private List<MenuItem> menuItems;
        public ConsoleList()
        {
            menuItems = new List<MenuItem>();
        }
        public int Length { get { return menuItems.Count; } }
        public void Add(string name, Action action)
        {
            menuItems.Add(new MenuItem(name, action, menuItems.Count));
        }
        public MenuItem this[int i]
        {
            get { return menuItems[i]; }
        }
    }
}
