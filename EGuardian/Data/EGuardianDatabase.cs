using EGuardian.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
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
        }        
    }
}
