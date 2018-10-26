using System;
using System.Collections.Generic;
using System.Text;

namespace EGuardian.Data
{
    public static class Constants
    {
        public static readonly string releasePampsipAPI = "https://dev.easygosa.com/2018_la_torre/";
        public static readonly string releaseFaceAPI = "https://southcentralus.api.cognitive.microsoft.com/";
        public static readonly string URL_PampsipAPI = releasePampsipAPI;
        public static readonly string URL_FaceAPI = releaseFaceAPI;

        public static readonly string URL_API = URL_PampsipAPI + "rest/default/V1/";
        public static readonly string URL_MEDIA = URL_PampsipAPI + "pub/media/catalog/product";

        public static readonly string URL_FACE_API = URL_FaceAPI + "face/v1.0/";

        public static readonly string URL_Login = URL_API + "tpp-login/login?";

        public static readonly string URL_Detect = URL_FACE_API + "detect?";
        public static readonly string URL_Identify = URL_FACE_API + "identify";
        public static readonly string URL_Person = URL_FACE_API + "largepersongroups/";

        public static string MenuException = "No se reconoce el menu";

        public const string SubscriptionKeyName = "ocp-apim-subscription-key";
        public const string StreamContentTypeHeader = "application/octet-stream";

        public static readonly string LargePersonGroupId = "pampsip-ciudadanos";
        public static readonly string SubscriptionKey = "ce0f754951d842baaf2d2a8035d0f4ee";
        public static readonly string SubscriptionKeyAlternative = "69f1478b2a4f43c783d7d80e576e4446";
        public static bool RedSocialPresentada;
        public static bool ExisteConexionAInternet = true;
        public static double NavigationBarHeight = 0f;

        public static int isEnableSelected = 1;
        public static int isEnableUnSelected = 0;

        public static bool PantallaAbierta = false;

        public static Dictionary<string, string> genero = new Dictionary<string, string>
        {
            { "MASCULINO", "M" },
            { "FEMENINO", "F" }
        };


        public static Dictionary<string, string> colaboradores = new Dictionary<string, string>
        {
            { "De 0 a 10", "1" },
            { "De 11 a 100", "2" },
            { "De 101 a 500", "3" },
            { "Más de 501 ", "4" }
        };

        public static Dictionary<string, string> sectores = new Dictionary<string, string>
        {
            { "Financiero", "1" },
            { "Ingeniería", "2" },
            { "Mercadotecnia", "3" },
            { "Textil", "4" }
        };

        public static Dictionary<string, string> puestos = new Dictionary<string, string>
        {
            { "Gerente G.", "1" },
            { "Supervisor", "2" },
            { "Asesor", "3" },
            { "RRHH", "4" }
        };

        public static int[] horas = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24};
    }
}