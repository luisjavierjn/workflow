namespace Workflow.Controles
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Componentes.BLL.WF;
	using Componentes.BLL;
	using Componentes.DAL;
	using System.Configuration;
	using System.Collections;

	/// <summary>
	///		Summary description for DescripcionWorkflow.
	/// </summary>
	public partial class DescripcionWorkflow : System.Web.UI.UserControl, WFIEditarControlWorkflow
	{

		private void Page_Load(object sender, System.EventArgs e)
		{
//			RequiredFieldValidator1.ErrorMessage = ESMensajes.ObtenerMensaje(245);
//			RequiredFieldValidator2.ErrorMessage = ESMensajes.ObtenerMensaje(246);
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ddlNotificacion.SelectedIndexChanged += new System.EventHandler(this.ddlNotificacion_SelectedIndexChanged);
			this.ddlCorreccion.SelectedIndexChanged += new System.EventHandler(this.ddlCorreccion_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

        //protected System.Web.UI.WebControls.TextBox txtIntervAprob;
        //protected System.Web.UI.WebControls.TextBox txtIntervCorrec;
        //protected System.Web.UI.WebControls.TextBox txtNumRecor;

		static WFRegla objRegla;
        //protected System.Web.UI.WebControls.DropDownList ddlNotificacion;
        //protected System.Web.UI.WebControls.DropDownList ddlCorreccion;
        //protected System.Web.UI.WebControls.RequiredFieldValidator rfvAprobacion;
        //protected System.Web.UI.WebControls.RequiredFieldValidator rfvCorreccion;
        //protected System.Web.UI.WebControls.RequiredFieldValidator rfvRocordatorios;
        //protected System.Web.UI.WebControls.RangeValidator rvAprobacion;
        //protected System.Web.UI.WebControls.RangeValidator rvCorreccion;
        //protected System.Web.UI.WebControls.RangeValidator rvRecordatorios;

		//*********************************************************************
		//
		// DescripcionWorkflow.ascx
		//
		// Este control de usuario es usado por ammbos el nuevo wizard control 
		// y la página de actualización del workflow.
		//
		//*********************************************************************

		bool FirstTime
		{
			get 
			{
				if (ViewState["FirstTime"] == null)
					return true;
				else
					return (bool)ViewState["FirstTime"];
			}

			set { ViewState["FirstTime"] = value; }
		}

        private int _WorkflowId = -1;

		public int WorkflowId 
		{
			get { return _WorkflowId; }
			set { _WorkflowId = value; }
		}

        private string _nodeIndex;

        public string NodeIndex
        {
            get { return _nodeIndex; }
            set { _nodeIndex = value; }
        }

		public bool Update() 
		{
			objRegla.intIntervaloAprobacion = Convert.ToInt32(txtIntervAprob.Text);
			objRegla.intIntervaloCorreccion = Convert.ToInt32(txtIntervCorrec.Text);
			objRegla.intNumRecordatorios = Convert.ToInt32(txtNumRecor.Text);

			objRegla.intCodLapsoAprobacion = Convert.ToInt32(ddlNotificacion.SelectedValue);
			objRegla.intCodLapsoCorreccion = Convert.ToInt32(ddlCorreccion.SelectedValue);

			objRegla.ActualizarReglas();
			return true;
		}

		public void Initialize() 
		{
			objRegla = new WFRegla(WorkflowId);
			ArrayList lapsosN = WFLapsoDeTiempo.ListarLapsosDeTiempo();
			ArrayList lapsosC = WFLapsoDeTiempo.ListarLapsosDeTiempo();

			ddlNotificacion.DataSource = lapsosN;
			ddlNotificacion.DataTextField = "strNbrLapsoDeTiempo";
			ddlNotificacion.DataValueField = "intCodLapsoDeTiempo";
			ddlNotificacion.SelectedValue = objRegla.intCodLapsoAprobacion.ToString();
			ddlNotificacion.DataBind();

			ddlCorreccion.DataSource = lapsosC;
			ddlCorreccion.DataTextField = "strNbrLapsoDeTiempo";
			ddlCorreccion.DataValueField = "intCodLapsoDeTiempo";
			ddlCorreccion.SelectedValue = objRegla.intCodLapsoCorreccion.ToString();
			ddlCorreccion.DataBind();

			txtIntervAprob.Text = objRegla.intIntervaloAprobacion.ToString();
			txtIntervCorrec.Text = objRegla.intIntervaloCorreccion.ToString();
			txtNumRecor.Text = objRegla.intNumRecordatorios.ToString();
		}

		private void ddlNotificacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			objRegla.intCodLapsoAprobacion = Convert.ToInt32(((DropDownList)sender).SelectedValue);
		}

		private void ddlCorreccion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			objRegla.intCodLapsoCorreccion = Convert.ToInt32(((DropDownList)sender).SelectedValue); 
		}

	} // Fin de la Clase
} // Fin del Namespace
