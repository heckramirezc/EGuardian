using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace EGuardian.Views.Perfil
{
	public class PerfilPage : ContentPage
	{
		public PerfilPage ()
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