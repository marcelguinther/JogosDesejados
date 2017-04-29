using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Game
    {
        public ObjectId Id { get; private set; }
        public string Nome { get; private set; }
        public string VideoGame { get; private set; }

        public Game(string nome, string videogame)
        {
            this.Nome = nome;
            this.VideoGame = videogame;
        }

        public Game(string id, string nome, string videogame)
        {
            this.Id = ObjectId.Parse(id);
            this.Nome = nome;
            this.VideoGame = videogame;
        }

        public void Alterar(string nome, string videogame)
        {
            this.Nome = nome;
            this.VideoGame = videogame;
        }

        public void AlteraValor(string novoNome, string novoVideoGame)
        {
            this.Nome = novoNome;
            this.VideoGame = novoVideoGame;
        }
    }
}
