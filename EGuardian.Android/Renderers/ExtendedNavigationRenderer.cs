using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

namespace EGuardian.Droid.Renderers
{
    public class ExtendedNavigationRenderer : NavigationPageRenderer
    {
        public ExtendedNavigationRenderer(Context context) : base(context)
        {

        }

        private Android.Support.V7.Widget.Toolbar toolbar;
        private Android.Support.V7.Widget.AppCompatTextView textView;

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);
            if (child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {
                toolbar = (Android.Support.V7.Widget.Toolbar)child;
                toolbar.ChildViewAdded += Toolbar_ChildViewAdded;
            }
        }


        private void Toolbar_ChildViewAdded(object sender, ChildViewAddedEventArgs e)
        {
            var view = e.Child.GetType();
            if (e.Child.GetType() == typeof(Android.Support.V7.Widget.AppCompatTextView))
            {
                var textView = (Android.Support.V7.Widget.AppCompatTextView)e.Child;
                var spaceFont = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, "Arial-Black.ttf");
                textView.Typeface = spaceFont;
                textView.TextSize = (float)(App.DisplayScreenWidth / 26.666666666666667);
                //textView.TextAlignment = Android.Views.TextAlignment.Center;
                //textView.Gravity = Android.Views.GravityFlags.CenterHorizontal;

                float toolbarCenter = (float)(App.DisplayScreenWidth / 2);
                float titleCenter = (float)(App.DisplayScreenWidth / 5) / 2;
                //textView.SetX(toolbarCenter - titleCenter);
                textView.SetX((float)150);
                toolbar.ChildViewAdded -= Toolbar_ChildViewAdded;
            }
        }
    }
}