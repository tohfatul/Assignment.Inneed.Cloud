using Assignment.Inneed.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Domain;

public class Role:BaseEntity
{
    public string RoleName { get; set; } = string.Empty;
}
