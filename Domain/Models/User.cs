using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public ObjectId Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public User(string nome, string email, string password)
        {
            this.Nome = nome;
            this.Email = email;
            this.Password = password;
        }

        public User(string id, string nome, string email, string password)
        {
            this.Id = ObjectId.Parse(id);
            this.Nome = nome;
            this.Email = email;
            this.Password = password;
        }
    }
}
