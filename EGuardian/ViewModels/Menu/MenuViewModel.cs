using EGuardian.Common.Resources;
using EGuardian.Models.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EGuardian.ViewModels.Menu
{
    public class MenuVistaModelo : BaseViewModel
    {
        public ObservableCollection<MenuItem> Menus { get; set; }
        public MenuVistaModelo()
        {
            Title = Strings.MenuTitle;
            Menus = new ObservableCollection<MenuItem>();
            Menus.Add(new MenuItem
            {
                Title = Strings.Menu1,
                Id = MenuItemType.Eventos,
                SeparatorVisibility = true
                //MenuTipoSiguiente = MenuItemType.Incidencias
            });
            Menus.Add(new MenuItem
            {
                Title = Strings.Menu2,
                Id = MenuItemType.Incidencias,
                SeparatorVisibility = true
                //MenuTipoSiguiente = MenuItemType.Perfil
            });
            Menus.Add(new MenuItem
            {
                Title = Strings.Menu3,
                SeparatorVisibility = true,
                Id = MenuItemType.Perfil,
                //MenuTipoSiguiente = MenuItemType.Reportes
            });
            Menus.Add(new MenuItem
            {
                Title = Strings.Menu4,
				SeparatorVisibility = true,
                Id = MenuItemType.Reportes,
                //MenuTipoSiguiente = MenuItemType.API
            });
            Menus.Add(new MenuItem
            {
                Title = Strings.Menu5,
                SeparatorVisibility = true,
                Id = MenuItemType.API,
                //MenuTipoSiguiente = MenuItemType.Salir
            });
            Menus.Add(new MenuItem
            {
                Title = Strings.Menu6,
                SeparatorVisibility = false,
                Id = MenuItemType.Salir
            });
        }
    }
}