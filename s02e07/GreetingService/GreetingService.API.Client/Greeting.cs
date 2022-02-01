﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingService.API.Client;

public class Greeting
{
    public string message { get; set; }
    public string from { get; set; }
    public string to { get; set; }
    public DateTime timestamp { get; set; }
    public Guid id { get; set; } = Guid.NewGuid();

   
}
