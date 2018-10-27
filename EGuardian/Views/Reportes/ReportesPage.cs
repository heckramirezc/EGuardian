using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EGuardian.Views.Reportes
{
	public class ReportesPage : ContentPage
	{
		public ReportesPage ()
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