using EGuardian.Interfaces;
using EGuardian.Models.Eventos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EGuardian.Data
{
    public class EGuardianDatabase
    {
        static object locker = new object();
        SQLiteConnection database;
        public EGuardianDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();

            //Modulo Eventos
            database.CreateTable<eventos>();
        }

        public IEnumerable<eventos> GetEventos()
        {
            lock (locker)
            {
                return database.Table<eventos>().ToList().OrderBy((i) => i.id);
            }
        }

        public int InsertEvento(eventos evento)
        {
            lock (locker)
            {
                if (evento.id != 0)
                {
                    database.Update(evento);
                    return evento.id;
                }
                else
                {
                    return database.Insert(evento);

                }
            }
        }
    }
}
