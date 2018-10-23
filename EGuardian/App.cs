using EGuardian.Data;
using EGuardian.Helpers;
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
            MessagingCenter.Subscribe<Views.Menu.Menu>(this, "logout", (sender) =>
            {
                MainPage = new LoginPage();
            });
            MessagingCenter.Subscribe<LoginPage>(this, "Login", (sender) =>
            {
                MainPage = new MainPage();
                Settings.session_Session_Token = "1";
                Settings.session_idUsuario = "1";
            });            

            ManejadorDatos = new ManejadorDatos(new DataStore());

            if (!string.IsNullOrEmpty(Settings.session_Session_Token))
                MainPage = new MainPage();
            else
                MainPage = new TutorialPage(); //MainPage = new Login();
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