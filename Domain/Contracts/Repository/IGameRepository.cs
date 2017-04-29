using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Contracts.Repository
{
    public interface IGameRepository : IDisposable
    {
        void Inserir(Game game);
        List<Game> ListarGames();
        Game BuscaGamePorNomeComPlataforma(string nome, string videogame);
        void Alterar(Game game);
        void DeletaPorNome(string nome);
        Game BuscaGamePorId(string id);
    }
}
