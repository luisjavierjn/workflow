//Desarrollado por: Yonny Florez.
//Fecha de Creación: 12/01/2006

using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Collections;
using Componentes.DAL;
using Mensajeria;

namespace Componentes.BLL.SE
{
	/// <summary>
	/// ESGrupoRoles: Clase para el manejo de grupos de roles.
	/// </summary>
	[Serializable]
	public class ESGrupoRoles
	{
		private short _shtGrupoRoles = 0;
		private string _strGrupoRoles = string.Empty;

		public short shtGrupoRoles
		{
			get { return _shtGrupoRoles; }
			set { _shtGrupoRoles = value; }
		}

		public string strGrupoRoles
		{
			get { return _strGrupoRoles; }
			set { _strGrupoRoles = value; }
		}

		public ESGrupoRoles()
		{
		}

		public ESGrupoRoles(short shtGrupoInicial, string strGrupoInicial)
		{
			_shtGrupoRoles = shtGrupoInicial;
			_strGrupoRoles = strGrupoInicial;
		}

		public static ArrayList ListarGrupoRoles()
		{
			ArrayList GrupoRoles = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarGrupoRoles); 
			
			ESGrupoRoles objInicial = new ESGrupoRoles(0,"[Seleccione]");
			GrupoRoles.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESGrupoRoles objGrupoRoles = new ESGrupoRoles();
				objGrupoRoles.shtGrupoRoles = Convert.ToInt16(r["rls_cod_rolasoc"]);
				objGrupoRoles.strGrupoRoles = Convert.ToString(r["rls_nbr_rolasoc"]);
				GrupoRoles.Add(objGrupoRoles);
			}
			return GrupoRoles;
		}
		
	}


	/// <summary>
	/// ESRol: Clase para el manejo de roles del sistema.
	/// </summary>
	[Serializable]
	public class ESRol
	{
		public enum Tipo 
		{ 
			T=1,
			L,
			C
		}

		private short _shtRol = 0;
		private string _strRol = string.Empty;
		private string _strDescripcionRol = string.Empty;
		private string _strAcceso = string.Empty;
		private int _intCodigoEmpleado = 0;

		public short shtRol
		{
			get { return _shtRol; }
			set { _shtRol = value; }
		}

		public string strRol
		{
			get { return _strRol; }
			set { _strRol = value; }
		}

		public string strDescripcionRol
		{
			get { return _strDescripcionRol; }
			set { _strDescripcionRol = value; }
		}

		public string strAcceso
		{
			get { return _strAcceso; }
			set { _strAcceso = value; }
		}

		public int intCodigoEmpleado
		{
			get { return _intCodigoEmpleado; }
			set { _intCodigoEmpleado = value; }
		}
		
		public ESRol()
		{
		}

		public ESRol(short shtRolInicial, string strRolInicial, string strDescripcionRolInicial)
		{
			_shtRol = shtRolInicial;
			_strRol = strRolInicial;
			_strDescripcionRol = strDescripcionRolInicial;
		}

		public ESRol(string strRolInicial, string strDescripcionRolInicial)
		{
			_strRol = strRolInicial;
			_strDescripcionRol = strDescripcionRolInicial;
		}

		public ESRol(short shtRolInicialValue, string strRolInicialText)
		{
			_shtRol = shtRolInicialValue;
			_strRol = strRolInicialText;
		}

		public short Guardar()
		{
			if (_shtRol == 0)
				return Insertar();
			else if (_shtRol > 0)
				return Actualizar();
			else
			{
				_shtRol = 0;
				return _shtRol;
			}
		}

		public short Insertar()
		{
			_shtRol = Convert.ToInt16(SqlHelper.ExecuteScalar(
				ESSeguridad.FormarStringConexion(), Queries.ES_InsertarRol, 
				_strRol,
				_strDescripcionRol
				));

			return _shtRol;	   
		}

		public short Actualizar()
		{
			_shtRol = Convert.ToInt16(SqlHelper.ExecuteScalar(
				ESSeguridad.FormarStringConexion(), Queries.ES_ActualizarRol, 
				_shtRol,
				_strRol,
				_strDescripcionRol
				));

			return _shtRol;
		}

		public static ESColeccionRol ListarRoles()
		{
			ESColeccionRol Roles = new ESColeccionRol();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarRoles); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESRol objRol = new ESRol();
				objRol.shtRol = Convert.ToInt16(r["rol_cod_rol"]);
				objRol.strRol = Convert.ToString(r["rol_nbr_rol"]);
				objRol.strDescripcionRol = Convert.ToString(r["rol_desc_rol"]);
				objRol.strAcceso = Convert.ToString(r["rol_val_tipo_acceso"]);
				Roles.Add(objRol);
			}
			return Roles;
		}

		public static ESColeccionRol ListarRoles(string strOpcionInicial)
		{
			ESColeccionRol Roles = new ESColeccionRol();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarRoles); 
			
			ESRol objInicial = new ESRol(0,strOpcionInicial);
			Roles.Add(objInicial);

			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESRol objRol = new ESRol();
				objRol.shtRol = Convert.ToInt16(r["rol_cod_rol"]);
				objRol.strRol = Convert.ToString(r["rol_nbr_rol"]);
				objRol.strDescripcionRol = Convert.ToString(r["rol_desc_rol"]);
				objRol.strAcceso = Convert.ToString(r["rol_val_tipo_acceso"]);
				Roles.Add(objRol);
			}
			return Roles;
		}

		public static ESColeccionRol ListarRolesSinAcceso()
		{
			ESColeccionRol Roles = new ESColeccionRol();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarRolesSinAcceso); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESRol objRol = new ESRol();
				objRol.shtRol = Convert.ToInt16(r["rol_cod_rol"]);
				objRol.strRol = Convert.ToString(r["rol_nbr_rol"]);
				objRol.strDescripcionRol = Convert.ToString(r["rol_desc_rol"]);
				objRol.strAcceso = Convert.ToString(r["rol_val_tipo_acceso"]);
				Roles.Add(objRol);
			}
			return Roles;
		}

		public static ESColeccionRol ListarRolesAsignados(int intEmpleadoListar)
		{
			ESColeccionRol Roles = new ESColeccionRol();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarRolesAsignados,intEmpleadoListar); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESRol objRol = new ESRol();
				objRol.shtRol = Convert.ToInt16(r["rol_cod_rol"]);
				objRol.strRol = Convert.ToString(r["rol_nbr_rol"]);
				objRol.strDescripcionRol = Convert.ToString(r["rol_desc_rol"]);
				
				Roles.Add(objRol);
			}
			return Roles;
		}

		public static ESColeccionRol ListarRolesNoAsignados(int intEmpleadoListar)
		{
			ESColeccionRol Roles = new ESColeccionRol();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarRolesNoAsignados,intEmpleadoListar); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESRol objRol = new ESRol();
				objRol.shtRol = Convert.ToInt16(r["rol_cod_rol"]);
				objRol.strRol = Convert.ToString(r["rol_nbr_rol"]);
				objRol.strDescripcionRol = Convert.ToString(r["rol_desc_rol"]);
				
				Roles.Add(objRol);
			}
			return Roles;
		}

		public static ESColeccionRol ListarRolesAsignadosGrupo(short shtGrupo)
		{
			ESColeccionRol Roles = new ESColeccionRol();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarRolesAsignadosGrupo,shtGrupo); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESRol objRol = new ESRol();
				objRol.shtRol = Convert.ToInt16(r["rol_cod_rol"]);
				objRol.strRol = Convert.ToString(r["rol_nbr_rol"]);
				objRol.strDescripcionRol = Convert.ToString(r["rol_desc_rol"]);
				
				Roles.Add(objRol);
			}
			return Roles;
		}

		public static ESColeccionRol ListarRolesNoAsignadosGrupo(short shtGrupo)
		{
			ESColeccionRol Roles = new ESColeccionRol();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarRolesNoAsignadosGrupo,shtGrupo); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESRol objRol = new ESRol();
				objRol.shtRol = Convert.ToInt16(r["rol_cod_rol"]);
				objRol.strRol = Convert.ToString(r["rol_nbr_rol"]);
				objRol.strDescripcionRol = Convert.ToString(r["rol_desc_rol"]);
				
				Roles.Add(objRol);
			}
			return Roles;
		}

		public static ESColeccionRol ListarRolesAsignadosCategoria(short shtCategoria)
		{
			ESColeccionRol Roles = new ESColeccionRol();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarRolesAsignadosCategoria,shtCategoria); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESRol objRol = new ESRol();
				objRol.shtRol = Convert.ToInt16(r["rol_cod_rol"]);
				objRol.strRol = Convert.ToString(r["rol_nbr_rol"]);
				objRol.strDescripcionRol = Convert.ToString(r["rol_desc_rol"]);
				
				Roles.Add(objRol);
			}
			return Roles;
		}

		public static ESColeccionRol ListarRolesNoAsignadosCategoria(short shtCategoria)
		{
			ESColeccionRol Roles = new ESColeccionRol();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarRolesNoAsignadosCategoria,shtCategoria); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESRol objRol = new ESRol();
				objRol.shtRol = Convert.ToInt16(r["rol_cod_rol"]);
				objRol.strRol = Convert.ToString(r["rol_nbr_rol"]);
				objRol.strDescripcionRol = Convert.ToString(r["rol_desc_rol"]);
				
				Roles.Add(objRol);
			}
			return Roles;
		}

		public static bool ObtenerAdministradorPresupuesto(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerAdministradorPresupuesto, intCodEmpleado)); 
		}

		public static bool ObtenerSocioAsignaciones(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerSocioAsignaciones, intCodEmpleado)); 
		}

		public static bool ObtenerSocioPlanificacion(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerSocioPlanificacion, intCodEmpleado)); 
		}
		
		public static bool ObtenerLiderLoS(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerLiderLoS, intCodEmpleado)); 
		}

		public static bool ObtenerLiderLoSCCS(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerLiderLoSCCS, intCodEmpleado)); 
		}
		public static bool VerificarSocioLiderLoS(int intCodEmpleado, short shtCodigoLoS)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_VerificarrSocioLiderLoS, intCodEmpleado, shtCodigoLoS)); 
		}


		public static bool ObtenerGerenteEncargado(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerGerenteEncargado, intCodEmpleado)); 
		}
		public static bool ESSecretaria(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerSecretaria, intCodEmpleado)); 
		}
		public static bool ObtenerSocioEncargado(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerSocioEncargado, intCodEmpleado)); 
		}

		public static bool ObtenerCoordinadorLoS(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerCoordinadorLoS, intCodEmpleado)); 
		}

		public static bool ObtenerSocioPrincipal(int intCodEmpleado)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerSocioPrincipal, intCodEmpleado)); 
		}
		public static bool AsignarRol(int intEmpleado, int intRol)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_AsignarRol, intEmpleado, intRol)); 
		}

		public static bool AsignarRolGrupo(short shtGrupo, int intRol)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_AsignarRolGrupo, shtGrupo, intRol)); 
		}

		public static bool EliminarRol(int intEmpleado, int intRol)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_EliminarRol, intEmpleado, intRol)); 
		}

		public static bool AsignarRolCategoria(short shtCategoria, int intRol)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_AsignarRolCategoria, shtCategoria, intRol)); 
		}

		public static bool EliminarRolCategoria(short shtCategoria, int intRol)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_EliminarRolCategoria, shtCategoria, intRol)); 
		}

		public static bool EliminarRolGrupo(short shtGrupo, int intRol)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_EliminarRolGrupo, shtGrupo, intRol)); 
		}

		public static bool AsignarAcceso(int intRol, string strNodo, short shtPosicion)
		{
			
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_AsignarAcceso, intRol, strNodo, shtPosicion)); 
		}

		public static bool EliminarAcceso(int intRol)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_EliminarAcceso, intRol)); 
		}

		public static string CodigoAcceso(int intEmpleado)
		{
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerCodigoAcceso,intEmpleado); 
			
			string strCodigoAcceso;

			if(ds.Tables[0].Rows.Count == 0)
				return "NaN";

			string strTipoAcceso = Convert.ToString(ds.Tables[0].Rows[0]["rol_val_tipo_acceso"]);
			int intLinea = Convert.ToInt16(ds.Tables[0].Rows[0]["emp_cod_linea"]);

			switch(strTipoAcceso)
			{
				case "T": strCodigoAcceso = strTipoAcceso + "%"; break;
				case "L": strCodigoAcceso = "%" + strTipoAcceso + intLinea.ToString() + "%"; break;
				case "C": strCodigoAcceso = "%" + strTipoAcceso + intEmpleado.ToString() + "C%"; break;
				default: strCodigoAcceso = "NaN"; break;
			}
			
			return strCodigoAcceso;
		}


		/// <summary>
		/// Permite obtener el código de staff del empleado que ocupa un Rol Determinado
		/// solo aplica para los roles que tengan SOLO UN EMPLEADO ASIGNADO
		/// </summary>
		public void ObtenerEmpleadoRol(short shtLoS)
		{
			DataSet dst = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), 
				Queries.ES_ObtenerEmpleadoRol, _shtRol, shtLoS); 

			DataRow drw = dst.Tables[0].Rows[0];

			_intCodigoEmpleado = Convert.ToInt32(drw["rla_cod_empleado"]);
		}


		public static string TipoAcceso(int intEmpleado)
		{
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerCodigoAcceso,intEmpleado); 
			
			if(ds.Tables[0].Rows.Count == 0)
				return "NaN";
			string strTipoAcceso = Convert.ToString(ds.Tables[0].Rows[0]["rol_val_tipo_acceso"]);
			
			return strTipoAcceso;
		}

		public static bool VerificarRolEspecifico(int intCodEmpleado, short shtCodigoRol)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_VerificarRolEspecifico, intCodEmpleado, shtCodigoRol)); 
		}

		public static int ObtenerEmpleadoRolEspecifico(short shtCodigoRol)
		{
			return Convert.ToInt32(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_ObtenerEmpleadoRolEspecifico, shtCodigoRol)); 
		}

	}
}
