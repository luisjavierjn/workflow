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
	/// Summary description for WFTipoDeTipo.
	/// </summary>
	public class WFTipoDeDato
	{
		private int _intCodTipoDeDato;
		private string _strNbrTipoDeDato;

		public int intCodTipoDeDato
		{
			get { return _intCodTipoDeDato; }
			set { _intCodTipoDeDato = value; }
		}

		public string strNbrTipoDeDato
		{
			get { return _strNbrTipoDeDato; }
			set { _strNbrTipoDeDato = value; }
		}

		public WFTipoDeDato(int intCodTipoDeDato, string strNbrTipoDeDato)
		{
			_intCodTipoDeDato = intCodTipoDeDato;
			_strNbrTipoDeDato = strNbrTipoDeDato;
		}

		public WFTipoDeDato()
		{
			_intCodTipoDeDato = 0;
			_strNbrTipoDeDato = "";
		}

		public static ArrayList ObtenerTiposDeDato()
		{
			ArrayList Catalogo = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerTiposDeDato);            
			
			WFTipoDeDato objInicial = new WFTipoDeDato(0,"[Seleccione]");
			Catalogo.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFTipoDeDato objTipoDeDato = new WFTipoDeDato();
				objTipoDeDato.intCodTipoDeDato = Convert.ToInt32(r[0]);
				objTipoDeDato.strNbrTipoDeDato = r[1].ToString();
				Catalogo.Add(objTipoDeDato);
			}
			return Catalogo;
		}

		public static WFTipoDeDato ObtenerTiposDeDatoPorID(int intCodTipoDeDato)
		{
			WFTipoDeDato objTipoDeDato = null;
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerTipoDeDatoPorID,intCodTipoDeDato);
			
			if(ds.Tables[0].Rows.Count > 0)
			{
				DataRow r = ds.Tables[0].Rows[0];
				objTipoDeDato = new WFTipoDeDato();
				objTipoDeDato.intCodTipoDeDato = Convert.ToInt32(r[0]);
				objTipoDeDato.strNbrTipoDeDato = r[1].ToString();
			}
			return objTipoDeDato;
		}

	} // Fin de la Clase
} // Fin del Namespace
