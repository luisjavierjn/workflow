using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using Mensajeria;

namespace WS
{
	/// <summary>
	/// Esta clase capta todos los mensajes del Workflow, llevándolos a una
	/// cola llamada Alpha que es revisada constantemmente por un Servicio de Windows
	/// </summary>
	[WebService(Namespace="http://localhost/workflow/WS/",
	Description="This is the Workflow WebService.")]
	public class Workflow : System.Web.Services.WebService
	{
		/// <summary>
		/// Inicializa la cola de mensajes
		/// </summary>
		public Workflow()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		private System.Messaging.MessageQueue msgQueue;

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.msgQueue = new System.Messaging.MessageQueue();
			// 
			// msgQueue
			// 
			this.msgQueue.Path = "FormatName:DIRECT=OS:localhost\\private$\\alpha";

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

//		[WebMethod]
//		public string HelloWorld()
//		{
//			return "Hello World";
//		}

		/// <summary>
		/// Encapsula el evento con sus parámetros insertándolos en una cola de mensajes
		/// </summary>
		/// <param name="evt">Evento manual que se genera del lado del cliente</param>
		/// <param name="xmlParams">Parámetros del evento estructurados como un texto XML</param>
		[WebMethod(MessageName="EnviarMensajeXml", 
			Description="Envia un msg con los parámetros en un xml")]
		public bool EnviarMensaje(Eventos evt, string xmlParams)
		{
			bool retVal = false;

			System.Messaging.Message msg = new System.Messaging.Message();
			msg.Body = new objMensaje(evt,xmlParams);

			try
			{
				msgQueue.Send(msg);
				retVal = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + " " + ex.InnerException.Message);
			}

			return retVal;
		}
	} // fin de la clase
} // fin del namespace
