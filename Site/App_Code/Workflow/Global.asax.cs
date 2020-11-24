// Estándar de namespaces
// Principal: namespace ES
// Global: namespace ES.Web
// Controles: namespace ES.Controles
// Lógica de Negocio: namespace Componentes.BLL
// Acceso a Datos: namespace Componentes.DAL
// Módulos: namespace ES.XX donde XX son las iniciales del Módulo. Ejemplo: ES.IG = Informe de gastos
  
using System;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;
using System.Configuration;
using Componentes.BLL.SE;
using System.Diagnostics;
using System.IO;
using System.Text;
using Componentes.BLL;
using System.Web.UI;

namespace Componentes.Web 
{
	/// <summary>
	/// Clase general para la aplicación
	/// </summary>
	
	public class Global : System.Web.HttpApplication
	{
        public const string CfgKeyConnString = "ConnectionString";
		public const string CfgKeyConfig = "DCF";
		public const string CfgKeyPath = "FCF";
		public const string CfgKeyFirstDayOfWeek = "FirstDayOfWeek";
		public const string CfgKeySmtpServer = "smtpServer";

		// Constants used to reference data stored in cookies
		public const string SkipWorkflowIntro = "skipprojectintro";
		public const string LogName = "WORKFLOW";
		public const string strSimboloMoneda = "Bs.F.";
		public const short shtAniosFiscalesAtras = 3;

		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			try
			{
				Thread.CurrentThread.CurrentCulture = new CultureInfo("es-VE");
				Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ",";
				Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ".";
				Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ",";
				Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ".";
				Thread.CurrentThread.CurrentCulture.NumberFormat.PercentDecimalSeparator = ",";
				Thread.CurrentThread.CurrentCulture.NumberFormat.PercentGroupSeparator = ".";
				Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
			}
			catch
			{
				Thread.CurrentThread.CurrentCulture = new CultureInfo("es-VE");
			}
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{
			ESError Error = new ESError();
			Error.strTitulo = "Error";
			Error.strDescripcion = "Ha ocurrido un error en el sistema.";
			Error.strDetalle = Server.GetLastError().ToString();

			Session["Error"] = Error;

			ESLog.Log(Convert.ToInt32(Session["IDUsuario"]),Convert.ToString(Session["Host"]),ESLog.TipoLog.Error,ESLog.TipoTransaccion.Desconocida,"",8,"",Server.GetLastError().ToString());
		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion

        public static Control FindMyControl(Control ctrl, string controlID)
        {
            Control Ret = null;

            foreach (Control Ctrl in ctrl.Controls)
            {
                if (Ctrl.ID != null && Ctrl.ID.ToLower() == controlID.ToLower())
                {
                    Ret = Ctrl;
                    break;
                }
                else
                {
                    Ret = FindMyControl(Ctrl, controlID);
                    if (Ret != null)
                    {
                        break;
                    }
                }
            }
            return Ret;
        }

        public static System.Web.UI.WebControls.TreeNode GetNodeFromPath(System.Web.UI.WebControls.TreeNodeCollection tree, string path)
        {
            System.Web.UI.WebControls.TreeNode retval = null;

            string[] nodes = path.Split('/');
            for (int i = 0; i < nodes.Length; i++)
                for (int j = 0; j < tree.Count; j++)
                    if (tree[j].Value == nodes[i])
                    {
                        if (i == nodes.Length - 1)
                            retval = tree[j];
                        else
                            tree = tree[j].ChildNodes;
                        break;
                    }

            return retval;
        }
	}
}

