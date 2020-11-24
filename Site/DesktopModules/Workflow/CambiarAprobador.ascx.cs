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

using WS;

namespace Workflow
{
    public partial class CambiarAprobador : System.Web.UI.UserControl
    {
        //protected System.Web.UI.WebControls.Label lblTitulo;
        //protected System.Web.UI.WebControls.Button btnDefault;
        //protected System.Web.UI.WebControls.Label lblModulo;
        //protected System.Web.UI.WebControls.DropDownList ddlModulo;
        //protected System.Web.UI.WebControls.Label lblWorkflow;
        //protected System.Web.UI.WebControls.DropDownList ddlWorkFlow;
        //protected System.Web.UI.WebControls.Label lblEmpleado;
        //protected System.Web.UI.WebControls.ImageButton ibtnConsultar;
        //protected System.Web.UI.WebControls.DataGrid dgdWorkflow;
        //protected System.Web.UI.WebControls.Button btnReversar;
        //protected System.Web.UI.WebControls.ValidationSummary vsmSolicitudFactura;
        //protected System.Web.UI.WebControls.ImageButton ibtnBuscarEmpleado;
        //protected System.Web.UI.WebControls.TextBox txtCodigoEmpleado;
        //protected System.Web.UI.WebControls.TextBox txtEmpleado;
        //protected System.Web.UI.WebControls.RequiredFieldValidator rfvModulo;
        //protected System.Web.UI.WebControls.RequiredFieldValidator rfvWF;
        //protected System.Web.UI.WebControls.RequiredFieldValidator rfvAprobador;
        //protected System.Web.UI.WebControls.TextBox txtCategoriaOrigen;
        //protected System.Web.UI.WebControls.Panel pnlDestino;
        //protected System.Web.UI.WebControls.Label lblTraspasar;
        //protected System.Web.UI.WebControls.TextBox txtCategoriaD;
        //protected System.Web.UI.WebControls.ImageButton ibtnBuscarDestino;
        //protected System.Web.UI.WebControls.TextBox txtEmpleadoD;
        //protected System.Web.UI.WebControls.TextBox txtCodigoEmpleadoD;
        //protected JLovell.WebControls.StaticPostBackPosition StaticPostBackPosition1;
        //protected System.Web.UI.WebControls.Label lblEmpleadoD;
        //protected System.Web.UI.WebControls.Label lblCategoriaD;
        //protected System.Web.UI.WebControls.Label lblCantidad;
        //protected System.Web.UI.WebControls.Label lblError;

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
        private int intCantidadRegistros
        {
            get { return (int)ViewState["intCantidadRegistros001A"]; }
            set { ViewState["intCantidadRegistros001A"] = value; }
        }
        private string strRolAsociado
        {
            get { return (string)ViewState["strRolAsociado"]; }
            set { ViewState["strRolAsociado"] = value; }
        }
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if (!Page.IsPostBack)
            {
                ESUsuario Empleado = new ESUsuario();
                Empleado.ObtenerUsuario((int)Session["IDUsuario"]);
                intIDEmpleado = Empleado.intCodStaff;
                strRolAsociado = "0";
                if (ESSeguridad.VerificarAcceso(intIDEmpleado, "ESWFP004A", 0))
                {
                    CargarAyuda();
                    CargarModulos();
                    ibtnBuscarEmpleado.Attributes.Add("OnClick", "javascript: AbrirBusquedaEmpleadoCategoria(document.Form1.txtCodigoEmpleado, document.Form1.txtEmpleado,document.Form1.txtCategoriaOrigen,'', '1', '0','0'" + "); return false;");
                    ibtnBuscarDestino.Attributes.Add("OnClick", "javascript: AbrirBusquedaEmpleadoCategoria(document.Form1.txtCodigoEmpleado, document.Form1.txtEmpleado,document.Form1.txtCategoriaD,'', '0', '0'" + "," + strRolAsociado + "); return false;");
                    //					btnReversar.Attributes.Add("OnClick","javascript: VerificarSeleccion(document.Form1.dgdWorkflow); return false;");
                    btnReversar.Attributes.Add("onclick", "return (VerificarSeleccion());");
                    CargarInicial();


                }
                else
                {
                    ESError Error = new ESError();
                    Error.strTitulo = "Error general";
                    Error.strDescripcion = "Ha ocurrido un error en el sistema. Por favor comuníquese con el administrador del sistema.";
                    Error.strDetalle = "Acceso denegado";
                    Session["Error"] = Error;
                    ESLog.Log(intIDEmpleado, Convert.ToString(Session["Host"]), ESLog.TipoLog.Error, ESLog.TipoTransaccion.Desconocida, "ESWFP004A", 10, "", "Acceso denegado");
                    Response.Redirect("../Principal/Error.aspx");
                }
            }
        }
        private void TotalizarItems(int intCount)
        {
            intCantidadRegistros = intCount;
            if (intCount == 1)
                lblCantidad.Text = intCount.ToString() + " Solicitud de aprobación";
            else
                lblCantidad.Text = intCount.ToString() + " Solicitudes de aprobación";
        }
        private void CargarAyuda()
        {
            arrAyuda = new ArrayList();
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1523));	//Referencia del documento
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1522));	//Numero de solicitud WF
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1027));	//Fecha de Creación
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1648));	//WorkFlow 
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1525));	//Nombre del solicitante
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1527));	//Nombre  aprobador actual
            arrAyuda.Add(ESAyuda.ObtenerAyudaCampo(1652));	//Seleccionar
            lblEmpleado.ToolTip = ESAyuda.ObtenerAyudaCampo(511);//Aprobador
            lblModulo.ToolTip = ESAyuda.ObtenerAyudaCampo(1519); //módulo
            lblWorkflow.ToolTip = ESAyuda.ObtenerAyudaCampo(1520);// workflow
            btnReversar.ToolTip = ESAyuda.ObtenerAyudaCampo(1649); // Cambiar aprobador
            ibtnBuscarEmpleado.ToolTip = ESAyuda.ObtenerAyudaCampo(1650); // Buscar aprobador(*)
            ibtnBuscarDestino.ToolTip = ESAyuda.ObtenerAyudaCampo(1651); // Buscar aprobador(*)
            lblEmpleadoD.ToolTip = ESAyuda.ObtenerAyudaCampo(1527); // Buscar aprobador(*)
            lblCategoriaD.ToolTip = ESAyuda.ObtenerAyudaCampo(34); // Buscar aprobador(*)
            ibtnConsultar.ToolTip = ESAyuda.ObtenerAyudaCampo(1653);

        }
        private void CargarModulos()
        {
            ArrayList arrModulos = new ArrayList();
            arrModulos = WFModulo.ListarModulos();
            //			arrModulos.RemoveAt(0);
            //			WFModulo objInicial = new WFModulo(0,"Todos");
            //			arrModulos.Insert(0,objInicial);
            ddlModulo.DataSource = arrModulos;
            ddlModulo.DataValueField = "intCodModulo";
            ddlModulo.DataTextField = "strNbrModulo";
            ddlModulo.DataBind();
            CargarWFInicial();
        }
        private void CargarWFInicial()
        {
            ArrayList arrWF = new ArrayList();
            WFWorkflow objInicial = new WFWorkflow(0, 0, "[Seleccione]", "");
            arrWF.Insert(0, objInicial);
            ddlWorkFlow.DataSource = arrWF;
            ddlWorkFlow.DataValueField = "Id";
            ddlWorkFlow.DataTextField = "Name";
            ddlWorkFlow.DataBind();
        }
        private void CargarWF()
        {
            if (Convert.ToInt32(ddlModulo.SelectedValue) > 0)
            {
                ArrayList arrWF = new ArrayList();
                arrWF = WFWorkflow.ListarWorkflows(Convert.ToInt32(ddlModulo.SelectedValue));
                //				arrWF.RemoveAt(0);
                //				WFWorkflow objInicial = new WFWorkflow(0,0,"Todos","");
                //				arrWF.Insert(0,objInicial);
                ddlWorkFlow.DataSource = arrWF;
                ddlWorkFlow.DataValueField = "Id";
                ddlWorkFlow.DataTextField = "Name";
                ddlWorkFlow.DataBind();
            }
            else
            {
                CargarWFInicial();
                CargarInicial();
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
        private void Cargar()
        {
            int intCodAprobador = 0;
            if (txtCodigoEmpleado.Text.Length > 0)
                intCodAprobador = Convert.ToInt32(txtCodigoEmpleado.Text);
            ArrayList arrSolicitudes = new ArrayList();
            if (arrSolicitudes.Count > 0)
                pnlDestino.Visible = false;
            else
                pnlDestino.Visible = true;
            btnReversar.Visible = pnlDestino.Visible;
            int intRolAsocI;
            arrSolicitudes = WFSolicitudWF.ListarWorkflowPorAprobador(Convert.ToInt32(ddlModulo.SelectedValue), Convert.ToInt32(ddlWorkFlow.SelectedValue), intCodAprobador, out intRolAsocI);
            strRolAsociado = Convert.ToString(intRolAsocI);
            dgdWorkflow.DataSource = arrSolicitudes;
            dgdWorkflow.DataBind();
            TotalizarItems(arrSolicitudes.Count);
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
            this.btnReversar.Click += new System.EventHandler(this.btnReversar_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void ddlModulo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlModulo.SelectedIndex > 0)
            {
                CargarWF();
                CargarInicial();
            }
            else
            {
                CargarWFInicial();
                CargarInicial();
                pnlDestino.Visible = false;
                btnReversar.Visible = false;
            }
        }

        private void ibtnConsultar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {

                System.Web.UI.WebControls.DataGridPageChangedEventArgs primera = new DataGridPageChangedEventArgs("", 0);
                dgdWorkflow_PageIndexChanged(this, primera);

                ibtnBuscarDestino.Attributes.Add("OnClick", "javascript: AbrirBusquedaEmpleadoCategoria(document.Form1.txtCodigoEmpleadoD, document.Form1.txtEmpleadoD,document.Form1.txtCategoriaD,encodeURI(document.Form1.txtCategoriaOrigen.value), '0', '0'" + "," + strRolAsociado + "); return false;");
                btnReversar.Attributes.Add("onclick", "return (VerificarSeleccion());");
            }
        }

        private void dgdWorkflow_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgdWorkflow.EditItemIndex = -1;
            dgdWorkflow.CurrentPageIndex = e.NewPageIndex;
            Cargar();
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
            else if (e.Item.ItemType == ListItemType.Header)
            {
                ((Label)e.Item.FindControl("lblReferenciaTtiulo")).ToolTip = arrAyuda[0].ToString();
                ((Label)e.Item.FindControl("lblSolicitudTitulo")).ToolTip = arrAyuda[1].ToString();
                ((Label)e.Item.FindControl("lblCreacionTtiulo")).ToolTip = arrAyuda[2].ToString();
                ((Label)e.Item.FindControl("lblWFTitulo")).ToolTip = arrAyuda[3].ToString();
                ((Label)e.Item.FindControl("lblSolicitanteTitulo")).ToolTip = arrAyuda[4].ToString();
                ((Label)e.Item.FindControl("lblAprobadorTitulo")).ToolTip = arrAyuda[5].ToString();
                ((CheckBox)e.Item.FindControl("chkSeleccioneTitulo")).ToolTip = arrAyuda[6].ToString();
            }
        }
        private void btnReversar_Click(object sender, System.EventArgs e)
        {
            ArrayList arrWorkFlow = new ArrayList();
            for (int intI = 0; intI < dgdWorkflow.Items.Count; intI++)
            {
                if (((CheckBox)dgdWorkflow.Items[intI].FindControl("chkSeleccione")).Checked)
                {
                    WFSolicitudWF objNuevo = new WFSolicitudWF();
                    objNuevo.shtWorkFlow = Convert.ToInt16(((Label)dgdWorkflow.Items[intI].FindControl("lblCodWF")).Text);
                    objNuevo.strReferencia = Convert.ToString(((Label)dgdWorkflow.Items[intI].FindControl("lblReferencia")).Text);
                    objNuevo.strSolicitante = Convert.ToString(((Label)dgdWorkflow.Items[intI].FindControl("lblNumSolicitud")).Text);
                    objNuevo.intCodUltimoAprobador = Convert.ToInt32(txtCodigoEmpleado.Text);
                    objNuevo.intCodSiguienteAprobador = Convert.ToInt32(txtCodigoEmpleadoD.Text);
                    WFSolicitudWF.ActualizarAprobadorHistorico(objNuevo.shtWorkFlow, objNuevo.strReferencia, objNuevo.strSolicitante, objNuevo.intCodSiguienteAprobador);
                    WFWorkflow.EnviarMensaje(WS.Eventos.CAMBIO_DE_DESTINATARIO, objNuevo.shtWorkFlow, objNuevo.strReferencia, objNuevo.intCodSiguienteAprobador, objNuevo.intCodUltimoAprobador);
                    arrWorkFlow.Add(objNuevo);
                }
            }

            LimpiarDestino();
        }
        private void LimpiarDestino()
        {
            ibtnConsultar_Click(this, null);
            txtCodigoEmpleadoD.Text = string.Empty;
            txtEmpleadoD.Text = string.Empty;
            txtCategoriaD.Text = string.Empty;

        }
    }
}