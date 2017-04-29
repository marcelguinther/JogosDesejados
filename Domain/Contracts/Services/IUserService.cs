using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Contracts.Services
{
    public interface IUserService : IDisposable
    {
        User Autenticar(string email, string password);
        void Registrar(string name, string email, string password);
        User BuscaPorEmail(string email);
    }
}
