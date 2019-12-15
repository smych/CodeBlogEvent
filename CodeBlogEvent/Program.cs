using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager NewObjmailManager = new MailManager();
            NewObjmailManager.NewMail += MailManagerMethod;

            Console.Write("Введите ваше имя: ");
            var sender = Console.ReadLine();

            Console.Write("С кем вы хотите связаться? Введите имя: ");
            var target = Console.ReadLine();

            Console.WriteLine("Введите текст сообщения: ");
            var message = Console.ReadLine();

            NewObjmailManager.SimulateNewMail(sender, target, message);

            Console.ReadLine();
        }

        private static void MailManagerMethod(object sender, NewMailEventArgs e)
        {
            var sms = new Sms();
            sms.SendMessage(string.Format($"сообщение SMS: '{e.Subject}' от: '{e.From}' для: '{e.To}'"));


            var print = new Print();
            print.PrintText(string.Format($"Сгенерирован текс для " +
                                            $"\n печати: '{e.Subject}'" +
                                            $"\n от: '{e.From}' " +
                                            $"\n для: '{e.To}'"));
        }
    }


}
