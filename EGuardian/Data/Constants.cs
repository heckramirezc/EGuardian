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

    }
}