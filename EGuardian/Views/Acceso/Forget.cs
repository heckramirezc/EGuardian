using EGuardian.Common.Resources;
using EGuardian.Controls;
using Plugin.Toasts;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EGuardian.Views.Acceso
{
    public class Forget : PopupPage
    {
        String PwdReset_ID="1850";
        public ExtendedEntry Usuario, contrasenia;
        ExtendedEntry codigo, confirmacionContrasenia;
        Button recuperar, continuar, cambiar;
        StackLayout envioCodigo, confirmacionCodigo, cambioContrasenia;
        public bool Logeado;
        RelativeLayout gridBotonRecuperar;

        public Forget()
        {
            Usuario = new ExtendedEntry()
            {
                Keyboard = Keyboard.Email,
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

            codigo = new ExtendedEntry
            {
                Keyboard = Keyboard.Numeric,
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
            codigo.TextChanged += (sender, e) =>
            {
                if (!codigo.Text.Equals(PwdReset_ID))
                {
                    codigo.TextColor = Color.FromHex("E9242A");
                }
                else
                {
                    codigo.TextColor = Color.FromHex("53A946");
                }
            };

            IconView emailView = new IconView
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Source = "email.png",
                Foreground = Color.FromHex("B2B2B2"),
                WidthRequest = 20
            };
            IconView codigoView = new IconView
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Source = "iSeguridad.png",
                Foreground = Color.FromHex("B2B2B2"),
                WidthRequest = 15
            };
            IconView contraseniaView = new IconView
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Source = "iPassView.png",
                Foreground = Color.FromHex("B2B2B2"),
                WidthRequest = 25
            };
            IconView contraseniaConfirmacionView = new IconView
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Source = "iPassView.png",
                Foreground = Color.FromHex("B2B2B2"),
                WidthRequest = 25
            };


            TapGestureRecognizer contraseniaViewTAP = new TapGestureRecognizer();
            TapGestureRecognizer contraseniaConfirmacionViewTAP = new TapGestureRecognizer();
            contraseniaViewTAP.Tapped += (sender, e) =>
            {
                if (contrasenia.IsPassword)
                {
                    contrasenia.IsPassword = false;
                    contraseniaView.Foreground = Color.FromHex("312851");

                }
                else
                {
                    contrasenia.IsPassword = true;
                    contraseniaView.Foreground = Color.FromHex("B2B2B2");
                }
            };

            contraseniaConfirmacionViewTAP.Tapped += (sender, e) =>
            {
                if (confirmacionContrasenia.IsPassword)
                {
                    confirmacionContrasenia.IsPassword = false;
                    contraseniaConfirmacionView.Foreground = Color.FromHex("312851");
                }
                else
                {
                    confirmacionContrasenia.IsPassword = true;
                    contraseniaConfirmacionView.Foreground = Color.FromHex("B2B2B2");
                }
            };

            contraseniaView.GestureRecognizers.Add(contraseniaViewTAP);
            contraseniaConfirmacionView.GestureRecognizers.Add(contraseniaConfirmacionViewTAP);


            recuperar = new Button
            {
                Text = "RECUPERAR",
                FontSize = 18,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("F7B819"),
                WidthRequest = 128,
                HeightRequest = 38,
            };
            recuperar.Clicked += Recuperar_Clicked;



            continuar = new Button
            {
                Text = "VALIDAR",
                FontSize = 18,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("F7B819"),
                WidthRequest = 128,
                HeightRequest = 38,
            };
            continuar.Clicked += Continuar_Clicked;

            cambiar = new Button
            {
                Text = "CONFIRMAR",
                FontSize = 18,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("F7B819"),
                WidthRequest = 138,
                HeightRequest = 38,
            };
            cambiar.Clicked += Cambiar_Clicked;

            gridBotonRecuperar = new RelativeLayout
            {
                WidthRequest = 130,
                HeightRequest = 42,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
            };
            gridBotonRecuperar.Children.Add(
            new RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView
            {
                BackgroundColor = Color.FromHex("B2B2B2"),
                CornerRadius = 6,
                HeightRequest = 40,
                WidthRequest = 128,
            }, Constraint.Constant(2), Constraint.Constant(2));
            gridBotonRecuperar.Children.Add(recuperar, Constraint.Constant(0), Constraint.Constant(0));


            RelativeLayout gridBotonValidar = new RelativeLayout
            {
                WidthRequest = 130,
                HeightRequest = 42,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
            };
            gridBotonValidar.Children.Add(
            new RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView
            {
                BackgroundColor = Color.FromHex("B2B2B2"),
                CornerRadius = 6,
                HeightRequest = 40,
                WidthRequest = 128,
            }, Constraint.Constant(2), Constraint.Constant(2));
            gridBotonValidar.Children.Add(continuar, Constraint.Constant(0), Constraint.Constant(0));

            RelativeLayout gridBoton = new RelativeLayout
            {
                WidthRequest = 140,
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
                WidthRequest = 138,
            }, Constraint.Constant(2), Constraint.Constant(2));
            gridBoton.Children.Add(cambiar, Constraint.Constant(0), Constraint.Constant(0));


             IconView cerrar = new IconView
             {
                 //Margin = new Thickness(0, 0, 10, 0),
                 HorizontalOptions = LayoutOptions.End,
                 Source = Images.Cancelar,
                 Foreground = Color.FromHex("a2b3bb"),
                 WidthRequest = 20,
                 HeightRequest = 20
             };
             TapGestureRecognizer cerrarTAP = new TapGestureRecognizer();
             cerrarTAP.Tapped += async (sender, e) =>
             {
                 bool accion = await DisplayAlert("", "¿Desea cancelar la recuperación?", "Cancelar", "Regresar");
                 if (accion)
                     await Navigation.PopPopupAsync();
             };
             cerrar.GestureRecognizers.Add(cerrarTAP);


            var indicador = new ActivityIndicator
            {
                IsVisible = true,
                IsRunning = true,
                BindingContext = this,
                Color = Color.FromHex("2AB4EE"),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            indicador.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");


            envioCodigo = new StackLayout
            {
                Padding = new Thickness(20, 5),
                Spacing = 25,
                Children =
                {
                    new Label
                    {
                        Text = "Ingresa\r\ntu correo electrónico",
                        HorizontalTextAlignment = TextAlignment.Center,
						TextColor = Color.FromHex("373152"),
                        FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                        FontSize = 18,
                        VerticalOptions = LayoutOptions.Center
                    },
                    new StackLayout
                    {
                        Spacing = 0,
                        Children =
                        {
                            new Label
                            {
                                Text ="CORREO ELECTRÓNICO: *",
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
                                            Usuario,
                                            emailView
                                        }
                                    },
									new BoxView {BackgroundColor= Color.FromHex("373152"), HeightRequest=2 },
                                    new BoxView {HeightRequest=0 }
                                }
                            }
                        }
                    },
                    indicador,
                    gridBotonRecuperar
                }
            };

            confirmacionCodigo = new StackLayout
            {
                IsVisible = false,
                Padding = new Thickness(20, 5),
                Spacing = 25,
                Children =
                {
                    new Label
                    {
                        Text = "Ingresa el código \r\nque has recibido \r\nen tu badeja de entrada",
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = Color.FromHex("312851"),
                        FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                        FontSize = 18,
                        VerticalOptions = LayoutOptions.Center
                    },
                    new StackLayout
                    {
                        Spacing = 0,
                        Children =
                        {
                            new Label
                            {
                                Text ="CÓDIGO DE SEGURIDAD: *",
                                FontSize = 13,
                                TextColor = Color.FromHex("312851"),
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
                                            codigo,
                                            codigoView
                                        }
                                    },
                                    new BoxView {BackgroundColor= Color.FromHex("312851"), HeightRequest=2 },
                                    new BoxView {HeightRequest=0 }
                                }
                            }
                        }
                    },
                    gridBotonValidar
                }
            };


            contrasenia = new ExtendedEntry
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

            confirmacionContrasenia = new ExtendedEntry
            {
                TextColor = Color.FromHex("3F3F3F"),
                HasBorder = false,
                IsPassword = false,
                Placeholder = "Toca para confirmar contraseña",
                PlaceholderColor = Color.FromHex("B2B2B2"),
                XAlign = TextAlignment.End,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null),
                FontSize = 14,
                Margin = new Thickness(0, 0, 35, 0)
            };

            confirmacionContrasenia.TextChanged += (sender, e) =>
            {
                if (!confirmacionContrasenia.Text.Equals(contrasenia.Text))
                {
                    confirmacionContrasenia.TextColor = Color.FromHex("E9242A");
                    contrasenia.TextColor = Color.FromHex("3F3F3F");
                }
                else
                {
                    contrasenia.TextColor = Color.FromHex("53A946");
                    confirmacionContrasenia.TextColor = Color.FromHex("53A946");
                }
            };


            cambioContrasenia = new StackLayout
            {
                IsVisible = false,
                Padding = new Thickness(20, 5),
                Spacing = 25,
                Children =
                {
                    new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Children =
                        {
                            new IconView
                            {
                                Source = "iSeguridad.png",
                                WidthRequest = 15,
                                HeightRequest = 15,
                                Foreground = Color.FromHex("312851"),
                                VerticalOptions = LayoutOptions.Center
                            },
                            new Label
                            {
                                Text = "Ingresa y confirma\r\ntu nueva contraseña",
                                HorizontalTextAlignment = TextAlignment.Center,
                                TextColor = Color.FromHex("312851"),
                                FontFamily = Device.OnPlatform("OpenSans-ExtraBold", "OpenSans-ExtraBold", null),
                                FontSize = 18,
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
                                Text ="NUEVA CONTRASEÑA:*",
                                FontSize = 13,
                                TextColor = Color.FromHex("312851"),
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
                                            contrasenia,
                                            contraseniaView
                                        }
                                    },
                                    new BoxView {BackgroundColor= Color.FromHex("312851"), HeightRequest=2 },
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
                                Text ="CONFIRMAR CONTRASEÑA:*",
                                FontSize = 13,
                                TextColor = Color.FromHex("312851"),
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
                                            confirmacionContrasenia,
                                            contraseniaConfirmacionView
                                        }
                                    },
                                    new BoxView {BackgroundColor= Color.FromHex("312851"), HeightRequest=2 },
                                    new BoxView {HeightRequest=0 }
                                }
                            }
                        }
                    },
                    gridBoton
                }
            };

            Padding = new Thickness(15, 0); ;
            Content = new Frame
            {
                VerticalOptions = LayoutOptions.Center,
                Padding = 5,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                OutlineColor = Color.White,
                HasShadow = true,
                BackgroundColor = Color.White,
                Content = new StackLayout
                {
                    Padding = 5,
                    Spacing = 0,
                    Children = {
                        cerrar,
                        new ScrollView
                        {
                            Padding= 0,
                            HorizontalOptions= LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Content = new StackLayout
                            {
                                Children =
                                {
                                    envioCodigo,
                                    confirmacionCodigo,
                                    cambioContrasenia
                                }
                            }
                        }

                    }
                }
            };
            contrasenia.IsPassword = true;
            confirmacionContrasenia.IsPassword = true;
        }

        async void Continuar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(codigo.Text))
            {
                await DisplayAlert("", "Por favor, ingrese el código enviado.", "Aceptar");
                codigo.Focus();
                return;
            }
            else
            {
                if (!String.IsNullOrEmpty(PwdReset_ID))
                {
                    if (codigo.Text.Equals(PwdReset_ID))
                    {
                        confirmacionCodigo.IsVisible = false;
                        cambioContrasenia.IsVisible = true;
                    }
                    else
                    {
                        await DisplayAlert("", "El código ingresado no coincide con el enviado.", "Aceptar");
                        codigo.Focus();
                        return;
                    }
                }
                else
                {
                    ShowToast(ToastNotificationType.Error, "Recuperación de contraseña", "Servicio no disponible, intente más tarde.", 7);
                    await Navigation.PopPopupAsync();
                }
            }
        }

        string getContrasenia()
        {
            //System.Diagnostics.Debug.WriteLine("HASH(MD5) " + MD5.GetHashString(contrasenia.Text.Trim() + Constantes.Salt_Text.Trim()));
            //return MD5.GetHashString(contrasenia.Text.Trim() + Constantes.Salt_Text.Trim());
            return contrasenia.Text.Trim();
        }

        async void Cambiar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(contrasenia.Text))
            {
                await DisplayAlert("", "Por favor, indique su nueva contraseña", "Aceptar");
                contrasenia.Focus();
                return;
            }
            else
            {
                if (!Regex.Match(contrasenia.Text, @"^\S{6,15}$").Success)
                {
                    await DisplayAlert("", "La contraseña debe tener entre 6 y 15 caracteres.", "Aceptar");
                    contrasenia.Focus();
                    return;
                }
            }
            if (String.IsNullOrEmpty(confirmacionContrasenia.Text))
            {
                await DisplayAlert("", "Por favor, confirme su nueva contraseña.", "Aceptar");
                confirmacionContrasenia.Focus();
                return;
            }

            if ((!String.IsNullOrEmpty(contrasenia.Text) && !String.IsNullOrEmpty(confirmacionContrasenia.Text)) && !confirmacionContrasenia.Text.Equals(contrasenia.Text))
            {
                await DisplayAlert("", "Las contraseñas no coinciden", "Aceptar");
                confirmacionContrasenia.Focus();
                return;
            }
            /* await Navigation.PushPopupAsync(new Indicador("Actualizando contraseña", Color.White));
             try
             {
                 PwdReset peticion = new PwdReset
                 {
                     email = Usuario.Text,
                     PwdReset_ID = PwdReset_ID,
                     NewPwd = getContrasenia()
                 };

                 var Respuesta = await App.ManejadorDatos.PwdResetAsync(peticion);
                 await Navigation.PopPopupAsync();
                 foreach (var user in Respuesta)
                 {
                     if (user.Result_Cd.Equals("0") || user.Result_Cd.Equals("OK"))
                     {
                         Login(Usuario.Text, getContrasenia());
                         return;
                     }
                     else if (user.Result_Cd.Equals("547"))
                     {
                         await DisplayAlert("¡Verifique!", "Ha ocurrido algo inesperado en la actualización de contraseña, inténtalo de nuevo.", "Aceptar");
                         return;
                     }
                     else if (user.Result_Cd.Equals("111"))
                     {
                         await DisplayAlert("Cambio de contraseña", "Código de seguridad invalido, inténtalo de nuevo.", "Aceptar");
                         return;
                     }
                     else
                     {
                         await DisplayAlert("Cambio de contraseña", user.Result_Msg, "Aceptar");
                     }
                 }
                 if (Respuesta.Count == 0)
                 {
                     ShowToast(ToastNotificationType.Error, "Cambio de contraseña", "Ha ocurrido algo inesperado en la actualización de contraseña, inténtalo de nuevo.", 7);
                     return;
                 }
             }
             catch
             {
                 await DisplayAlert("Cambio de contraseña", "¡Ha ocurrido algo inesperado!", "Aceptar");
             }*/
            await Navigation.PopAllPopupAsync();
            ShowToast(ToastNotificationType.Success, "Cambio de contraseña", "Tu cambio de contraseña fue exitoso.", 7);
            MessagingCenter.Send<Forget>(this, "Forget");
        }

        async void Recuperar_Clicked(object sender, EventArgs e)
        {
            Usuario.IsEnabled = false;
            if (String.IsNullOrEmpty(Usuario.Text))
            {
                await DisplayAlert("", "Por favor, indique su correo electrónico ", "Aceptar");
                Usuario.IsEnabled = true;
                Usuario.Focus();
                return;
            }
            else
            {
                if (!Regex.Match(Usuario.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
                {
                    await DisplayAlert("", "Por favor, indique una dirección de correo electrónico válida", "Aceptar");
                    Usuario.IsEnabled = true;
                    Usuario.Focus();
                    return;
                }
            }
            /*this.IsBusy = true;
            recuperar.IsEnabled = false;
            recuperar.IsVisible = false;
            gridBotonRecuperar.IsVisible = false;
            

            PwdForget peticion = new PwdForget
            {
                email = Usuario.Text,
                deviceOS = Constantes.device_OS,
                deviceLatLang = deviceLatLang
            };
            List<ContraseniaRespuesta> Respuesta = new List<ContraseniaRespuesta>();
            Respuesta = await App.ManejadorDatos.PwdForgetAsync(peticion);
            bool isEmpty = !Respuesta.Any();
            if (isEmpty)
            {
                ShowToast(ToastNotificationType.Error, "Inconvenientes de conexión", "Lo lamentamos, existen inconvenientes en la conexión; intente más tarde.", 7);
                Usuario.IsEnabled = true;
                this.IsBusy = false;
            }
            else
            {
                foreach (var respuesta in Respuesta)
                {
                    if (!string.IsNullOrEmpty(respuesta.Result_Cd) && respuesta.Result_Cd.Equals("OK") || respuesta.Result_Cd.Equals("0"))
                    {
                        this.IsBusy = false;
                        PwdReset_ID = respuesta.PwdReset_ID;
                        if (!String.IsNullOrEmpty(PwdReset_ID))
                        {
                            envioCodigo.IsVisible = false;
                            confirmacionCodigo.IsVisible = true;
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
                        Usuario.IsEnabled = true;
                        this.IsBusy = false;
                    }
                }
            }
            recuperar.IsVisible = true;
            recuperar.IsEnabled = true;
            gridBotonRecuperar.IsVisible = true;*/

            envioCodigo.IsVisible = false;
            confirmacionCodigo.IsVisible = true;
        }

        private async void ShowToast(ToastNotificationType type, string titulo, string descripcion, int tiempo)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            bool tapped = await notificator.Notify(type, titulo, descripcion, TimeSpan.FromSeconds(tiempo));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        protected virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }

        protected virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1); ;
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("", "¿Desea cancelar la recuperación?", "Cancelar", "Regresar");
                if (result) await this.Navigation.PopPopupAsync();
            });
            return true;
        }

        protected override bool OnBackgroundClicked()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("", "¿Desea cancelar la recuperación?", "Cancelar", "Regresar");
                if (result) await this.Navigation.PopPopupAsync();
            });
            return false;
        }

        private async void Login(string email, string password)
        {
            /* await Navigation.PushPopupAsync(new Indicador("Iniciando sesión", Color.White));

             Login peticion = new Login
             {
                 email = email,
                 password = password,
                 deviceOS = Constantes.device_OS,
                 deviceLatLang = deviceLatLang
             };
             List<UsuarioRespuesta> Session = new List<UsuarioRespuesta>();
             Session = await App.ManejadorDatos.LoginAsync(peticion);
             bool isEmpty = !Session.Any();
             if (isEmpty)
             {
                 await Navigation.PopAllPopupAsync();
                 ShowToast(ToastNotificationType.Error, "Inconvenientes de conexión", "Tu cambio de contraseña fue exitoso, sin embargo existen inconvenientes en la conexión; intente iniciar sesión más tarde.", 7);
                 MessagingCenter.Send<Forget>(this, "Forget");
                 await Navigation.PopModalAsync();
             }
             else
             {
                 foreach (var session in Session)
                 {
                     if (string.IsNullOrEmpty(session.Result_Cd) || session.Result_Cd.Equals("ER"))
                     {
                         await Navigation.PopAllPopupAsync();
                         ShowToast(ToastNotificationType.Warning, "Verifique sus datos de inicio de sesión", session.Result_Msg, 5);
                         MessagingCenter.Send<Forget>(this, "Forget");
                         await Navigation.PopModalAsync();
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
                         ShowToast(ToastNotificationType.Success, "¡Genial!", "Tu cambio de contraseña fue exitoso, nos estamos preparando para tu uso.", 7);
                         MessagingCenter.Send<Forget>(this, "Autenticado");
                     }
                     else
                     {
                         await Navigation.PopAllPopupAsync();
                         ShowToast(ToastNotificationType.Error, "Inconvenientes de conexión", "Tu cambio de contraseña fue exitoso, sin embargo existen inconvenientes en la conexión; intente iniciar sesión más tarde.", 7);
                         MessagingCenter.Send<Forget>(this, "Forget");
                         await Navigation.PopModalAsync();
                     }
                 }
             }*/
        }
    }
}
