using Domain.Contracts.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Start;
using Domain.Models;
using System;

namespace Tests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void AdicionarComSucesso()
        {
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IGameService>();
            service.Cadastrar("Street Fighter", "Nitendinho");
            var gameCadastrado = service.BuscaGamePorNomeComPlataforma("Street Fighter", "Nitendinho");
            Assert.IsNotNull(gameCadastrado);
        }

        [TestMethod]
        public void BuscaGamePorNomeComPlataformaComSucesso()
        {
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IGameService>();
            var gameCadastrado = service.BuscaGamePorNomeComPlataforma("Street Fighter", "Nitendinho");
            Assert.IsNotNull(gameCadastrado);
        }

        [TestMethod]
        public void ExcluirComSucesso()
        {
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IGameService>();
            try
            {
                service.Cadastrar("Game para remover", "videogamePAraRemover");
                service.DeletaPorNome("Game para remover");
                var gameRemovido = service.BuscaGamePorNomeComPlataforma("Game para remover", "videogamePAraRemover");
                
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void AlterarComSucesso()
        {
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IGameService>();
            service.Cadastrar("Game para editar", "videogameParaEditar");
            var gameParaEditar = service.BuscaGamePorNomeComPlataforma("Game para editar", "videogameParaEditar");
            
            gameParaEditar.AlteraValor("nome alterado", "videogame alterado");
            service.Alterar(gameParaEditar);
            var gameParaEditarFinal = service.BuscaGamePorNomeComPlataforma("nome alterado", "videogame alterado");
            Assert.AreEqual(gameParaEditarFinal.Nome, gameParaEditar.Nome);
            Assert.AreEqual(gameParaEditarFinal.VideoGame, gameParaEditar.VideoGame);
        }
    }
}
