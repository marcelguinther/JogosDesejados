using Domain.Contracts.Repository;
using Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Infra.Data
{
    public class GameData : IGameRepository
    {    
        public void Inserir(Game game)
        {
            //var client = new MongoClient("mongodb://localhost:32768");
            //var database = client.GetDatabase("Globo");
            var client = new MongoClient("mongodb://marcelguinther:123marcel@cluster0-shard-00-00-vlxv0.mongodb.net:27017,cluster0-shard-00-01-vlxv0.mongodb.net:27017,cluster0-shard-00-02-vlxv0.mongodb.net:27017/globo?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin");
            var database = client.GetDatabase("MarcelTestes");

            var collection = database.GetCollection<Game>("games");
            var entity = game;
            collection.InsertOne(entity);
        }

        public List<Game> ListarGames()
        {
            //var client = new MongoClient("mongodb://localhost:32768");
            //var database = client.GetDatabase("Globo");
            var client = new MongoClient("mongodb://marcelguinther:123marcel@cluster0-shard-00-00-vlxv0.mongodb.net:27017,cluster0-shard-00-01-vlxv0.mongodb.net:27017,cluster0-shard-00-02-vlxv0.mongodb.net:27017/globo?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin");
            var database = client.GetDatabase("MarcelTestes");

            var collection = database.GetCollection<Game>("games");
            var documents = collection.Find(m => true).ToList();
            return documents;
        }
        public Game BuscaGamePorNomeComPlataforma(string nome, string videogame)
        {
            //var client = new MongoClient("mongodb://localhost:32768");
            //var database = client.GetDatabase("Globo");
            var client = new MongoClient("mongodb://marcelguinther:123marcel@cluster0-shard-00-00-vlxv0.mongodb.net:27017,cluster0-shard-00-01-vlxv0.mongodb.net:27017,cluster0-shard-00-02-vlxv0.mongodb.net:27017/globo?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin");
            var database = client.GetDatabase("MarcelTestes");

            var collection = database.GetCollection<Game>("games");
            var document = collection.Find(m => m.Nome == nome && m.VideoGame == videogame).ToList();

            if (document.Count == 0)
                throw new Exception("Game não encontrado");

            return document[0];
        }

        public Game BuscaGamePorId(string id)
        {
            //var client = new MongoClient("mongodb://localhost:32768");
            //var database = client.GetDatabase("Globo");
            var client = new MongoClient("mongodb://marcelguinther:123marcel@cluster0-shard-00-00-vlxv0.mongodb.net:27017,cluster0-shard-00-01-vlxv0.mongodb.net:27017,cluster0-shard-00-02-vlxv0.mongodb.net:27017/globo?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin");
            var database = client.GetDatabase("MarcelTestes");

            var collection = database.GetCollection<Game>("games");
            var document = collection.Find(m => m.Id == ObjectId.Parse(id)).ToList();

            if (document.Count == 0)
                throw new Exception("Game não encontrado");

            return document[0];
        }

        public void Alterar(Game game)
        {
            //var client = new MongoClient("mongodb://localhost:32768");
            //var database = client.GetDatabase("Globo");
            var client = new MongoClient("mongodb://marcelguinther:123marcel@cluster0-shard-00-00-vlxv0.mongodb.net:27017,cluster0-shard-00-01-vlxv0.mongodb.net:27017,cluster0-shard-00-02-vlxv0.mongodb.net:27017/globo?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin");
            var database = client.GetDatabase("MarcelTestes");

            var collection = database.GetCollection<Game>("games");
            collection.ReplaceOne(m => m.Id == game.Id, game);

        }
        public void DeletaPorNome(string nome)
        {
            //var client = new MongoClient("mongodb://localhost:32768");
            //var database = client.GetDatabase("Globo");
            var client = new MongoClient("mongodb://marcelguinther:123marcel@cluster0-shard-00-00-vlxv0.mongodb.net:27017,cluster0-shard-00-01-vlxv0.mongodb.net:27017,cluster0-shard-00-02-vlxv0.mongodb.net:27017/globo?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin");
            var database = client.GetDatabase("MarcelTestes");

            var collection = database.GetCollection<Game>("games");
            collection.DeleteOne(a => a.Nome == nome);
        }
        public void Dispose()
        {
            //Dispose();
        }
    }
}
