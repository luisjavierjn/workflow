using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Componentes.DAL;
using System.Configuration;
using WS;
using Componentes.BLL.SE;

namespace Componentes.BLL.WF
{
	/// <summary>
	/// Summary description for WFWorkflow.
	/// </summary>
	public class WFWorkflow
	{
		/*** PRIVATE FIELDS ***/

		private string       _Description;
		private int          _DocumentId;
		private int			 _Id;
		private string       _Name; 
		private string       _CreatorUserName;
		private string       _CreatorDisplayName;
		private DateTime     _DateCreated;

		/*** CONSTRUCTORS ***/

		public WFWorkflow(int id, int documentId, string name, string description)
			:this (id, documentId, name, description, String.Empty, String.Empty, DateTime.Now)
		{ }

		public WFWorkflow(int documentId, string name, string description, string creatorUsername)
			:this (-1, documentId, name, description, creatorUsername, String.Empty, DateTime.Now)
		{ }

		public WFWorkflow(int id, int documentId, string name, string description, string creatorUsername, string creatorDisplayName, DateTime dateCreated) 
		{
			// Validate Mandatory Fields//
			if (name == null ||name.Length==0)
				throw (new ArgumentOutOfRangeException("name"));

			_Id						  = id;
			_DocumentId               = documentId;
			_Name                     = name;
			_Description              = description;
			_CreatorUserName          = creatorUsername;
			//
			_CreatorDisplayName       = creatorDisplayName;
			_DateCreated              = dateCreated;
		}

		/*** PROPERTIES ***/

		public int Id 
		{
			get {return _Id;}
		}

		public int DocumentId
		{
			get {return _DocumentId;}
		}

		public string Name
		{
			get {return _Name;}
		}

		public string Description
		{
			get {return _Description;}
		}

		//		public string CreatorUserName 
		//		{
		//			get {return _CreatorUserName;}
		//		}

		/*** INSTANCE METHOD ***/

		public bool Save () 
		{
			object obj = SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.WF_InsertarWorkflow,_Id,_DocumentId,_Name,_Description);

			if(obj != null)
			{
				_Id = Convert.ToInt32(obj);
				if(_Id > -1) return true;
			}

			return false;
		}

		/*** STATIC METHODS ***/

		public static bool CambiarReferencia(int workflowId, string oldRef, string newRef)
		{
			int retVal = SqlHelper.ExecuteNonQuery(ESSeguridad.FormarStringConexion(),Queries.WF_CambiarReferencia,workflowId,oldRef,newRef);
			return retVal > 0 ? true : false;
		}

		public static WFWorkflow GetWorkflowById(int workflowId) 
		{
			if (workflowId <= 0)
				throw (new ArgumentOutOfRangeException("workflowId"));

			SqlDataReader sdr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerWorkflowPorID,workflowId);

			if(sdr.Read())
			{
				int id = sdr.GetInt32(0);
				int documentId = sdr.GetInt16(1);
				string name = sdr.GetString(2);
				string description = sdr.GetString(3);

				return new WFWorkflow(id,documentId,name,description);
			}

			return null;
		}

		/// <summary>
		/// Recupera la ruta de un determinado workflow según un conjunto de políticas
		/// </summary>
		/// <param name="parameterValues">
		/// Parameter[0] = código del workflow
		/// Parameter[1] = código del empleado que generó el workflow
		/// Parameter[2...] = políticas
		/// </param>
		/// <returns>ruta, secuencia de "grupo de roles" tales como: 1;12;14;11</returns>
		public static string ObtenerRuta(params object[] parameterValues)
		{
			string politicas = "";
			int PARAMETROS_FIJOS = 3;

			if (parameterValues == null || parameterValues.Length < PARAMETROS_FIJOS) 
				return null;

			for (int i = 2, j = parameterValues.Length; i < j; i++)
			{					
				politicas += i + 1 < j ? parameterValues[i].ToString().Trim() + ";" : parameterValues[i].ToString().Trim();
			}

			string xmlContent = "";
			if(politicas != "")
			{
				int workflowId = Convert.ToInt32(parameterValues[0]); // código del workflow
				int staffId = Convert.ToInt32(parameterValues[1]); // quien origino el workflow
				ArrayList rutas = WFPolitica.ObtenerRuta(workflowId,politicas,staffId);
				
				if(rutas != null)
				{
//					for(int i = 0, j = rutas.Count; i < j; i++)
//					{
//						xmlContent += rutas[i].ToString();
//					}

					xmlContent = rutas[0].ToString();
				}
				else
				{
					return null;
					//					throw new Exception("No se pudo recuperar la ruta con las políticas establecidas");
				}
			}

			return xmlContent;
		}

		public static bool EnviarMensaje(Eventos evt, params object[] parameterValues)
		{
			string xmlContent = AsignarParametrosXmlContent(evt,parameterValues);
			
			if(xmlContent == null) 
				return false;     

			return new Workflow().EnviarMensaje(evt,xmlContent);
		}

		private static string AsignarParametrosXmlContent(Eventos evt, object[] parameterValues)
		{
			string politicas = "";
			int PARAMETROS_FIJOS = 4;

			// Si el Workflow se va a crear los parámetros son:
			// Parámetro 0 = Código del Workflow
			// Parámetro 1 = Referencia del Documento
			// Parámetro 2 = Código de Staff Origen
			// Parámetro 3 = Código de Staff Destino

			// Si el mensaje es mientras la ejecución los parámetros son:
			// Parámetro 0 = Código de la Solicitud
			// Parámetro 1 = Referencia del Documento
			// Parámetro 2 = Código de Staff Destino
			// Parámetro 3 = Observaciones

			if (parameterValues == null || parameterValues.Length < PARAMETROS_FIJOS)
				return null;

			string xmlContent = "<root>";
			for (int i = 0, j = parameterValues.Length; i < j; i++)
			{					
				if(i < PARAMETROS_FIJOS)
				{
					xmlContent += "<param" + i + ">" + parameterValues[i].ToString().Trim() + "</param" + i + ">";
				}
				else
				{
					politicas += i + 1 < j ? parameterValues[i].ToString().Trim() + ";" : parameterValues[i].ToString().Trim();
				}
			}
			//Actualizar Ruta en Solicitud Corregida
			if(evt == Eventos.SOLICITUD_CORREGIDA && politicas != "")
			{
				int workflowId = Convert.ToInt32(parameterValues[0]);
				int staffId = Convert.ToInt32(parameterValues[PARAMETROS_FIJOS-2]);
				string strReferencia= parameterValues[1].ToString(); //Referencia del documento
				try
				{
					DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
					Queries.WF_ObtenerCreador,workflowId,strReferencia); 
			
					foreach(DataRow r in ds.Tables[0].Rows)
					{
						staffId = Convert.ToInt32(r["swf_cod_empleado_creador"]);
						break;
					}
				}
				catch(Exception ee)
				{
					System.Console.Write(ee.Message);
				}
				
				ArrayList rutas = WFPolitica.ObtenerRuta(workflowId,politicas,staffId);
				try
				{
					string strRuta = Convert.ToString(rutas[0]);
					
					SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),
						Queries.WF_ActualizarRutaSolicitud,strReferencia,workflowId,staffId,strRuta);
				}
				catch(Exception ee)
				{
					System.Console.Write(ee.Message);
				}
				if(rutas != null)
				{
					for(int i=0; i<rutas.Count; i++)
					{
						xmlContent += "<param" + (PARAMETROS_FIJOS + i) + ">" + rutas[i].ToString() + "</param" + (PARAMETROS_FIJOS + i) + ">";
					}
				}
				else
				{
					return null;
					//					throw new Exception("No se pudo establecer una ruta con las políticas establecidas");
				}

			}
			// LAS POLÍTICAS SE PASAN AL WORKFLOW CUANDO ESTE SE CREA
			if(evt == Eventos.CREAR_SOLICITUD)// && politicas != "")
			{
				int workflowId = Convert.ToInt32(parameterValues[0]);
                string strReferencia = parameterValues[1].ToString();
				int staffId = Convert.ToInt32(parameterValues[PARAMETROS_FIJOS-2]);                

                ArrayList rutas = null;// WFPolitica.ObtenerRuta(workflowId, politicas, staffId);
                string strRuta = string.Empty;
				try
				{
                    if (politicas != string.Empty)
                    {
                        rutas = WFPolitica.ObtenerRuta(workflowId, politicas, staffId);
                        strRuta = Convert.ToString(rutas[0]);
                        SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),
                        Queries.WF_ActualizarRutaSolicitud, strReferencia, workflowId, staffId, strRuta);
                    }
				}
				catch(Exception ee)
				{
					System.Console.Write(ee.Message);
				}

                if (rutas != null)
                {
                    for (int i = 0; i < rutas.Count; i++)
                    {
                        xmlContent += "<param" + (PARAMETROS_FIJOS + i) + ">" + rutas[i].ToString() + "</param" + (PARAMETROS_FIJOS + i) + ">";
                    }
                }

                else
                {
                    xmlContent += "<param" + PARAMETROS_FIJOS + ">0;0;</param" + PARAMETROS_FIJOS + ">";
                }
                    /*
				else
				{
					return null;
					//					throw new Exception("No se pudo establecer una ruta con las políticas establecidas");
				}
                     * */
			}

			xmlContent += "</root>";
			return xmlContent;
		}

		public static bool InsertarCamino(int rutaId, string camino)
		{
			object obj = SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.WF_InsertarCamino,rutaId,camino);

			if(obj != null)
			{
				int _intCuenta = Convert.ToInt32(obj);
				if(_intCuenta > -1) return true;
			}

			return false;
		}

		public static int InsertarCaminoNuevo(int nodoId, string camino)
		{
			object obj = SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.WF_InsertarCaminoNuevo,nodoId,camino);

			if(obj != null)
			{
				int _intCodRuta = Convert.ToInt32(obj);
				if(_intCodRuta > -1) return _intCodRuta;
			}

			return -1;
		}

		public static bool BorrarCamino(int rutaId)
		{
			SqlHelper.ExecuteNonQuery(ESSeguridad.FormarStringConexion(),Queries.WF_BorrarCamino,rutaId);
			return true;
		}

		public static bool ActualizarUltimoUsuario(string strProcedimiento, string strReferencia, int intEmpleado)
		{
            object obj = SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(), strProcedimiento, strReferencia, intEmpleado);

            int retval = 0;
            if(obj != null)
            {
                retval = Convert.ToInt32(obj);
            }

            return retval > 0 ? true : false;
		}

		public static bool AprobacionInmediata(string strRuta)
		{
			if(strRuta != "")
			{   
				strRuta = strRuta.Substring(0,strRuta.Length-1);
				string [] GRoles = strRuta.Split(';');
				return GRoles.Length == 1 ? true : false; 
			}

			return false;
		}

		public static int UltimoDestino(int workflowId, string refId)
		{
			int retVal = -1;

			try
			{
				SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerDatosRuta,workflowId,refId);
				
				if(dr.Read())
				{
					string lados = dr.GetString(0);
					int numSec = dr.GetInt32(1);
					string [] _ruta = lados.Split(';');
					
					if ((_ruta.Length-2) == numSec)
						retVal = 1;
					else retVal = 0;
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message + " " + e.InnerException);
			}

			return retVal;
		}

		public static ArrayList ListarWorkflows(int moduloId)
		{
			ArrayList Catalogo = new ArrayList();
			SqlDataReader sdr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ListarWorkflows,moduloId);

			WFWorkflow objInicial = new WFWorkflow(0,0,"[Seleccione]","");
			Catalogo.Add(objInicial);

			while(sdr.Read())
			{
				int id = sdr.GetInt32(0);
				int documentId = sdr.GetInt16(1);
				string name = sdr.GetString(2);
				string description = sdr.GetString(3);

				Catalogo.Add(new WFWorkflow(id,documentId,name,description));
			}

			return Catalogo;
		}

		public static void ObtenerReglas(int workflowId, out int intervalo_aprobacion, out int intervalo_correccion, out int num_recordatorios)
		{
			intervalo_aprobacion = 0;
			intervalo_correccion = 0;
			num_recordatorios = 0;

			SqlDataReader sdr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerReglas,workflowId);

			if(sdr.Read())
			{
				intervalo_aprobacion = sdr.GetInt32(0);
				intervalo_correccion = sdr.GetInt32(1);
				num_recordatorios = sdr.GetInt32(2);
			}
		}

		public static void ActualizarReglas(int workflow, int intervalo_aprobacion,int intervalo_correccion, int num_recordatorios)
		{
			SqlHelper.ExecuteNonQuery(ESSeguridad.FormarStringConexion(),Queries.WF_ActualizarReglas,workflow,intervalo_aprobacion,intervalo_correccion,num_recordatorios);
		}

		public static bool ActualizarHistoricoMismoRolAprobador(int intCodWorkFlow, string strReferencia,int intAprobadorNuevo)
		{
			try
			{
				SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),
					Queries.WF_ActualizarHistoricoMismoRolAprobador, intCodWorkFlow,strReferencia,intAprobadorNuevo); 
				return true;
			}
			catch(Exception e)
			{
				System.Console.Write(e.Message);
				return false;
			}
		}

		/// <summary>
		/// Obtiene la posicion actual en la aprobacion de un documento
		/// </summary>
		/// <param name="intCodWorkFlow"></param>
		/// <param name="strReferencia"></param>
		/// <returns></returns>
		public static short ObtenerPosicionAprobacion(int intCodWorkFlow, string strReferencia)
		{
			DataSet dsResultado = SqlHelper.ExecuteDataset(
				ESSeguridad.FormarStringConexion(),	Queries.WF_ObtenerPosicionAprobacion
				,intCodWorkFlow
				,strReferencia);
			
			return Convert.ToInt16(dsResultado.Tables[0].Rows[0]["swf_num_posicion_actual"]);
		}

		/// <summary>
		/// Ubica la posicion de la aprobación de un documento en un siguiente nivel
		/// </summary>
		/// <param name="intCodWorkFlow"></param>
		/// <param name="strReferencia"></param>
		/// <returns></returns>
		public static bool ActualizarPosicionAprobacion(int intCodWorkFlow, string strReferencia)
		{
			try
			{
				SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.WF_ActualizarPosicionAprobacion
					,intCodWorkFlow
					,strReferencia); 
				return true;
			}
			catch(Exception e)
			{
				System.Console.Write(e.Message);
				return false;
			}
		}

	} // Fin de la Clase
} // Fin del Namespace
