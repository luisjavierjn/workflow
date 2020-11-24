
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using Componentes.DAL;
using Componentes.BLL.SE;

namespace Componentes.BLL
{
	/// <summary>
	/// Clase que representa los mensajes de error del sistema.
	/// </summary>
	public class ESMensajes
	{
		// Constructores
		public ESMensajes()
		{
		}

		/// <summary>
		/// Método que Obtiene el mensaje de  error asociado con el código de error especificado
		/// </summary>
		/// <param name="CodMensaje">El código de error</param>
		/// <returns></returns>
		public static string ObtenerMensaje(int intCodMensaje)
		{
			string strMensaje;

            DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), Queries.WF_ObtenerMensaje, intCodMensaje);            
			strMensaje = ds.Tables[0].Rows[0]["mensaje"].ToString();
			return strMensaje;
		}
	}
}
