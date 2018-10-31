using System;
using System.Text.RegularExpressions;
using EGuardian.Common.Resources;
using EGuardian.Controls;
using EGuardian.Data;
using Plugin.Toasts;
using Xamarin.Forms;

namespace EGuardian.ViewModels.Perfil
{
    public class UsuarioDTViewModel : ContentView
    {
        ExtendedEntry nombres, apellidos, correo, direccion;
        ExtendedPicker puesto, genero;
        ExtendedDatePicker fechaNacimiento;
        Button guardar;
        int control;
        int anios, meses = 0;
        System.Globalization.CultureInfo globalizacion;
        Label edad, tipoEdad;
        ScrollView ContenidoVista;
        StackLayout Contenido;
        //perfiles perfil = App.Database.GetPerfil(Convert.ToInt32(Settings.session_idUsuario));



        public UsuarioDTViewModel()
        {

            globalizacion = new System.Globalization.CultureInfo("es-GT");
            /*MessagingCenter.Subscribe<CuentaAjustesView>(this, "DisplayAlert", (sender) =>
            {
                Focus();
                control = -1;
            });*/


            guardar = new Button
            {
                Text = "GUARDAR",
                FontSize = 18,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("F7B819"),
                WidthRequest = 128,
                HeightRequest = 38,
            };
            guardar.Clicked += Guardar_Clicked;

            RelativeLayout gridBoton = new RelativeLayout
            {
                WidthRequest = 130,
                HeightRequest = 42,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
            };
            gridBoton.Children.Add(
            new RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView
            {
                BackgroundColor = Color.FromHex("B2B2B2"),
                CornerRadius = 6,
                HeightRequest = 40,
                WidthRequest = 128,
            }, Constraint.Constant(2), Constraint.Constant(2));
            gridBoton.Children.Add(guardar, Constraint.Constant(0), Constraint.Constant(0));



            nombres = new ExtendedEntry
            {
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = perfil.First_Nm
            };

            apellidos = new ExtendedEntry
            {
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = perfil.Last_Nm
            };


            genero = new ExtendedPicker
            {
                Title = "Seleccione",
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.End,
                Margin = new Thickness(0, 0, 35, 0),
                Font = Device.OnPlatform<Font>(Font.OfSize("OpenSans-Bold", 14), Font.OfSize("OpenSans-Bold", 14), Font.Default)
            };

            IconView generoDropdown = new IconView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                Source = Images.Estado,
                WidthRequest = 25,
                HeightRequest = 25,
            };
            genero.SelectedIndexChanged += (sender, e) =>
            {
                if (genero.SelectedIndex == 1)
                    generoDropdown.Foreground = Color.FromHex("E91B5C");
                else
                    generoDropdown.Foreground = Color.FromHex("0C55A2");
            };

            foreach (string generos in Constants.genero.Keys)
            {
                genero.Items.Add(generos);
            }

            /*if (perfil.Gender.Equals("M"))
                genero.SelectedIndex = 0;
            else
                genero.SelectedIndex = 1;*/



            edad = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                FontSize = 14,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
            };

            tipoEdad = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                FontSize = 14,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
            };

            correo = new ExtendedEntry
            {
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                TextColor = Color.FromHex("B2B2B2"),
                HasBorder = false,
                IsEnabled = false,
                Keyboard = Keyboard.Email,
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = perfil.EMail
            };

            Grid Genero = new Grid();
            Genero.Children.Add(genero);
            Genero.Children.Add(generoDropdown);
            genero.SelectedIndex = 0;

            puesto = new ExtendedPicker
            {
                Title = "Seleccione",
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.End,
                Margin = new Thickness(0, 0, 35, 0),
                Font = Device.OnPlatform<Font>(Font.OfSize("OpenSans-Bold", 14), Font.OfSize("OpenSans-Bold", 14), Font.Default)
            };

            foreach (string puestosT in Constants.puestos.Keys)
            {
                puesto.Items.Add(puestosT);
            }

            IconView puestoDropdown = new IconView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                Source = "idropdown.png",
                WidthRequest = 10,
                HeightRequest = 10,
                Foreground = Color.FromHex("373152")
            };

            Grid Puesto = new Grid();
            Puesto.Children.Add(puesto);
            Puesto.Children.Add(puestoDropdown);
            puesto.SelectedIndex = -1;

            Grid generoPuesto = new Grid
            {
                RowSpacing = 0,
                ColumnSpacing = 15,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength (5, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength (5, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) }
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                }
            };
            generoPuesto.Children.Add(new Label
            {
                Text = "PUESTO:",
                FontSize = 13,
                TextColor = Color.FromHex("373152"),
                FontAttributes = FontAttributes.Bold,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
            }, 0, 0);
            generoPuesto.Children.Add(new Label
            {
                Text = "GÉNERO:",
                FontSize = 13,
                TextColor = Color.FromHex("373152"),
                FontAttributes = FontAttributes.Bold,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
            }, 1, 0);
            generoPuesto.Children.Add(Puesto, 0, 2);
            generoPuesto.Children.Add(Genero, 1, 2);
            generoPuesto.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("373152"), HeightRequest = 2 }
                , 0, 4);
            generoPuesto.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("373152"), HeightRequest = 2 }
                , 1, 4);                

            StackLayout datosGenerales = new StackLayout
            {
                Padding = new Thickness(15, 15, 15, 20),
                Spacing = 15,
                BackgroundColor = Color.FromHex("E5E5E5"),
                Children =
                    {
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            Children =
                            {
                                new IconView
                                {
                                    Source = "iNPadmin.png",
                                    WidthRequest = 15,
                                    Foreground = Color.FromHex("373152"),
                                    VerticalOptions = LayoutOptions.Center
                                },
                                new Label
                                {
                                    Text = "Datos de Usuario",
                                    TextColor = Color.FromHex("373152"),
                                    VerticalOptions = LayoutOptions.Center,
                                    FontFamily = Device.OnPlatform("OpenSans-ExtraBold", "OpenSans-ExtraBold", null),
                                    FontSize = 18
                                }
                            }
                        },
                    new StackLayout
                        {
                            Spacing = 0,
                            Children =
                            {
                                new Label
                                {
                                    Text ="NOMBRES:*",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("373152"),
                                    FontAttributes = FontAttributes.Bold,
                                       FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                                },
                                new StackLayout
                                {
                                    Spacing=1,
                                    Children=
                                    {
                                        new Grid
                                        {
                                            Children=
                                            {
                                                nombres,
                                            }
                                        },
                                        new BoxView {BackgroundColor= Color.FromHex("373152"), HeightRequest=2 },
                                        new BoxView {HeightRequest=0 }
                                    }
                                }
                            }
                        },
                        new StackLayout
                        {
                            Spacing = 0,
                            Children =
                            {
                                new Label
                                {
                                    Text ="APELLIDOS:*",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("373152"),
                                    FontAttributes = FontAttributes.Bold,
                                       FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                                },
                                new StackLayout
                                {
                                    Spacing=1,
                                    Children=
                                    {
                                        new Grid
                                        {
                                            Children=
                                            {
                                                apellidos,
                                            }
                                        },
                                        new BoxView {BackgroundColor= Color.FromHex("373152"), HeightRequest=2 },
                                        new BoxView {HeightRequest=0 }
                                    }
                                }
                            }
                        },
                        new StackLayout
                        {
                            Spacing = 0,
                            Children =
                            {
                            new StackLayout
                                {
                                    Spacing=1,
                                    Children=
                                    {
                                        generoPuesto,
                                    }
                                }
                            }
                        },
                    new StackLayout
                        {
                            Spacing = 0,
                            Children =
                            {
                                new Label
                                {
                                    Text ="CORREO ELECTRÓNICO:*",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("373152"),
                                    FontAttributes = FontAttributes.Bold,
                                    FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                                },
                                new StackLayout
                                {
                                    Spacing=1,
                                    Children=
                                    {
                                        new Grid
                                        {
                                            Children=
                                            {
                                                correo
                                            }
                                        },
                                        new BoxView {BackgroundColor= Color.FromHex("373152"), HeightRequest=2 },
                                        new BoxView {HeightRequest=0 }
                                    }
                                }
                            }
                        }
                    }
            };



            ContenidoVista = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 0,
                Content = new StackLayout
                {
                    Spacing = 10,
                    Children =
                            {
                                new StackLayout
                                {
                                    Spacing = 0,
                                    Children =
                                    {
                                        datosGenerales,
                                        new BoxView { VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.FromHex("B3B3B3"), HeightRequest=4},
                                    }
                                }
                            }
                }
            };




            Contenido = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 15),
                Children = { ContenidoVista, gridBoton }
            };

            Content = Contenido;
        }
        private async void ShowToast(ToastNotificationType type, string titulo, string descripcion, int tiempo)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            bool tapped = await notificator.Notify(type, titulo, descripcion, TimeSpan.FromSeconds(tiempo));
        }
        protected async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nombres.Text))
            {
                DisplayAlert("", "Por favor, indique un nombre");
                control = 0;
                return;
            }
            if (String.IsNullOrEmpty(apellidos.Text))
            {
                DisplayAlert("", "Por favor, indique un apellido");
                control = 1;
                return;
            }

            if (genero.SelectedIndex == -1)
            {
                DisplayAlert("", "Por favor, seleccione el género");
                control = 3;
                return;
            }
            if (String.IsNullOrEmpty(correo.Text))
            {
                DisplayAlert("", "Por favor, indique su correo electrónico");
                control = 4;
                return;
            }
            else
            {
                if (!Regex.Match(correo.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    DisplayAlert("", "Por favor, indique una dirección de correo electrónico válida");
                    control = 4;
                    return;
                }
            }

            /*await Navigation.PushPopupAsync(new Indicador("Actualizando usuario", Color.White));
            try
            {
                var deviceLatLang = await App.obtenerUbicacion();
                ProfileSave peticion = new ProfileSave
                {
                    Phone_1 = telefono1.Text,
                    First_Nm = nombres.Text,
                    Last_Nm = apellidos.Text,
                    Gender = Constantes.genero[genero.Items[genero.SelectedIndex]],
                    DOB = fechaNacimiento.Date.ToString(@"yyyy-MM-dd"),
                    Short_Nm = perfil.Short_Nm
                };

                if (prefijo.SelectedIndex == -1)
                    peticion.Prefix_Nm = ".";
                else
                    peticion.Prefix_Nm = prefijo.Items[prefijo.SelectedIndex];

                var Usuario = await App.ManejadorDatos.SaveUserProfileAsync(peticion);
                await Navigation.PopAllPopupAsync();
                foreach (var user in Usuario)
                {
                    if (user.Result_Cd.Equals("0") || user.Result_Cd.Equals("OK"))
                    {
                        ShowToast(ToastNotificationType.Success, "Usuario", "Datos de usuario actualizados.", 7);
                        return;
                    }
                    else if (user.Result_Cd.Equals("547"))
                    {
                        DisplayAlert("¡Verifique!", "Ha ocurrido algo inesperado en la actualización de datos, inténtalo de nuevo.");
                        return;
                    }
                    else
                    {
                        DisplayAlert("", user.Result_Msg);
                    }
                }
                if (Usuario.Count == 0)
                {
                    ShowToast(ToastNotificationType.Error, "Usuario", "Ha ocurrido algo inesperado en la actualización de datos, inténtalo de nuevo.", 5);
                    return;
                }
            }
            catch
            {
                await Navigation.PopAllPopupAsync();
                DisplayAlert("¡Ha ocurrido algo inesperado!", "Inténtalo de nuevo");
            }*/

        }
        public void DisplayAlert(string title, string message)
        {
            string[] values = { title, message };
            MessagingCenter.Send<UsuarioDTViewModel, string[]>(this, "DisplayAlert", values);
        }
        public void Focus()
        {
            switch (control)
            {
                case 0:
                    nombres.Focus();
                    break;
                case 1:
                    apellidos.Focus();
                    break;
                case 2:
                    genero.Focus();
                    break;
                case 3:
                    correo.Focus();
                    break;
            }
        }
    }
}