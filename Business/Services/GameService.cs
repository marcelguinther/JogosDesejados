using Domain.Contracts.Services;
using Domain.Contracts.Repository;
using Domain.Models;
using System.Collections.Generic;
namespace Business.Services
{
    public class GameService : IGameService
    {
        private IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            this._repository = repository;
        }
        public void Cadastrar(string nome, string videogame)
        {
            var game = new Game(nome,videogame);
            _repository.Inserir(game);
        }
        public void Alterar(Game game)
        {
            _repository.Alterar(game);
        }
        public List<Game> ListarGames()
        {
            return _repository.ListarGames();
        }
        public Game BuscaGamePorNomeComPlataforma(string nome, string videogame)
        {
            return _repository.BuscaGamePorNomeComPlataforma(nome, videogame);
        }
        public Game BuscaGamePorId(string id)
        {
            return _repository.BuscaGamePorId(id);
        }
        public void DeletaPorNome(string nome)
        {
            _repository.DeletaPorNome(nome);
        }
        public void Dispose()
        {
            if(_repository != null)
                _repository.Dispose();
        }
    }
}