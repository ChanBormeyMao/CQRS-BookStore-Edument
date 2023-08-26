using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book3ReadModels
{
    public interface IBookReadModel
    {
        List<BookReadModel.Book> GetAllBooks();
        BookReadModel.Book SearchedBook(Guid BookId);
        void Handle(AddedBook e);
        void Handle(UpdatedBook e);
        void Handle(DeletedBook e);


    }
}
