using Assignment.Inneed.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Domain;

public class User:BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } 
    public byte[] PasswordSalt { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }
    
}
