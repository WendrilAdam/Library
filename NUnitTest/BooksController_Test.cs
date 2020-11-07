using Library.Controllers;
using Library.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Library.NUnitTest
{
    [TestFixture]
    public class BooksController_Test
    {

        private readonly LibraryContext context;



        [SetUp]
        public void Setup()
        {

        }

        [TestCase(1)]
        public void GetBooksId_Passe(int id)
        {
            //Padrão AAA:
            //Arrange;
            var booksController = new BooksController(context);
            //Act
            var lista = booksController.GetBooksId(id).IsCompleted;

            //Assert
            Assert.IsTrue(lista);
        }


        [Test]
        public void GetBooks_Falhe()
        {
            //Padrão AAA:
            //Arrange
            var booksController = new BooksController(context);
            //Act
            var result = booksController.GetBooks().IsCanceled;

            //Assert
            Assert.IsFalse(result);
        }
    }
}
