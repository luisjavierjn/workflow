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

using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using Componentes.BLL;
//using Componentes.BLL.FA;
using Componentes.BLL.SE;
using Componentes.BLL.WF;
using System.IO;
using Mensajeria;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
using System.Drawing.Printing;
using System.Threading;

namespace Workflow
{
    public partial class ReversoAprobacion : System.Web.UI.UserControl
    {
        //protected System.Web.UI.WebControls.Label lblTitulo;
        //protected System.Web.UI.WebControls.Button btnDefault;
        //protected System.Web.UI.WebControls.Label lblModulo;
        //protected System.Web.UI.WebControls.Label lblWorkflow;
        //protected System.Web.UI.WebControls.ValidationSummary vsmSolicitudFactura;
        //protected System.Web.UI.WebControls.Label lblError;
        //protected System.Web.UI.WebControls.DropDownList ddlModulo;
        //protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
        //protected System.Web.UI.WebControls.DataGrid dgdWorkflow;
        //protected System.Web.UI.WebControls.Button btnReversar;
        //protected System.Web.UI.WebControls.Label lblEmpleado;
        //protected System.Web.UI.WebControls.TextBox txtEmpleado;
        //protected System.Web.UI.WebControls.Label lblCantidad;
        //protected System.Web.UI.WebControls.DropDownList ddlWorkFlow;

        private int intIDEmpleado
        {
            get { return (int)ViewState["intIDEmpleado"]; }
            set { ViewState["intIDEmpleado"] = value; }
        }
        
        private ArrayList arrAyuda
        {
            get { return (ArrayList)ViewState["arrAyuda"]; }
            set { ViewState["arrAyuda"] = (ArrayList)value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ESUsuario Empleado = new ESUsuario();
                Empleado.ObtenerUsuario((int)Session["IDUsuario"]);
                intIDEmpleado = Empleado.intCodStaff;
                if (ESSeguridad.VerificarAcceso(intIDEmpleado, "ESWFP002A", 0))
                {
                    if (!(ESSeguridad.VerificarAcceso(intIDEmpleado, "ESWFP002A", 1)))
                    {
                        btnReversar.Visible = false;
                        dgdWorkflow.Columns[10].Visible = false;
                        lblTitulo.Text = "Workflow > Consulta de aprobaciones pendientes";
                    }
                    else
                    {
                        btnReversar.Visible = true;
                        dgdWorkflow.Columns[10].Visible = true;
                        lblTitulo.Text = "Workflow > Reverso de aprobación";
                    }
                    CargarAyuda();
                    CargarModulos();
                    CargarInicial();

                }
                else
                {
                    ESError Error = new ESError();
                    Error.strTitulo = "Error general";
                    Error.strDescripcion = "Ha ocurrido un error en el sistema. Por favor comuníquese con el administrador del sistema.";
                    Error.strDetalle = "Acceso denegado";
                    Session["Error"] = Error;
                    ESLog.Log(intIDEmpleado, Convert.ToString(Session["Host"]), ESLog.TipoLog.Error, ESLog.TipoTransaccion.Desconocida, "ESWFP002A", 10, "", "Acceso denegado");
                    Response.Redirect("../Principal/Error.aspx");
                }
            }
        }

        private void CargarAyuda()
        {
            arrAyuda = new ArrayList();
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1522));	//Numero de solicitud WF
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1523));	//Referencia del documento
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1524));	//Código del solicitante
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1525));	//Nombre del solicitante
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1526));	//Nombre del ulimo aprobador
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1527));	//Nombre del siguiente aprobador
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1528));	//Estatus
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1529));	//Seleccionar
            lblEmpleado.ToolTip = ESAyuda.ObtenerAyudaCampo(1521);
            lblModulo.ToolTip = ESAyuda.ObtenerAyudaCampo(1519);
            lblWorkflow.ToolTip = ESAyuda.ObtenerAyudaCampo(1520);
            btnReversar.ToolTip = ESAyuda.ObtenerAyudaCampo(1530);
        }

        private void CargarModulos()
        {
            ddlModulo.DataSource = WFModulo.ListarModulos();
            ddlModulo.DataValueField = "intCodModulo";
            ddlModulo.DataTextField = "strNbrModulo";
            ddlModulo.DataBind();
        }

        private void CargarWorkFlow()
        {
            if (Convert.ToInt32(ddlModulo.SelectedValue) > 0)
            {
                ddlWorkFlow.DataSource = WFWorkflow.ListarWorkflows(Convert.ToInt32(ddlModulo.SelectedValue));
                ddlWorkFlow.DataValueField = "Id";
                ddlWorkFlow.DataTextField = "Name";
                ddlWorkFlow.DataBind();
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
            this.ddlModulo.SelectedIndexChanged += new System.EventHandler(this.ddlModulo_SelectedIndexChanged);
            this.ibtnConsultar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnConsultar_Click);
            this.dgdWorkflow.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdWorkflow_ItemCreated);
            this.dgdWorkflow.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdWorkflow_PageIndexChanged);
            this.dgdWorkflow.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdWorkflow_ItemDataBound);
            this.btnReversar.Click += new System.EventHandler(this.btnReversar_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void ddlModulo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CargarWorkFlow();
            System.Web.UI.WebControls.DataGridPageChangedEventArgs primera = new DataGridPageChangedEventArgs("", 0);
            dgdWorkflow_PageIndexChanged(this, primera);
            //            CargarInicial();
        }
        private void Cargar()
        {
            string strSolicitante = string.Empty;
            strSolicitante = txtEmpleado.Text;
            strSolicitante = strSolicitante.TrimEnd();
            ArrayList arrSolicitudes = new ArrayList();
            arrSolicitudes = WFSolicitudWF.ListarWorkflow(Convert.ToInt32(ddlModulo.SelectedValue), Convert.ToInt32(ddlWorkFlow.SelectedValue), strSolicitante);
            dgdWorkflow.DataSource = arrSolicitudes;
            dgdWorkflow.DataBind();

            lblCantidad.Text = "0 Documentos pendientes";
            btnReversar.Visible = false;
            if (arrSolicitudes.Count > 0)
            {
                btnReversar.Visible = true;
                lblCantidad.Text = arrSolicitudes.Count + " Documento pendiente";

                if (arrSolicitudes.Count > 1)
                    lblCantidad.Text = arrSolicitudes.Count + " Documentos pendientes";
            }

        }
        private void CargarInicial()
        {
            ArrayList arrSolicitudes = new ArrayList();
            WFSolicitudWF WFSolicitud = new WFSolicitudWF();
            arrSolicitudes.Add(WFSolicitud);
            arrSolicitudes.RemoveAt(0);
            dgdWorkflow.DataSource = arrSolicitudes;
            dgdWorkflow.DataBind();
        }
        private void ibtnConsultar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            System.Web.UI.WebControls.DataGridPageChangedEventArgs primera = new DataGridPageChangedEventArgs("", 0);
            dgdWorkflow_PageIndexChanged(this, primera);
        }

        private void dgdWorkflow_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                ((CheckBox)e.Item.FindControl("chkSeleccioneTitulo")).Attributes.Add("onclick", "javascript: SombrearTodos(this);");
            }
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ((CheckBox)e.Item.FindControl("chkSeleccione")).Attributes.Add("onclick", "javascript: SombrearItem(this);");
                if (e.Item.ItemType == ListItemType.Item)
                    e.Item.Attributes.Add("Color", "#" + dgdWorkflow.ItemStyle.BackColor.Name.Substring(2, 6));
                else
                    e.Item.Attributes.Add("Color", "#" + dgdWorkflow.AlternatingItemStyle.BackColor.Name.Substring(2, 6));

            }
            if (e.Item.ItemType == ListItemType.Pager)
            {
                TableCell tdCelda = e.Item.Cells[0];
                Label lblPagina = new Label();
                lblPagina.Width = 40;
                lblPagina.CssClass = "EtiquetaNormal";
                lblPagina.Text = "Página";
                tdCelda.Controls.AddAt(0, lblPagina);
            }
            if (e.Item.ItemType == ListItemType.Header)
            {
                ((Label)e.Item.FindControl("lblSolicitudTitulo")).ToolTip = arrAyuda[0].ToString();
                ((Label)e.Item.FindControl("lblReferenciaTtiulo")).ToolTip = arrAyuda[1].ToString();
                ((Label)e.Item.FindControl("lblCodigoTitulo")).ToolTip = arrAyuda[2].ToString();
                ((Label)e.Item.FindControl("lblSolicitanteTitulo")).ToolTip = arrAyuda[3].ToString();
                ((Label)e.Item.FindControl("lblUltimoTitulo")).ToolTip = arrAyuda[4].ToString();
                ((Label)e.Item.FindControl("lblSiguienteTitulo")).ToolTip = arrAyuda[5].ToString();
                ((Label)e.Item.FindControl("lblEstatusTitulo")).ToolTip = arrAyuda[6].ToString();
                ((CheckBox)e.Item.FindControl("chkSeleccioneTitulo")).ToolTip = arrAyuda[7].ToString();
            }
        }

        private void dgdWorkflow_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgdWorkflow.EditItemIndex = -1;
            dgdWorkflow.CurrentPageIndex = e.NewPageIndex;
            Cargar();
        }

        private bool ReversarWorkFlow(int intCodWorkFlow, string strReferencia, string strSolicitud)
        {
            return WFSolicitudWF.ReversarWorkFlow(intCodWorkFlow, strReferencia, strSolicitud);
        }
        public void EnviarEmail(int intCodSolicitante, string strReferencia, string strSolicitud)
        {
            string strNbrFormato = string.Empty;
            string strBody = string.Empty;
            string stremailTo = string.Empty;
            ESEmpleado Empleado = new ESEmpleado();
            Empleado.BuscarEmpleado(intCodSolicitante);
            try
            {
                if ((stremailTo.Length != 0))
                {
                    strNbrFormato = Server.MapPath(@"..\FA\ESFAF001A.xsl");
                    strBody = EmailHelper.BuildMessage(strNbrFormato, "Solicitud de aprobación", "fue reversada", "Número de solicitud de workflow:" + strSolicitud, "Número de documento: " + strReferencia, string.Empty, string.Empty, string.Empty);
                    EmailHelper.SendEmail(ConfigurationSettings.AppSettings[Componentes.Web.Global.CfgKeySmtpServer], Empleado.strEmail, "SISTEMA_SPIN@soacat-ve", "Reverso de Solicitud de aprobación", strBody, System.Web.Mail.MailFormat.Html);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message + " " + e.InnerException);
            }
        }
        private void btnReversar_Click(object sender, System.EventArgs e)
        {
            int intCodWorkFlow = 0;
            int intFila = 0;
            string strReferencia = string.Empty;
            string strSolicitud = string.Empty;
            CheckBox chkCb = new CheckBox();
            intCodWorkFlow = Convert.ToInt32(ddlWorkFlow.SelectedValue);
            lblError.Visible = false;
            lblError.Text = string.Empty;

            foreach (DataGridItem dgi in this.dgdWorkflow.Items)
            {
                chkCb = (CheckBox)dgi.Cells[10].Controls[1];
                if (chkCb.Checked)
                {
                    strReferencia = ((Label)(dgdWorkflow.Items[intFila].FindControl("lblReferencia"))).Text;
                    strSolicitud = ((Label)(dgdWorkflow.Items[intFila].FindControl("lblNumSolicitud"))).Text;
                    if (!ReversarWorkFlow(intCodWorkFlow, strReferencia, strSolicitud))
                    {
                        lblError.Visible = true;
                        lblError.Text = "Ha ocurrido un error al intentar reversar la aprobación del documento. Por favor intente nuevamente o comuiquese con el administrador";
                        return;
                    }
                    else
                    {
                        EnviarEmail(Convert.ToInt32(((Label)(dgdWorkflow.Items[intFila].FindControl("lblCodigo"))).Text), strReferencia, strSolicitud);
                    }
                }
                intFila++;
            }
            ibtnConsultar_Click(this, null);
        }

        private void dgdWorkflow_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            switch ((int)(e.Item.ItemType))
            {
                case (int)ListItemType.Header:
                    break;
                case (int)ListItemType.Item:
                case (int)ListItemType.AlternatingItem:
                    if (((Label)e.Item.FindControl("lblUltimo")).Text == "---")
                    {
                        ((Label)e.Item.FindControl("lblItemFechaAprobacion")).Visible = false;
                        ((Label)e.Item.FindControl("lblItemAprobacionNada")).Visible = true;
                    }
                    break;
                case (int)ListItemType.Footer:
                    break;
            }
        }

    }// fin de la clase
}// fin del namespace