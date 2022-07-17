using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Constants
{
    public class MessageHelper
    {
        public static string CreateMessage(string subject, string message)
        {
            return String.Format(message, subject);
        }
    }
}
