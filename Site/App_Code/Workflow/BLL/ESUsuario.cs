//Desarrollado por: Yonny Florez.
//Fecha de Creación: 20/01/2005


using System;
using Componentes.DAL;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using Componentes.BLL.SE;


namespace Componentes.BLL
{
	/// <summary>
	/// ESUsuario, maneja todos los procesos relacionados con usuarios del sistema.
	/// </summary>
	[Serializable]

	public class ESUsuario
	{
		private int _intCodStaff = 0;
    	private string _strNombreLargo = string.Empty;
		private string _strNombreCorto = string.Empty;
		private short _shtOficina = 0;
		private short _shtLoS = 0;
		private short _shtEspecializacion = 0;
		private short _shtCategoria = 0;
		private string _strLineaDepartamento = string.Empty;
		private string _strOficina = string.Empty;
		private string _strCategoria = string.Empty;
		private string _strCargo = string.Empty;
		private DateTime _dttFechaCreacion;
		private DateTime _dttFechaUltimoIngreso;

		private string _strUsuario = string.Empty;
		private int _intIDUsuario = 0;
		private string _strPassword = string.Empty;
		private string _strEstatus = string.Empty;
		private string _strComentarios = string.Empty;
		private bool _blnActivo;
		private bool _blnCambiarPassword;
		private string _strEmail;

		//Contructores
		public ESUsuario()
		{
		}

		public ESUsuario(int intEmpleado)
		{
			_intCodStaff = intEmpleado;
		}

		public int intIDUsuario
		{
			get { return _intIDUsuario; }
			set { _intIDUsuario = value; }
		}	

		public string strUsuario
		{
			get { return _strUsuario; }
			set { _strUsuario = value; }
		}	

		public string strPassword
		{
			get { return _strPassword; }
			set { _strPassword = value; }
		}

		public string strComentarios
		{
			get { return _strComentarios; }
			set { _strComentarios = value; }
		}

		public bool blnActivo
		{
			get { return _blnActivo; }
			set { _blnActivo = value; }
		}

		public bool blnCambiarPassword
		{
			get { return _blnCambiarPassword; }
			set { _blnCambiarPassword = value; }
		}

		public int intCodStaff
		{
			get { return _intCodStaff; }
			set { _intCodStaff = value; }
		}

		public string strNombreLargo
		{
			get { return _strNombreLargo; }
			set { _strNombreLargo = value; }
		}

		public string strNombreCorto
		{
			get { return _strNombreCorto; }
			set { _strNombreCorto = value; }
		}

		public short shtOficina
		{
			get { return _shtOficina; }
			set { _shtOficina = value; }
		}
		public short shtLoS
		{
			get { return _shtLoS; }
			set { _shtLoS = value; }
		}
		public short shtEspecializacion
		{
			get { return _shtEspecializacion; }
			set { _shtEspecializacion = value; }
		}

		public short shtCategoria
		{
			get { return _shtCategoria; }
			set { _shtCategoria = value; }
		}

		public string strLineaDepartamento
		{
			get { return _strLineaDepartamento; }
			set { _strLineaDepartamento = value; }
		}

		public string strOficina
		{
			get { return _strOficina; }
			set { _strOficina = value; }
		}

		public string strCargo
		{
			get { return _strCargo; }
			set { _strCargo = value; }
		}

		public string strCategoria
		{
			get { return _strCategoria; }
			set { _strCategoria = value; }
		}

		public DateTime dttFechaCreacion
		{
			get { return _dttFechaCreacion; }
			set { _dttFechaCreacion = value; }
		}

		public DateTime dttFechaUltimoIngreso
		{
			get { return _dttFechaUltimoIngreso; }
			set { _dttFechaUltimoIngreso = value; }
		}

		public string strEstatus
		{
			get { return _strEstatus; }
			set { _strEstatus = value; }
		}

		public string strEmail
		{
			get { return _strEmail; }
			set { _strEmail = value; }
		}

		/// <summary>
		/// Login:
		/// Metodo de Ingreso, valida usuario y contraseña en la base de datos.
		/// </summary>
		/// <param name="Usuario"> Usuario del Sistema</param>
		/// <param name="Password"> Contraseña</param>
		/// <returns> Nombre del usuario</returns>
		/// 
		public int Login(string Usuario, string Password)
		{
			int intUsuario = 0;
			intUsuario = Convert.ToInt32(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(), Queries.ES_Login, Usuario, Password));

			return intUsuario;
		}

		public int Login(string Usuario)
		{
			int intUsuario = 0;
			intUsuario = Convert.ToInt32(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(), Queries.ES_LoginUsuario, Usuario));

			return intUsuario;
		}

		public int Login(int intEmpleado, string Password)
		{
			int intUsuario = 0;
			intUsuario = Convert.ToInt32(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(), Queries.ES_LoginCodigo, intEmpleado, Password));

			return intUsuario;
		}

		public static bool CambiarPassword(int intEmpleado, string strPassword)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_CambiarPassword, intEmpleado, strPassword, 0)); 
		}

		public static bool CambiarPassword(int intEmpleado, string strPassword, bool blnCambiarPassword)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_CambiarPassword, intEmpleado, strPassword, blnCambiarPassword?1:0)); 
		}

		/// <summary>
		/// ObtenerUsuario:
		/// Consulta el usuario que tiene activa la sesión actual
		/// </summary>
		/// <param name="Usuario">Usuario del sistema</param>
		/// <returns>ArrayList de Objetos tipo Usuario</returns>
		/// 
		//Desarrollado por: Jhanmara Duque
		//Fecha de Creación: 24/01/2005

		public bool ObtenerUsuario(int intCodUsuario)
		{
			DataSet dsUsuario = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
				Queries.ES_ConsultaUsuario, intCodUsuario); 

			if (dsUsuario.Tables[0].Rows.Count < 1)
				return false;

			DataRow drUsuario = dsUsuario.Tables[0].Rows[0];
			
			intCodStaff = Convert.ToInt32(drUsuario["usu_cod_empleado"]);
			strNombreLargo = drUsuario["NombreEmpleadoLargo"].ToString();
			strNombreCorto = drUsuario["NombreEmpleadoCorto"].ToString();
			strOficina = drUsuario["ofi_desc_oficina"].ToString();
			shtOficina = Convert.ToInt16(drUsuario["emp_cod_oficina"]);
            shtLoS = Convert.ToInt16(drUsuario["emp_cod_linea"]);
			shtEspecializacion = Convert.ToInt16(drUsuario["emp_cod_especializacion"]);
			shtCategoria = Convert.ToInt16(drUsuario["emp_cod_categoria"]);
			blnCambiarPassword = Convert.ToBoolean(drUsuario["usu_val_cambiar_password"]);
			dttFechaUltimoIngreso = Convert.ToDateTime(drUsuario["usu_fecha_ultimo_ingreso"]);
 
			return true;
		}

		public static ESColeccionUsuario ListarUsuarios(string strBusqueda, short shtLoS, short shtEstatus, short shtOficina)
		{
			ESColeccionUsuario Usuarios = new ESColeccionUsuario();

			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarUsuarios,strBusqueda,shtLoS,shtEstatus,shtOficina); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESUsuario objUsuario = new ESUsuario();
				objUsuario.dttFechaCreacion = Convert.ToDateTime(r["usu_fecha_creacion"]);
				objUsuario.intCodStaff = Convert.ToInt32(r["usu_cod_empleado"]);
				objUsuario.strUsuario = Convert.ToString(r["usu_str_login"]);
				objUsuario.strNombreCorto = Convert.ToString(r["NombreEmpleadoCorto"]);
				objUsuario.strNombreLargo = Convert.ToString(r["NombreEmpleadoLargo"]);
				objUsuario.strLineaDepartamento = Convert.ToString(r["lin_desc_linea"]);
				objUsuario.strOficina = Convert.ToString(r["ofi_desc_oficina"]);
				objUsuario.strEstatus = (Convert.ToBoolean(r["usu_bln_activo"]))?"Activo":"Inactivo";
				objUsuario.strCategoria = Convert.ToString(r["cat_desc_categoria"]);
				Usuarios.Add(objUsuario);
			}
			return Usuarios;
		}

		public static ESColeccionUsuario ListarUsuariosIniciales()
		{
			ESColeccionUsuario Usuarios = new ESColeccionUsuario();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarUsuariosIniciales); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESUsuario objUsuario = new ESUsuario();
				objUsuario.dttFechaCreacion = Convert.ToDateTime(r["usu_fecha_creacion"]);
				objUsuario.intCodStaff = Convert.ToInt32(r["usu_cod_empleado"]);
				objUsuario.strUsuario = Convert.ToString(r["usu_str_login"]);
				objUsuario.strNombreCorto = Convert.ToString(r["NombreEmpleadoCorto"]);
				objUsuario.strNombreLargo = Convert.ToString(r["NombreEmpleadoLargo"]);
				objUsuario.strLineaDepartamento = Convert.ToString(r["lin_desc_linea"]);
				objUsuario.strOficina = Convert.ToString(r["ofi_desc_oficina"]);
				objUsuario.strEstatus = (Convert.ToBoolean(r["usu_bln_activo"]))?"Activo":"Inactivo";
				objUsuario.strCategoria = Convert.ToString(r["cat_desc_categoria"]);
				objUsuario.strEmail = Convert.ToString(r["emp_str_email"]);
				Usuarios.Add(objUsuario);
			}
			return Usuarios;
		}

		public void VerificarUsuario(int intEmpleado, string strUsuario)
		{
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_VerificarUsuario, intEmpleado, strUsuario); 

			if(ds.Tables[0].Rows.Count > 0)
			{
				this.intCodStaff = Convert.ToInt32(ds.Tables[0].Rows[0]["usu_cod_empleado"]);
				this.strUsuario = Convert.ToString(ds.Tables[0].Rows[0]["usu_str_login"]);
			}
		}

		public void CargarUsuario()
		{
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_CargarUsuario,_intCodStaff); 

			this.intCodStaff = Convert.ToInt32(ds.Tables[0].Rows[0]["usu_cod_empleado"]);
			this.strUsuario = Convert.ToString(ds.Tables[0].Rows[0]["usu_str_login"]);
			this.strNombreLargo = Convert.ToString(ds.Tables[0].Rows[0]["NombreEmpleadoLargo"]);
			this.strCategoria = Convert.ToString(ds.Tables[0].Rows[0]["cat_desc_categoria"]);
			this.strPassword = Convert.ToString(ds.Tables[0].Rows[0]["usu_str_password"]);
			this.blnActivo = Convert.ToBoolean(ds.Tables[0].Rows[0]["usu_bln_activo"]);
			this.blnCambiarPassword = Convert.ToBoolean(ds.Tables[0].Rows[0]["usu_val_cambiar_password"]);
			this.strComentarios = Convert.ToString(ds.Tables[0].Rows[0]["usu_str_comentarios"]);
		}

		public int Guardar()
		{
			if (_intIDUsuario == 0)
				return Insertar();
			else if (_intIDUsuario > 0)
				return Actualizar();
			else
			{
				_intIDUsuario = 0;
				return _intIDUsuario;
			}
		}

		public int Insertar()
		{
			_intIDUsuario = Convert.ToInt32(SqlHelper.ExecuteScalar(
				ESSeguridad.FormarStringConexion(), Queries.ES_InsertarUsuario, 
				_intCodStaff,
				_strUsuario,
				_strPassword,
				_blnActivo,
				_blnCambiarPassword,
				_strComentarios
				));

			return _intIDUsuario;	   
		}

		public int Actualizar()
		{
			_intIDUsuario = Convert.ToInt32(SqlHelper.ExecuteScalar(
				ESSeguridad.FormarStringConexion(), Queries.ES_ActualizarUsuario, 
				_intCodStaff,
				_blnActivo,
				_blnCambiarPassword,
				_strComentarios
				));

			return _intIDUsuario;	
		}

		public static bool VerificarGeneracion(int intEmpleado, string strPassword, short shtGeneraciones)
		{
			return	Convert.ToBoolean(SqlHelper.ExecuteScalar(
					ESSeguridad.FormarStringConexion(), Queries.ES_VerificarGeneracion, 
					intEmpleado,
					strPassword,
					shtGeneraciones));
		}

		public static bool VerificarCaducidad(int intEmpleado, short shtDias)
		{
			return	Convert.ToBoolean(SqlHelper.ExecuteScalar(
				ESSeguridad.FormarStringConexion(), Queries.ES_VerificarCaducidad, 
				intEmpleado,
				shtDias));
		}
	}
}
