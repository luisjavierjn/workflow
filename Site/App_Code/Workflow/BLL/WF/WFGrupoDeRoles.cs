using System;
using System.Data;
using System.Configuration;
using System.Collections;
using Componentes.DAL;
using Componentes.BLL.SE;

namespace Componentes.BLL.WF
{
	/// <summary>
	/// Summary description for WFRol.
	/// </summary>
	public class WFGrupoDeRoles
	{
		private int _intCodRoles;
		private string _strNbrRoles;

		public int intCodRoles
		{
			get { return _intCodRoles; }
			set { _intCodRoles = value; }
		}

		public string strNbrRoles
		{
			get { return _strNbrRoles; }
			set { _strNbrRoles = value; }
		}

		public WFGrupoDeRoles()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static ArrayList ObtenerGruposDeRolesExcepto(int intCodRuta)
		{
			ArrayList arrGrupoDeRoles = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), Queries.WF_ObtenerGrupoDeRolesExcepto, intCodRuta); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFGrupoDeRoles objGrupoDeRoles = new WFGrupoDeRoles();
				
				objGrupoDeRoles.intCodRoles = Convert.ToInt32(r["rls_cod_rolasoc"]);
				objGrupoDeRoles.strNbrRoles = Convert.ToString(r["rls_nbr_rolasoc"]);

				arrGrupoDeRoles.Add(objGrupoDeRoles);
			}
			return arrGrupoDeRoles;
		}

		public static ArrayList ObtenerGruposDeRoles(int intCodRuta)
		{
			ArrayList arrGrupoDeRoles = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerGrupoDeRoles, intCodRuta); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFGrupoDeRoles objGrupoDeRoles = new WFGrupoDeRoles();
				
				objGrupoDeRoles.intCodRoles = Convert.ToInt32(r["rls_cod_rolasoc"]);
				objGrupoDeRoles.strNbrRoles = Convert.ToString(r["rls_nbr_rolasoc"]);

				arrGrupoDeRoles.Add(objGrupoDeRoles);
			}
			return arrGrupoDeRoles;
		}

		public static ArrayList ObtenerGruposDeRoles(int intCodRuta,string strRuta)
		{
			int i = 0;
			int j = 0;
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerGrupoDeRoles, intCodRuta); 
			string [] arrStrRuta = strRuta.Split(';');
			int [] arrIntRuta = new int[arrStrRuta.Length-1];
			WFGrupoDeRoles [] arrGDR = new WFGrupoDeRoles[arrIntRuta.Length];
			ArrayList arrGrupoDeRoles = new ArrayList();
			for(i = 0; i< arrIntRuta.Length; i++) arrIntRuta[i] = Convert.ToInt32(arrStrRuta[i]);
			/*
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFGrupoDeRoles objGrupoDeRoles = new WFGrupoDeRoles();
				
				objGrupoDeRoles.intCodRoles = Convert.ToInt32(r["rls_cod_rolasoc"]);
				objGrupoDeRoles.strNbrRoles = Convert.ToString(r["rls_nbr_rolasoc"]);

				for(j = 0; j < arrIntRuta.Length; j++)
				{
					if(arrIntRuta[j] == objGrupoDeRoles.intCodRoles) 
					{
						arrGDR[j] = objGrupoDeRoles;
						break;
					}
				}
			}
            */
            
            for (j = 0; j < arrIntRuta.Length; j++)
            {
                WFGrupoDeRoles objGrupoDeRoles = new WFGrupoDeRoles();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    objGrupoDeRoles.intCodRoles = Convert.ToInt32(r["rls_cod_rolasoc"]);
                    objGrupoDeRoles.strNbrRoles = Convert.ToString(r["rls_nbr_rolasoc"]);

                    if (arrIntRuta[j] == objGrupoDeRoles.intCodRoles)
                    {
                        arrGDR[j] = objGrupoDeRoles;
                        break;
                    }
                }
            }

			for(j = 0; j < arrIntRuta.Length; j++) arrGrupoDeRoles.Add(arrGDR[j]);
			return arrGrupoDeRoles;
		}
	}
}
