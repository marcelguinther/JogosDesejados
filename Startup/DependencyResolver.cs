using Microsoft.Practices.Unity;
using Business.Services;
using Domain.Models;
using Domain.Contracts.Services;
using Domain.Contracts.Repository;
using Infra.Data;

namespace Start
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<IGameService, GameService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserRepository, UserData>(new HierarchicalLifetimeManager());
            container.RegisterType<IGameRepository, GameData>(new HierarchicalLifetimeManager());

            container.RegisterType<Game, Game>(new HierarchicalLifetimeManager());
            container.RegisterType<User, User>(new HierarchicalLifetimeManager());
        }
    }
}
