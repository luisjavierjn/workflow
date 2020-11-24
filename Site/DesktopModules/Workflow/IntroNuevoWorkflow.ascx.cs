namespace Workflow.Controles
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using Componentes.BLL.WF;

	/// <summary>
	///		Summary description for NewWorkflowIntro.
	/// </summary>
	public partial class IntroNuevoWorkflow : System.Web.UI.UserControl, WFIEditarControlWorkflow
	{
        //protected System.Web.UI.WebControls.CheckBox chkSkip;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		//**********************************************************************
		//
		// IntroNuevoWorkflow.ascx
		//
		// Este control de usuario es usado por la página wizard nuevo workflow.
		//
		//**********************************************************************
    
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
			if (chkSkip.Checked) 
			{
                Response.Cookies[Componentes.Web.Global.SkipWorkflowIntro].Value = "1";
                Response.Cookies[Componentes.Web.Global.SkipWorkflowIntro].Path = "/";
                Response.Cookies[Componentes.Web.Global.SkipWorkflowIntro].Expires = DateTime.MaxValue;
				Response.Redirect("ESWFP001A.aspx");
			}
    
			return true;
		}

		public void Initialize() 
		{
		}

	} // Fin de la Clase
} // Fin del Namespace
