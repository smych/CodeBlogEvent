using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBlogEvent
{
    internal class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            // Проверка на null
            NewMailEventArgs _ = e ?? throw new ArgumentNullException(nameof(e));

            #region 1
            // Вариант 1
            // Может быть уязвимость при многопоточности

            NewMail?.Invoke(this, e);
            #endregion 1

            #region 2
            // Вариант 2
            // Решает проблему, но поведение компилятора может изменится

            //EventHandler<NewMailEventArgs> temp = NewMail;
            //if (temp != null)
            //{
            //    temp(this, e);
            //}

            #endregion 2

            #region 3
            // Вариант 3
            // Сохранить ссылку на делегата во временной переменной
            // Для обеспичения безопастности потоков

            //Volatile.Read(ref NewMail)?.Invoke(this, e);

            #endregion 3
        }

        public void SimulateNewMail(string _from, string _to, string _subject)
        {
            // Необходимо проверить входные данные на корректность

            // Создать объект для хранения информации, которую нужно передать получателям уведомления
            NewMailEventArgs e = new NewMailEventArgs(_from, _to, _subject);

            // Вызвать виртуальный метод, уведомляющий объект о событии
            OnNewMail(e);
        }
    }

    internal class TOXA : MailManager
    {
        void MethodName(object sender, NewMailEventArgs e)
        { 
            
        }
    }
}
