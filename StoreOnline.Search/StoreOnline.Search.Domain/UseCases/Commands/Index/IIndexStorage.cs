using System;
using System.Collections.Generic;
using System.Text;

namespace StoreOnline.Search.Domain.UseCases.Commands.Index;

public interface IIndexStorage
{
    Task IndexProduct(Guid productId, string name, string? description, CancellationToken cancellationToken);
}
