using System;
using Xamarin.Forms;
using SQLite;
using System.Collections;
using System.Collections.Generic;

namespace EGuardian.Models.Eventos
{
    public class eventos
    {
        System.Globalization.CultureInfo globalizacion = new System.Globalization.CultureInfo("es-GT");
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int calendarID { get; set; }
        public string asunto { get; set; }
        public string ubicacion { get; set; }
        public string capacitador { get; set; }
        public int estado { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string fechaCita => getSelectedDate(Convert.ToDateTime(fechaInicio));
        public string horaInicioCita => Convert.ToDateTime(fechaInicio).ToString(@"hh:mm");
        public string horaFinCita => Convert.ToDateTime(fechaFin).ToString(@"hh:mm");
        public string horaTiempoCita => getHoraTiempoCita(Convert.ToDateTime(fechaInicio));
        public string horaTiempoCitaFinal => getHoraTiempoCita(Convert.ToDateTime(fechaFin));
        public string horarioCita
        {
            get
            {
                return horaInicioCita + " " + horaTiempoCita + " - " + horaFinCita + " " + horaTiempoCitaFinal;
            }
        }
        public Color estadoColor
        {
            get
            {
                return Color.FromHex("0067E7");
            }
        }
        public string estadoCita
        {
            get
            {
                return "EN ESPERA";
            }
        }

        public IEnumerable Asistentes
        {
            get
            {
                List<asistentes> asistentesEvento = new List<asistentes>();

                asistentesEvento.Add(new asistentes
                {
                    nombre ="José Hernández Gomez",
                    puesto="Área de ventas",
                    rol="Capacitador"
                });

                asistentesEvento.Add(new asistentes
                {
                    nombre = "José Hernández Gomez",
                    puesto = "Área de ventas",
                    rol = "Asistente"
                });

                asistentesEvento.Add(new asistentes
                {
                    nombre = "José Hernández Gomez",
                    puesto = "Área de ventas",
                    rol = "Asistente"
                });

                asistentesEvento.Add(new asistentes
                {
                    nombre = "José Hernández Gomez",
                    puesto = "Área de ventas",
                    rol = "Asistente"
                });

                asistentesEvento.Add(new asistentes
                {
                    nombre = "José Hernández Gomez",
                    puesto = "Área de ventas",
                    rol = "Asistente"
                });

                return asistentesEvento;
            }
        }

        private string getHoraTiempoCita(DateTime Fecha)
        {
            var horatiempo = Fecha.ToString(@"tt", globalizacion);
            return horatiempo.ToLower();
        }
        private String getSelectedDate(DateTime fechaInicio)
        {
            var currentDate = char.ToUpper(globalizacion.DateTimeFormat.GetDayName(fechaInicio.DayOfWeek).ToString()[0]) + globalizacion.DateTimeFormat.GetDayName(fechaInicio.DayOfWeek).ToString().Substring(1) + " " + Convert.ToDateTime(fechaInicio).Day + " de " + globalizacion.DateTimeFormat.GetMonthName(fechaInicio.Month);
            return currentDate;
        }
    }
}