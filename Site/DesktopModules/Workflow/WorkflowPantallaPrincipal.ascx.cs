using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Users;
using System.Xml;
using Componentes.Web;
using Componentes.DAL;
using Componentes.BLL.SE;
using Componentes.BLL.WF;
using Componentes.BLL;
using System.Collections;

namespace Workflow
{
    public partial class WorkflowPantallaPrincipal : PortalModuleBase, WFIEditarStatusWF
    {
        UserInfo _usuarioLogueado;
        List<string> _wizardSteps = new List<string>();

        public int CtrlIndex
        {
            get
            {
                if (hfDataKey.Value == String.Empty)
                    return 0;
                else
                    return Convert.ToInt32(hfDataKey.Value);
            }
            set { hfDataKey.Value = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hfIdUser.Value = "0";
            switch (UserInfo.UserID)
            {
                case 3:
                    hfIdUser.Value = "2181";
                    break;
                case 4:
                    hfIdUser.Value = "2180";
                    break;
                case 5:
                    hfIdUser.Value = "2179";
                    break;
                case 6:
                    hfIdUser.Value = "2178";
                    break;
                case 7:
                    hfIdUser.Value = "2177";
                    break;
                case 8:
                    hfIdUser.Value = "2176";
                    break;
            }

            if (!IsPostBack) hfSource.Value = "0";

            if (DotNetNuke.Framework.AJAX.IsInstalled())
                DotNetNuke.Framework.AJAX.RegisterScriptManager();            

            if (_wizardSteps.Count == 0)
            {
                _wizardSteps.Add("DesktopModules/Workflow/GridPantallaPrincipal.ascx");
                _wizardSteps.Add("DesktopModules/Workflow/OperacionExitosa.ascx");
                _wizardSteps.Add("DesktopModules/Workflow/ControlDePagos.ascx");
                _wizardSteps.Add("DesktopModules/Workflow/PantallaPedidos.ascx");
                _wizardSteps.Add("DesktopModules/Workflow/SublimacionPedidos.ascx");
            }

            LkBtnBE.Font.Bold = false;
            LkBtnAprobado.Font.Bold = false;
            LkBtnCancelados.Font.Bold = false;
            LkBtncorregir.Font.Bold = false;
            LkBtnPausados.Font.Bold = false;
            LkBtnPendiente.Font.Bold = false;
            LkBtnRechazado.Font.Bold = false;

            LoadWizardStep();
            _usuarioLogueado = DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo();
        }

        public void LoadWizardStep()
        {
            Control ctlWizardStep = Page.LoadControl(_wizardSteps[CtrlIndex]);
            ctlWizardStep.ID = ctlWizardStep.ToString();
            PlaceholderWF.Controls.Clear();
            PlaceholderWF.Controls.Add(ctlWizardStep);

            bool isNext = false;
            int refId = hfRefId.Value == String.Empty ? 0 : Convert.ToInt32(hfRefId.Value);
            if (CtrlIndex != 1) // 1 es OperacionExitosa
                isNext = ((WFIEditarFormsWorkflow)ctlWizardStep).Initialize(this, refId, Convert.ToInt32(hfIdUser.Value));

            LkBtnBE.Font.Bold = false;
            LkBtnAprobado.Font.Bold = false;
            LkBtnCancelados.Font.Bold = false;
            LkBtncorregir.Font.Bold = false;
            LkBtnPausados.Font.Bold = false;
            LkBtnPendiente.Font.Bold = false;
            LkBtnRechazado.Font.Bold = false;

            if (hfSource.Value == "0") // GridPantallaPrincipal u OperacionExitosa
            {
                BtnEnviar.Visible = false;
                BtnAprobar.Visible = false;
                BtnRechazar.Visible = false;
                BtnCancelar.Visible = false;
                BtnSalvar.Visible = false;

                LkBtnBE.Font.Bold = true;
            }
            else if (hfSource.Value == "1") // 1 es formulario desde GridPantallaPrincipal contiene información
            {
                BtnAprobar.Visible = isNext;
                BtnRechazar.Visible = isNext;
                BtnCancelar.Visible = true;
                BtnCancelar.Text = "Volver";
                BtnEnviar.Visible = false;
                BtnSalvar.Visible = false;

                if (CtrlIndex == 0) hfSource.Value = "0";
            }
            else if (hfSource.Value == "2") // 2 es formulario desde DropDownList es Nuevo
            {
                BtnEnviar.Visible = true;
                BtnSalvar.Visible = true;
                BtnCancelar.Visible = true;
                BtnCancelar.Text = "Cancelar";
                BtnAprobar.Visible = false;
                BtnRechazar.Visible = false;

                if (CtrlIndex == 0) hfSource.Value = "0";
            }
        }

        protected void ddlPH_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlIndex = Convert.ToInt32(DropDownList1.SelectedValue);
            hfSource.Value = CtrlIndex == 0 ? "0" : "2";
            hfRefId.Value = String.Empty;
            LoadWizardStep();
        }

        public void Cargar_PlaceHolder(int _idPh, int _wfId)
        {
            {
                if (_wfId == 329)
                {
                    List<WFFormularioPagos> lstOrders = WFFormularioPagos.ObtenerPagos(_idPh);
                    var h = from c in lstOrders select c;
                    List<WFFormularioPagos> j = h.ToList();

                    DropDownList _ddlMoneda = (DropDownList)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_controldepagos_ascx").FindControl("ddlMoneda");
                    DropDownList _ddlTipoTransaccion = (DropDownList)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_controldepagos_ascx").FindControl("ddlTipoTransaccion");
                    DropDownList _ddlCuentas = (DropDownList)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_controldepagos_ascx").FindControl("ddlCuentas");
                    TextBox _txtNroTransaccion = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_controldepagos_ascx").FindControl("txtNroTransaccion");
                    TextBox txtCalendario = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_controldepagos_ascx").FindControl("txtCalendario");
                    TextBox _txtMonto = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_controldepagos_ascx").FindControl("txtMonto");
                    TextBox _txtObservaciones = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_controldepagos_ascx").FindControl("txtObservaciones");
                    TextBox _txtNombreClt = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_controldepagos_ascx").FindControl("textbox1");
                    
                    _ddlMoneda.Text = j.ElementAt(0).Moneda.ToString();
                    _ddlTipoTransaccion.Text = j.ElementAt(0).TipoTransaccion.ToString();
                    _ddlCuentas.Text = j.ElementAt(0).Cuenta.ToString();
                    _txtNroTransaccion.Text = j.ElementAt(0).NroTransaccion.ToString();
                    txtCalendario.Text = j.ElementAt(0).Fecha.ToString();
                    _txtMonto.Text = j.ElementAt(0).Monto.ToString();
                    _txtObservaciones.Text = j.ElementAt(0).Observaciones.ToString();
                    //XmlDocument xDoc = new XmlDocument();

                    ////La ruta del documento XML permite rutas relativas
                    ////respecto del ejecutable!

                    ////xDoc.Load("../../../../personas1.xml");
                    ////xDoc.DocumentElement(j.ElementAt(0).DatoXml.ToString());
                    //xDoc.Load(j.ElementAt(0).DatoXml.ToString());
                    
                    //XmlNodeList Root = xDoc.GetElementsByTagName("root");

                    //XmlNodeList lista =
                    //((XmlElement)Root[0]).GetElementsByTagName("Descripcion");

                    //foreach (XmlElement nodo in lista)
                    //{

                    //    //int i = 0;
                    //    XmlNodeList Moneda =
                    //    nodo.GetElementsByTagName("Moneda");

                    //    XmlNodeList TipoTransaccion =
                    //    nodo.GetElementsByTagName("TipoTransaccion");

                    //    XmlNodeList CuentaBank =
                    //    nodo.GetElementsByTagName("CuentaBank");

                    //    XmlNodeList NroTransaccion =
                    //    nodo.GetElementsByTagName("NroTransaccion");

                    //    XmlNodeList Fecha =
                    //    nodo.GetElementsByTagName("Fecha");

                    //    XmlNodeList Monto =
                    //    nodo.GetElementsByTagName("Monto");

                    //    XmlNodeList Observaciones =
                    //    nodo.GetElementsByTagName("Observaciones");

                    //    //(TextBox)PlaceHolderWkf.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox1") = nNombre;
                    //    TextBox _ddlMoneda = (TextBox)PlaceHolderWkf.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("ddlMoneda");
                    //    TextBox _ddlTipoTransaccion = (TextBox)PlaceHolderWkf.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("ddlTipoTransaccion");
                    //    TextBox _ddlCuentas = (TextBox)PlaceHolderWkf.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("ddlCuentas");
                    //    TextBox _txtNroTransaccion = (TextBox)PlaceHolderWkf.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("txtNroTransaccion");
                    //    TextBox txtCalendario = (TextBox)PlaceHolderWkf.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("txtCalendario");
                    //    TextBox _txtMonto = (TextBox)PlaceHolderWkf.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("txtMonto");
                    //    TextBox _txtObservaciones = (TextBox)PlaceHolderWkf.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("txtObservaciones");

                    //    _ddlMoneda.Text = Moneda.ToString();
                    //    _ddlTipoTransaccion.Text = TipoTransaccion.ToString();
                    //    _ddlCuentas.Text = CuentaBank.ToString();
                    //    _txtNroTransaccion.Text = NroTransaccion.ToString();
                    //    txtCalendario.Text = Fecha.ToString();
                    //    _txtMonto.Text = Monto.ToString();
                    //    _txtObservaciones.Text = Observaciones.ToString();

                    //}
                }
                /*
                else if (_wfId == 328)
                {
                    
                    List<WFFormularioPedidos> lstOrders = WFFormularioPedidos.ObtenerPedidos(_idPh);
                    var h = from c in lstOrders select c;
                    List<WFFormularioPedidos> j = h.ToList();

                    //XmlDocument xDoc = new XmlDocument();

                    // //La ruta del documento XML permite rutas relativas
                    ////respecto del ejecutable!

                    ////xDoc.Load("../../../../personas1.xml");
                    //xDoc.Load(j.ElementAt(0).DatoXml.ToString());

                    //XmlNodeList Root = xDoc.GetElementsByTagName("root");

                    //XmlNodeList lista =
                    //((XmlElement)Root[0]).GetElementsByTagName("Descripcion");

                                           //(TextBox)PlaceHolderWkf.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox1") = nNombre;
                    TextBox _nombreClt = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox1");
                    TextBox _kilosPreQ = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox2");
                    TextBox _nombreDelSolici = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox3");
                    TextBox _kilosDeCojin = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox4");
                    TextBox _codigoDePedido = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox5");
                    TextBox _kilosDeCordon = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox6");
                    TextBox _fechaPedido = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox7");
                    TextBox _kilosDeCemento = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox8");
                    TextBox _tipoFT = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox9");
                    TextBox _tiraAlfa = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox10");
                    TextBox _pesoEnKg = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox11");
                    TextBox _kilosDePintura = (TextBox)PlaceholderWF.FindControl("ASP.desktopmodules_workflow_pantallapedidos_ascx").FindControl("textbox12");

                    _nombreClt.Text = j.ElementAt(0).NombreClt.ToString();
                    _kilosPreQ.Text = j.ElementAt(0).KilosPreQ.ToString();
                    _nombreDelSolici.Text = j.ElementAt(0).NombreSoli.ToString();
                    _kilosDeCojin.Text = j.ElementAt(0).KilosCojin.ToString();
                    _codigoDePedido.Text = j.ElementAt(0).Codigo.ToString();
                    _kilosDeCordon.Text = j.ElementAt(0).KilosCordon.ToString();
                    _fechaPedido.Text = j.ElementAt(0).Fecha.ToString();
                    _kilosDeCemento.Text = j.ElementAt(0).KilosCemento.ToString();
                    _tipoFT.Text = j.ElementAt(0).Contenedor.ToString();
                    _tiraAlfa.Text = j.ElementAt(0).KilosAlfa.ToString();
                    _pesoEnKg.Text = j.ElementAt(0).PesoTotal.ToString();
                    _kilosDePintura.Text = j.ElementAt(0).KilosPintura.ToString();                    
                }
                */
            }

        }

        protected void LinkBtnConf_Click(object sender, EventArgs e)
        {
            //Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(PortalSettings.ActiveTab.TabID, "Wizard"));
        }

        #region Opciones de Formularios

        private void EnlazarAprobadores()
        {
            int lastUser = 0;
            ArrayList arrAprobador = ((WFIEditarFormsWorkflow)PlaceholderWF.Controls[0]).Approvers(Convert.ToInt32(hfIdUser.Value), out lastUser);

            if (lastUser == 1)
            {
                pnlAprobar.Visible = false;
            }
            else
            {
                pnlAprobar.Visible = true;
                ddlAprobado.DataSource = arrAprobador;
                ddlAprobado.DataValueField = "intEmpleado";
                ddlAprobado.DataTextField = "strEmpleado";
                ddlAprobado.DataBind();
                if (arrAprobador.Count >= 2)
                    ddlAprobado.SelectedIndex = 1;
            }
        }

        private void EnlazarMotivos()
        {
            ddlRechazo.DataSource = ESMotivosRechazo.ListarMotivosRechazo();
            ddlRechazo.DataValueField = "intMotivoRechazo";
            ddlRechazo.DataTextField = "strMotivoRechazo";
            ddlRechazo.DataBind();
        }

        protected void BtnAprobar_Click(object sender, EventArgs e)
        {
            hfOpcion.Value = "Aprobar";
            EnlazarAprobadores();
            pnlRechazar.Visible = false;
            txtObservaciones.Text = String.Empty;
            ModalPopupExtender1.Show();
        }

        protected void BtnRechazar_Click(object sender, EventArgs e)
        {
            hfOpcion.Value = "Rechazar";
            EnlazarMotivos();
            pnlAprobar.Visible = false;
            pnlRechazar.Visible = true;
            txtObservaciones.Text = String.Empty;
            ModalPopupExtender1.Show();
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {            
            CtrlIndex = 0; // cargar GridPantallaPrincipal
            hfSource.Value = "0"; // esconder lo necesario
            LoadWizardStep();
            
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton9.Visible = true;
            DropDownList1.Visible = true;

            DropDownList1.SelectedIndex = 0; 
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            int retval = ((WFIEditarFormsWorkflow)PlaceholderWF.Controls[0]).Save(Convert.ToInt32(hfIdUser.Value));
            if (retval > 0)
            {
                CtrlIndex = 1; // cargar OperacionExitosa
                hfSource.Value = "0"; // esconder lo necesario
                LoadWizardStep();

                BtnCancelar.Visible = true;
                BtnCancelar.Text = "Volver";
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                LinkButton9.Visible = false;
                DropDownList1.Visible = false;   
            }
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            int retval = ((WFIEditarFormsWorkflow)PlaceholderWF.Controls[0]).Save(Convert.ToInt32(hfIdUser.Value));
            if (retval > 0)
            {
                hfOpcion.Value = "Enviar";
                EnlazarAprobadores();
                pnlRechazar.Visible = false;
                txtObservaciones.Text = String.Empty;
                ModalPopupExtender1.Show();
            }
        }

        #endregion

        #region Opciones del PopUp

        protected void bttnCancelar_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void bttnAceptar_Click(object sender, EventArgs e)
        {
            int selectedValue = ddlAprobado.SelectedValue == String.Empty ? 0 : Convert.ToInt32(ddlAprobado.SelectedValue);

            switch (hfOpcion.Value)
            {
                case "Aprobar":
                    ((WFIEditarFormsWorkflow)PlaceholderWF.Controls[0]).Approve(Convert.ToInt32(hfIdUser.Value), selectedValue, txtObservaciones.Text);
                    break;
                case "Rechazar":
                    selectedValue = Convert.ToInt32(hfIdCreador.Value);
                    if (ddlRechazo.SelectedValue == "1") // rechazo parcial, es decir, correccion
                        ((WFIEditarFormsWorkflow)PlaceholderWF.Controls[0]).Revise(Convert.ToInt32(hfIdUser.Value), selectedValue, txtObservaciones.Text);
                    else
                        ((WFIEditarFormsWorkflow)PlaceholderWF.Controls[0]).Reject(Convert.ToInt32(hfIdUser.Value), selectedValue, txtObservaciones.Text);
                    break;
                case "Enviar":
                    ((WFIEditarFormsWorkflow)PlaceholderWF.Controls[0]).Send(Convert.ToInt32(hfIdUser.Value), selectedValue, txtObservaciones.Text);
                    break;
            }

            CtrlIndex = 1; // cargar OperacionExitosa
            hfSource.Value = "0"; // esconder lo necesario
            LoadWizardStep();
            
            BtnCancelar.Visible = true;
            BtnCancelar.Text = "Volver";
            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
            LinkButton9.Visible = false;
            DropDownList1.Visible = false;   
        }

        #endregion

        #region Menú de Estatus

        protected void LinkBtnBE_Click(object sender, EventArgs e)
        {
            CtrlIndex = 0;
            hfSource.Value = "0";
            LoadWizardStep();
            ((WFIEditarStatusWF)PlaceholderWF.Controls[0]).Status("Todos", Convert.ToInt32(hfIdUser.Value));
            LkBtnBE.Font.Bold = true;
        }

        protected void LinkBtnAprobados_Click(object sender, EventArgs e)
        {
            CtrlIndex = 0;
            hfSource.Value = "0";
            LoadWizardStep();
            ((WFIEditarStatusWF)PlaceholderWF.Controls[0]).Status("Aprobado", Convert.ToInt32(hfIdUser.Value));
            LkBtnAprobado.Font.Bold = true;
            LkBtnBE.Font.Bold = false;
        }

        protected void LinkBtnRechazado_Click(object sender, EventArgs e)
        {
            CtrlIndex = 0;
            hfSource.Value = "0";
            LoadWizardStep();
            ((WFIEditarStatusWF)PlaceholderWF.Controls[0]).Status("Rechazado", Convert.ToInt32(hfIdUser.Value));
            LkBtnRechazado.Font.Bold = true;
            LkBtnBE.Font.Bold = false;
        }

        protected void LinkBtnPendientes_Click(object sender, EventArgs e)
        {
            CtrlIndex = 0;
            hfSource.Value = "0";
            LoadWizardStep();
            ((WFIEditarStatusWF)PlaceholderWF.Controls[0]).Status("Pendiente", Convert.ToInt32(hfIdUser.Value));
            LkBtnPendiente.Font.Bold = true;
            LkBtnBE.Font.Bold = false;
        }

        protected void LinkBtnPorCorregir_Click(object sender, EventArgs e)
        {
            CtrlIndex = 0;
            hfSource.Value = "0";
            LoadWizardStep();
            ((WFIEditarStatusWF)PlaceholderWF.Controls[0]).Status("Por corregir", Convert.ToInt32(hfIdUser.Value));
            LkBtncorregir.Font.Bold = true;
            LkBtnBE.Font.Bold = false;
        }

        protected void LinkBtnPausados_Click(object sender, EventArgs e)
        {
            CtrlIndex = 0;
            hfSource.Value = "0";
            LoadWizardStep();
            ((WFIEditarStatusWF)PlaceholderWF.Controls[0]).Status("Pausado", Convert.ToInt32(hfIdUser.Value));
            LkBtnPausados.Font.Bold = true;
            LkBtnBE.Font.Bold = false;
        }

        protected void LinkBtnCancelados_Click(object sender, EventArgs e)
        {
            CtrlIndex = 0;
            hfSource.Value = "0";
            LoadWizardStep();
            ((WFIEditarStatusWF)PlaceholderWF.Controls[0]).Status("Cancelado", Convert.ToInt32(hfIdUser.Value));
            LkBtnCancelados.Font.Bold = true;
            LkBtnBE.Font.Bold = false;
        }

        #endregion

        #region Miembros de WFIEditarStatusWF

        public void Status(string status, int userId)
        {
            //throw new NotImplementedException(); , int source
            //return String.Empty;
        }

        public int IdPH(int idPH, int wfId, int creadorId, string status)
        {
            hfRefId.Value = idPH.ToString();
            hfIdCreador.Value = creadorId.ToString();

            if (wfId == 328)
                CtrlIndex = 3;
            else if (wfId == 329)
                CtrlIndex = 2;

            if (Convert.ToInt32(hfIdUser.Value) == creadorId && (status == "Por corregir" || status == "Creado"))
                hfSource.Value = "2";
            else
                hfSource.Value = "1"; // 1 es formulario desde GridPantallaPrincipal contiene información

            LoadWizardStep();
            Cargar_PlaceHolder(idPH, wfId);
            return idPH;
        }

        #endregion
    }
}