using EGuardian.Interfaces;
using EGuardian.Models;
using EGuardian.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGuardian.Services
{
    public class DataStore : IDataStore
    {        
        public DataStore()
        {
        }

        public async Task<LoginResponse> LoginAsync(Login peticion)
        {           
            return new LoginResponse();
        }      
    }
}