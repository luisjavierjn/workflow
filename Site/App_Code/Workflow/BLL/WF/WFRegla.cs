using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Componentes.DAL;
using System.Configuration;
using Componentes.BLL.SE;

namespace Componentes.BLL.WF
{
	/// <summary>
	/// Summary description for WFRegla.
	/// </summary>
	public class WFRegla
	{
		private int _workflowId;

		private int _IntervaloAprobacion;
		private int _IntervaloCorreccion;
		private int _NumRecordatorios;

		private int _codLapsoAprobacion;
		private int _codLapsoCorreccion;

		public int WorkflowId
		{
			get
			{
				return _workflowId;
			}
		}

		public int intIntervaloAprobacion
		{
			get
			{
				return _IntervaloAprobacion;
			}
			set
			{
				_IntervaloAprobacion = value;
			}
		}

		public int intIntervaloCorreccion
		{
			get
			{
				return _IntervaloCorreccion;
			}
			set
			{
				_IntervaloCorreccion = value;
			}
		}

		public int intNumRecordatorios
		{
			get
			{
				return _NumRecordatorios;
			}
			set
			{
				_NumRecordatorios = value;
			}
		}

		public int intCodLapsoAprobacion
		{
			get
			{
				return _codLapsoAprobacion;
			}
			set
			{
				_codLapsoAprobacion = value;
			}
		}

		public int intCodLapsoCorreccion
		{
			get
			{
				return _codLapsoCorreccion;
			}
			set
			{
				_codLapsoCorreccion = value;
			}
		}

		public WFRegla(int workflowId)
		{
			_workflowId = workflowId;

            SqlDataReader sdr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(), Queries.WF_ObtenerReglas, workflowId);

			if(sdr.Read())
			{
				intIntervaloAprobacion = sdr.GetInt32(0);
				intIntervaloCorreccion = sdr.GetInt32(1);
				intNumRecordatorios = sdr.GetInt32(2);
				
				intCodLapsoAprobacion = sdr.GetInt32(3);
				intCodLapsoCorreccion = sdr.GetInt32(4);
			}
		}

		public void ActualizarReglas()
		{
			SqlHelper.ExecuteNonQuery(ESSeguridad.FormarStringConexion(),Queries.WF_ActualizarReglas,WorkflowId,intIntervaloAprobacion,intIntervaloCorreccion,intNumRecordatorios,intCodLapsoAprobacion,intCodLapsoCorreccion);
		}
	}
}
