using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Service.Helpers
{
 public   class EmailTemplate
    {
        public static bool Gmail(string Sendto, string Subject, string Body)
        {
                
            bool issent = false;
            try
            {
                ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP1);

                service.Credentials = new WebCredentials("bwsshriprakashsingh@gmail.com", "Welcometobws@2022");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string serviceUrl = "https://outlook.office365.com/ews/exchange.asmx";
                service.Url = new Uri(serviceUrl);
                EmailMessage Mail = new EmailMessage(service);

                foreach (string str in Sendto.Split(','))
                {
                    if (str.Trim() != "")
                    {
                        Mail.ToRecipients.Add(str.Trim());
                    }
                }
                Mail.Subject = Subject;
                Mail.Body = new MessageBody(Body);
                Mail.Send();
                issent = true;
            }
            catch (Exception ex)
            {
                issent = false;
                //send_subsource_noreply_email("bwsshivani@gmail.com,bwsakhilesh", "Send_Subsource_helpdesk_Email Error", ex.ToString());
            }
            return issent;
        }
    }
}

