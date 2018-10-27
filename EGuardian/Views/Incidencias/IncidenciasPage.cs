using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EGuardian.Views.Incidencias
{
	public class IncidenciasPage : ContentPage
	{
		public IncidenciasPage ()
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