using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Componentes.BLL.WF;
using Componentes.BLL;
using Componentes.DAL;
using Componentes.Web;
using System.Collections;
using Mensajeria;
using DotNetNuke.Entities.Users;

namespace Workflow
{
    public partial class PantallaPedidos : System.Web.UI.UserControl, WFIEditarFormsWorkflow
    {
        //WFFormularioPedidos Pedidos;
        WFIEditarStatusWF wpp;

        public WFFormularioPedidos Pedidos
        {
            get { return (WFFormularioPedidos)Session["Pedidos"]; }
            set { Session["Pedidos"] = value; }
        }

        public int WorkflowId
        {
            //get { return (int)ViewState["WorkflowId"]; }
            get { return 328; }
        }

        //userId es lo mismo que intEmpleado
        protected void Page_Load(object sender, EventArgs e)
        {
            //ViewState["WorkflowId"] = 328;
            //Pedidos = new WFFormularioPedidos();
        }

        private void EnlazarAprobadores()
        {
            ////DropDownList ddlAprobado = (DropDownList)Global.FindMyControl(Page, "ddlAprobado");
            ////if (Pedidos == null) return;
            //ArrayList arrAprobador = WFAprobadores.ListarAprobadores(WorkflowId, Pedidos.PedidoId.ToString(), "");
            //ddlAprobador.DataSource = arrAprobador;
            //ddlAprobador.DataValueField = "intEmpleado";
            //ddlAprobador.DataTextField = "strEmpleado";
            //ddlAprobador.DataBind();
            //if (arrAprobador.Count >= 2)
            //    ddlAprobador.SelectedIndex = 1;
        }

        // este procedimiento se llama en todos los eventos que afectan a las políticas
        // todo campo que refleje un cambio de política debe llamar a este procedimiento
        private void EnlazarAprobacion()
        {
            ////if (ddlMoneda.SelectedIndex == 0 || dgdDetalle.Items.Count == 0)
            ////{
            ////    ddlAprobador.Items.Clear();
            ////    ddlAprobador.Enabled = false;
            ////    return;
            ////}

            ////ArrayList Moneda = (ArrayList)ViewState["Moneda"];

            //HiddenField _hfIdUser = (HiddenField)Global.FindMyControl(Page, "hfIdUser");
            //if (_hfIdUser.Value == string.Empty) return;
            //string strRuta = WFWorkflow.ObtenerRuta(WorkflowId, Convert.ToUInt32(_hfIdUser.Value), "ClienteAlDia", "CreditoSuficiente", "HayEnAlmacen");

            //ddlAprobador.DataSource = WFAprobadores.ListarAprobadores(WorkflowId, Pedidos.PedidoId.ToString(), strRuta);
            //ddlAprobador.DataValueField = "intEmpleado";
            //ddlAprobador.DataTextField = "strEmpleado";
            //ddlAprobador.DataBind();

            //// si el que emite el documento aparece en la lista es porque no necesita de más nadie para que
            //// el documento esté aprobado y tenga validez
            //if (Pedidos.PedidoId != 0)
            //{
            //    WFAprobadores Aprobador = new WFAprobadores();
            //    Aprobador = WFAprobadores.ConsultarAprobador(WorkflowId, Pedidos.PedidoId.ToString(), Pedidos.UserId);
            //    ddlAprobador.Items.FindByValue(Aprobador.intEmpleado.ToString()).Selected = true;
            //}

            //if (((ArrayList)ddlAprobador.DataSource).Count >= 2)
            //    ddlAprobador.SelectedIndex = 1;
            ////ddlAprobador.Enabled = true;
        }

        private void AprobacionInmediata()
        {
            //if (Pedidos.StatusId == StateConst.ESPERAR_CORRECCION)
            //    return;

            ////if (ddlMoneda.SelectedIndex == 0)
            ////    return;

            ////ArrayList Moneda = (ArrayList)ViewState["Moneda"];

            //string strRuta = WFWorkflow.ObtenerRuta(WorkflowId, Pedidos.UserId, "ClienteAlDia", "CreditoSuficiente", "HayEnAlmacen");

            //if (WFWorkflow.AprobacionInmediata(strRuta))
            //{
            //    //btnEnviar.Text = "Enviar";
            //    ddlAprobador.Visible = false;
            //    //btnAceptar.Visible = false;
            //}
            //else
            //{
            //    //btnEnviar.Text = "Solicitar aprobación";
            //    ddlAprobador.Visible = true;
            //    //btnAceptar.Visible = true;
            //}
        }

        public int Save(int userId)
        {
            string strData = "<root>";
            strData += "<Descripcion NombreClt='" + textbox1.Text + "' ";
            strData += "KilosPreQ='" + textbox2.Text + "' ";
            strData += "NombreDelSolici='" + textbox3.Text + "' ";
            strData += "KilosDeCojin='" + textbox4.Text + "' ";
            strData += "CodigoDePedido='" + textbox5.Text + "' ";
            strData += "KilosDeCordon='" + textbox6.Text + "' ";
            strData += "FechaPedido='" + textbox7.Text + "' ";
            strData += "KilosDeCemento='" + textbox8.Text + "' ";
            strData += "TipoFT='" + textbox9.Text + "' ";
            strData += "TiraAlfa='" + textbox10.Text + "' ";
            strData += "PesoEnKg='" + textbox11.Text + "' ";
            strData += "KilosDePintura='" + textbox12.Text + "'/>";
            strData += "</root>";

            Pedidos = Pedidos ?? new WFFormularioPedidos();
            Pedidos.UserId = userId; // _usuarioLogueado
            Pedidos.FechaIngreso = DateTime.Now;
            Pedidos.FechaModificacion = DateTime.Now;
            Pedidos.DatoXml = strData;
            //Pedidos.StatusId: 1 es creado y 0 es no registrado en el workflow
            Pedidos.DocumentoId = 2;
            Pedidos.NombreClt = textbox1.Text;
            Pedidos.KilosPreQ = textbox2.Text;
            Pedidos.NombreSoli = textbox3.Text;
            Pedidos.KilosCojin = textbox4.Text;
            Pedidos.Codigo = Convert.ToInt32(textbox5.Text == string.Empty ? "0" : textbox5.Text);
            Pedidos.KilosCordon = textbox6.Text;
            Pedidos.Fecha = DateTime.Now;
            Pedidos.KilosCemento = textbox8.Text;
            Pedidos.Contenedor = textbox9.Text;
            Pedidos.KilosAlfa = textbox10.Text;
            Pedidos.PesoTotal = textbox11.Text;
            Pedidos.KilosPintura = textbox12.Text;
            
            Pedidos.PedidoId = WFFormularioPedidos.InsertarPedidos(Pedidos);
            if (Pedidos.PedidoId > 0 && Pedidos.StatusId == 0)
            {
                if (WFWorkflow.ActualizarUltimoUsuario(Queries.WF_ActualizarUltimaAprobacionPedido, Pedidos.PedidoId.ToString(), userId))
                    WFWorkflow.EnviarMensaje(WS.Eventos.CREAR_SOLICITUD, WorkflowId, Pedidos.PedidoId, userId, userId);
            }

            return Pedidos.PedidoId;
        }

        public void Send(int userId, int userDestinoId, string obs)
        {
            //if (Save(userId) > 0) // significa que se guardo un pedidoId válido
            //{
            // status 11 es Por corregir, esto ocurre si es devuelto el formulario pues hay que volverlo a enviar
            if (Pedidos.StatusId == 11)
            {
                if (!WFWorkflow.ActualizarUltimoUsuario(Queries.WF_ActualizarUltimaAprobacionPedido, Pedidos.PedidoId.ToString(), userId) ||
                    !WFWorkflow.EnviarMensaje(WS.Eventos.SOLICITUD_CORREGIDA, WorkflowId, Pedidos.PedidoId, userDestinoId, obs, "ClienteAlDia", "CreditoSuficiente", "HayEnAlmacen"))
                {
                    //lblError.Text = ESMensajes.ObtenerMensaje(425);
                    return;
                }
            }
            else // se está enviando por primera vez el formulario
            {
                if (WFWorkflow.ActualizarUltimoUsuario(Queries.WF_ActualizarUltimaAprobacionPedido, Pedidos.PedidoId.ToString(), userId) &&
                    WFWorkflow.EnviarMensaje(WS.Eventos.CREAR_SOLICITUD, WorkflowId, Pedidos.PedidoId, userId, userDestinoId, "ClienteAlDia", "CreditoSuficiente", "HayEnAlmacen"))
                {
                    WFWorkflow.EnviarMensaje(WS.Eventos.INCLUIR_SOLICITUD, WorkflowId, Pedidos.PedidoId, userDestinoId, obs);
                }
                else
                {
                    //lblError.Text = ESMensajes.ObtenerMensaje(425);
                    return;
                }
            }
            //}
            //else
            //{
            //    //if (S == 0)
            //    //    lblError.Text = ESMensajes.ObtenerMensaje(168);
            //    //else
            //    //{
            //    //    if (S == -2) lblError.Text = ESMensajes.ObtenerMensaje(660);
            //    //    return;
            //    //}
            //}
        }

        public void Approve(int userId, int userDestinoId, string obs)
        {
            if (WFWorkflow.ActualizarUltimoUsuario(Queries.WF_ActualizarUltimaAprobacionPedido, Pedidos.PedidoId.ToString(), userId))
                WFWorkflow.EnviarMensaje(WS.Eventos.SOLICITUD_APROBADA, WorkflowId, Pedidos.PedidoId, userDestinoId, obs);
        }

        public void Reject(int userId, int userDestinoId, string obs)
        {
            if (WFWorkflow.ActualizarUltimoUsuario(Queries.WF_ActualizarUltimaAprobacionPedido, Pedidos.PedidoId.ToString(), userId))
                WFWorkflow.EnviarMensaje(WS.Eventos.RECHAZADO_TOTAL, WorkflowId, Pedidos.PedidoId, userDestinoId, obs);
        }

        public void Revise(int userId, int userDestinoId, string obs)
        {
            if (WFWorkflow.ActualizarUltimoUsuario(Queries.WF_ActualizarUltimaAprobacionPedido, Pedidos.PedidoId.ToString(), userId))
                WFWorkflow.EnviarMensaje(WS.Eventos.RECHAZADO_PARCIAL, WorkflowId, Pedidos.PedidoId, userDestinoId, obs);
        }

        public ArrayList Approvers(int userId, out int last)
        {
            string pedidoId = Pedidos == null || Pedidos.StatusId == 11 || Pedidos.StatusId == 1 ? "0" : Pedidos.PedidoId.ToString();

            last = 0; // si pedidoId es 0 no existe o espera correción por lo tanto ni siquiera es el ultimo
            string ruta = String.Empty;
            if (pedidoId == "0")
            {
                // se consultan las políticas según lo que aparece en el formulario
                ruta = WFWorkflow.ObtenerRuta(WorkflowId, userId, "ClienteAlDia", "CreditoSuficiente", "HayEnAlmacen");
            }
            else
            {
                last = WFWorkflow.UltimoDestino(WorkflowId, pedidoId);
            }

            return WFAprobadores.ListarAprobadores(WorkflowId, pedidoId, ruta);
        }

        public bool Initialize(object obj, int refId, int userId)
        {            
            wpp = (WFIEditarStatusWF)obj;
            Pedidos = WFFormularioPedidos.ObtenerPedido(refId);

            bool pendiente = false;
            bool siguiente = false;
            // si Pedidos es null significa que ni siquiera se ha creado la solicitud
            // por lo tanto los botones habilitados en la interfaz son cancelar y enviar
            // es decir que el formulario no se llamó desde el Grid sino desde la lista
            // desplegable y se trata de uno nuevo
            if (Pedidos != null)
            {
                textbox1.Text = Pedidos.NombreClt;
                textbox2.Text = Pedidos.KilosPreQ;
                textbox3.Text = Pedidos.NombreSoli;
                textbox4.Text = Pedidos.KilosCojin;
                textbox5.Text = Pedidos.Codigo.ToString();
                textbox6.Text = Pedidos.KilosCordon;
                textbox7.Text = Pedidos.Fecha.ToString();
                textbox8.Text = Pedidos.KilosCemento;
                textbox9.Text = Pedidos.Contenedor;
                textbox10.Text = Pedidos.KilosAlfa;
                textbox11.Text = Pedidos.PesoTotal;
                textbox12.Text = Pedidos.KilosPintura;

                WFAprobadores approver = WFAprobadores.ConsultarAprobadorActual(WorkflowId, Pedidos.PedidoId.ToString(), userId);
                if (approver.intEmpleado == userId) siguiente = true;
                pendiente = Pedidos.StatusId == 17;
            }
            return siguiente && pendiente;
        }
    }
}