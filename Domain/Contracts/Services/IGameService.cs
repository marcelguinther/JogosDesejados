using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Contracts.Services
{
    public interface IGameService : IDisposable
    {
        void Cadastrar(string nome, string videogame);
        void Alterar(Game game);
        List<Game> ListarGames();
        void DeletaPorNome(string nome);
        Game BuscaGamePorNomeComPlataforma(string nome, string videogame);
        Game BuscaGamePorId(string id);
    }   
}
