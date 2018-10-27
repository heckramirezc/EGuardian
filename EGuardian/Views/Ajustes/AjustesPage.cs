using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EGuardian.Views.Ajustes
{
	public class AjustesPage : ContentPage
	{
		public AjustesPage ()
		{
            Content = new Grid {
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