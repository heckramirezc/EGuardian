using EGuardian.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EGuardian.ViewModels.Menu
{
    public class MenuDTViewModel : ExtendedViewCell
    {
        public MenuDTViewModel()
        {

            Label tituloMenu = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = 0,
                FontSize = (App.DisplayScreenWidth / 25.066666666666667),
                VerticalTextAlignment = TextAlignment.Center,
            };
            tituloMenu.SetBinding(Label.TextProperty, "Title");
            tituloMenu.SetBinding(Label.TextColorProperty, "TextColor");
            tituloMenu.SetBinding(Label.FontFamilyProperty, "FontFamily");


            BoxView Separator = new BoxView { VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.FromHex("BFBFBF"), HeightRequest = (App.DisplayScreenWidth / 341.818181818181818), Opacity = 0.25 };
            Separator.SetBinding(VisualElement.IsVisibleProperty, "SeparatorVisibility");

            Grid Menu = new Grid
            {
                Padding = new Thickness((App.DisplayScreenWidth / 9.4), 0),
                RowSpacing = 0,
                HeightRequest = Convert.ToInt32((App.DisplayScreenHeight / 13.533333333333333)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength ((App.DisplayScreenHeight / 341.818181818181818), GridUnitType.Absolute) }
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) }
                }
            };
            Menu.Children.Add(tituloMenu, 0, 0);
            Menu.Children.Add(Separator, 0, 1);
            View = Menu;
            SelectedBackgroundColor = Color.Transparent;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }
}