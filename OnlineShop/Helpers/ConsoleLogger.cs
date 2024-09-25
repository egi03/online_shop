using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Helpers
{
    class ConsoleLogger : ILogger
    {
        public ConsoleLogger() { }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
