using StoreOnline.Domain.UseCases.UserUseCases.Commands.Create;
using StoreOnline.Domain.UseCases.UserUseCases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOnline.Domain.UseCases.UserUseCases.Abstract
{
    public interface IRoleStorage
    {
        Task AssigneRole (Guid userId, string roleName, CancellationToken cancellationToken);
    }
}
