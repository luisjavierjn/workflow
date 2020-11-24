//Desarrollado por: Yonny Florez.
//Fecha de Creación: 28/02/2006

using System;
using System.Xml;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Componentes.DAL;
using System.Configuration;

namespace Componentes.BLL.SE
{
	public class ESTipoLog
	{
		private short _shtTipoLog = 0;
		private string _strTipoLog = string.Empty;

		public short shtTipoLog
		{
			get { return _shtTipoLog; }
			set { _shtTipoLog = value; }
		}

		public string strTipoLog
		{
			get { return _strTipoLog; }
			set { _strTipoLog = value; }
		}
		
		public ESTipoLog()
		{
		}

		public ESTipoLog(short shtTipoLogInicial, string strTipoLogInicial)
		{
			this._shtTipoLog = shtTipoLogInicial;
			this._strTipoLog = strTipoLogInicial;
		}

		public static ArrayList ListarTipoLog()
		{
			ArrayList TipoLog = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarTipoLog); 
			
			ESTipoLog objInicial = new ESTipoLog(0,"[Seleccione]");
			TipoLog.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESTipoLog objTipoLog = new ESTipoLog();
				objTipoLog.shtTipoLog = Convert.ToInt16(r["tdl_cod_tipo_log"]);
				objTipoLog.strTipoLog = Convert.ToString(r["tdl_desc_tipo_log"]);
				TipoLog.Add(objTipoLog);
			}

			return TipoLog;
		}

	}

	public class ESTipoTransaccion
	{
		private short _shtTipoTransaccion = 0;
		private string _strTipoTransaccion = string.Empty;

		public short shtTipoTransaccion
		{
			get { return _shtTipoTransaccion; }
			set { _shtTipoTransaccion = value; }
		}

		public string strTipoTransaccion
		{
			get { return _strTipoTransaccion; }
			set { _strTipoTransaccion = value; }
		}

		public ESTipoTransaccion()
		{
		}

		public ESTipoTransaccion(short shtTipoTransaccionInicial, string strTipoTransaccionInicial)
		{
			this._shtTipoTransaccion = shtTipoTransaccionInicial;
			this._strTipoTransaccion = strTipoTransaccionInicial;
		}

		public static ArrayList ListarTipoTransaccion()
		{
			ArrayList TipoTransaccion = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarTipoTransaccion); 
			
			ESTipoTransaccion objInicial = new ESTipoTransaccion(0,"[Seleccione]");
			TipoTransaccion.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESTipoTransaccion objTipoTransaccion = new ESTipoTransaccion();
				objTipoTransaccion.shtTipoTransaccion = Convert.ToInt16(r["ttr_cod_tipo_transaccion"]);
				objTipoTransaccion.strTipoTransaccion = Convert.ToString(r["ttr_desc_tipo_transaccion"]);
				TipoTransaccion.Add(objTipoTransaccion);
			}

			return TipoTransaccion;
		}
	}

	public class ESLog
	{
//		private long _lngCodigo = 0;
		private DateTime _dttFechaHora;
		private int _intEmpleado = 0;
		private string _strEmpleado = string.Empty;
		private string _strUsuario = string.Empty;
		private string _strEquipo = string.Empty;
		
		public enum TipoLog 
		{
			Informativo = 1,
			Error
		}

		public enum TipoTransaccion
		{
			Insertar = 1,
			Actualizar,
			Desconocida,
			Eliminar,
		}
		
		private string _strRequerimiento = string.Empty;
		private short _shtModulo = 0;
		private string _strModulo = string.Empty;
		private string _strReferencia = string.Empty;
		private string _strLog = string.Empty;
		private short _shtTipoLog = 0;
		private string _strTipoLog = string.Empty;
		private short _shtTipoTransaccion = 0;
		private string _strTipoTransaccion = string.Empty;

		public short shtTipoTransaccion
		{
			get { return _shtTipoTransaccion; }
			set { _shtTipoTransaccion = value; }
		}

		public string strTipoTransaccion
		{
			get { return _strTipoTransaccion; }
			set { _strTipoTransaccion = value; }
		}

		public short shtTipoLog
		{
			get { return _shtTipoLog; }
			set { _shtTipoLog = value; }
		}

		public string strTipoLog
		{
			get { return _strTipoLog; }
			set { _strTipoLog = value; }
		}

		public DateTime dttFechaHora
		{
			get { return _dttFechaHora; }
			set { _dttFechaHora = value; }
		}

		public int intEmpleado
		{
			get { return _intEmpleado; }
			set { _intEmpleado = value; }
		}

		public string strEmpleado
		{
			get { return _strEmpleado; }
			set { _strEmpleado = value; }
		}

		public string strUsuario
		{
			get { return _strUsuario; }
			set { _strUsuario = value; }
		}

		public string strEquipo
		{
			get { return _strEquipo; }
			set { _strEquipo = value; }		
		}

		public string strRequerimiento
		{
			get { return _strRequerimiento; }
			set { _strRequerimiento = value; }
		}

		public short shtModulo
		{
			get { return _shtModulo; }
			set { _shtModulo = value; }
		}

		public string strModulo
		{
			get { return _strModulo; }
			set { _strModulo = value; }
		}

		public string strLog
		{
			get { return _strLog; }
			set { _strLog = value; }
		}

		public string strReferencia
		{
			get { return _strReferencia; }
			set { _strReferencia = value; }
		}

		public ESLog()
		{
			
		}

		/// <summary>
		/// Registra el Log de auditoría del sistema
		/// </summary>
		/// <param name="Empleado">Empleado activo en la aplicación</param>
		/// <param name="Equipo">Equipo desde el cual ingreso a la aplicacion. Se obtiene de la variable Session["Host"]</param>
		/// <param name="TLog">Tipo de Log. Se Obtiene de Componentes.BLL.SE.ESLog.TipoLog</param>
		/// <param name="TTransaccion">Tipo de Transacción. Se obtiene de Componentes.BLL.SE.ESLog.TipoTransaccion</param>
		/// <param name="Requerimiento">Requerimiento activo</param>
		/// <param name="Modulo">Módulo al cual pertenece el requerimiento activo</param>
		/// <param name="Referencia">Referencia o identificador del documento sobre el cual se marca el Log</param>
		/// <param name="Log">String con información adicional</param>
		/// <returns>bool</returns>
		public static bool Log(int Empleado, string Equipo, TipoLog TLog, TipoTransaccion TTransaccion, string Requerimiento, short Modulo, string Referencia, string Log)
		{
			bool retVal =  Convert.ToBoolean(SqlHelper.ExecuteScalar(
				ESSeguridad.FormarStringConexion(), Queries.ES_InsertarLog, 
				Empleado,
				Equipo,
				TLog,
				TTransaccion,
				Requerimiento,
				Modulo,
				Referencia,
				Log
				));

			return retVal;
		}

		public static ESColeccionLog ListarLog(string dttFechaDesde, string dttFechaHasta, short shtTipoBusqueda, short shtAccionBusqueda, string strContiene)
		{
			ESColeccionLog Log = new ESColeccionLog();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarLog,dttFechaDesde,dttFechaHasta,shtTipoBusqueda,shtAccionBusqueda,strContiene); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESLog objLog = new ESLog();
				objLog.dttFechaHora = Convert.ToDateTime(r["rdt_val_hora_fecha"]);
				objLog.intEmpleado = Convert.ToInt32(r["rdt_cod_empleado"]);
				objLog.strUsuario = Convert.ToString(r["usu_str_login"])==""?"N/A":Convert.ToString(r["usu_str_login"]);
				objLog.strEquipo = Convert.ToString(r["rdt_str_equipo"])==""?"N/A":Convert.ToString(r["rdt_str_equipo"]);
				objLog.strModulo = Convert.ToString(r["mod_desc_modulo"]);
				objLog.strReferencia = Convert.ToString(r["rdt_str_referencia"]);
				objLog.strRequerimiento = Convert.ToString(r["rdt_str_requerimiento"]);
				objLog.strTipoLog = Convert.ToString(r["tdl_desc_tipo_log"]);
				objLog.strTipoTransaccion = Convert.ToString(r["ttr_desc_tipo_transaccion"]);
				objLog.shtTipoTransaccion = Convert.ToInt16(r["rdt_cod_tipo_transaccion"]);

				if(((ESLog.TipoTransaccion) objLog.shtTipoTransaccion) == ESLog.TipoTransaccion.Desconocida)
					objLog.strLog = Convert.ToString(r["rdt_str_log"]);
				else
					objLog.strLog = (objLog.strModulo!=""?objLog.strModulo.Trim() + " / ":"") + (objLog.strRequerimiento!=""?objLog.strRequerimiento.Trim() + " / ":"") + (objLog.strReferencia!=""?objLog.strReferencia.Trim() + " / ":"") + Convert.ToString(r["rdt_str_log"]);
				
				objLog.shtTipoLog = Convert.ToInt16(r["rdt_cod_tipo_log"]);

				Log.Add(objLog);
			}

			return Log;
		}
	}
}
