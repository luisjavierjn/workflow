using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Componentes.BLL.WF;
using Componentes.BLL;
using Componentes.Web;

namespace Workflow.Controles
{
	/// <summary>
	///		Summary description for DocumentoWorkflow.
	/// </summary>
	public partial class DocumentoWorkflow : System.Web.UI.UserControl, WFIEditarControlWorkflow
	{
        //protected System.Web.UI.WebControls.DropDownList ddlModulo;
        //protected System.Web.UI.WebControls.DropDownList ddlDocumento;
        //protected System.Web.UI.WebControls.TextBox txtDescription;
        //protected System.Web.UI.WebControls.Label Label1;
        //protected System.Web.UI.WebControls.Label Label2;
        //protected System.Web.UI.WebControls.Label Label3;
		private static ArrayList arrModulos;

		private void Page_Load(object sender, System.EventArgs e)
		{
//			ESMensajes.ObtenerMensaje(245);
//			ESMensajes.ObtenerMensaje(246);
//			ESMensajes.ObtenerMensaje(254);
		}

		//#region Web Form Designer generated code
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
            //this.ddlDocumento.SelectedIndexChanged += new System.EventHandler(this.ddlDocumento_SelectedIndexChanged);
            //this.ddlModulo.SelectedIndexChanged += new System.EventHandler(this.ddlModulo_SelectedIndexChanged);			
			//this.Load += new System.EventHandler(this.Page_Load);

		}
		//#endregion

		int Modulo
		{
			get 
			{
				if (ViewState["Modulo"] == null)
					return 0;
				else
					return (int)ViewState["Modulo"];
			}

			set { ViewState["Modulo"] = value; }
		}

		int Documento
		{
			get 
			{
				if (ViewState["Documento"] == null)
					return 0;
				else
					return (int)ViewState["Documento"];
			}

			set { ViewState["Documento"] = value; }
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
			if(WorkflowId == -1)
			{
                Label lblError = (Label)Global.FindMyControl(Page, "lblError");
				lblError.Visible = true;
				lblError.Text = ESMensajes.ObtenerMensaje(253);
				return false;
			}

            //Label lblNombre = (Label)Page.FindControl("lblNombre");
            //lblNombre.Text = "'" + ddlDocumento.SelectedItem.Text + "'";

			return true;
		}

		public void Initialize() 
		{
			//Label lblNombre = (Label)Page.FindControl("lblNombre");
			//lblNombre.Text = "";
            System.Web.UI.WebControls.TreeView wft = (System.Web.UI.WebControls.TreeView)Componentes.Web.Global.FindMyControl(Page, "wfTreeView");
            wft.Visible = false;

			ddlModulo.SelectedIndex = Modulo;
			ddlDocumento.SelectedIndex = Documento;
			CargarModulos();
			CargarDocumentos();
		}

		protected void ddlModulo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Modulo = ddlModulo.SelectedIndex;
			Documento = 0;
			CargarModulos();
			CargarDocumentos();
		}

		private void CargarModulos()
		{
			ddlModulo.DataSource = arrModulos = WFModulo.ListarModulos();
			ddlModulo.DataValueField = "intCodModulo";
			ddlModulo.DataTextField = "strNbrModulo";
			ddlModulo.DataBind();
			ddlModulo.SelectedIndex = Modulo;
		}

        protected void ddlDocumento_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            //Documento = ddlDocumento.SelectedIndex;
            Documento = Convert.ToInt32(hfDocumento.Value);
			CargarDocumentos();
		}

		private void CargarDocumentos()
		{
			int intCodModulo = ((WFModulo)arrModulos[Modulo]).intCodModulo;
			ddlDocumento.DataSource = WFWorkflow.ListarWorkflows(intCodModulo);
			ddlDocumento.DataValueField = "Id";
			ddlDocumento.DataTextField = "Name";
			ddlDocumento.DataBind();

			int Id = ((WFWorkflow)WFWorkflow.ListarWorkflows(intCodModulo)[Documento]).Id;
			WorkflowId = Id == 0 ? -1 : Id;
			txtDescription.Text = ((WFWorkflow)WFWorkflow.ListarWorkflows(intCodModulo)[Documento]).Description;
			ddlDocumento.SelectedIndex = Documento;

            //if(Documento != 0)
            //{
            //    Label lblError = (Label)Page.FindControl("lblError");
            //    lblError.Visible = false;
            //}
		}

	} // Fin de la Clase
} // Fin del Namespace
