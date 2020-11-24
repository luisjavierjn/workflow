//Desarrollado por: Yonny Florez.
//Fecha de Creación: 09/09/2005
using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Collections;
using Componentes.DAL;
using Mensajeria;
using Componentes.BLL.SE;

namespace Componentes.BLL.WF
{
	/// <summary>
	/// Clase principal para el manejo del historial de aprobación de un documento
	/// </summary>
	public class WFHistoricoWorkflow
	{
		private int _intEmpleadoAprobador;
		private string _strEmpleadoAprobador;
		private string _strCargoAprobador;
		private string _strObservaciones;
		private string _strEstatus;
		private DateTime _dttFecha;

		public int intEmpleadoAprobador
		{
			get { return _intEmpleadoAprobador; }
			set { _intEmpleadoAprobador = value; }
		}

		public string strEmpleadoAprobador
		{
			get { return _strEmpleadoAprobador; }
			set { _strEmpleadoAprobador = value; }
		}

		public string strCargoAprobador
		{
			get { return _strCargoAprobador; }
			set { _strCargoAprobador = value; }
		}

		public string strObservaciones
		{
			get { return _strObservaciones; }
			set { _strObservaciones = value; }
		}

		public string strEstatus
		{
			get { return _strEstatus; }
			set { _strEstatus = value; }
		}

		public DateTime dttFecha
		{
			get { return _dttFecha; }
			set { _dttFecha = value; }
		}

		public WFHistoricoWorkflow()
		{
		}

		/// <summary>
		/// Muestra el historial de aprobadores para un documento determinado
		/// </summary>
		/// <param name="intWorkflow">Identificador del Workflow del documento</param>
		/// <param name="strReferencia">Identificador del documento</param>
		/// <returns>Arreglo con el historial de los aprobadores para un documento determinado</returns>
		public static ArrayList ListarHistoricoWorkflow(int intWorkflow, string strReferencia)
		{
			ArrayList arrHistorico = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ListarHistoricoWorkflow, intWorkflow, strReferencia); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFHistoricoWorkflow objHistorico = new WFHistoricoWorkflow();
				
				objHistorico.intEmpleadoAprobador = Convert.ToInt32(r["cwi_cod_staff_destino"]);
				objHistorico.dttFecha = Convert.ToDateTime(r["hwf_fecha_historico"]);
				objHistorico.strEmpleadoAprobador = Convert.ToString(r["emp_nbr_empleado"]);
				objHistorico.strCargoAprobador = Convert.ToString(r["cat_desc_categoria"]);
				objHistorico.strObservaciones = Convert.ToString(r["hwf_str_observaciones"]);
				objHistorico.strEstatus = Convert.ToString(r["ewf_nbr_estatusdoc"]);

				arrHistorico.Add(objHistorico);
			}
			return arrHistorico;
		}
	}
}
