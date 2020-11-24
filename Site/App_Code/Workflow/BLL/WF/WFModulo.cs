using System;
using System.Data;
using Componentes.DAL;
using System.Configuration;
using System.Collections;
using Componentes.BLL.SE;

namespace Componentes.BLL.WF
{
	/// <summary>
	/// Summary description for WFDocumento.
	/// </summary>
	public class WFModulo
	{
		private int _intCodModulo;
		private string _strNbrModulo;

		public int intCodModulo
		{
			get { return _intCodModulo; }
			set { _intCodModulo = value; }
		}

		public string strNbrModulo
		{
			get { return _strNbrModulo; }
			set { _strNbrModulo = value; }
		}

		public WFModulo(int intCodModulo, string strNbrModulo)
		{
			_intCodModulo = intCodModulo;
			_strNbrModulo = strNbrModulo;
		}

		public WFModulo()
		{
			_intCodModulo = 0;
			_strNbrModulo = "";
		}

		public static ArrayList ListarModulos()
		{
			ArrayList Catalogo = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerModulos);            
			
			WFModulo objInicial = new WFModulo(0,"[Seleccione]");
			Catalogo.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFModulo objModulo = new WFModulo();
				objModulo.intCodModulo = Convert.ToInt32(r[0]);
				objModulo.strNbrModulo = r[1].ToString();
				Catalogo.Add(objModulo);
			}
			return Catalogo;
		}

		public static ArrayList ListarTodosModulos()
		{
			ArrayList Catalogo = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerTodosModulos); 
			
			WFModulo objInicial = new WFModulo(0,"[Seleccione]");
			Catalogo.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFModulo objModulo = new WFModulo();
				objModulo.intCodModulo = Convert.ToInt32(r[0]);
				objModulo.strNbrModulo = r[1].ToString();
				Catalogo.Add(objModulo);
			}
			return Catalogo;
		}

		public static ArrayList ListarTodosModulos(string strOpcionInicial)
		{
			ArrayList Catalogo = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerTodosModulos); 
			
			WFModulo objInicial = new WFModulo(0, strOpcionInicial);
			Catalogo.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFModulo objModulo = new WFModulo();
				objModulo.intCodModulo = Convert.ToInt32(r[0]);
				objModulo.strNbrModulo = r[1].ToString();
				Catalogo.Add(objModulo);
			}
			return Catalogo;
		}
	}
}
