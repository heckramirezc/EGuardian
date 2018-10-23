using EGuardian.Common.Resources;
using EGuardian.Models.Menu;
using EGuardian.Views.Ajustes;
using EGuardian.Views.API;
using EGuardian.Views.Eventos;
using EGuardian.Views.Incidencias;
using EGuardian.Views.Inicio;
using EGuardian.Views.Perfil;
using EGuardian.Views.Reportes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EGuardian.Views.Menu
{
    public class MainPage : MasterDetailPage
    {        
        Menu Menu = new Menu();
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            Title = Strings.MenuTitle;
            Master = Menu;
            MasterBehavior = MasterBehavior.Popover;
            NavigateFromMenu((int)MenuItemType.Inicio);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
                AddMenuPage(id);

            var menu = MenuPages[id];
            if (menu != null && Detail != menu)
            {
                menu.BarTextColor = Colors.BarTextColor;
                menu.BarBackgroundColor = Colors.BarBackgroundColor;
                Detail = menu;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        private void AddMenuPage(int id)
        {
            switch (id)
            {
                case (int)MenuItemType.Inicio:
                    MenuPages.Add(id, new NavigationPage(new InicioPage()));
                    break;
                case (int)MenuItemType.Eventos:
                    MenuPages.Add(id, new NavigationPage(new EventosPage()));
                    break;
                case (int)MenuItemType.Incidencias:
                    MenuPages.Add(id, new NavigationPage(new IncidenciasPage()));
                    break;
                case (int)MenuItemType.Perfil:
                    MenuPages.Add(id, new NavigationPage(new PerfilPage()));
                    break;
                case (int)MenuItemType.Reportes:
                    MenuPages.Add(id, new NavigationPage(new ReportesPage()));
                    break;
                case (int)MenuItemType.API:
                    MenuPages.Add(id, new NavigationPage(new APIPage()));
                    break;
                case (int)MenuItemType.Ajustes:                
                    MenuPages.Add(id, new NavigationPage(new AjustesPage()));
                    break;                
            }
        }
    }
}