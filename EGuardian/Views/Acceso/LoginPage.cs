using EGuardian.Controls;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Plugin.Toasts;
using Xamarin.Forms;
using EGuardian.Helpers;

namespace EGuardian.Views.Acceso
{
    public class LoginPage : ContentPage
    {
        ExtendedEntry Usuario, Contrasenia;
        Label forget;
        Button login;
        public bool Logeado;

        public LoginPage()
        {
            MessagingCenter.Subscribe<Registro>(this, "Registro", (sender) =>
            {
                Usuario.Text = sender.correo.Text;
                Contrasenia.Text = sender.contrasenia.Text;
            });

            MessagingCenter.Subscribe<Forget>(this, "Forget", (sender) =>
            {
                Usuario.Text = sender.Usuario.Text;
                Contrasenia.Text = sender.contrasenia.Text;
            });

            /*MessagingCenter.Subscribe<CambioContraseniaModeloVista>(this, "Cambio", (sender) =>
            {
                Usuario.Text = sender.emailLogin;
                Contrasenia.Focus();
            });*/

            var logo = new Image
            {
                Source = "logo.png",
                WidthRequest = 150
            };
            var iUsuario = new Grid
            {
                Padding = new Thickness(3, 0, 0, 0),
                InputTransparent = true,
                Children = { new Image { Source = "email.png", WidthRequest = 15 } }
            };

            Usuario = new ExtendedEntry()
            {
                AutomationId = "LoginUser",
                Keyboard = Keyboard.Email,
                Placeholder = "Correo electrónico",
                PlaceholderColor = Color.FromHex("91a5af"),
                FontFamily = Device.OnPlatform("OpenSans", "OpenSans-Regular", null),
                TextColor = Color.FromHex("91a5af"),
                BackgroundColor = Color.White,
                Text = string.Empty,
                HeightRequest = 50,
                HasBorder = false
            };
            var gUsuario = new Grid
            {
                Padding = new Thickness(Device.OnPlatform(10, 5, 5), 0, 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { Usuario }
            };

            var email = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children = { iUsuario, gUsuario }
            };

            var iContrasenia = new Grid
            {
                InputTransparent = true,
                Padding = new Thickness(3, 0, 0, 0),
                Children = { new Image { Source = "key.png", WidthRequest = 15 } }
            };

            Contrasenia = new ExtendedEntry()
            {
                AutomationId = "LoginPass",
                Placeholder = "Contraseña",
                PlaceholderColor = Color.FromHex("91a5af"),
                FontFamily = Device.OnPlatform("OpenSans", "OpenSans-Regular", null),
                TextColor = Color.FromHex("91a5af"),
                BackgroundColor = Color.Transparent,
                Text = string.Empty,
                HeightRequest = 50,
                HasBorder = false,
            };

            var gContrasenia = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(Device.OnPlatform(10, 5, 5), 0, 0, 0),
                Children = { Contrasenia }
            };

            var pass = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Horizontal,
                Children = { iContrasenia, gContrasenia }
            };

            var ingreso = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(10, 1, 10, 1),
                Spacing = 0,
                Children =
                {
                    email,
                    new BoxView {BackgroundColor= Color.FromHex("a2b3bb"), HeightRequest=0.5 },
                    pass
                }
            };

            var fIngreso = new Frame
            {
                WidthRequest = 300,
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.White,
                OutlineColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = false,
                Content = ingreso
            };

            login = new Button
            {
                AutomationId = "Login",
                Text = "INGRESAR",
                TextColor = Color.FromHex("373152"),
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromHex("ffffff"),
                CornerRadius = 7,
                WidthRequest = 300,
                HeightRequest = 50
            };
            login.Clicked += Login_Clicked;

            var indicador = new ActivityIndicator
            {
                IsVisible = true,
                IsRunning = true,
                BindingContext = this,
                Color = Color.FromHex("f7efd9"),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            indicador.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");

            forget = new Label
            {
                Text = "Restablecer contraseña",
                TextColor = Color.FromHex("f7efd9"),
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 20,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            var tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) => Forget_Clicked();
            forget.GestureRecognizers.Add(tap);

            var acceso = new StackLayout
            {
                Spacing = 40,
                Children = { login, indicador, forget }
            };

            var registro = new Button
            {
                Text = "CREAR EMPRESA",
                TextColor = Color.White,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 20,
                VerticalOptions = LayoutOptions.EndAndExpand,
                BackgroundColor = Color.FromHex("f7b819"),
                HeightRequest = 65,
                BorderRadius = 0
            };
            registro.Clicked += Registro_Clicked;
            var content_ingreso = new StackLayout
            {
                Spacing = 50,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { logo, fIngreso }
            };

            var content_login = new StackLayout
            {
                Spacing = 20,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { content_ingreso, acceso }
            };
            var content = new StackLayout
            {
                Spacing = 20,
                Padding = new Thickness(0, 50, 0, 0),
                Children = { content_login, registro }
            };
            var contenido = new ScrollView
            {
                Content = content
            };
            Content = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Image
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Aspect = Aspect.AspectFill,
                        Source="login_bk",
                    },
                    contenido
                }
            };
        }

        private void Registro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Registro());
        }
        string getContrasenia()
        {
            /*System.Diagnostics.Debug.WriteLine("HASH(MD5) " + MD5.GetHashString(Contrasenia.Text.Trim() + Constantes.Salt_Text.Trim()));
            return MD5.GetHashString(Contrasenia.Text.Trim() + Constantes.Salt_Text.Trim());*/
            return Contrasenia.Text.Trim();
        }
        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Usuario.Text))
            {
                await DisplayAlert("", "Por favor, indique su correo electrónico ", "Aceptar");
                Usuario.Focus();
                return;
            }
            else
            {
                if (!Regex.Match(Usuario.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    await DisplayAlert("", "Por favor, indique una dirección de correo electrónico válida", "Aceptar");
                    Usuario.Focus();
                    return;
                }
            }
            if (String.IsNullOrEmpty(Contrasenia.Text))
            {
                await DisplayAlert("", "Por favor, indique su contraseña", "Aceptar");
                Contrasenia.Focus();
                return;
            }
            this.IsBusy = true;
            login.IsEnabled = false;
            login.IsVisible = false;

            /*Login peticion = new Login
            {
                email = Usuario.Text,
                password = getContrasenia(),
                deviceOS = Constantes.device_OS,
                deviceLatLang = deviceLatLang
            };
            List<UsuarioRespuesta> Session = new List<UsuarioRespuesta>();
            Session = await App.ManejadorDatos.LoginAsync(peticion);
            bool isEmpty = !Session.Any();
            if (isEmpty)
            {
                ShowToast(ToastNotificationType.Error, "Inconvenientes de conexión", "Lo lamentamos, existen inconvenientes en la conexión; intente más tarde.", 7);
                login.IsVisible = true;
                login.IsEnabled = true;
                this.IsBusy = false;
            }
            else
            {
                foreach (var session in Session)
                {
                    if (string.IsNullOrEmpty(session.Result_Cd) || session.Result_Cd.Equals("ER"))
                    {
                        ShowToast(ToastNotificationType.Error, "Verifique sus datos de inicio de sesión", session.Result_Msg, 5);
                        login.IsVisible = true;
                        login.IsEnabled = true;
                        this.IsBusy = false;
                    }
                    else if (string.IsNullOrEmpty(session.Result_Cd) || session.Result_Cd.Equals("OK"))
                    {
                        Medicloud.Helpers.Settings.session_Session_Token = session.Session_Token;
                        Medicloud.Helpers.Settings.session_User_Nm = session.User_Nm;
                        Medicloud.Helpers.Settings.session_Account_Nm = session.Account_Nm;
                        Medicloud.Helpers.Settings.session_Ctry_Cd = session.Ctry_Cd;
                        usuario usuario = App.Database.GetUser(peticion.email);
                        if (usuario == null)
                        {
                            usuario = new usuario();
                            usuario.email = peticion.email;
                            Logeado = false;
                        }
                        else
                            Logeado = true;
                        usuario.fechaUltimoInicio = DateTime.Now.ToString();
                        usuario.LatLangUltimoInicio = peticion.deviceLatLang;
                        usuario.User_Nm = Settings.session_User_Nm;
                        usuario.Account_Nm = Settings.session_Account_Nm;
                        usuario.Ctry_Cd = Settings.session_Ctry_Cd;
                        var res = App.Database.InsertUsuario(usuario);
                        if (!Logeado)
                            usuario = App.Database.GetUser(peticion.email);
                        Medicloud.Helpers.Settings.session_idUsuario = usuario.id.ToString();
                        this.IsBusy = false;
                        MessagingCenter.Send<InicioSesion>(this, "Autenticado");
                    }
                    else
                    {
                        ShowToast(ToastNotificationType.Error, "Inconvenientes de conexión", "Lo lamentamos, existen inconvenientes en la conexión; intente más tarde.", 7);
                        login.IsVisible = true;
                        login.IsEnabled = true;
                        this.IsBusy = false;
                    }
                }
            }*/
            MessagingCenter.Send<LoginPage>(this, "Autenticado");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Contrasenia.IsPassword = true;
        }

        private async void Forget_Clicked()
        {
            await Navigation.PushPopupAsync(new Forget());
        }

        private async void ShowToast(ToastNotificationType type, string titulo, string descripcion, int tiempo)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            bool tapped = await notificator.Notify(type, titulo, descripcion, TimeSpan.FromSeconds(tiempo));
        }
    }
}