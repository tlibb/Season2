using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingService.API.Client;

public class Greeting
{
    public string Message { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime TimeStamp { get; set; }
    public Guid id { get; set; } = Guid.NewGuid();

   
}
