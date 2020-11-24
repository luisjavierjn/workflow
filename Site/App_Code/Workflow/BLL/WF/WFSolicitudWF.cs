using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Componentes.DAL;
using System.Configuration;
//using ES.WS;
using Componentes.BLL.SE;

namespace Componentes.BLL.WF
{
	/// <summary>
	/// Summary description for WFSolicitudWF.
	/// </summary>
	public class WFSolicitudWF
	{
		private int _intSolicitud=0;
		private string _strReferencia=string.Empty;
		private int _intCodSolicitante=0;
		private string _strSolicitante=string.Empty;
		private int _intCodUltimoAprobador=0;
		private string _strUltimoAprobador=string.Empty;
		private int _intCodSiguienteAprobador=0;
		private string _strSiguienteAprobador=string.Empty;
		private short _shtCodEstatus=0;
		private string _strEstatus=string.Empty;
		private string _strWorkFlow=string.Empty;
		private short _shtWorkFlow=0;
		private int _intRolAsoc=0;
//===< By Ramón
		private DateTime _dttFechaCreacion;
		private DateTime _dttFechaRevision;
//===>

		public int intSolicitud
		{
			get { return _intSolicitud; }
			set { _intSolicitud = value; }
		}

		public string strReferencia
		{
			get { return _strReferencia; }
			set { _strReferencia = value; }
		}

		public int intCodSolicitante
		{
			get { return _intCodSolicitante; }
			set { _intCodSolicitante = value; }
		}

		public string strSolicitante
		{
			get { return _strSolicitante; }
			set { _strSolicitante = value; }
		}

		public int intCodUltimoAprobador
		{
			get { return _intCodUltimoAprobador; }
			set { _intCodUltimoAprobador = value; }
		}

		public string strUltimoAprobador
		{
			get { return _strUltimoAprobador; }
			set { _strUltimoAprobador = value; }
		}

		public int intCodSiguienteAprobador
		{
			get { return _intCodSiguienteAprobador; }
			set { _intCodSiguienteAprobador = value; }
		}

		public string strSiguienteAprobador
		{
			get { return _strSiguienteAprobador; }
			set { _strSiguienteAprobador = value; }
		}

		public short shtCodEstatus
		{
			get { return _shtCodEstatus; }
			set { _shtCodEstatus = value; }
		}

		public string strEstatus
		{
			get { return _strEstatus; }
			set { _strEstatus = value; }
		}
		public string strWorkFlow
		{
			get { return _strWorkFlow; }
			set { _strWorkFlow = value; }
		}
		public short shtWorkFlow
		{
			get { return _shtWorkFlow; }
			set { _shtWorkFlow = value; }
		}
		public int intRolAsoc
		{
			get { return _intRolAsoc; }
			set { _intRolAsoc = value; }
		}
//===< By Ramón
		public DateTime dttFechaCreacion
		{
			get { return _dttFechaCreacion; }
			set { _dttFechaCreacion = value; }
		}
		public DateTime dttFechaRevision
		{
			get { return _dttFechaRevision; }
			set { _dttFechaRevision = value; }
		}
//===>



		public WFSolicitudWF()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static ArrayList ListarWorkflow(int intCodModulo, int intCodWorkflow,string strSolicitante)
		{
			ArrayList arrWorkFlow = new ArrayList();
			DataSet dsWorkFlow = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
				Queries.WF_ListarSolicitudWorkflow,intCodWorkflow,strSolicitante);
			foreach(DataRow r in dsWorkFlow.Tables[0].Rows)
			{
				WFSolicitudWF WFSolicitud = new WFSolicitudWF();
				WFSolicitud.intSolicitud=Convert.ToInt32(r["swf_cod_solicitud"]);
				WFSolicitud.strReferencia=Convert.ToString(r["swf_str_referencia"]);
//===< By Ramón
				WFSolicitud.dttFechaCreacion = Convert.ToDateTime(r["swf_fecha_solicitud"]);
//===>
				WFSolicitud.intCodSolicitante=Convert.ToInt32(r["swf_cod_empleado_creador"]);
				WFSolicitud.strSolicitante=Convert.ToString(r["emp_nbr_empleado_creador"]);
				WFSolicitud.intCodUltimoAprobador=Convert.ToInt32(r["hwf_cod_empleado_origen"]);
				WFSolicitud.strUltimoAprobador=Convert.ToString(r["emp_nbr_empleado_ultimo"]);
//===< By Ramón
				WFSolicitud.dttFechaRevision = Convert.ToDateTime(r["hwf_fecha_historico"]);
//===>
				if(WFSolicitud.intCodSolicitante==WFSolicitud.intCodUltimoAprobador)
					WFSolicitud.strUltimoAprobador="---";

				WFSolicitud.intCodSiguienteAprobador=Convert.ToInt32(r["hwf_cod_empleado_destino"]);
				WFSolicitud.strSiguienteAprobador=Convert.ToString(r["emp_nbr_empleado_destino"]);
				WFSolicitud.shtCodEstatus=Convert.ToInt16(r["hwf_cod_estatuswkf"]);
				WFSolicitud.strEstatus=Convert.ToString(r["est_nbr_estatus"]);
				arrWorkFlow.Add(WFSolicitud);
			}		
			return arrWorkFlow;
		}

		public static ArrayList ListarWorkflowPorAprobador(int intCodModulo, int intCodWorkflow,int intCodAprobador, out int intRolAsocI)
		{
			ArrayList arrWorkFlow = new ArrayList();
			intRolAsocI=0;
			bool blnRolAsoc=true;
			DataSet dsWorkFlow = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
				Queries.WF_ListarSolicitudWorkflowPorAprobador,intCodModulo,intCodWorkflow,intCodAprobador);
			foreach(DataRow r in dsWorkFlow.Tables[0].Rows)
			{
				WFSolicitudWF WFSolicitud = new WFSolicitudWF();
				WFSolicitud.intSolicitud=Convert.ToInt32(r["swf_cod_solicitud"]);
				WFSolicitud.strReferencia=Convert.ToString(r["swf_str_referencia"]);
				//===< By Ramón
				WFSolicitud.dttFechaCreacion = Convert.ToDateTime(r["swf_fecha_solicitud"]);
				//===>
				WFSolicitud.intCodSolicitante=Convert.ToInt32(r["swf_cod_empleado_creador"]);
				WFSolicitud.strSolicitante=Convert.ToString(r["emp_nbr_empleado_creador"]);
				WFSolicitud.intCodUltimoAprobador=Convert.ToInt32(r["hwf_cod_empleado_origen"]);
				WFSolicitud.strUltimoAprobador=Convert.ToString(r["emp_nbr_empleado_ultimo"]);

				//===< By Ramón
				WFSolicitud.dttFechaRevision = Convert.ToDateTime(r["hwf_fecha_historico"]);
				//===>
				if(WFSolicitud.intCodSolicitante==WFSolicitud.intCodUltimoAprobador)
					WFSolicitud.strUltimoAprobador="---";

				WFSolicitud.intCodSiguienteAprobador=Convert.ToInt32(r["hwf_cod_empleado_destino"]);
				WFSolicitud.strSiguienteAprobador=Convert.ToString(r["emp_nbr_empleado_destino"]);
				WFSolicitud.strWorkFlow=Convert.ToString(r["WorkFlow"]);
				WFSolicitud.shtWorkFlow=Convert.ToInt16(r["CodWorkFlow"]);
				WFSolicitud.intRolAsoc=Convert.ToInt32(r["RolAsociado"]);
				if(blnRolAsoc)
				{
					intRolAsocI=WFSolicitud.intRolAsoc;
				}
				arrWorkFlow.Add(WFSolicitud);
			}		
			return arrWorkFlow;
		}

		public static bool ReversarWorkFlow(int intCodWorkFlow, string strReferencia,string strSolicitud)
		{
			try
			{
				SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),
					Queries.WF_ReversarWorkFlow, intCodWorkFlow,strReferencia,strSolicitud); 
				return true;
			}
			catch(Exception e)
			{
				System.Console.Write(e.Message);
				return false;
			}
		}

		public static bool ActualizarAprobadorHistorico(int intCodWorkFlow, string strReferencia,string strSolicitud, int intAprobadorNuevo)
		{
			try
			{
				SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),
					Queries.WF_ActualizarAprobadorHistorico, intCodWorkFlow,strReferencia,strSolicitud,intAprobadorNuevo); 
				return true;
			}
			catch(Exception e)
			{
				System.Console.Write(e.Message);
				return false;
			}
		}
		public static string VerificarViaje(int intCodWorkFlow,string strReferencia)
		{
			return Convert.ToString(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.WF_VerificarWFViaje, intCodWorkFlow,strReferencia)); 
		}
	}
}
