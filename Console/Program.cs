using Domain.Contracts.Services;
using System;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Start;
using Domain.Models;
using MongoDB.Bson;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IGameService>();

            //CADASTRO
            //try
            //{
            //    service.Cadastrar("Fifa 19", "PlayStaion");
            //    System.Console.WriteLine("Criado com sucesso!");
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //}

            ////GET ALL
            //try
            //{
            //    var games = service.ListarGames();
            //    foreach (Game game in games)
            //    {
            //        System.Console.WriteLine("ID: " + game.Id + " - nome: " + game.Nome + " - plataforma: " + game.VideoGame);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    //service.Dispose();
            //}

            ////ALTERAR
            //try
            //{
            //    var id = ObjectId.Parse("58ffe53bd134622ab0807fea");
            //    var gameUpdate = new Game(id, "Fallout", "XBoxOne");

            //    service.Alterar(gameUpdate);
            //    System.Console.WriteLine("Alterado com sucesso!");

            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}


            //DELETE
            //try
            //{
            //    service.DeletaPorNome("Fifa 17");
            //    System.Console.WriteLine("Delete com sucesso!");

            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    service.Dispose();
            //}


            ///////////////////////////////////////////////////////////////
            var serviceUser = container.Resolve<IUserService>();
            //CRIAR USUARIO

            try
            {
                serviceUser.Registrar("RH Globo", "rh@globo.com", "marcel");
                System.Console.WriteLine("Usuário criado com sucesso!");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }


            //Autenticar USUARIO
            //try
            //{
            //    var user = serviceUser.Autenticar("rh@globo.com", "marcel");
            //    System.Console.WriteLine("Acesso realizado: "+ user.Nome +" - ID: "+user.Id);
            //}
            //catch (Exception ex)
            //{
            //    System.Console.WriteLine(ex.Message);
            //}
            //serviceUser.Dispose();
            System.Console.ReadLine();
        }
    }
}
