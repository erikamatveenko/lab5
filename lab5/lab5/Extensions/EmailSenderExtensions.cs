using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using lab5.Services;

namespace lab5.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Подтвердите ваш email",
                $"Пожалуйста, подтвердите ваш аккаунт нажатием на эту ссылку: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
