using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGuardian.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string Session_Token = "Session_Token";
        private const string idUsuario = "idUsuario";
        private const string subscriptionKey = "subscriptionKey";
        private const string metodoPago = "metodoPago";
        private static readonly string Predeterminado = string.Empty;
        private const string lastUpdate = "lastUpdate";
        private static readonly DateTime lastUpdateDefault = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Local);


        #endregion


        public static string session_Session_Token
        {
            get
            {
                return AppSettings.GetValueOrDefault(Session_Token, Predeterminado);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Session_Token, value);
            }
        }



        public static string session_idUsuario
        {
            get
            {
                return AppSettings.GetValueOrDefault(idUsuario, Predeterminado);
            }
            set
            {
                AppSettings.AddOrUpdateValue(idUsuario, value);
            }
        }

        public static string session_SubscriptionKey
        {
            get
            {
                return AppSettings.GetValueOrDefault(subscriptionKey, Predeterminado);
            }
            set
            {
                AppSettings.AddOrUpdateValue(subscriptionKey, value);
            }
        }

        public static string session_MetodoPago
        {
            get
            {
                return AppSettings.GetValueOrDefault(metodoPago, Predeterminado);
            }
            set
            {
                AppSettings.AddOrUpdateValue(metodoPago, value);
            }
        }

        public static DateTime session_lastUpdate
        {
            get
            {
                return AppSettings.GetValueOrDefault(lastUpdate, lastUpdateDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(lastUpdate, value);
            }
        }
    }
}