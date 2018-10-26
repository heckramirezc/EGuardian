using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EGuardian.Common.Resources
{
    public static class Images
    {
        public static readonly ImageSource LoginIcon = "iLaTorre.png";
        public static readonly ImageSource LoginIr = "iLaTorre.png";

        public static readonly FileImageSource LoginFacebook = "iLoginFacebook.png";

        public static readonly FileImageSource MenuIcon = "menu.png";

        public static readonly ImageSource SocialMedia1 = "iFacebook.png";
        public static readonly ImageSource SocialMedia2 = "iTwitter.png";
        public static readonly ImageSource SocialMedia3 = "iPinterest.png";

        public static readonly ImageSource EnDesarrollo = "iDesarrollo.jpg";

        public static readonly FileImageSource Cancelar = new FileImageSource() { File = "iCancelarEdicion.png" };
        public static FileImageSource Anterior = new FileImageSource() { File = "iAnterior.png" };
        public static FileImageSource Siguiente = new FileImageSource() { File = "iSiguiente.png" };
        public static FileImageSource AnteriorC = new FileImageSource() { File = "iAnteriorC.png" };
        public static FileImageSource SiguienteC = new FileImageSource() { File = "iSiguienteC.png" };
        public static FileImageSource Actual = new FileImageSource() { File = "fechaActual.png" };
        public static FileImageSource Seleccionada = new FileImageSource() { File = "fechaSeleccionada.png" };
        public static FileImageSource Reloj = new FileImageSource() { File = "iCitaReloj.png" };
        public static FileImageSource Paciente = new FileImageSource() { File = "iAlertas.png" };
        public static FileImageSource Cita = new FileImageSource() { File = "iCitaDetalle.png" };
    }
}