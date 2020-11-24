using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Componentes.BLL.WF;
using Componentes.Web;
using Componentes.BLL;
using System.Collections;
using Componentes.DAL;

namespace Workflow
{
    public partial class ControlDePagos : System.Web.UI.UserControl, WFIEditarFormsWorkflow
    {
        WFIEditarStatusWF wpp;

        public WFFormularioPagos Pagos
        {
            get { return (WFFormularioPagos)Session["Pagos"]; }
            set { Session["Pagos"] = value; }
        }

        public int WorkflowId
        {
            //get { return (int)ViewState["WorkflowId"]; }
            get { return 329; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //ViewState["WorkflowId"] = 329;
            Pagos = new WFFormularioPagos();
        }

        private void EnlazarAprobadores()
        {
            ////DropDownList ddlAprobado = (DropDownList)Global.FindMyControl(Page, "ddlAprobado");
            ////if (Pagos == null) return;
            //ArrayList arrAprobador = WFAprobadores.ListarAprobadores(WorkflowId, Pagos.PagoId.ToString(), "");
            //ddlAprobador.DataSource = arrAprobador;
            //ddlAprobador.DataValueField = "intEmpleado";
            //ddlAprobador.DataTextField = "strEmpleado";
            //ddlAprobador.DataBind();
            //if (arrAprobador.Count >= 2)
            //    ddlAprobador.SelectedIndex = 1;
        }



        //protected void BtnAceptar_Click(object sender, EventArgs e)
        //{

        //    //List<Forms> LsTrans = Forms.ListarForms();
        //    //GridView1.DataSource = Formss.ListarForms();
        //    //GridView1.DataBind();

        //}

        //protected void BtnCancelar_Click(object sender, EventArgs e)
        //{

        //    //List<Forms> LsTrans = Forms.ListarForms();
        //    //GridView1.DataSource = Formss.ListarForms();
        //    //GridView1.DataBind();

        //}

        //protected void lb_Procesar_Click(object sender, EventArgs e)
        //{

        //    //List<Forms> LsTrans = Forms.ListarForms();
        //    //GridView1.DataSource = Formss.ListarForms();
        //    //GridView1.DataBind();

        //}

        //protected void btnShowPopup_Click(object sender, EventArgs e)
        //{

        //    //List<Forms> LsTrans = Forms.ListarForms();
        //    //GridView1.DataSource = Formss.ListarForms();
        //    //GridView1.DataBind();

        //}

        public int Save(int userId)
        {
            string strData = "<root>"; 
            strData += "<Descripcion Moneda='" + ddlMoneda.SelectedValue + "' ";
            strData += "TipoTransaccion='" + ddlTipoTransaccion.SelectedValue + "' ";
            strData += "CuentaBank='" + ddlCuentas.SelectedValue + "' ";
            strData += "NroTransaccion='" + txtNroTransaccion.Text + "' ";
            strData += "Fecha='" + txtCalendario.Text + "' ";
            strData += "Monto='" + txtMonto.Text + "' ";
            strData += "Observaciones='" + txtObservaciones.Text + "'/>";
            strData += "</root>";

            Pagos.UserId = userId; //_usuarioLogueado
            Pagos.FechaIngreso = DateTime.Now;
            Pagos.FechaModificacion = DateTime.Now;
            Pagos.DatoXml = strData;
            Pagos.StatusId = 1;
            Pagos.DocumentoId = 1;
            Pagos.Moneda = ddlMoneda.SelectedItem.Text;
            Pagos.TipoTransaccion = ddlTipoTransaccion.SelectedItem.Text;
            Pagos.Cuenta = ddlCuentas.SelectedItem.Text;
            Pagos.NroTransaccion = Convert.ToInt32(txtNroTransaccion.Text == string.Empty ? "0" : txtNroTransaccion.Text);
            Pagos.Fecha = DateTime.Now;
            Pagos.Monto = txtMonto.Text;
            Pagos.Observaciones = txtObservaciones.Text;

            Pagos.PagoId = WFFormularioPagos.InsertarPagos(Pagos);
            return Pagos.PagoId;
        }

        public void Send(int userId, int userDestinoId, string obs)
        {
            if (Save(userId) > 0)
            {
                // status 11 es Por corregir, esto ocurre si es devuelto el formulario pues hay que volverlo a enviar
                if (Pagos.StatusId == 11)
                {
                    if (!WFWorkflow.ActualizarUltimoUsuario(Queries.WF_ActualizarUltimaAprobacionPedido, Pagos.PagoId.ToString(), userId) ||
                        !WFWorkflow.EnviarMensaje(WS.Eventos.SOLICITUD_CORREGIDA, WorkflowId, Pagos.PagoId, userDestinoId, obs, "PAGOS"))
                    {
                        //lblError.Text = ESMensajes.ObtenerMensaje(425);
                        return;
                    }
                }
                else // se está enviando por primera vez el formulario
                {
                    if (WFWorkflow.ActualizarUltimoUsuario(Queries.WF_ActualizarUltimaAprobacionPedido, Pagos.PagoId.ToString(), userId) &&
                        WFWorkflow.EnviarMensaje(WS.Eventos.CREAR_SOLICITUD, WorkflowId, Pagos.PagoId, userId, userDestinoId, "PAGOS")) 
                    {
                        WFWorkflow.EnviarMensaje(WS.Eventos.INCLUIR_SOLICITUD, WorkflowId, Pagos.PagoId, userDestinoId, obs);
                    }
                    else
                    {
                        //lblError.Text = ESMensajes.ObtenerMensaje(425);
                        return;
                    }
                }
            }
        }

        public void Approve(int userId, int userDestinoId, string obs)
        {
            WFWorkflow.EnviarMensaje(WS.Eventos.SOLICITUD_APROBADA, WorkflowId, Pagos.PagoId, userDestinoId, obs);
        }

        public void Reject(int userId, int userDestinoId, string obs)
        {
            WFWorkflow.EnviarMensaje(WS.Eventos.RECHAZADO_TOTAL, WorkflowId, Pagos.PagoId, userDestinoId, obs);
        }

        public void Revise(int userId, int userDestinoId, string obs)
        {
            WFWorkflow.EnviarMensaje(WS.Eventos.RECHAZADO_PARCIAL, WorkflowId, Pagos.PagoId, userDestinoId, obs);
        }

        public ArrayList Approvers(int userId, out int last)
        {
            last = 0;
            return WFAprobadores.ListarAprobadores(WorkflowId, Pagos.PagoId.ToString(), "");
        }

        public bool Initialize(object obj, int refId, int userId)
        {
            wpp = (WFIEditarStatusWF)obj;
            EnlazarAprobadores();
            return true;
        }

    }

}
