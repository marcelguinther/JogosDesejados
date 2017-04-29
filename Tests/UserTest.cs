using Domain.Contracts.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Start;
using Domain.Models;
using System;

namespace Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ServicoRegistraComSucesso()
        {
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);
            var serviceUser = container.Resolve<IUserService>();
            serviceUser.Registrar("RH Globo", "rh@globo.comTeste", "marcel");
            var user = serviceUser.Autenticar("rh@globo.comTeste", "marcel");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void ServicoAutenticacaoComSucesso()
        {
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);
            var serviceUser = container.Resolve<IUserService>();
            var user = serviceUser.Autenticar("rh@globo.comTeste", "marcel");
            
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void ServicoAutenticaccaoComErro()
        {
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);
            try
            {
                var serviceUser = container.Resolve<IUserService>();
            }
            catch(Exception ex)
            {
                Assert.IsFalse(true);
            }
            
            
        }
    }
}
