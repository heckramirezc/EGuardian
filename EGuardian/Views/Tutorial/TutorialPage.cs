using CarouselView.FormsPlugin.Abstractions;
using EGuardian.Models.Tutorial;
using EGuardian.ViewModels.Tutorial;
using EGuardian.Views.Acceso;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EGuardian.Views.Tutorial
{
    public class TutorialPage : ContentPage
    {
        CarouselViewControl tutorialCarousel;
        List<TutorialItem> contenidoCarousel;
        StackLayout Indicator1, Indicator2, Indicator3, Indicator4;
        Grid indicadores;

        public TutorialPage()
        {
            BackgroundImage = "tutorial_bk";
            contenidoCarousel = new List<TutorialItem>();
            contenidoCarousel.Add(
                new TutorialItem
                {
                    index = 0,
                    texto = "TutorialItem1",
                    imagen = "tutorialItem1.png",
                    WidthRequest = 275,
                    Padding = new Thickness(0, 100, 0, 0),
                    Spacing = 50
                });
            contenidoCarousel.Add(
                new TutorialItem
                {
                    index = 1,
                    texto = "TutorialItem2",
                    imagen = "tutorialItem2.png",
                    WidthRequest = 175,
                    Padding = new Thickness(0, 50, 0, 0),
                    Spacing = 25
                });
            contenidoCarousel.Add(
                new TutorialItem
                {
                    index = 2,
                    texto = "TutorialItem3",
                    imagen = "tutorialItem3.png",
                    WidthRequest = 175,
                    Padding = new Thickness(0, 50, 0, 0),
                    Spacing = 25
                });
            contenidoCarousel.Add(
                new TutorialItem
                {
                    index = 3,
                    texto = "TutorialItem4",
                    imagen = "tutorialItem4.png",
                    WidthRequest = 175,
                    Padding = new Thickness(0, 50, 0, 0),
                    Spacing = 25
                });

            tutorialCarousel = new CarouselViewControl
            {
                ItemsSource = contenidoCarousel,
                ItemTemplate = new DataTemplate(typeof(TutorialViewModel)),
                InterPageSpacing = 10,
                HeightRequest = 70,
                Orientation = CarouselViewOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };


            Indicator1 = new StackLayout
            {                
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children ={
                    new Image
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Source = "indicator_fill"}
                    },

            };

            Indicator2 = new StackLayout
            {
                Spacing = 0,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children ={
                    new Image
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Source = "indicator_fill"}
                    }
            };
            Indicator3 = new StackLayout
            {                
                Spacing = 0,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children ={
                    new Image
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Source = "indicator_fill"}
                    }
            };
            Indicator4 = new StackLayout
            {                
                Spacing = 0,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =              {
                    new Image
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Source = "indicator_fill"                    }
                    }
            };

            TapGestureRecognizer tapIndicator1 = new TapGestureRecognizer();
            tapIndicator1.Tapped += (sender, e) =>
            {
                if (tutorialCarousel.Position != 0)
                    tutorialCarousel.Position=0;
            };
            TapGestureRecognizer tapIndicator2 = new TapGestureRecognizer();
            tapIndicator2.Tapped += (sender, e) =>
            {
                if (tutorialCarousel.Position != 1)
                    tutorialCarousel.Position=1;
            };
            TapGestureRecognizer tapIndicator3 = new TapGestureRecognizer();
            tapIndicator3.Tapped += (sender, e) =>
            {
                if (tutorialCarousel.Position != 2)
                    tutorialCarousel.Position=2;
            };
            TapGestureRecognizer tapIndicator4 = new TapGestureRecognizer();
            tapIndicator4.Tapped += (sender, e) =>
            {
                if (tutorialCarousel.Position != 3)
                    tutorialCarousel.Position=3;
            };

            Indicator1.GestureRecognizers.Add(tapIndicator1);
            Indicator2.GestureRecognizers.Add(tapIndicator2);
            Indicator3.GestureRecognizers.Add(tapIndicator3);
            Indicator4.GestureRecognizers.Add(tapIndicator4);

            indicadores = new Grid
            {
                HeightRequest = 20,
                RowSpacing = 0,
                ColumnSpacing = 5,
                Padding = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(20, GridUnitType.Absolute) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) }
                }
            };

            indicadores.Children.Add(Indicator1, 0, 0);
            indicadores.Children.Add(Indicator2, 1, 0);
            indicadores.Children.Add(Indicator3, 2, 0);
            indicadores.Children.Add(Indicator4, 3, 0);

            Button comenzar = new Button
            {
                Text = "COMENZAR",
                AutomationId = "comenzar",
                WidthRequest = 300,
                HeightRequest = 50,
                FontFamily = Device.OnPlatform("OpenSans-ExtraBold", "OpenSans-ExtraBold", null),
                FontSize = 20,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromHex("f7b819")
            };
            comenzar.Clicked += Comenzar_Clicked;

            RelativeLayout Contenido = new RelativeLayout();
            Contenido.Children.Add(tutorialCarousel,
                                   Constraint.Constant(0),
                                   Constraint.Constant(0),
                                   Constraint.RelativeToParent((parent) => { return parent.Width; }),
                                   Constraint.RelativeToParent((parent) => { return parent.Height; })
                                  );

            Contenido.Children.Add(indicadores,
                                   Constraint.RelativeToParent((parent) => { return (parent.Width / 2) - 50; }),
                                   Constraint.RelativeToParent((parent) => { return parent.Height - (parent.Height / 7.35) - 60; })
                                  );

            Contenido.Children.Add(comenzar,
                                   Constraint.RelativeToParent((parent) => { return (parent.Width / 2) - 150; }),
                                   Constraint.RelativeToParent((parent) => { return parent.Height - (parent.Height / 7.35); })
                                  );
            Content = Contenido;
            tutorialCarousel.PositionSelected += tutorialCarousel_PositionSelected;
        }

        void Comenzar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LoginPage());
        }

        void defaultIndicators()
        {
            ((Image)Indicator1.Children[0]).Source = "indicator_fill";
            ((Image)Indicator2.Children[0]).Source = "indicator_fill";
            ((Image)Indicator3.Children[0]).Source = "indicator_fill";
            ((Image)Indicator4.Children[0]).Source = "indicator_fill";
        }

        void tutorialCarousel_PositionSelected(object sender, EventArgs e)
        {
            try
            {
                switch (tutorialCarousel.Position)
                {
                    case 0:
                        defaultIndicators();
                        ((Image)Indicator1.Children[0]).Source = "indicator";
                        break;
                    case 1:
                        defaultIndicators();
                        ((Image)Indicator2.Children[0]).Source = "indicator";
                        break;
                    case 2:
                        defaultIndicators();
                        ((Image)Indicator3.Children[0]).Source = "indicator";
                        break;
                    case 3:
                        defaultIndicators();
                        ((Image)Indicator4.Children[0]).Source = "indicator";
                        break;
                    default:
                        defaultIndicators();
                        ((Image)Indicator1.Children[0]).Source = "indicator";
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}