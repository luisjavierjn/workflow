using System;
using System.Collections;
using Componentes.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Componentes.BLL.SE;

namespace Componentes.BLL.WF
{
	/// <summary>
	/// Summary description for WFCondicion.
	/// </summary>
	public class WFCondicion
	{
		private int _intCodCondicion;
		private string _strNbrCondicion;

		public int intCodCondicion
		{
			get { return _intCodCondicion; }
			set { _intCodCondicion = value; }
		}

		public string strNbrCondicion
		{
			get { return _strNbrCondicion; }
			set { _strNbrCondicion = value; }
		}

		public WFCondicion(int intCodCondicion, string strNbrCondicion)
		{
			_intCodCondicion = intCodCondicion;
			_strNbrCondicion = strNbrCondicion;
		}

		public WFCondicion()
		{
			_intCodCondicion = 0;
			_strNbrCondicion = "";
		}

		public static ArrayList ObtenerCondiciones()
		{
			ArrayList Catalogo = new ArrayList();
            DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerCondiciones);
			
			WFCondicion objInicial = new WFCondicion(0,"[Seleccione]");
			Catalogo.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFCondicion objCondicion = new WFCondicion();
				objCondicion.intCodCondicion = Convert.ToInt32(r[0]);
				objCondicion.strNbrCondicion = r[2].ToString();
				Catalogo.Add(objCondicion);
			}
			return Catalogo;
		}

		public static WFCondicion ObtenerCondicionPorID(int intCodCondicion)
		{
			WFCondicion objCondicion = null;
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), Queries.WF_ObtenerCondicionPorID,intCodCondicion);
			
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow r = ds.Tables[0].Rows[0];
				objCondicion = new WFCondicion();
				objCondicion.intCodCondicion = Convert.ToInt32(r[0]);
				objCondicion.strNbrCondicion = r[1].ToString();
			}
			return objCondicion;
		}

		public static int ObtenerCondicionContrariaID(int intCodCondicion)
		{
			int retVal = 0;
			Math.DivRem(intCodCondicion,2,out retVal);
			return retVal > 0 ? intCodCondicion + 1 : intCodCondicion - 1;
		}

	} // Fin de la Clase
} // Fin del Namespace
