using System;
using System.Linq;
using EGuardian.Data;
using EGuardian.Helpers;
using EGuardian.Models.Eventos;
using EGuardian.Services;
using EGuardian.Views.Acceso;
using EGuardian.Views.Menu;
using EGuardian.Views.Tutorial;
using Xamarin.Forms;

namespace EGuardian
{
    public partial class App : Application
    {
        public static EGuardianDatabase database;
        public static ManejadorDatos ManejadorDatos { get; set; }

        public static double DisplayScreenWidth = 0f;
        public static double DisplayScreenHeight = 0f;
        public static double NavigationBarHeight = 0f;
        public static double DisplayScaleFactor = 0f;

        public static EGuardianDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new EGuardianDatabase();
                }
                return database;
            }
        }

        public App()
        {
            MessagingCenter.Subscribe<Views.Menu.MainPage>(this, "noAutenticado", (sender) =>
            {
                MainPage = new LoginPage();
            });
            MessagingCenter.Subscribe<LoginPage>(this, "Autenticado", (sender) =>
            {
                MainPage = new MainPage();
                Settings.session_Session_Token = "1";
                Settings.session_idUsuario = "1";
            });

            MessagingCenter.Subscribe<Registro>(this, "Autenticado", (sender) =>
            {
                MainPage = new MainPage();
                Settings.session_Session_Token = "1";
                Settings.session_idUsuario = "1";
            });

            if(App.Database.GetEventos().ToList().Count==0)
            {
                for (int i = 0; i < 3;i++)
                {
                    string Asunto = "CAPACITACIÓN" + i;
                    App.Database.InsertEvento(
                       new eventos
                       {
                        asunto= Asunto,
                        fechaInicio=DateTime.Now.AddHours(-8+i).ToString(),
                        fechaFin = DateTime.Now.AddHours(-8 + i).AddMinutes(30+i).ToString()
                       });
                }
            }


            ManejadorDatos = new ManejadorDatos(new DataStore());
            if (!string.IsNullOrEmpty(Settings.session_Session_Token))
                MainPage = new MainPage();
            else
                MainPage = new TutorialPage();
        }

        protected override void OnStart()
        {            
        }

        protected override void OnSleep()
        {            
        }

        protected override void OnResume()
        {            
        }
    }
}