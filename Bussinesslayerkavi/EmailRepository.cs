using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace Bussinesslayerkavi
{
    public interface IEmailRepository
    {
        public void SendEmail(string fromAddress, string password, string toAddress, string body, string Subject);
    }
    public class EmailRepository: IEmailRepository
    {    
        public void SendEmail(string fromAddress, string password,string toAddress,string body,string Subject)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, password)

            };
            Console.WriteLine(fromAddress);
            string subject = "Good Morning";

            try
            {
                Console.WriteLine("sending email ");
                email.Send(fromAddress,toAddress,password ,subject);
                Console.WriteLine("email sent ");
            }
            catch (Exception e)
            {
                throw;
            }

        }
      

        }
    }

