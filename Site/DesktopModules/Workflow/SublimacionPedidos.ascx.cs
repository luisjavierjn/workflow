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
using Componentes.BLL.WF;
using Componentes.BLL;
using Componentes.DAL;
using System.Globalization;

namespace Workflow
{
    public partial class SublimacionPedidos : System.Web.UI.UserControl, WFIEditarFormsWorkflow
    {
        WFIEditarStatusWF wpp;

        public WFSublimacionPedidos pedido
        {
            get { return (WFSublimacionPedidos)Session["Pedidos"]; }
            set { Session["Pedidos"] = value; }
        }

        public int WorkflowId
        {
            get { return 335; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //
        }

        //protected void lb_Procesar_Click(object sender, EventArgs e)
        //{
        //    CultureInfo Culture = new CultureInfo("es-VE");

        //    LBProcesarMPE.Show();
        //}

        //protected void BtnAceptar_Click(object sender, EventArgs e)
        //{
        //    CultureInfo Culture = new CultureInfo("es-VE");

        //    //Depositos lstDeposito = new Depositos();
        //    //int bInserto = Depositos.InsertarDeposito(lstDeposito);
        //    //ReiniciarControles();
        //    //((IRefreshInfo)_solicitud).Refresh();
        //}

        #region Miembros de WFIEditarFormsWorkflow

        public bool Initialize(object obj, int refId, int userId)
        {
            wpp = (WFIEditarStatusWF)obj;
            pedido = WFSublimacionPedidos.ObtenerPedido(refId);

            bool pendiente = false;
            bool siguiente = false;
            // si Pedidos es null significa que ni siquiera se ha creado la solicitud
            // por lo tanto los botones habilitados en la interfaz son cancelar y enviar
            // es decir que el formulario no se llamó desde el Grid sino desde la lista
            // desplegable y se trata de uno nuevo
            if (pedido != null)
            {
                //textbox1.Text = Pedidos.NombreClt;
                //textbox2.Text = Pedidos.KilosPreQ;
                //textbox3.Text = Pedidos.NombreSoli;
                //textbox4.Text = Pedidos.KilosCojin;
                //textbox5.Text = Pedidos.Codigo.ToString();
                //textbox6.Text = Pedidos.KilosCordon;
                //textbox7.Text = Pedidos.Fecha.ToString();
                //textbox8.Text = Pedidos.KilosCemento;
                //textbox9.Text = Pedidos.Contenedor;
                //textbox10.Text = Pedidos.KilosAlfa;
                //textbox11.Text = Pedidos.PesoTotal;
                //textbox12.Text = Pedidos.KilosPintura;

                WFAprobadores approver = WFAprobadores.ConsultarAprobadorActual(WorkflowId, pedido.TransId.ToString(), userId);
                if (approver.intEmpleado == userId) siguiente = true;
                pendiente = pedido.EstatusId == 17;
            }
            return siguiente && pendiente;
        }

        public int Save(int userId)
        {
            pedido = pedido ?? new WFSublimacionPedidos();
            pedido.TipoTransId = 1; // 1 el cliente está realizando un abono
            pedido.MotivoId = int.Parse(ddlTipoTransaccion.SelectedValue);
            pedido.EmpleadoId = userId; // _usuarioLogueado
            pedido.CentroId = 1; // 1 es Caracas, San Martín
            pedido.NumTrans = txtNroTransaccion.Text;
            pedido.IvaAplicable = 0.12m;
            pedido.MontoTotal = Convert.ToDecimal(txtMonto.Text);
            pedido.FechaTrans = Convert.ToDateTime(txtCalendario.Text);
            pedido.FechaActual = DateTime.Now;
            pedido.FechaDeEntrega = DiasDeEntrega(DateTime.Now);
            pedido.Observaciones = txtObservaciones.Text;

            WFSublimacionPedidos.InsertarPedido(pedido);
            if (pedido.TransId > 0 && pedido.EstatusId == 0)
            {
                if (WFWorkflow.ActualizarUltimoUsuario(Queries.WF_ActualizarUltimaAprobacionTrans, pedido.TransId.ToString(), userId))
                    WFWorkflow.EnviarMensaje(WS.Eventos.CREAR_SOLICITUD, WorkflowId, pedido.TransId, userId, userId);
            }

            return pedido.TransId;
        }

        private DateTime DiasDeEntrega(DateTime now)
        {
            int retval = 3;
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Thursday:
                    retval = 5;
                    break;
                case DayOfWeek.Friday:
                    retval = 5;
                    break;
                case DayOfWeek.Saturday:
                    retval = 4;
                    break;
            }
            return now.AddDays(retval);
        }

        public void Send(int userId, int userDestinoId, string obs)
        {
            throw new NotImplementedException();
        }

        public void Approve(int userId, int userDestinoId, string obs)
        {
            throw new NotImplementedException();
        }

        public void Reject(int userId, int userDestinoId, string obs)
        {
            throw new NotImplementedException();
        }

        public void Revise(int userId, int userDestinoId, string obs)
        {
            throw new NotImplementedException();
        }

        public ArrayList Approvers(int userId, out int last)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}