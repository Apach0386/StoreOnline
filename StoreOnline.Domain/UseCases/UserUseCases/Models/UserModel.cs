using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOnline.Domain.UseCases.UserUseCases.Models;

public class UserModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }

    //public List<UserRole>? UserRoles { get; set; }
}
