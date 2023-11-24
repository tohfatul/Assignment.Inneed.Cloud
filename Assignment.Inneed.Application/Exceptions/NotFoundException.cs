﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.Exceptions;

public class NotFoundException: Exception
{
    public NotFoundException(string message) : base($"{message} was not found")
    {

    }
    public NotFoundException(string name, object key): base($"{name} ({key}) was not found" )
    {
        
    }
}
