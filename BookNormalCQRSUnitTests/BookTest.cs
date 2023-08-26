using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edument.CQRS;
using BookNormalCQRS;
using NUnit.Framework.Internal;
using System.IO;
using Events;

namespace BookNormalCQRSUnitTests
{
    [TestFixture]
    public class BookTest : BDDTest<BookAggregate>
    {
        private Guid _bookId;
        //private Guid _reservationId;

        private string _bookTitle;
        private string _updateBookTitle;

        [SetUp]
        public void Setup()
        {
            _bookId = Guid.NewGuid();
            _bookTitle = "Intro to Crying";
            _updateBookTitle = "Intro Updated";

        }
        [Test]
        public void AddNewBookTest()
        {
            Test(
               Given(),
           When(new AddNewBook
           {
               Id = _bookId,
               BookTitle = _bookTitle
           }),
           Then(new AddedBook
           {
               Id = _bookId,
               BookTitle = _bookTitle
           }));
        }
        [Test]
        public void UpdateBookTest()
        {
            Test(
               Given(),
           When(new UpdateBook
           {
               Id = _bookId,
               UpdatedBookTitle = _updateBookTitle
           }),
           Then(new UpdatedBook
           {
               Id = _bookId,
               UpdatedBookTitle = _updateBookTitle
           }));
        }
        [Test]
        public void DeleteBookTest()
        {
            Test(
               Given(),
           When(new DeleteBook
           {
               Id = _bookId,

           }),
           Then(new DeletedBook
           {
               Id = _bookId,

           }));
        }

    }
}
