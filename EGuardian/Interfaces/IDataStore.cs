using EGuardian.Models.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EGuardian.Interfaces
{
    public interface IDataStore
    {
        Task<LoginResponse> LoginAsync(Login peticion);
    }
}