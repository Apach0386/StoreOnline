using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOnline.Domain.Base;

public interface IStorage
{
    Task<bool> IsExist(Guid entityId, CancellationToken cancellationToken);
}
