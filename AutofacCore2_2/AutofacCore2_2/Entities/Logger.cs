using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacCore2_2.Entities
{
    public interface ILogger
    {
        void log(string msg);
    }

    /// <summary>
    /// LD003 for each class select the class name and then by "ctrl+." exstract the interface
    /// </summary>
    public class Logger : ILogger
    {  
        /// <summary>
        /// I may decide to write in database instead of console, no impact on external classes
        /// </summary>
        /// <param name="msg"></param>
        public void log(string msg)
        {
            Console.WriteLine($"Logging { msg }");
        }
    }
}
