using System;
using System.Collections.Generic;
using System.Text;

namespace EGuardian.Models
{
    public enum MenuItemType
    {
        Inicio,
        Salir
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
