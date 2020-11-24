using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Drawing;
using Componentes.BLL;
using Componentes.BLL.WF;
using Componentes.BLL.SE;

namespace Workflow
{
    public partial class ConsultarRutas : System.Web.UI.UserControl
    {
        //protected System.Web.UI.WebControls.Label lblTitulo;
        //protected System.Web.UI.WebControls.ValidationSummary vsmErrores;
        //protected System.Web.UI.WebControls.Label lblError;
        //protected System.Web.UI.WebControls.Button btnConsultar;
        //protected System.Web.UI.WebControls.Label lblModulo;
        //protected System.Web.UI.WebControls.Label lblTipoDocumento;
        //protected System.Web.UI.WebControls.Label lblWorkFlow;
        //protected System.Web.UI.WebControls.DropDownList ddlModulo;
        //protected System.Web.UI.WebControls.DropDownList ddlTipoDocumento;
        //protected System.Web.UI.WebControls.TextBox txtDescripcion;
        //protected System.Web.UI.WebControls.RequiredFieldValidator rfvTipoDocumento;
        //protected JLovell.WebControls.StaticPostBackPosition StaticPostBackPosition1;

        private int intCodigoEmpleado
        {
            get { return (int)ViewState["intCodigoEmpleado"]; }
            set { ViewState["intCodigoEmpleado"] = (int)value; }
        }
        private int WorkflowId
        {
            get { return (int)ViewState["WorkflowId"]; }
            set { ViewState["WorkflowId"] = (int)value; }
        }

        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if (!IsPostBack)
            {
                // Carga el código de empleado activo en el sistema
                ESUsuario Empleado = new ESUsuario();
                Empleado.ObtenerUsuario((int)Session["IDUsuario"]);
                intCodigoEmpleado = Empleado.intCodStaff;

                if (!ESSeguridad.VerificarAcceso(intCodigoEmpleado, "ESWFP003A", 0))
                {
                    Response.Redirect("../Principal/Error.aspx");
                }

                WorkflowId = -1;
                rfvTipoDocumento.ErrorMessage = ESMensajes.ObtenerMensaje(700);
                CargarModulos();
            }
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            this.ddlModulo.SelectedIndexChanged += new System.EventHandler(this.ddlModulo_SelectedIndexChanged);
            this.ddlTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.ddlTipoDocumento_SelectedIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void CargarModulos()
        {
            ddlModulo.DataSource = WFModulo.ListarModulos();
            ddlModulo.DataValueField = "intCodModulo";
            ddlModulo.DataTextField = "strNbrModulo";
            ddlModulo.DataBind();
        }

        private void ddlModulo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CargarDocumentos();
            txtDescripcion.Text = "";
            WorkflowId = -1;
        }

        private void CargarDocumentos()
        {
            ddlTipoDocumento.DataSource = WFWorkflow.ListarWorkflows(Convert.ToInt32(ddlModulo.SelectedValue));
            ddlTipoDocumento.DataValueField = "Id";
            ddlTipoDocumento.DataTextField = "Name";
            ddlTipoDocumento.DataBind();
        }

        private void ddlTipoDocumento_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            WorkflowId = (ddlTipoDocumento.SelectedValue == "0") ? Convert.ToInt32(-1) : Convert.ToInt32(ddlTipoDocumento.SelectedValue);
            txtDescripcion.Text = ((WFWorkflow)WFWorkflow.ListarWorkflows(Convert.ToInt32(ddlModulo.SelectedValue))[ddlTipoDocumento.SelectedIndex]).Description;
        }

        private bool ActivarValidadores()
        {
            rfvTipoDocumento.Enabled = true;
            rfvTipoDocumento.Validate();

            if (ddlTipoDocumento.Items.Count == 0)
                rfvTipoDocumento.IsValid = false;

            return rfvTipoDocumento.IsValid;
        }

        private void btnConsultar_Click(object sender, System.EventArgs e)
        {
            if (ActivarValidadores())
            {
                Context.Items.Add("intWorkflowId", WorkflowId);
                Context.Items.Add("strNombre", ddlTipoDocumento.Items.FindByValue(ddlTipoDocumento.SelectedValue).Text);
                Context.Items.Add("blnConsultar", true);

                Server.Transfer("../WF/ESWFP001B.aspx", true);
            }
        }

    }// fin de la clase
}// fin del namespace