using System;
using EGuardian.Common.Resources;
using EGuardian.Controls;
using Xamarin.Forms;

namespace EGuardian.ViewModels.Eventos.Evento
{
    public class AsistenteDetalleDTViewModel : ExtendedViewCell
    {
        public AsistenteDetalleDTViewModel()
        {
            Label Nombre = new Label
            {
                TextColor = Color.FromHex("2C2895"),
                FontSize = 12,
                FontFamily = Device.OnPlatform("OpenSans-Bold", "OpenSans-Bold", null)
            };
            Nombre.SetBinding(Label.TextProperty, "nombre");

            Label Puesto = new Label
            {
                TextColor = Color.FromHex("828282"),
                FontSize = 10,
                FontFamily = Device.OnPlatform("OpenSans", "OpenSans-Regular", null)
            };
            Puesto.SetBinding(Label.TextProperty, "puesto");

            Label Rol = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.FromHex("828282"),
                FontSize = 12,
                FontFamily = Device.OnPlatform("OpenSans", "OpenSans-Regular", null)
            };
            Rol.SetBinding(Label.TextProperty, "rol");

            Grid Item = new Grid
            {
                Padding = new Thickness(5, 10),
                ColumnSpacing = 0,
                RowSpacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (0, GridUnitType.Auto) }
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength (90, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength (60, GridUnitType.Auto) }
                }
            };

            Item.Children.Add(new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 0,
                Children = 
                {
                    Nombre,
                    Puesto
                }
            }, 0, 0);
            Item.Children.Add(new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    Rol
                }
            }, 1, 0);
            Item.Children.Add(new IconView
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Source=Images.Alerta,
                Foreground = Color.FromHex("19164B"),
                WidthRequest = 20,
                HeightRequest = 20
            }, 2, 0);
            View = Item;
            SelectedBackgroundColor = Color.Transparent;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }
}