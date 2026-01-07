using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainerHub.Domain.UseCases.BookUseCases.Abstract;
using TrainerHub.Domain.UseCases.BookUseCases.Model;

namespace TrainerHub.Domain.UseCases.BookUseCases.Commands.Create
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookModel>
    {
        private readonly IBookStorage _storage;

        public CreateBookCommandHandler(IBookStorage storage)
        {
            _storage = storage;
        }
        public Task<BookModel> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            return _storage.CreateBook(command, cancellationToken);

        }
    }
}
