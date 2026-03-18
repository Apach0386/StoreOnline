using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOnline.Domain.UseCases.UserUseCases.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public required string Email { get; set; }    
    public required string PhoneNumber { get; set; }

    public List<string> Roles { get; set; } = [];
}
