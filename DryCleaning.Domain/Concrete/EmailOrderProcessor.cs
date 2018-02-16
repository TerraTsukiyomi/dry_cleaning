﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using DryCleaning.Domain.Abstract;
using DryCleaning.Domain.Entities;
using System.Net;

namespace DryCleaning.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "sportsstore@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\sports_store_emails";
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }
        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username,
               emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder()
                .AppendLine("Новая накладная")
                .AppendLine("---")
                .AppendLine("Вещи:");
                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Order.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (начислено: {2:c}", line.Quantity,
                   line.Order.Name, subtotal);
                }
                body.AppendFormat("Всего: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Клиенту:")
                    .AppendLine(shippingInfo.Client)
                    .AppendLine(shippingInfo.Service)
                    .AppendLine(shippingInfo.Clothes ?? "")
                    .AppendLine(shippingInfo.Defect ?? "")
                    .AppendLine(shippingInfo.Price)
                    .AppendLine("---")
                    .AppendFormat("Скидка: {0}", shippingInfo.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(
                emailSettings.MailFromAddress, // From
                emailSettings.MailToAddress, // To
                "Готово!", // Subject
                body.ToString()); // Body
                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);
            }
        }
    }
}