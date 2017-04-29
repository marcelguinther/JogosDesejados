using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repository
{
    public interface IUserRepository : IDisposable
    {
        void Criar(User user);
        User BuscaPorEmail(string email);
    }
}
