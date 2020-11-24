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
/// Descripción breve de WFFormularioPagos
/// </summary>

namespace Componentes.BLL.WF
{
    public class WFFormularioPagos
    {
        int _pagoId;
        int _userId;
        DateTime _fechaIngreso;
        DateTime _fechaModificacion;
        string _datoXml;
        int _statusId;
        int _documentoId;

        string _moneda;
        string _tipoTransaccion;
        string _cuenta;
        int _nroTransaccion;
        DateTime _fecha;
        string _monto;
        string _observaciones;
        string _nombreClt;

        public string NombreClt
        {
            get { return _nombreClt; }
            set { _nombreClt = value; }
        }
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        public string Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public int NroTransaccion
        {
            get { return _nroTransaccion; }
            set { _nroTransaccion = value; }
        }
        public string Cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }
        public string TipoTransaccion
        {
            get { return _tipoTransaccion; }
            set { _tipoTransaccion = value; }
        }
        public string Moneda
        {
            get { return _moneda; }
            set { _moneda = value; }
        }
        public int DocumentoId
        {
            get { return _documentoId; }
            set { _documentoId = value; }
        }
        public int PagoId
        {
            get { return _pagoId; }
            set { _pagoId = value; }
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
            set { _statusId = value; }
        }

        public WFFormularioPagos()
        { }

        //public static List<WFFormularioPagos> ObtenerAccionesDescripcion()
        //{
        //    List<WFFormularioPagos> lstPagos = new List<WFFormularioPagos>();
        //    SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.InsertarPagos);

        //    while (dr.Read())
        //    {
        //        WFFormularioPagos Pagos = new WFFormularioPagos();

        //        Pagos._userId = dr.GetInt32(0);
        //        Pagos._fechaIngreso = dr.GetDateTime(1);
        //        Pagos._fechaModificacion = dr.GetDateTime(2);
        //        Pagos._datoXml = dr.GetString(3);
        //        Pagos._statusId = dr.GetInt32(4);

        //        lstPagos.Add(Pagos);
        //    }

        //    return lstPagos;
        //}

        public static List<WFFormularioPagos> ObtenerPagos(int _idPh)
        {
            List<WFFormularioPagos> lstPagos = new List<WFFormularioPagos>();
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.WF_ObtenerPagos, _idPh);

            while (dr.Read())
            {
                WFFormularioPagos Pagos = new WFFormularioPagos();

                Pagos._userId = dr.GetInt32(0);
                //Pagos._fechaIngreso = dr.GetDateTime(2);
                //Pagos._fechaModificacion = dr.GetDateTime(3);
                Pagos._datoXml = dr.GetString(1);
                Pagos._statusId = dr.GetInt32(2);
                Pagos._documentoId = dr.GetInt32(3);
                Pagos._moneda = dr.GetString(4);
                Pagos._tipoTransaccion = dr.GetString(5);
                Pagos._cuenta = dr.GetString(6) ;
                Pagos._nroTransaccion = dr.GetInt32(7);
                Pagos._fecha = dr.GetDateTime(8); 
                Pagos._monto = dr.GetString(9); 
                Pagos._observaciones = dr.GetString(10);
                Pagos._nombreClt = dr.GetString(11);
                lstPagos.Add(Pagos);
            }

            return lstPagos;
        }

        //public static List<WFFormularioPagos> InsertarPagos(List<WFFormularioPagos> lstPagos)
        //{
        //    //List<WFFormularioPagos> lstPagos = new List<WFFormularioPagos>();
        //    WFFormularioPedidos Pagos = new WFFormularioPedidos(); 
            
        //    SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.InsertarPagos
               
        //    int resultado =(
        //        Pagos.UserId = 1; //_usuarioLogueado
        //        Pagos.FechaIngreso = DateTime.Now;
        //        Pagos.FechaModificacion = DateTime.Now;
        //        Pagos.DatoXml = strData;
        //        Pagos.StatusId = 1;
        //)
        //    return resultado ;
        //}

        public static int InsertarPagos(WFFormularioPagos InsertarPagos)
        {
            int nResultado = 0;
            try
            {
                object obj = SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.WF_InsertarPagos,
                InsertarPagos.UserId,
                InsertarPagos.FechaIngreso,
                InsertarPagos.FechaModificacion,
                InsertarPagos.DatoXml,
                InsertarPagos.StatusId,
                InsertarPagos.DocumentoId,
                InsertarPagos.Moneda,
                InsertarPagos.TipoTransaccion,
                InsertarPagos.Cuenta,
                InsertarPagos.NroTransaccion,
                InsertarPagos.Fecha,
                InsertarPagos.Monto,
                InsertarPagos.Observaciones);

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

