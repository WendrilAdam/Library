using Library.Controllers;
using Library.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Library.NUnitTest
{
    [TestFixture]
    public class ClientsController_Test
    {

        private readonly LibraryContext context;
        


        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase(1)]
        public void GetClientesById_Passe(int id)
        {
            //Padrão AAA:
            //Arrange;
            var clientsController = new ClientsController(context);
            //Act
            var lista = clientsController.GetClientsId(id).IsCompleted;

            //Assert
            Assert.IsTrue(lista);
        }


        [Test]
        public void GetClientes_Falhe()
        {
            //Padrão AAA:
            //Arrange
            var clientsController = new ClientsController(context);
            //Act
            var result = clientsController.GetClients().IsCanceled;

            //Assert
            Assert.IsFalse(result);
        }
    }
}