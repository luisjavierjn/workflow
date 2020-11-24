using System;
using System.Web.Mail;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using MSXML2;

namespace Mensajeria
{
	/// <summary>
	/// Summary description for EmailHelper.
	/// </summary>
	public sealed class EmailHelper
	{
		private EmailHelper() {}

		#region SendEmail

		public static void SendEmail(string smtpServer, string to, string from, string cc, string cco, string subject, string msg, System.Web.Mail.MailFormat format, string[] filesToAttach)
		{
			MailMessage msgMail = new MailMessage();
			msgMail.To = to;
			msgMail.Cc = cc;
			msgMail.Bcc = cco;
			msgMail.From = from;
			msgMail.Subject = subject;
			msgMail.Body = msg;
			msgMail.BodyFormat = format;
			SmtpMail.SmtpServer = smtpServer;

			if(filesToAttach != null)
			{
				string file = string.Empty;

				for(int i=0; i<filesToAttach.Length; i++)
				{
					file = filesToAttach[i] as String;
					msgMail.Attachments.Add(new MailAttachment(file,System.Web.Mail.MailEncoding.Base64));
				}
			}

			try
			{
				SmtpMail.Send(msgMail);				
			}
			catch
			{
				// catch code here
			}
		}

		public static void SendEmail(string smtpServer, string to, string from, string subject, string msg, System.Web.Mail.MailFormat format, string[] filesToAttach)
		{
			SendEmail(smtpServer,to,from,string.Empty,string.Empty,subject,msg,format,filesToAttach);
		}

		public static void SendEmail(string smtpServer, string to, string from, string subject, string msg, System.Web.Mail.MailFormat format)
		{
			SendEmail(smtpServer,to,from,string.Empty,string.Empty,subject,msg,format,null);
		}

		#endregion
		
		#region BuildMessage

		public static string BuildMessage(string formatFile, params object[] parameterValues)
		{
			if (parameterValues == null)
				return null;

			string xmlContent = "<root>";

			for (int i = 0; i < parameterValues.Length; i++)
				xmlContent += "<param" + i + ">" + parameterValues[i].ToString().Trim() + "</param" + i + ">";

			xmlContent += "</root>";
			
			DOMDocument xslDoc = new DOMDocument();
			DOMDocument xmlDoc = new DOMDocument();
			
			xmlDoc.loadXML(xmlContent);
			xslDoc.load(formatFile);
			
			return xmlDoc.transformNode(xslDoc);
		}

		#endregion
	}
}
