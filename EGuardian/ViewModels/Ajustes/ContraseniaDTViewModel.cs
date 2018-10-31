using System;
using EGuardian.Controls;
using Plugin.Toasts;
using Xamarin.Forms;

namespace EGuardian.ViewModels.Ajustes
{
    public class ContraseniaDTViewModel : ContentView
    {
        Button guardar;
        StackLayout EdicionCreacion;
        RelativeLayout gridBoton;
        ScrollView contenidoCreacionEdicion;
        int control;
        public ContraseniaDTViewModel()
        {

            /*MessagingCenter.Subscribe<CuentaAjustesView>(this, "DisplayAlert", (sender) =>
            {
                Focus();
                control = -1;
            });*/

            /*
            contraseniaAnterior = new ExtendedEntry
            {
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                IsPassword = false,
                Placeholder = "Toca para ingresar",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                Margin = new Thickness(0, 0, 35, 0)
            };
            */

            /*
            IconView contraseniaAnteriorView = new IconView
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Source = "iPassView.png",
                Foreground = Color.FromHex("B2B2B2"),
                WidthRequest = 25
            };
*/

            TapGestureRecognizer contraseniaAnteriorViewTAP = new TapGestureRecognizer();
            /*
            contraseniaAnteriorViewTAP.Tapped += (sender, e) =>
            {
                if (contraseniaAnterior.IsPassword)
                {
                    contraseniaAnterior.IsPassword = false;
                    contraseniaAnteriorView.Foreground = Color.FromHex("007D8C");
                }
                else
                {
                    contraseniaAnterior.IsPassword = true;
                    contraseniaAnteriorView.Foreground = Color.FromHex("B2B2B2");
                }
            };*/

            //contraseniaAnteriorView.GestureRecognizers.Add(contraseniaAnteriorViewTAP);











            guardar = new Button
            {
                Text = "CAMBIAR",
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







            gridBoton = new RelativeLayout
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


            StackLayout administrativo = new StackLayout
            {
                Padding = 15,
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
                                    Source = "iSeguridad.png",
                                    WidthRequest = 15,
                                    Foreground = Color.FromHex("007D8C"),
                                    VerticalOptions = LayoutOptions.Center
                                },
                                new Label
                                {
                                    Text = "¿Deseas cambiar tu contraseña actual?",
                                    TextColor = Color.FromHex("007D8C"),
                                    FontFamily = Device.OnPlatform("OpenSans-ExtraBold", "OpenSans-ExtraBold", null),
                                    FontSize = 18,
                                    VerticalOptions = LayoutOptions.Center
                                }
                            }
                        }/*,
                        new StackLayout
                        {
                            Spacing = 0,
                            Children =
                            {
                                new Label
                                {
                                    Text ="CONTRASEÑA ANTERIOR:*",
                                    FontSize = 13,
                                    TextColor = Color.FromHex("007D8C"),
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
                                                    contraseniaAnterior,
                                                    contraseniaAnteriorView
                                                }
                                            },
                                        new BoxView {BackgroundColor= Color.FromHex("007D8C"), HeightRequest=2 },
                                        new BoxView {HeightRequest=0 }
                                    }
                                }
                            }
                        },
                        */,

                    }
            };
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
                                        administrativo,
                                        new BoxView { VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.FromHex("B3B3B3"), HeightRequest=4},
                                    }
                                }
                            }
                }
            };


            EdicionCreacion = new StackLayout
            {
                Padding = new Thickness(0, 15),
                Spacing = 40,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Spacing = 10,
                        Children =
                        {
                            new IconView
                            {
                                Source = "iSeguridad.png",
                                WidthRequest = 20,
                                HeightRequest = 20,
                                Foreground = Color.FromHex("007D8C"),
                                VerticalOptions = LayoutOptions.Center
                            },
                            new Label
                            {
                                Text = "¿Deseas cambiar\r\ntu contraseña actual?",
                                HorizontalTextAlignment = TextAlignment.Center,
                                TextColor = Color.FromHex("007D8C"),
                                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                                FontSize = 22,
                                VerticalOptions = LayoutOptions.Center
                            }
                        }
                    },
                    gridBoton
                }
            };
            Content = EdicionCreacion;
        }

        private async void ShowToast(ToastNotificationType type, string titulo, string descripcion, int tiempo)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            bool tapped = await notificator.Notify(type, titulo, descripcion, TimeSpan.FromSeconds(tiempo));
        }
        async void Guardar_Clicked(object sender, EventArgs e)
        {
            /*var stack = Navigation.NavigationStack;
            if (guardar.IsEnabled && !Constants.ModalAbierto && (stack.Count == 0 || (stack[stack.Count - 1].GetType() != typeof(CambioContraseniaModeloVista))))
            {
                await Navigation.PushPopupAsync(new Indicador("Enviando código de seguridad.", Color.White));
                guardar.IsEnabled = false;
                guardar.IsVisible = false;
                gridBoton.IsVisible = false;
                string deviceLatLang = ",";
                Position posicion = null;
                await Task.Run(async () => { posicion = await App.obtenerUbicacion(); });
                if (posicion != null)
                {
                    deviceLatLang = posicion.Latitude + "," + posicion.Longitude;
                }
                PwdForget peticion = new PwdForget
                {
                    email = ((usuario)App.Database.GetEmailUser(Convert.ToInt32(Settings.session_idUsuario))).email,
                    deviceOS = Constantes.device_OS,
                    deviceLatLang = deviceLatLang
                };
                List<ContraseniaRespuesta> Respuesta = new List<ContraseniaRespuesta>();
                Respuesta = await App.ManejadorDatos.PwdForgetAsync(peticion);
                bool isEmpty = !Respuesta.Any();
                await Navigation.PopAllPopupAsync();
                if (isEmpty)
                {
                    ShowToast(ToastNotificationType.Error, "Inconvenientes de conexión", "Lo lamentamos, existen inconvenientes en la conexión; intente más tarde.", 7);
                }
                else
                {
                    foreach (var respuesta in Respuesta)
                    {
                        if (!string.IsNullOrEmpty(respuesta.Result_Cd) && respuesta.Result_Cd.Equals("OK") || respuesta.Result_Cd.Equals("0"))
                        {
                            if (!String.IsNullOrEmpty(respuesta.PwdReset_ID))
                            {
                                Constantes.ModalAbierto = true;
                                await Navigation.PushPopupAsync(new CambioContraseniaModeloVista(respuesta.PwdReset_ID));
                            }
                            else
                            {
                                ShowToast(ToastNotificationType.Error, "Recuperación de contraseña", "Servicio no disponible, intente más tarde.", 7);
                                await Navigation.PopPopupAsync();
                            }
                        }
                        else
                        {
                            ShowToast(ToastNotificationType.Error, "Recuperación de contraseña", respuesta.Result_Msg, 7);
                        }
                    }
                }
                guardar.IsEnabled = true;
                guardar.IsVisible = true;
                gridBoton.IsVisible = true;
            }
            else
                System.Diagnostics.Debug.WriteLine("Modal abierto actualmente");*/
            return;
        }
        public void DisplayAlert(string title, string message)
        {
            string[] values = { title, message };
            MessagingCenter.Send<ContraseniaDTViewModel, string[]>(this, "DisplayAlert", values);
        }
    }
}