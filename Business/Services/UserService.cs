using Domain.Contracts.Services;
using Domain.Contracts.Repository;
using Domain.Models;
using System;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public User Autenticar(string email, string password)
        {
            var user = BuscaPorEmail(email);

            if (user.Password != Encrypt(password))
                throw new Exception("Senha Incorreta");

            return user;
        }        
        public void Registrar(string name, string email, string password)
        {
            var user = new User(name, email, Encrypt(password));
            _repository.Criar(user);
        }
        public User BuscaPorEmail(string email)
        {
            var user = _repository.BuscaPorEmail(email);

            return user;
        }
        public void Dispose()
        {
            if(_repository != null)
                _repository.Dispose();
        }
        private static string Encrypt(string password)
        {
            password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));
            var sbString = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}
