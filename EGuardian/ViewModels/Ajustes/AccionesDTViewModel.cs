using System;
using System.Collections.Generic;
using EGuardian.Controls;
using Plugin.Toasts;
using Xamarin.Forms;

namespace EGuardian.ViewModels.Ajustes
{
    public class AccionesDTViewModel : ContentView
    {

        ExtendedEntry primerNombre, segundoNombre, primerApellido, segundoApellido, nombreClinica, correo;
        ExtendedEntry telefono1, telefono2, direccion1, direccion2, colegiado;
        ExtendedPicker especialidad1, especialidad2, prefijo, lugar, pais, notificacionesCorreo;
        public bool Logeado;
        Dictionary<string, int> lugarSeleccionado = new Dictionary<string, int>();
        Dictionary<string, int> paisSeleccionado = new Dictionary<string, int>();
        Dictionary<string, int> especialidad1Seleccionado = new Dictionary<string, int>();
        Dictionary<string, int> especialidad2Seleccionado = new Dictionary<string, int>();
        Dictionary<string, string> paises = new Dictionary<string, string>();
        Dictionary<string, string> lugares = new Dictionary<string, string>();
        Dictionary<string, string> especialidades = new Dictionary<string, string>();
        int control;
        Button guardar;
        int anios, meses = 0;
        ExtendedEditor notasObservaciones;
        System.Globalization.CultureInfo globalizacion;
        StackLayout EdicionCreacion;
        ScrollView contenidoCreacionEdicion;
        //cuentas cuenta = App.Database.GetCuenta(Convert.ToInt32(Settings.session_idUsuario));

        public AccionesDTViewModel()
        {
            globalizacion = new System.Globalization.CultureInfo("es-GT");

            /*MessagingCenter.Subscribe<CuentaAjustesView>(this, "DisplayAlert", (sender) =>
            {
                Focus();
                control = -1;
            });

            MessagingCenter.Subscribe<App>(this, "CargaInicial", (sender) =>
            {
                if (Constantes.CargaInicial)
                {
                    try
                    {
                        int index = 0;
                        foreach (var country in App.Database.GetPaises().ToList())
                        {
                            paises.Add(country.nombre, country.codigo);
                            pais.Items.Add(country.nombre);
                            paisSeleccionado.Add(country.codigo, index);
                            index++;
                        }
                        index = 0;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }

                    try
                    {
                        int index = 0;
                        foreach (var speciality in App.Database.GetEspecialidades().ToList())
                        {
                            especialidades.Add(speciality.nombre.ToUpper(), speciality.idEspecialidad);
                            especialidad1.Items.Add(speciality.nombre.ToUpper());
                            especialidad2.Items.Add(speciality.nombre.ToUpper());
                            especialidad1Seleccionado.Add(speciality.idEspecialidad, index);
                            especialidad2Seleccionado.Add(speciality.idEspecialidad, index);
                            index++;
                        }
                        index = 0;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                    Navigation.PopAllPopupAsync();
                }
                CargarSeleccionables();
            });*/




            primerNombre = new ExtendedEntry
            {
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                Placeholder = "Primer nombre",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = cuenta.First_Nm1
            };





            segundoNombre = new ExtendedEntry
            {
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                Placeholder = "Segundo nombre",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = cuenta.First_Nm2
            };


            Grid nombres = new Grid
            {
                RowSpacing = 0,
                ColumnSpacing = 15,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                }
            };
            nombres.Children.Add(primerNombre, 0, 0);
            nombres.Children.Add(segundoNombre, 1, 0);
            nombres.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("0076A3"), HeightRequest = 2 }
                , 0, 1);
            nombres.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("0076A3"), HeightRequest = 2 }
                , 1, 1);



            primerApellido = new ExtendedEntry
            {
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                Placeholder = "Primer apellido",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = cuenta.Last_Nm1
            };
            primerApellido.TextChanged += (sender, e) =>
            {
                //  primerApellido.Text = primerApellido.Text.ToUpper();
            };




            segundoApellido = new ExtendedEntry
            {
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                Placeholder = "Segundo apellido",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = cuenta.Last_Nm2
            };
            segundoApellido.TextChanged += (sender, e) =>
            {
                //segundoApellido.Text = segundoApellido.Text.ToUpper();
            };

            Grid apellidos = new Grid
            {
                RowSpacing = 0,
                ColumnSpacing = 15,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                }
            };
            apellidos.Children.Add(primerApellido, 0, 0);
            apellidos.Children.Add(segundoApellido, 1, 0);
            apellidos.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("0076A3"), HeightRequest = 2 }
                , 0, 1);
            apellidos.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("0076A3"), HeightRequest = 2 }
                , 1, 1);

            nombreClinica = new ExtendedEntry
            {
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.End,
                FontSize = 14,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                //Text = cuenta.Account_Nm
            };


            lugar = new ExtendedPicker
            {
                Title = "Toca para seleccionar",
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.Center,
                Font = Device.OnPlatform<Font>(Font.OfSize("OpenSans-Bold", 12), Font.OfSize("OpenSans-Bold", 12), Font.Default)
                //HeightRequest = 60,
                //MinimumHeightRequest = 20,
                //VerticalOptions = LayoutOptions.CenterAndExpand,
                //HorizontalOptions = LayoutOptions.CenterAndExpand
            };



            pais = new ExtendedPicker
            {
                Title = "Toca para seleccionar",
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.Center,
                Font = Device.OnPlatform<Font>(Font.OfSize("OpenSans-Bold", 12), Font.OfSize("OpenSans-Bold", 12), Font.Default)
                //HeightRequest = 60,
                //MinimumHeightRequest = 20,
                //VerticalOptions = LayoutOptions.CenterAndExpand,
                //HorizontalOptions = LayoutOptions.CenterAndExpand
            };




            pais.SelectedIndexChanged += Pais_SelectedIndexChanged;
            direccion1 = new ExtendedEntry
            {
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = cuenta.Adr1_Txt
            };

            direccion2 = new ExtendedEntry
            {
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = cuenta.Adr2_Txt
            };

            telefono1 = new ExtendedEntry
            {
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                Keyboard = Keyboard.Telephone,
                XAlign = TextAlignment.Center,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = cuenta.Phone_1
            };




            telefono2 = new ExtendedEntry
            {
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                Keyboard = Keyboard.Telephone,
                XAlign = TextAlignment.Center,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = cuenta.Phone_2
            };



            Grid grid2 = new Grid
            {
                RowSpacing = 0,
                ColumnSpacing = 15,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                }
            };

            Grid grid3 = new Grid
            {
                RowSpacing = 10,
                ColumnSpacing = 15,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) }
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                }
            };

            grid3.Children.Add(
                new Label
                {
                    Text = "PAÍS:*",
                    FontSize = 13,
                    TextColor = Color.FromHex("187041"),
                    FontAttributes = FontAttributes.Bold,
                    FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                }, 0, 0);
            grid3.Children.Add(
                new Label
                {
                    Text = "LUGAR:",
                    FontSize = 13,
                    TextColor = Color.FromHex("187041"),
                    FontAttributes = FontAttributes.Bold,
                    FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                }, 1, 0);
            grid3.Children.Add(
                new Grid
                {
                    Children =
                    {
                        pais,
                        new Image
                        {
                            HorizontalOptions = LayoutOptions.End,
                            VerticalOptions = LayoutOptions.Center,
                            Source="idropdown.png",
                            WidthRequest=10
                        }
                    }
                }, 0, 1);
            grid3.Children.Add(
                new Grid
                {
                    Children =
                    {
                        lugar,
                        new Image
                        {
                            HorizontalOptions = LayoutOptions.End,
                            VerticalOptions = LayoutOptions.Center,
                            Source="idropdown.png",
                            WidthRequest=10
                        }
                    }
                }, 1, 1);
            grid3.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("187041"), HeightRequest = 2 }
                , 0, 2);
            grid3.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("187041"), HeightRequest = 2 }
                , 1, 2);

            grid2.Children.Add(
                new Label
                {
                    Text = "TELÉFONO 1:*",
                    FontSize = 13,
                    TextColor = Color.FromHex("187041"),
                    FontAttributes = FontAttributes.Bold,
                    FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                }, 0, 0);
            grid2.Children.Add(
                new Label
                {
                    Text = "TELÉFONO 2:",
                    FontSize = 13,
                    TextColor = Color.FromHex("187041"),
                    FontAttributes = FontAttributes.Bold,
                    FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                }, 1, 0);
            grid2.Children.Add(telefono1, 0, 1);
            grid2.Children.Add(telefono2, 1, 1);
            grid2.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("187041"), HeightRequest = 2 }
                , 0, 2);
            grid2.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("187041"), HeightRequest = 2 }
                , 1, 2);





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
                //Text = cuenta.EMail_1
            };

            notificacionesCorreo = new ExtendedPicker
            {
                Title = "Toca para agregar un recordatorio",
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.End,
                Margin = new Thickness(0, 0, 15, 0),
                Font = Device.OnPlatform<Font>(Font.OfSize("OpenSans-Bold", 14), Font.OfSize("OpenSans-Bold", 14), Font.Default)
            };

            /*foreach (string notificaciones in Constants.notificacionesCorreoCuenta.Keys)
            {
                notificacionesCorreo.Items.Add(notificaciones);
            }

            try
            {
                if (!string.IsNullOrEmpty(cuenta.Calendar_Send_EMail_YN) && !cuenta.Calendar_Send_EMail_YN.Equals(".") && !cuenta.Calendar_Send_EMail_YN.Equals("NULL") && !cuenta.Calendar_Send_EMail_YN.Equals("nulll") && !cuenta.Calendar_Send_EMail_YN.Equals("Null"))
                    notificacionesCorreo.SelectedIndex = Constantes.notificacionSeleccionadaCuenta[cuenta.Calendar_Send_EMail_YN];
                else
                    notificacionesCorreo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                notificacionesCorreo.SelectedIndex = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }*/
            StackLayout Notificacion = new StackLayout
            {
                Spacing = 0,
                IsVisible = string.IsNullOrEmpty(correo.Text) ? false : true,
                Children =
                            {
                                new StackLayout
                                {
                                    Spacing=1,
                                    Children=
                                    {
                                        new Grid
                                        {
                                            Children=
                                            {
                                                notificacionesCorreo,
                                                new Image
                                                {
                                                    HorizontalOptions = LayoutOptions.End,
                                                    VerticalOptions = LayoutOptions.Center,
                                                    Source="idropdown.png",
                                                    WidthRequest=10
                                                }
                                            }
                                        },
                                        new BoxView {BackgroundColor= Color.FromHex("187041"), HeightRequest=2 },
                                        new BoxView {HeightRequest=0 }
                                    }
                                }
                            }
            };

            correo.TextChanged += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(correo.Text)) Notificacion.IsVisible = true;
                else Notificacion.IsVisible = false;
            };





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
                                    Source = "iClinica.png",
                                    WidthRequest = 20,
                                    Foreground = Color.FromHex("187041"),
                                    VerticalOptions = LayoutOptions.Center
                                },
                                new Label
                                {
                                    Text = "Datos de clínica",
                                    TextColor = Color.FromHex("187041"),
                                    FontSize = 18,
                                    FontFamily = Device.OnPlatform("OpenSans-ExtraBold", "OpenSans-ExtraBold", null),
                                    VerticalOptions = LayoutOptions.Center
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
                                    Text ="NOMBRE CLÍNICA:*",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("187041"),
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
                                                nombreClinica,
                                            }
                                        },
                                        new BoxView {BackgroundColor= Color.FromHex("187041"), HeightRequest=2 },
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
                                        new Grid
                                        {
                                            Children=
                                            {
                                                grid3,
                                            }
                                        }
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
                                        Text ="DIRECCIÓN 1:*",
                                        FontSize = 13,
                                        TextColor = Color.FromHex("187041"),
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
                                                    direccion1,
                                                }
                                            },
                                            new BoxView {BackgroundColor= Color.FromHex("187041"), HeightRequest=2 },
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
                                    Text ="DIRECCIÓN 2:",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("187041"),
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
                                                direccion2,
                                            }
                                        },
                                        new BoxView {BackgroundColor= Color.FromHex("187041"), HeightRequest=2 },
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
                                        new Grid
                                        {
                                            Children=
                                            {
                                                grid2,
                                            }
                                        }
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
                                    Text ="CORREO ELECTRÓNICO:",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("187041"),
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
                                        new BoxView {BackgroundColor= Color.FromHex("187041"), HeightRequest=2 },
                                        new BoxView {HeightRequest=0 }
                                    }
                                }
                            }
                        },
                    Notificacion
                                    }
            };






















            especialidad1 = new ExtendedPicker
            {
                Title = "Toca para seleccionar especialidad",
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.End,
                Margin = new Thickness(0, 0, 15, 0),
                Font = Device.OnPlatform<Font>(Font.OfSize("OpenSans-Bold", 14), Font.OfSize("OpenSans-Bold", 14), Font.Default)
            };


            especialidad2 = new ExtendedPicker
            {
                Title = "Toca para seleccionar especialidad",
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.End,
                Margin = new Thickness(0, 0, 15, 0),
                Font = Device.OnPlatform<Font>(Font.OfSize("OpenSans-Bold", 14), Font.OfSize("OpenSans-Bold", 14), Font.Default)
            };

            colegiado = new ExtendedEntry
            {
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                Keyboard = Keyboard.Numeric,
                XAlign = TextAlignment.Center,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                //Text = cuenta.Legal_Cd
            };


            prefijo = new ExtendedPicker
            {
                Title = "Toca para seleccionar prefijo",
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                XAlign = TextAlignment.Center,
                Margin = new Thickness(0, 0, 15, 0),
                Font = Device.OnPlatform<Font>(Font.OfSize("OpenSans-Bold", 14), Font.OfSize("OpenSans-Bold", 14), Font.Default)
            };

            /*
            foreach (string pref in Constants.prefijos.Keys)
            {
                prefijo.Items.Add(pref);
            }

            try
            {
                if (!string.IsNullOrEmpty(cuenta.Prefix_Nm))
                    prefijo.SelectedIndex = Constantes.prefijos[cuenta.Prefix_Nm];
                else
                    prefijo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                prefijo.SelectedIndex = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            foreach (string notificaciones in Constantes.notificacionesCorreo.Keys)
            {
                //notificacionesCorreo.Items.Add(notificaciones);
            }*/
            //notificacionesCorreo.SelectedIndex = 2;


            Grid grid5 = new Grid
            {
                RowSpacing = 0,
                ColumnSpacing = 15,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength (2, GridUnitType.Absolute) },
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                }
            };



            grid5.Children.Add(
                new Label
                {
                    Text = "PREFIJO:",
                    FontSize = 13,
                    TextColor = Color.FromHex("0076A3"),
                    FontAttributes = FontAttributes.Bold,
                    FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                }, 0, 0);
            grid5.Children.Add(
                new Label
                {
                    Text = "NO. DE COLEGIADO:*",
                    FontSize = 13,
                    TextColor = Color.FromHex("0076A3"),
                    FontAttributes = FontAttributes.Bold,
                    FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                }, 1, 0);
            grid5.Children.Add(prefijo, 0, 1);
            grid5.Children.Add(colegiado, 1, 1);
            grid5.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("0076A3"), HeightRequest = 2 }
                , 0, 2);
            grid5.Children.Add(
                new BoxView { BackgroundColor = Color.FromHex("0076A3"), HeightRequest = 2 }
                , 1, 2);








            StackLayout localizacion = new StackLayout
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
                                    Foreground = Color.FromHex("0076A3"),
                                    VerticalOptions = LayoutOptions.Center
                                },
                                new Label
                                {
                                    Text = "Datos de Propietario",
                                    TextColor = Color.FromHex("0076A3"),
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
                                new StackLayout
                                {
                                    Spacing=1,
                                    Children=
                                    {
                                        new Grid
                                        {
                                            Children=
                                            {
                                                grid5,
                                            }
                                        }
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
                                    Text ="NOMBRE(S):*",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("0076A3"),
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
                                        }
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
                                    Text ="APELLIDO(S):*",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("0076A3"),
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
                                        }
                                    }
                                }
                            }
                        },
                    new StackLayout
                        {
                            Spacing = 10,
                            Children =
                            {
                                new Label
                                {
                                    Text ="ESPECIALIDAD 1:",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("0076A3"),
                                    FontAttributes = FontAttributes.Bold,
                                    FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                                },
                                new StackLayout
                                {
                                    Spacing=10,
                                    Children=
                                    {
                                        new Grid
                                        {
                                            Children=
                                            {
                                                especialidad1,
                                                new Image
                                                {
                                                    HorizontalOptions = LayoutOptions.End,
                                                    VerticalOptions = LayoutOptions.Center,
                                                    Source="idropdown.png",
                                                    WidthRequest=10
                                                }
                                            }
                                        },
                                        new BoxView {BackgroundColor= Color.FromHex("0076A3"), HeightRequest=2 },
                                        new BoxView {HeightRequest=0 }
                                    }
                                }
                            }
                        },
                    new StackLayout
                        {
                            Spacing = 10,
                            Children =
                            {
                                new Label
                                {
                                    Text ="ESPECIALIDAD 2:",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("0076A3"),
                                    FontAttributes = FontAttributes.Bold,
                                    FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
                                },
                                new StackLayout
                                {
                                    Spacing=10,
                                    Children=
                                    {
                                        new Grid
                                        {
                                            Children=
                                            {
                                                especialidad2,
                                                new Image
                                                {
                                                    HorizontalOptions = LayoutOptions.End,
                                                    VerticalOptions = LayoutOptions.Center,
                                                    Source="idropdown.png",
                                                    WidthRequest=10
                                                }
                                            }
                                        },
                                        new BoxView {BackgroundColor= Color.FromHex("0076A3"), HeightRequest=2 },
                                        new BoxView {HeightRequest=0 }
                                    }
                                }
                            }
                        }
                    }
            };




            guardar = new Button
            {
                Text = "GUARDAR",
                FontSize = 18,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("53A946"),
                WidthRequest = 128,
                HeightRequest = 38,
            };
            guardar.Clicked += Guardar_Clicked;








            notasObservaciones = new ExtendedEditor
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.FromHex("3F3F3F")
            };
            //notasObservaciones.TextChanged += NotasObservaciones_TextChanged;
            //notasObservaciones.SetBinding(EditorControl.TextProperty, "notasObservaciones");
            //notasObservaciones.Text = "Toca para agregar una nota";

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




            this.BackgroundColor = Color.White;

            contenidoCreacionEdicion = new ScrollView
            {
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
                                },
                                new StackLayout
                                {
                                    Spacing = 0,
                                    Children =
                                    {
                                        localizacion,
                                        new BoxView { VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.FromHex("B3B3B3"), HeightRequest=4},
                                    }
                                }
                            }
                }
            };


            EdicionCreacion = new StackLayout
            {
                Padding = new Thickness(0, 15),
                Children = { contenidoCreacionEdicion, gridBoton }
            };
            Content = EdicionCreacion;



            /*if (!Constants.CargaInicial)
                Navigation.PushPopupAsync(new Indicador("Descargando datos de sistema, por favor espere.", Color.White));
            else
            {

                try
                {
                    int index = 0;
                    foreach (var country in App.Database.GetPaises().ToList())
                    {
                        paises.Add(country.nombre, country.codigo);
                        pais.Items.Add(country.nombre);
                        paisSeleccionado.Add(country.codigo, index);
                        index++;
                    }
                    index = 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }

                try
                {
                    int index = 0;
                    foreach (var speciality in App.Database.GetEspecialidades().ToList())
                    {
                        especialidades.Add(speciality.nombre.ToUpper(), speciality.idEspecialidad);
                        especialidad1.Items.Add(speciality.nombre.ToUpper());
                        especialidad2.Items.Add(speciality.nombre.ToUpper());
                        especialidad1Seleccionado.Add(speciality.idEspecialidad, index);
                        especialidad2Seleccionado.Add(speciality.idEspecialidad, index);
                        index++;
                    }
                    index = 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                CargarSeleccionables();
            }*/
        }

        void Pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (pais.SelectedIndex > -1)
            {
                lugar.Items.Clear();
                lugarSeleccionado.Clear();
                lugares.Clear();
                try
                {
                    int index = 0;
                    foreach (var place in App.Database.GetLugares(paises[pais.Items[pais.SelectedIndex]]).ToList())
                    {
                        lugares.Add(place.nombre, place.idLugar);
                        lugar.Items.Add(place.nombre);
                        lugarSeleccionado.Add(place.idLugar, index);
                        index++;
                    }
                    index = 0;

                    if (lugar.Items.Count == 0)
                    {
                        lugar.Items.Clear();
                        lugar.Items.Add("Información no disponible");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }*/
        }
        private async void ShowToast(ToastNotificationType type, string titulo, string descripcion, int tiempo)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            bool tapped = await notificator.Notify(type, titulo, descripcion, TimeSpan.FromSeconds(tiempo));
        }

        async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nombreClinica.Text))
            {
                DisplayAlert("", "Por favor, indique nombre de clínica");
                control = 0;
                return;
            }
            if (pais.SelectedIndex == -1)
            {
                DisplayAlert("", "Por favor, seleccione el país");
                control = 2;
                return;
            }
            if (String.IsNullOrEmpty(direccion1.Text))
            {
                DisplayAlert("", "Por favor, indique una dirección");
                control = 1;
                return;
            }


            if (String.IsNullOrEmpty(telefono1.Text))
            {
                DisplayAlert("", "Por favor, indique un número de teléfono");
                control = 3;
                return;
            }


            if (String.IsNullOrEmpty(primerNombre.Text))
            {
                DisplayAlert("", "Por favor, indique un nombre");
                control = 4;
                return;
            }
            if (String.IsNullOrEmpty(primerApellido.Text))
            {
                DisplayAlert("", "Por favor, indique un apellido");
                control = 5;
                return;
            }



            /*await Navigation.PushPopupAsync(new Indicador("Actualizando cuenta", Color.White));
            try
            {
                AccountSave peticion = new AccountSave
                {
                    Account_Nm = nombreClinica.Text,
                    Adr1_Txt = direccion1.Text,
                    Adr2_Txt = direccion2.Text,
                    //Adr_Place_ID = lugares[lugar.Items[lugar.SelectedIndex]],
                    Ctry_Cd = paises[pais.Items[pais.SelectedIndex]],
                    Phone_1 = telefono1.Text,
                    Phone_2 = telefono2.Text,
                    //Prefix_Nm = prefijo.Items[prefijo.SelectedIndex],
                    First_Nm1 = primerNombre.Text,
                    First_Nm2 = segundoNombre.Text,
                    Last_Nm1 = primerApellido.Text,
                    Last_Nm2 = segundoApellido.Text,
                    Legal_Cd = colegiado.Text,

                    //Specialty_1 = especialidades[especialidad.Items[especialidad.SelectedIndex]],

                };

                if (lugar.Equals("Información no disponible") || lugar.SelectedIndex == -1)
                    peticion.Adr_Place_ID = ".";
                else
                    peticion.Adr_Place_ID = lugares[lugar.Items[lugar.SelectedIndex]];
                if (prefijo.SelectedIndex == -1)
                    peticion.Prefix_Nm = ".";
                else
                    peticion.Prefix_Nm = prefijo.Items[prefijo.SelectedIndex];
                if (String.IsNullOrEmpty(segundoNombre.Text))
                    peticion.First_Nm2 = ".";
                if (String.IsNullOrEmpty(segundoApellido.Text))
                    peticion.Last_Nm2 = ".";
                if (String.IsNullOrEmpty(telefono2.Text))
                    peticion.Phone_2 = ".";
                if (String.IsNullOrEmpty(colegiado.Text))
                    peticion.Legal_Cd = ".";
                if (especialidad1.SelectedIndex == -1)
                    peticion.Specialty_1 = ".";
                else
                    peticion.Specialty_1 = especialidades[especialidad1.Items[especialidad1.SelectedIndex]];
                if (especialidad2.SelectedIndex == -1)
                    peticion.Specialty_2 = ".";
                else
                    peticion.Specialty_2 = especialidades[especialidad2.Items[especialidad2.SelectedIndex]];
                if (notificacionesCorreo.SelectedIndex == -1 || string.IsNullOrEmpty(correo.Text))
                    peticion.Calendar_Send_EMai_YN = ".";
                else
                    peticion.Calendar_Send_EMai_YN = Constantes.notificacionesCorreoCuenta[notificacionesCorreo.Items[notificacionesCorreo.SelectedIndex]];

                var Usuario = await App.ManejadorDatos.AccountSaveAsync(peticion);
                await Navigation.PopAllPopupAsync();
                foreach (var user in Usuario)
                {
                    if (user.Result_Cd.Equals("0") || user.Result_Cd.Equals("OK"))
                    {
                        ShowToast(ToastNotificationType.Success, "Clínica", "Datos de clínica actualizados.", 7);
                        return;
                    }
                    else if (user.Result_Cd.Equals("547"))
                    {
                        DisplayAlert("¡Verifique!", "Ha ocurrido algo inesperado en la actualización de datos, intentalo de nuevo.");
                        return;
                    }
                    else
                    {
                        DisplayAlert("", user.Result_Msg);
                    }
                }
                if (Usuario.Count == 0)
                {
                    ShowToast(ToastNotificationType.Error, "Clínica", "Ha ocurrido algo inesperado en la actualización de datos, intentalo de nuevo.", 5);
                    return;
                }
            }
            catch
            {
                await Navigation.PopAllPopupAsync();
                DisplayAlert("¡Ha ocurrido algo inesperado!", "Intentalo de nuevo");
            }*/

        }
        public void DisplayAlert(string title, string message)
        {
            string[] values = { title, message };
            MessagingCenter.Send<AccionesDTViewModel, string[]>(this, "DisplayAlert", values);
        }

        public void CargarSeleccionables()
        {
            /*try
            {
                if (!string.IsNullOrEmpty(cuenta.Ctry_Cd))
                    pais.SelectedIndex = paisSeleccionado[cuenta.Ctry_Cd];
                else
                    pais.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                pais.SelectedIndex = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            try
            {
                if (!string.IsNullOrEmpty(cuenta.Adr_Place_ID))
                    lugar.SelectedIndex = lugarSeleccionado[cuenta.Adr_Place_ID];
                else
                    lugar.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                lugar.SelectedIndex = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            try
            {
                if (!string.IsNullOrEmpty(cuenta.Specialty_1))
                    especialidad1.SelectedIndex = especialidad1Seleccionado[cuenta.Specialty_1];
                else
                    especialidad1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                especialidad1.SelectedIndex = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            try
            {
                if (!string.IsNullOrEmpty(cuenta.Specialty_2))
                    especialidad2.SelectedIndex = especialidad2Seleccionado[cuenta.Specialty_2];
                else
                    especialidad2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                especialidad2.SelectedIndex = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }*/

        }

        public void Focus()
        {
            switch (control)
            {
                case 0:
                    nombreClinica.Focus();
                    break;
                case 1:
                    direccion1.Focus();
                    break;
                case 2:
                    pais.Focus();
                    break;
                case 3:
                    telefono1.Focus();
                    break;
                case 4:
                    primerNombre.Focus();
                    break;
                case 5:
                    primerApellido.Focus();
                    break;
            }
        }
    }
}