using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using Componentes.Web;
using Componentes.DAL;
using Componentes.BLL.SE;
using System.Xml;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Componentes.BLL.WF
{
    /// <summary>
    /// Descripción breve de WFSublimacionPedidos
    /// </summary>
    public class WFSublimacionPedidos
    {
        int _transId;
        int _tipoTransId;
        int _motivoId;
        int _empleadoId;
        int _centroId;
        int _estatusId;
        int _ultimoUsuarioId;
        string _numTrans;
        decimal _ivaAplicable;
        decimal _montoTotal;
        DateTime _fechaTrans;
        DateTime _fechaActual;
        DateTime _fechaDeEntrega;
        string _observaciones;

        public int TransId 
        {
            get { return _transId; }
        }

        public int TipoTransId
        {
            get { return _tipoTransId; }
            set { _tipoTransId = value; }
        }

        public int MotivoId
        {
            get { return _motivoId; }
            set { _motivoId = value; }
        }

        public int EmpleadoId
        {
            get { return _empleadoId; }
            set { _empleadoId = value; }
        }

        public int CentroId
        {
            get { return _centroId; }
            set { _centroId = value; }
        }

        public int EstatusId
        {
            get { return _estatusId; }
        }

        public int UltimoUsuarioId
        {
            get { return _ultimoUsuarioId; }
        }

        public string NumTrans
        {
            get { return _numTrans; }
            set { _numTrans = value; }
        }

        public decimal IvaAplicable
        {
            get { return _ivaAplicable; }
            set { _ivaAplicable = value; }
        }

        public decimal MontoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }

        public DateTime FechaTrans
        {
            get { return _fechaTrans; }
            set { _fechaTrans = value; }
        }

        public DateTime FechaActual
        {
            get { return _fechaActual; }
            set { _fechaActual = value; }
        }

        public DateTime FechaDeEntrega
        {
            get { return _fechaDeEntrega; }
            set { _fechaDeEntrega = value; }
        }

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        public WFSublimacionPedidos()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public static WFSublimacionPedidos ObtenerPedido(int transId)
        {
            WFSublimacionPedidos pedido = null;
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.WF_ObtenerTransaccion, transId);

            if (dr.Read())
            {
                pedido = new WFSublimacionPedidos();
                pedido._transId = dr.GetInt32(0);
                pedido._tipoTransId = dr.GetBoolean(1) ? 1 : 0;
                pedido._motivoId = dr.GetInt32(2);
                pedido._empleadoId = dr.GetInt32(3);
                pedido._centroId = dr.GetInt32(4);
                pedido._estatusId = dr.GetInt32(5);
                pedido._ultimoUsuarioId = dr.GetInt32(6);
                pedido._numTrans = dr.GetString(7);
                pedido._ivaAplicable = dr.GetDecimal(8);
                pedido._montoTotal = dr.GetDecimal(9);
                pedido._fechaTrans = dr.GetDateTime(10);
                pedido._fechaActual = dr.GetDateTime(11);
                pedido._fechaDeEntrega = dr.GetDateTime(12);
                pedido._observaciones = dr.GetString(13);
            }

            return pedido;
        }

        public static int InsertarPedido(WFSublimacionPedidos pedido)
        {
            int nResultado = 0;
            try
            {
                object obj = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.WF_InsertarTransaccion,
                pedido._transId,
                pedido._tipoTransId == 1 ? true : false,
                pedido._motivoId,
                pedido._empleadoId,
                pedido._centroId,
                pedido._estatusId,
                pedido._ultimoUsuarioId,
                pedido._numTrans,
                pedido._ivaAplicable,
                pedido._montoTotal,
                pedido._fechaTrans,
                pedido._fechaActual,
                pedido._fechaDeEntrega,
                pedido._observaciones
                );
                if (obj != null)
                {
                    nResultado = Convert.ToInt32(obj);
                }
            }
            catch (Exception) //ex)
            {
                //String cm = String.Empty;
                //EventLog.WriteEntry("Clever", "Clase Bonos: " + ex.Message, EventLogEntryType.Error, 232);
            }

            pedido._transId = nResultado;
            return nResultado;
        }
    }
}