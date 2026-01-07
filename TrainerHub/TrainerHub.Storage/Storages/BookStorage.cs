using System;
using System.Collections.Generic;
using System.Text;
using TrainerHub.Domain.UseCases.BookUseCases.Abstract;
using TrainerHub.Domain.UseCases.BookUseCases.Commands.Create;
using TrainerHub.Domain.UseCases.BookUseCases.Model;

namespace TrainerHub.Storage.Storages
{
    public class BookStorage : IBookStorage
    {
        public Task<BookModel> CreateBook(CreateBookCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
