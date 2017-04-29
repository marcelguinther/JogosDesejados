using Domain.Contracts.Repository;
using Domain.Models;
using MongoDB.Driver;
using System;

namespace Infra.Data
{
    public class UserData : IUserRepository
    {
        public void Criar(User user)
        {
            //var client = new MongoClient("mongodb://localhost:32768");
            //var database = client.GetDatabase("Globo");
            var client = new MongoClient("mongodb://marcelguinther:123marcel@cluster0-shard-00-00-vlxv0.mongodb.net:27017,cluster0-shard-00-01-vlxv0.mongodb.net:27017,cluster0-shard-00-02-vlxv0.mongodb.net:27017/globo?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin");
            var database = client.GetDatabase("MarcelTestes");

            var collection = database.GetCollection<User>("users");
            var entity = user;
            collection.InsertOne(entity);
        }

        public User BuscaPorEmail(string email)
        {
            //var client = new MongoClient("mongodb://localhost:32768");
            //var database = client.GetDatabase("Globo");
            var client = new MongoClient("mongodb://marcelguinther:123marcel@cluster0-shard-00-00-vlxv0.mongodb.net:27017,cluster0-shard-00-01-vlxv0.mongodb.net:27017,cluster0-shard-00-02-vlxv0.mongodb.net:27017/globo?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin");
            var database = client.GetDatabase("MarcelTestes");

            var collection = database.GetCollection<User>("users");
            var document = collection.Find(m => m.Email == email).ToList();

            if (document.Count == 0)
                throw new Exception("E-mail não encontrado");

            return document[0];
        }
        public void Dispose()
        {
            //Dispose();
        }

    }
}
