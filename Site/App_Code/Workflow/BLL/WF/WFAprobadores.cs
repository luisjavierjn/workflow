using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Collections;
using Componentes.DAL;
using Componentes.BLL.SE;

namespace Componentes.BLL
{
	/// <summary>
	/// Summary description for ESAprobadores.
	/// </summary>
	public class WFAprobadores
	{
		private int _intEmpleado = 0;
		private string _strEmpleado = string.Empty;
		private int _intCargo = 0;
		
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

		public int intCargo
		{
			get { return _intCargo; }
			set { _intCargo = value; }
		}

		public WFAprobadores()
		{
		}

		public WFAprobadores(int ID, string Nombre)
		{
			_intEmpleado = ID;
			_strEmpleado = Nombre;
		}

		public static ArrayList ListarAprobadores(int intWorkflow, string strReferencia, string strRuta)
		{
			ArrayList Aprobadores = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ListaAprobacion, intWorkflow, strReferencia, strRuta); 
			
			WFAprobadores objInicial = new WFAprobadores(0,"[Seleccione]");
			Aprobadores.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFAprobadores objAprobador = new WFAprobadores();
				objAprobador.intEmpleado = Convert.ToInt32(r["emp_cod_empleado"]);
				objAprobador.strEmpleado = r["emp_nombre"].ToString();
				Aprobadores.Add(objAprobador);
			}
			return Aprobadores;
		}

		public static WFAprobadores ConsultarAprobadorWorkflow(int intWorkflow, string strReferencia, int intEmpleado)
		{
			WFAprobadores Aprobador = new WFAprobadores();

			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ConsultarAprobadorWorkflow, intWorkflow, strReferencia, intEmpleado); 

			if(ds.Tables[0].Rows.Count > 0)
			{
				Aprobador.intEmpleado = Convert.ToInt32(ds.Tables[0].Rows[0]["emp_cod_empleado"]);
				Aprobador.strEmpleado = Convert.ToString(ds.Tables[0].Rows[0]["emp_nbr_empleado"]);
			}

			return Aprobador;
		}

        public static WFAprobadores ConsultarAprobadorActual(int intWorkflow, string strReferencia, int intEmpleado)
        {
            WFAprobadores Aprobador = new WFAprobadores();

            DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), Queries.WF_ConsultarAprobadorActual, intWorkflow, strReferencia, intEmpleado);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Aprobador.intEmpleado = Convert.ToInt32(ds.Tables[0].Rows[0]["emp_cod_empleado"]);
                Aprobador.strEmpleado = Convert.ToString(ds.Tables[0].Rows[0]["emp_nbr_empleado"]);
            }

            return Aprobador;
        }

		/// Permite obtener el código de staff del empleado que ocupa un Rol de LoS

		public bool ObtenerCodigoLiderLoS(short shtLoS)
		{
			DataSet dst = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), 
				Queries.WF_ObtenerSocioLiderCodigo, shtLoS); 

			if (dst.Tables[0].Rows.Count < 1)
				return false;

			DataRow drw = dst.Tables[0].Rows[0];
			intEmpleado = Convert.ToInt32(drw["rla_cod_empleado"]);
			return true;
		}

		public bool ObtenerCodigoSocioPrincipal()
		{
			DataSet dst = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), 
				Queries.WF_ObtenerSocioPrincipalCodigo); 

			if (dst.Tables[0].Rows.Count < 1)
				return false;

			DataRow drw = dst.Tables[0].Rows[0];
			intEmpleado = Convert.ToInt32(drw["rla_cod_empleado"]);
			return true;
		}

	}
}
