using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EGuardian.ViewModels.Tutorial
{
    public class TutorialViewModel : ContentView
    {
        public TutorialViewModel()
        {
            Label texto = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                FontSize = 18,
                FontFamily = Device.OnPlatform("OpenSans", "OpenSans-Regular", null)
            };

            Image image = new Image
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            texto.SetBinding(Label.TextProperty, "texto");
            image.SetBinding(Image.SourceProperty, "imagen");
            image.SetBinding(Image.WidthRequestProperty, "WidthRequest");
            StackLayout Contenido = new StackLayout
            {
                WidthRequest = 275,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { image, texto }
            };

            Contenido.SetBinding(StackLayout.PaddingProperty, "Padding");
            Contenido.SetBinding(StackLayout.SpacingProperty, "Spacing");
            Content = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 0,
                Children =
                {
                    Contenido
                }
            };
        }
    }
}