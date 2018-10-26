using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using Plugin.Toasts;
using Xamarin.Forms;
using RoundedBoxView.Forms.Plugin.Droid;
using Refractored.XamForms.PullToRefresh.Droid;
using ImageCircle.Forms.Plugin.Droid;

namespace EGuardian.Droid
{    
    //[Activity(Label = "EGuardian", Icon = "@mipmap/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    [Activity(Label = "EGuardian")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
			Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            App.DisplayScreenWidth = (double)Resources.DisplayMetrics.WidthPixels / (double)Resources.DisplayMetrics.Density;
            App.DisplayScreenHeight = (double)Resources.DisplayMetrics.HeightPixels / (double)Resources.DisplayMetrics.Density;
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CarouselViewRenderer.Init();
            RoundedBoxViewRenderer.Init();
            ImageCircleRenderer.Init();
            PullToRefreshLayoutRenderer.Init();
            DependencyService.Register<ToastNotificatorImplementation>();
            ToastNotificatorImplementation.Init(this);
            LoadApplication(new App());
        }
    }
}