using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    class SendMail
    {
        private string bodyMail = string.Empty;
        private string emailUser = string.Empty;
        private string rating = string.Empty;
        private string subject = "Комментарий о работе ПО Библиотека";
        private const string passMail = "5E1a7f9p7t";
        public static List<string> file = new List<string>();

        public SendMail(string bodyMail, string emailUser, string rating) //присвоение значений переменным
        {
            this.bodyMail = bodyMail;
            this.emailUser = emailUser;
            this.rating = rating;
        }

        public void MySendMail()    //отправка сообщения
        {
            MailAddress from = new MailAddress("drackonov.drag@yandex.ru", emailUser); 
            MailAddress to = new MailAddress("i_e.v.antonov@mpt.ru", "Evgeny Antonov");

            try
            {
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from.Address, passMail);
                smtp.EnableSsl = true;
                smtp.Timeout = 20000;
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = subject;
                mail.Body =  $"Оценка пользователя: {rating}\nЛогин пользователя: {AuthorizationForm.LoginUser}\n" + bodyMail;

                foreach (var item in file)  //прикрепление файлов к сообщению
                {
                    mail.Attachments.Add(new Attachment(item));
                }

                smtp.Send(mail);

                MessageBox.Show("Сообщение успешно отправлено!", "Библиотека", MessageBoxButtons.OK, MessageBoxIcon.Information);
                file.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Библиотека", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
