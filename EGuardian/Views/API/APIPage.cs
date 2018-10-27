using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EGuardian.Views.API
{
	public class APIPage : ContentPage
	{
		public APIPage ()
		{
            Content = new Grid
            {
                Children = {
                    new Image
                    {
                        Source = "iDesarrollo.jp",
                        Aspect = Aspect.AspectFill
                    }
                }
            };
        }
	}
}