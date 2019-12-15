using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogEvent
{
    internal class Sms
    {
        public void SendMessage(string _message)
        {
            Console.WriteLine($"Отправляем SMS сообщение: \r\n'{ _message }'\r\n");
        }
        
    }
}
