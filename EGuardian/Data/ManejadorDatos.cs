using EGuardian.Interfaces;
using EGuardian.Models.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EGuardian.Data
{
    public class ManejadorDatos
    {
        IDataStore ServicioWeb;

        public ManejadorDatos(IDataStore servicio)
        {
            ServicioWeb = servicio;
        }

        public Task<LoginResponse> LoginAsync(Login peticion)
        {
            return ServicioWeb.LoginAsync(peticion);
        }
    }
}
