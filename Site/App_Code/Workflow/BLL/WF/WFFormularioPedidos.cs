using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Componentes.Web;
using Componentes.DAL;
using Componentes.BLL.SE;
using System.Xml;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
/// <summary>
/// Descripción breve de WFFormularioPedidos
/// </summary>
/// 

namespace Componentes.BLL.WF
{
    public class WFFormularioPedidos
    {
        int _pedidoId;
        int _userId;
        DateTime _fechaIngreso;
        DateTime _fechaModificacion;
        string _datoXml;
        int _statusId;
        string _responsable;
        string _cliente;
        int _documentoId;

        string _nombreClt;
        string _kilosPreQ;
        string _nombreSoli;
        string _kilosCojin;
        int _codigo;
        string _kilosCordon;
        DateTime _fecha;
        string _kilosCemento;
        string _contenedor;
        string _kilosAlfa;
        string _pesoTotal;
        string _kilosPintura;

        public string Contenedor
        {
            get { return _contenedor; }
            set { _contenedor = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public string KilosPintura
        {
            get { return _kilosPintura; }
            set { _kilosPintura = value; }
        }
        public string PesoTotal
        {
            get { return _pesoTotal; }
            set { _pesoTotal = value; }
        }
        public string KilosAlfa
        {
            get { return _kilosAlfa; }
            set { _kilosAlfa = value; }
        }
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string KilosCemento
        {
            get { return _kilosCemento; }
            set { _kilosCemento = value; }
        }
        public string KilosCordon
        {
            get { return _kilosCordon; }
            set { _kilosCordon = value; }
        }
        public string KilosCojin
        {
            get { return _kilosCojin; }
            set { _kilosCojin = value; }
        }
        public string NombreSoli
        {
            get { return _nombreSoli; }
            set { _nombreSoli = value; }
        }
        public string KilosPreQ
        {
            get { return _kilosPreQ; }
            set { _kilosPreQ = value; }
        }
        public string NombreClt
        {
            get { return _nombreClt; }
            set { _nombreClt = value; }
        }
        public int DocumentoId
        {
            get { return _documentoId; }
            set { _documentoId = value; }
        }

        public int PedidoId
        {
            get { return _pedidoId; }
            set { _pedidoId = value; }
        }
        public string Responsable
        {
            get { return _responsable; }
            set { _responsable = value; }
        }
        public string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }
        public DateTime FechaModificacion
        {
            get { return _fechaModificacion; }
            set { _fechaModificacion = value; }
        }
        public string DatoXml
        {
            get { return _datoXml; }
            set { _datoXml = value; }
        }
        public int StatusId
        {
            get { return _statusId; }
            //set { _statusId = value; }
        }

        public WFFormularioPedidos() { }

        public static List<WFFormularioPedidos> ObtenerPedidos(int _idPh)
        {
            List<WFFormularioPedidos> lstPedidos = new List<WFFormularioPedidos>();
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.WF_ObtenerPedidos, _idPh);

            while (dr.Read())
            {
                WFFormularioPedidos Pedidos = new WFFormularioPedidos();

                Pedidos._userId = dr.GetInt32(0);
                //Pedidos._fechaIngreso = dr.GetDateTime(2);
                //Pedidos._fechaModificacion = dr.GetDateTime(3);
                Pedidos._datoXml = dr.GetString(1);
                Pedidos._statusId = dr.GetInt32(2);
                Pedidos._documentoId = dr.GetInt32(3);
                Pedidos._nombreClt = dr.GetString(4);
                Pedidos._kilosPreQ = dr.GetString(5);
                Pedidos._nombreSoli = dr.GetString(6);
                Pedidos._kilosCojin = dr.GetString(7);
                Pedidos._codigo = dr.GetInt32(8);
                Pedidos._kilosCordon = dr.GetString(9);
                Pedidos._fecha = dr.GetDateTime(10);
                Pedidos._kilosCemento = dr.GetString(11);
                Pedidos._contenedor = dr.GetString(12);
                Pedidos._kilosAlfa = dr.GetString(13);
                Pedidos._pesoTotal = dr.GetString(14);
                Pedidos._kilosPintura = dr.GetString(15);
                lstPedidos.Add(Pedidos);
            }

            return lstPedidos;
        }

        public static WFFormularioPedidos ObtenerPedido(int _idPh)
        {
            WFFormularioPedidos Pedidos = null;
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.WF_ObtenerPedidos, _idPh);

            if (dr.Read())
            {
                Pedidos = new WFFormularioPedidos();
                Pedidos._userId = dr.GetInt32(0);
                //Pedidos._fechaIngreso = dr.GetDateTime(2);
                //Pedidos._fechaModificacion = dr.GetDateTime(3);
                Pedidos._datoXml = dr.GetString(1);
                Pedidos._statusId = dr.GetInt32(2);
                Pedidos._documentoId = dr.GetInt32(3);
                Pedidos._nombreClt = dr.GetString(4);
                Pedidos._kilosPreQ = dr.GetString(5);
                Pedidos._nombreSoli = dr.GetString(6);
                Pedidos._kilosCojin = dr.GetString(7);
                Pedidos._codigo = dr.GetInt32(8);
                Pedidos._kilosCordon = dr.GetString(9);
                Pedidos._fecha = dr.GetDateTime(10);
                Pedidos._kilosCemento = dr.GetString(11);
                Pedidos._contenedor = dr.GetString(12);
                Pedidos._kilosAlfa = dr.GetString(13);
                Pedidos._pesoTotal = dr.GetString(14);
                Pedidos._kilosPintura = dr.GetString(15);
                Pedidos._pedidoId = _idPh;
            }

            return Pedidos;
        }

        //public static List<WFFormularioPedidos> ObtenerAccionesDescripcion()
        //{
        //    List<WFFormularioPedidos> lstPedidos = new List<WFFormularioPedidos>();
        //    SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.InsertarPedidos);

        //    while (dr.Read())
        //    {
        //        WFFormularioPedidos Pedidos = new WFFormularioPedidos();

        //        Pedidos._userId = dr.GetInt32(0);
        //        Pedidos._fechaIngreso = dr.GetDateTime(1);
        //        Pedidos._fechaModificacion = dr.GetDateTime(2);
        //        Pedidos._datoXml = dr.GetString(3);
        //        Pedidos._statusId = dr.GetInt32(4);

        //        lstPedidos.Add(Pedidos);
        //    }

        //    return lstPedidos;
        //}

        //public static List<WFFormularioPagos> InsertarPagos(List<WFFormularioPagos> lstPagos)
        //{
            //List<WFFormularioPagos> lstPagos = new List<WFFormularioPagos>();
        //    WFFormularioPedidos Pagos = new WFFormularioPedidos(); 
            
        //    SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.InsertarPagos
               
        //    int resultado =(
        //        Pagos.UserId = 1; //_usuarioLogueado
        //        Pagos.FechaIngreso = DateTime.Now;
        //        Pagos.FechaModificacion = DateTime.Now;
        //        Pagos.DatoXml = strData;
        //        Pagos.StatusId = 1;
        //);
        //    return resultado ;
        //}

        public static int InsertarPedidos(WFFormularioPedidos InsertarPedidos)
        {
            int nResultado = 0;
            try
            {
                object obj = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.WF_InsertarPedidos,
                InsertarPedidos.PedidoId,
                InsertarPedidos.UserId,
                InsertarPedidos.FechaIngreso,
                InsertarPedidos.FechaModificacion,
                InsertarPedidos.DatoXml,
                InsertarPedidos.StatusId,
                InsertarPedidos.DocumentoId,
                InsertarPedidos.NombreClt,
                InsertarPedidos.KilosPreQ,
                InsertarPedidos.NombreSoli,
                InsertarPedidos.KilosCojin,
                InsertarPedidos.Codigo,
                InsertarPedidos.KilosCordon,
                InsertarPedidos.Fecha,
                InsertarPedidos.KilosCemento,
                InsertarPedidos.Contenedor,
                InsertarPedidos.KilosAlfa,
                InsertarPedidos.PesoTotal,
                InsertarPedidos.KilosPintura
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

            return nResultado;
        }


    }
}
