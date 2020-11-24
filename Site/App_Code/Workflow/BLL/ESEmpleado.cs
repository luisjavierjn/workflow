using System;
using System.Data;
using System.Configuration;
using System.Collections;
using Componentes.DAL;
using Componentes.BLL;
using Componentes.BLL.SE;

namespace Componentes.BLL
{
	/// <summary>
	/// Summary description for ESEmpleado.
	/// </summary>
	public class ESEmpleado
	{
		private int _intCodStaff;
		private string _strCodStaff;
		private string _strNbr1;
		private string _strNbr2;
		private string _strApe1;
		private string _strApe2;
		private string _strIniciales;
		private short _shtCodOficina;
		private short _shtCodLinea;
		private short _shtCodCategoria;
		private short _shtCodTipoEmpleado;
		private string _strEmail;
		private string _strUsuario;
		private int _intCodCargo;
		private DateTime _dttFechaIngreso;
		private string _strFechaIngreso;
		private DateTime _dttFechaEgreso;
		private short _shtCodDepartamento;
		private string _strFechaEgreso;
		private string _strCedula;
		private string _strDescripcionLoS = string.Empty;
		private string _strDescripcionCategoria = string.Empty;
		private string _strDescripcionCargo = string.Empty;
		private string _strDescripcionOficina = string.Empty;
		private short _shtIdCoordinador = 0;
		private byte _bytMedioTiempo = 0;
		private string _strDeparLoS = string.Empty;
		private short _shtDeparLoS = 0;
		private int _intHorasTrabajo = 0;
//===< By Ramón
		private byte _bytActivo;
		private char _chrSexo;
//===>

		//Atributos para las descripciones de los códigos
		private string _strOficina;
		private string _strAbrOficina;
		private string _strLoS;
		private string _strDepartamento;
		private string _strCategoria;
		private string _strCargo;
		private string _strNbrAbr;

		//Atributos para el despliegue del nombre del empleado
		private string _strNombreCorto;
		private string _strNombreLargo;
		
		private int _intCodSocioEncargado;
		//Constructor
		public ESEmpleado()
		{
		}
		public ESEmpleado(int Id, string Opcion)
		{
			_intCodStaff = Id;
			_strNombreCorto = Opcion;
		}

		public ESEmpleado(int Id, string Opcion, string Opcion1 )
		{
			_intCodStaff = Id;
			_strNombreCorto = Opcion;
			_strNombreLargo = Opcion1;
		}
		
		public int intCodStaff
		{
			get { return _intCodStaff; }
			set { _intCodStaff = value; }
		}

		public string strCodStaff
		{
			get { return _strCodStaff; }
			set { _strCodStaff = value; }
		}
		
		public string strNbr1
		{
			get { return _strNbr1; }
			set { _strNbr1 = value; }
		}
		
		public string strNbr2
		{
			get { return _strNbr2; }
			set { _strNbr2 = value; }
		}
		
		public string strApe1
		{
			get { return _strApe1; }
			set { _strApe1 = value; }
		}
		
		public string strApe2
		{
			get { return _strApe2; }
			set { _strApe2 = value; }
		}
		
		public string strIniciales
		{
			get { return _strIniciales; }
			set { _strIniciales = value; }
		}
		
		public short shtCodOficina
		{
			get { return _shtCodOficina; }
			set { _shtCodOficina = value; }
		}
		
		public short shtCodLinea
		{
			get { return _shtCodLinea; }
			set { _shtCodLinea = value; }
		}
		
		public short shtCodCategoria
		{
			get { return _shtCodCategoria; }
			set { _shtCodCategoria = value; }
		}

		public short shtCodTipoEmpleado
		{
			get { return _shtCodTipoEmpleado; }
			set { _shtCodTipoEmpleado = value; }
		}
		
		public string strEmail
		{
			get { return _strEmail; }
			set { _strEmail = value; }
		}

		public string strUsuario
		{
			get { return _strUsuario; }
			set { _strUsuario = value; }
		}
		
		public int intCodCargo
		{
			get { return _intCodCargo; }
			set { _intCodCargo = value; }
		}
		
		public string strOficina
		{
			get { return _strOficina; }
			set { _strOficina = value; }
		}
		public string strAbrOficina
		{
			get { return _strAbrOficina; }
			set { _strAbrOficina = value; }
		}
		
		public string strLoS
		{
			get { return _strLoS; }
			set { _strLoS = value; }
		}

		public string strDepartamento
		{
			get { return _strDepartamento; }
			set { _strDepartamento = value; }
		}
		
		public string strCategoria
		{
			get { return _strCategoria; }
			set { _strCategoria = value; }
		}
		
		public string strCargo
		{
			get { return _strCargo; }
			set { _strCargo = value; }
		}
		
		public string strNombreCorto
		{
			get { return _strNombreCorto; }
			set { _strNombreCorto = value; }
		}
		
		public string strNombreLargo
		{
			get { return _strNombreLargo; }
			set { _strNombreLargo = value; }
		}

		public DateTime dttFechaIngreso
		{
			get { return _dttFechaIngreso; }
			set { _dttFechaIngreso = value; }
		}

		public string strFechaIngreso
		{
			get { return _strFechaIngreso; }
			set { _strFechaIngreso = value; }
		}

		public string strCedula
		{
			get { return _strCedula; }
			set { _strCedula = value; }
		}

		public DateTime dttFechaEgreso
		{
			get { return _dttFechaEgreso; }
			set { _dttFechaEgreso = value; }
		}

		public string strFechaEgreso
		{
			get { return _strFechaEgreso; }
			set { _strFechaEgreso = value; }
		}

		public short shtCodDepartamento
		{
			get { return _shtCodDepartamento; }
			set { _shtCodDepartamento = value; }
		}
		public int intCodSocioEncargado
		{
			get { return _intCodSocioEncargado; }
			set { _intCodSocioEncargado = value; }
		}

		public short shtIdCoordinador
		{
			get { return _shtIdCoordinador; }
			set { _shtIdCoordinador = value; }
		}

		public byte bytMedioTiempo
		{
			get { return _bytMedioTiempo; }
			set { _bytMedioTiempo = value; }
		}

		public string strDeparLoS
		{
			get { return _strDeparLoS; }
			set { _strDeparLoS = value; }
		}

		public short shtDeparLoS
		{
			get { return _shtDeparLoS; }
			set { _shtDeparLoS = value; }
		}

		public int intHorasTrabajo
		{
			get { return _intHorasTrabajo; }
			set { _intHorasTrabajo = value; }
		}
		public string strNbrAbr
		{
			get { return _strNbrAbr; }
			set { _strNbrAbr = value; }
		}

//===< By Ramón
		public byte bytActivo
		{
			get { return _bytActivo; }
			set { _bytActivo = value; }
		}
		public char chrSexo
		{
			get { return _chrSexo; }
			set { _chrSexo = value; }
		}
//===>

		/// <summary>
		/// Método que dado parte del nombre y/o apellido, busca los empleados que coinciden con el criterio
		/// </summary>
		/// <param name="strABuscar">Parte del nombre y/o apellido a buscar</param>
		/// <returns>Lista de códigos de staff y nombres encontrados</returns>
		public static ArrayList BuscarEmpleado(string strPABuscar, short shtPCodLinea, short shtPCodCategoria)
		{
			ArrayList arrArregloEmpleados = new ArrayList();
			
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_BuscarEmpleados, strPABuscar, shtPCodLinea, shtPCodCategoria); 
			
			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado Empleado = new ESEmpleado();
				Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
				Empleado.strCodStaff = Convert.ToString(r["emp_cod_empleado"]);
				Empleado.strNombreLargo = r["emp_nbr_empleado"].ToString();
				Empleado.strCategoria = r["cat_desc_categoria"].ToString();
				arrArregloEmpleados.Add(Empleado);
			}
			return arrArregloEmpleados;			
		}

		/// <summary>
		/// Método que busca los coordinadores de LoS dado el código de la línea
		/// </summary>
		/// <param name="shtLos"></param>
		/// <returns></returns>
		public static ArrayList BuscarCoordinadorLoS(short shtLoS)
		{
			ArrayList arrArregloCoordinadores = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_BuscarCoordinadorLoS, shtLoS);

			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado Empleado = new ESEmpleado();
				Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
				Empleado.strNombreLargo = r["emp_nbr_empleado"].ToString();
				Empleado.strEmail = r["emp_str_email"].ToString();
				arrArregloCoordinadores.Add(Empleado);
			}
			return arrArregloCoordinadores;
		}

		/// <summary>
		/// Método que dado parte del nombre y/o apellido, busca los empleados que coinciden con el criterio
		/// </summary>
		/// <param name="strABuscar">Parte del nombre y/o apellido a buscar</param>
		/// <returns>Lista de códigos de staff y nombres encontrados</returns>
		public static ArrayList BuscarEmpleadoExtenso(string strPABuscar, short shtPCodLinea, short shtPCodCategoria, string strPCategoria, bool blnInactivos)
		{
			ArrayList arrArregloEmpleados = new ArrayList();
			
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_BuscarEmpleadosExtenso, strPABuscar, shtPCodLinea, shtPCodCategoria, strPCategoria); 
			
			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado Empleado = new ESEmpleado();
				
				if( !blnInactivos ) // SOLO ACTIVOS
				{
					if( Convert.ToByte(r["emp_bln_activo"]) == 1 )
					{
						Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
						Empleado.strCodStaff = Convert.ToString(r["emp_cod_empleado"]);
						Empleado.strNombreLargo = r["emp_nbr_empleado"].ToString();
						Empleado.shtCodLinea = Convert.ToInt16(r["emp_cod_linea"]);
						Empleado.shtCodCategoria = Convert.ToInt16(r["cat_cod_categoria"]);
						Empleado.strCategoria = r["cat_desc_categoria"].ToString();
						Empleado.strUsuario = r["emp_str_usuario"].ToString();
						Empleado.bytActivo = 1;

						arrArregloEmpleados.Add(Empleado);
					}
				}
				else // TODOS
				{
					Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
					Empleado.strCodStaff = Convert.ToString(r["emp_cod_empleado"]);
					Empleado.strNombreLargo = r["emp_nbr_empleado"].ToString();
					Empleado.shtCodLinea = Convert.ToInt16(r["emp_cod_linea"]);
					Empleado.shtCodCategoria = Convert.ToInt16(r["cat_cod_categoria"]);
					Empleado.strCategoria = r["cat_desc_categoria"].ToString();
					Empleado.strUsuario = r["emp_str_usuario"].ToString();
					Empleado.bytActivo = Convert.ToByte(r["emp_bln_activo"]);

					arrArregloEmpleados.Add(Empleado);
				}
			}
			return arrArregloEmpleados;			
		}

		public static ArrayList BuscarEmpleadoExtensoWF(string strPABuscar, short shtPCodLinea, int intCatDesde, int intCatHasta, int intRolAsoc)
		{
			ArrayList arrArregloEmpleados = new ArrayList();
			
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_BuscarEmpleadosExtensoWF, 
				strPABuscar, shtPCodLinea, intCatDesde, intCatHasta,intRolAsoc); 
			
			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado Empleado = new ESEmpleado();
				Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
				Empleado.strCodStaff = Convert.ToString(r["emp_cod_empleado"]);
				Empleado.strNombreLargo = r["emp_nbr_empleado"].ToString();
				Empleado.shtCodLinea = Convert.ToInt16(r["emp_cod_linea"]);
				Empleado.shtCodCategoria = Convert.ToInt16(r["cat_cod_categoria"]);
				Empleado.strCategoria = r["cat_desc_categoria"].ToString();
				Empleado.strUsuario = r["emp_str_usuario"].ToString();
				Empleado.bytActivo = Convert.ToByte(r["emp_bln_activo"]);
				arrArregloEmpleados.Add(Empleado);
			}
			return arrArregloEmpleados;			
		}

		
		public static ArrayList BuscarEmpleadoNivelGerencial(string strPABuscar, short shtPCodLinea, int intCategoria)
		{
			ArrayList arrArregloEmpleados = new ArrayList();
			
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion()
							,Queries.ES_BuscarEmpleados_NivelGerencial, strPABuscar, shtPCodLinea, intCategoria); 
			
			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado Empleado = new ESEmpleado();
				Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
				Empleado.strCodStaff = Convert.ToString(r["emp_cod_empleado"]);
				Empleado.strNombreLargo = r["emp_nbr_empleado"].ToString();
				Empleado.shtCodLinea = Convert.ToInt16(r["emp_cod_linea"]);
				Empleado.shtCodCategoria = Convert.ToInt16(r["cat_cod_categoria"]);
				Empleado.strCategoria = r["cat_desc_categoria"].ToString();
				Empleado.strUsuario = r["emp_str_usuario"].ToString();
				Empleado.bytActivo = Convert.ToByte(r["emp_bln_activo"]);
				arrArregloEmpleados.Add(Empleado);
			}
			return arrArregloEmpleados;			
		}


		/// <summary>
		/// Método que dado parte del nombre y/o apellido, busca los empleados que coinciden con el criterio
		/// </summary>
		/// <param name="strABuscar">Parte del nombre y/o apellido a buscar</param>
		/// <returns>Lista de códigos de staff y nombres encontrados</returns>
		public static ArrayList BuscarEmpleadoxParametros(string strPABuscar, short shtPCodLinea, short shtPCodCategoria, short shtPCodOficina)
		{
			ArrayList arrArregloEmpleados = new ArrayList();
			
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_BuscarEmpleadosxParametros, strPABuscar, shtPCodLinea, shtPCodCategoria, shtPCodOficina); 
			
			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado Empleado = new ESEmpleado();
				Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
				Empleado.strCodStaff = Convert.ToString(r["emp_cod_empleado"]);
				Empleado.strNombreLargo = r["emp_nbr_empleado"].ToString();
				Empleado.strCategoria = r["cat_desc_categoria"].ToString();
				arrArregloEmpleados.Add(Empleado);
			}
			return arrArregloEmpleados;			
		}

		/// <summary>
		/// Método que dado el código de staff de un empleado, obtiene todos sus atributos
		/// </summary>
		/// <param name="intCodStaff">Código de staff a buscar</param>
		/// <returns></returns>
		public  bool BuscarEmpleado(int intParCodStaff)
		{
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), 
				Queries.ES_BuscarEmpleadoEspecifico, intParCodStaff); 
			
			if (dstEmpleado.Tables[0].Rows.Count < 1)
				return false;

			DataRow drwEmpleado = dstEmpleado.Tables[0].Rows[0];
			
			intCodStaff = Convert.ToInt32(drwEmpleado["emp_cod_empleado"]);
			strCodStaff = Convert.ToString(drwEmpleado["emp_cod_empleado"]);
			strCedula = Convert.ToString(drwEmpleado["emp_str_cedula"]);
			strNbr1 = drwEmpleado["emp_nbr_empleado1"].ToString();
			strNbr2 = drwEmpleado["emp_nbr_empleado2"].ToString();
			strApe1 = drwEmpleado["emp_ape_empleado1"].ToString();
			strApe2 = drwEmpleado["emp_ape_empleado2"].ToString();
			strIniciales = drwEmpleado["emp_abr_iniciales"].ToString();
			shtCodOficina = Convert.ToInt16(drwEmpleado["emp_cod_oficina"]);
			if ((Convert.ToByte(drwEmpleado["emp_bln_LoS_Dep"]) == 0) && (Convert.ToString(drwEmpleado["emp_cod_linea"]).Length != 0))
                shtCodLinea = Convert.ToInt16(drwEmpleado["emp_cod_linea"]);
			shtCodCategoria = Convert.ToInt16(drwEmpleado["emp_cod_categoria"]);
			shtCodTipoEmpleado = Convert.ToInt16(drwEmpleado["emp_cod_tipo_empleado"]);
			strEmail = drwEmpleado["emp_str_email"].ToString();
			strOficina = drwEmpleado["ofi_desc_oficina"].ToString();
			strAbrOficina = drwEmpleado["ofi_abr_oficina"].ToString();
			strLoS = drwEmpleado["lin_desc_linea"].ToString();
			strCategoria = drwEmpleado["cat_desc_categoria"].ToString();
			strNombreCorto = drwEmpleado["nombrecorto"].ToString();
			strNombreLargo = drwEmpleado["nombrelargo"].ToString();
			strDepartamento = Convert.ToString(drwEmpleado["dep_desc_departamento"]);
			if ((Convert.ToByte(drwEmpleado["emp_bln_LoS_Dep"]) == 1) && (Convert.ToString(drwEmpleado["emp_cod_departamento"]).Length != 0))
				shtCodDepartamento = Convert.ToInt16(drwEmpleado["emp_cod_departamento"]);
		    if(strIniciales.Length<=0)
				strIniciales=ObtenerIniciales(strNbr1,strApe1);
			if ( Convert.ToString(drwEmpleado["emp_fecha_ingreso"]).Length != 0 )
			{
				dttFechaIngreso = Convert.ToDateTime(drwEmpleado["emp_fecha_ingreso"]);
				strFechaIngreso = dttFechaIngreso.ToShortDateString();
			}
			else
				strFechaIngreso = string.Empty;
			if ( Convert.ToString(drwEmpleado["emp_fecha_egreso"]).Length != 0 )
			{
				dttFechaEgreso = Convert.ToDateTime(drwEmpleado["emp_fecha_egreso"]);
				strFechaEgreso = dttFechaEgreso.ToShortDateString();
			}
			else
				strFechaEgreso = string.Empty;
			shtIdCoordinador = Convert.ToInt16(drwEmpleado["emp_id_coordinador"]);
			bytMedioTiempo = Convert.ToByte(drwEmpleado["emp_bln_medio_tiempo"]);
			if ((Convert.ToByte(drwEmpleado["emp_bln_LoS_Dep"]) == 1))
			{
				if (drwEmpleado["dep_desc_departamento"] != System.DBNull.Value)
				{
					strDeparLoS = Convert.ToString(drwEmpleado["dep_desc_departamento"]);
				}
				if (drwEmpleado["emp_cod_departamento"] != System.DBNull.Value)
				{
					shtDeparLoS = Convert.ToInt16(drwEmpleado["emp_cod_departamento"]);
				}
			}
			else
			{
				strDeparLoS = Convert.ToString(drwEmpleado["lin_desc_linea"]);
				shtDeparLoS = Convert.ToInt16(drwEmpleado["emp_cod_linea"]);
			}
//			intHorasTrabajo = Convert.ToInt32(drwEmpleado["emp_num_horas_trabajo"]);
			if (Convert.ToString(drwEmpleado["emp_num_horas_trabajo"]).Length != 0)
			{
				intHorasTrabajo = Convert.ToInt32(drwEmpleado["emp_num_horas_trabajo"]);
			}
			else
			{
				if (bytMedioTiempo == 0)
				{
					intHorasTrabajo = 8;
				}
				else
				{
					intHorasTrabajo = 4; 
				}
			}

			chrSexo = Convert.ToChar(drwEmpleado["emp_val_sexo"]);

			return true;			
		}

		public string ObtenerIniciales(string strNbr1,string strApe1)
		{	char[] nomIniciales,apeIniciales;
			string iniciales=string.Empty;
			nomIniciales=strNbr1.ToCharArray();
			apeIniciales=strApe1.ToCharArray();
			if(strApe1.IndexOf(' ')>0)
			  iniciales=nomIniciales[0].ToString()+apeIniciales[0].ToString()+apeIniciales[strApe1.IndexOf(' ')+1].ToString();
			else
			  iniciales=nomIniciales[0].ToString()+apeIniciales[0].ToString();
			return iniciales; 
		}
		/// <summary>
		/// Método que dado el cargo y la línea de servicio me trae una lista de socios 
		/// </summary>
		/// <param name="shtCodLinea">código de la línea de servicio</param>
		/// <param name="intCargo">código del cargo</param>
		/// <returns>Lista de socios que cumplen las condiciones requeridas</returns>

		public static ArrayList BuscarEmpleado_CategoriaLoS(short shtCodLinea,string strCategorias)
		{
			ArrayList arlArregloEmpleados = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), 
				Queries.ES_ListarEmpleado, shtCodLinea,strCategorias); 
			ESEmpleado EmpleadoI = new ESEmpleado();
			EmpleadoI.intCodStaff = 0;
			EmpleadoI.strNombreCorto ="[Seleccione]";
			arlArregloEmpleados.Add(EmpleadoI);
			
			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				
				ESEmpleado Empleado = new ESEmpleado ();
				Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
				Empleado.strNbr1 = r["emp_nbr_empleado1"].ToString();
				Empleado.strNbr2 = r["emp_nbr_empleado2"].ToString();
				Empleado.strApe1 = r["emp_ape_empleado1"].ToString();
				Empleado.strApe2 = r["emp_ape_empleado2"].ToString();
				Empleado.strIniciales = r["emp_abr_iniciales"].ToString();
				Empleado.shtCodOficina = Convert.ToInt16(r["emp_cod_oficina"]);
				Empleado.shtCodLinea = Convert.ToInt16(r["emp_cod_linea"]);
				Empleado.shtCodCategoria = Convert.ToInt16(r["emp_cod_categoria"]);
				Empleado.strEmail = r["emp_str_email"].ToString();
				Empleado.intCodCargo = Convert.ToInt32(r["emp_cod_cargo"]);
				Empleado.strNombreCorto = r["nombrecorto"].ToString();
				Empleado.strNombreLargo = r["nombrelargo"].ToString();

				arlArregloEmpleados.Add(Empleado);
			}
			return arlArregloEmpleados;			
		}

// by Will

		public static ArrayList BuscarRespCobranza(short shtCodOficina)
		{
			ArrayList arrRespCobranzas = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), 
				Queries.ES_BuscarRespCobranza, shtCodOficina);
			ESEmpleado EmpleadoI = new ESEmpleado();
			
			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado Empleado = new ESEmpleado ();
				Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
				Empleado.strNbr1 = r["emp_nbr_empleado1"].ToString();
				Empleado.strNbr2 = r["emp_nbr_empleado2"].ToString();
				Empleado.strApe1 = r["emp_ape_empleado1"].ToString();
				Empleado.strApe2 = r["emp_ape_empleado2"].ToString();
				Empleado.strIniciales = r["emp_abr_iniciales"].ToString();
				Empleado.shtCodOficina = Convert.ToInt16(r["emp_cod_oficina"]);
				Empleado.shtCodLinea = Convert.ToInt16(r["emp_cod_linea"]);
				Empleado.shtCodCategoria = Convert.ToInt16(r["emp_cod_categoria"]);
				Empleado.strEmail = r["emp_str_email"].ToString();

				arrRespCobranzas.Add(Empleado);
			}
			return arrRespCobranzas;
		}

// end Will

		public static ESColeccionEmpleado ListarEmpleadoXOficina(short shtParCodOficina, int intParCodDepartamento, short shtParCategoria)
		{
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), 
				Queries.ES_ListaEmpleadoOficina1, shtParCodOficina, intParCodDepartamento, shtParCategoria); 
			
			ESColeccionEmpleado arrEmpleado = new ESColeccionEmpleado();
			foreach(DataRow drwEmpleado in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado esEmp = new ESEmpleado();
				esEmp.strNombreLargo = Convert.ToString(drwEmpleado["NombreLargo"]);
				esEmp.strCodStaff = string.Format("{0:00000}", drwEmpleado["emp_cod_empleado"]);
				esEmp.strDepartamento = Convert.ToString(drwEmpleado["dep_desc_departamento"]);
				esEmp.strCategoria = Convert.ToString(drwEmpleado["cat_desc_categoria"]);
				if ( Convert.ToString(drwEmpleado["emp_fecha_ingreso"]).Length != 0 )
				{
					esEmp.dttFechaIngreso = Convert.ToDateTime(drwEmpleado["emp_fecha_ingreso"]);
					esEmp.strFechaIngreso = esEmp.dttFechaIngreso.ToShortDateString();
				}
				else
					esEmp.strFechaIngreso = string.Empty;
				esEmp.strEmail = Convert.ToString(drwEmpleado["emp_str_email"]);
				arrEmpleado.Add(esEmp);

			}
			return arrEmpleado;			
		}

		//-------------------------------------------------------------
		/// <summary>
		/// Listado de los Empleados ACTIVOS filtrado por Linea de Servicio, Categoria,
		/// Cargo y Oficina
		/// </summary>
		/// <returns> ArrayList con los resultados de la consulta</returns>
		public static ArrayList ListarEmpleados(short LoS, short Categoria, int Cargo, short Oficina)
		{
			ArrayList arrEmpleado = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarEmpleados, LoS, Categoria, Cargo, Oficina); 

			ESEmpleado objInicial = new ESEmpleado(0,"[Seleccione]");
			arrEmpleado.Add(objInicial);

			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();

				objEmpleado.intCodStaff = Convert.ToInt32((r["emp_cod_empleado"]));
				objEmpleado.strCodStaff = string.Format("{0:00000}",r["emp_cod_empleado"]);
				objEmpleado.strNbr1 = r["emp_nbr_empleado1"].ToString();
				objEmpleado.strNbr2 = r["emp_nbr_empleado2"].ToString();
				objEmpleado.strApe1 = r["emp_ape_empleado1"].ToString();
				objEmpleado.strApe2 = r["emp_ape_empleado2"].ToString();
				objEmpleado.strIniciales = r["emp_abr_iniciales"].ToString();
				objEmpleado.shtCodLinea = Convert.ToInt16((r["emp_cod_linea"]));
				objEmpleado.shtCodCategoria = Convert.ToInt16((r["emp_cod_categoria"]));
				objEmpleado.shtCodOficina = Convert.ToInt16((r["emp_cod_oficina"]));
				objEmpleado.strAbrOficina = r["ofi_abr_oficina"].ToString();
//				objEmpleado.strCargo = r["car_nbr_cargo"].ToString();
				objEmpleado.strCategoria = r["cat_desc_categoria"].ToString();
				objEmpleado.strLoS = r["lin_desc_linea"].ToString();
				objEmpleado.strOficina = r["ofi_desc_oficina"].ToString();
				objEmpleado.strEmail = r["emp_str_email"].ToString();
				objEmpleado.strCedula = r["emp_str_cedula"].ToString();
				objEmpleado.dttFechaIngreso = Convert.ToDateTime((r["emp_fecha_ingreso"]));
				objEmpleado.strNombreCorto = r["emp_nbr_empleado1"].ToString() + ", " + r["emp_ape_empleado1"].ToString();
				objEmpleado.strNombreLargo = r["emp_ape_empleado1"].ToString() + " " + r["emp_ape_empleado2"].ToString() + ", " + r["emp_nbr_empleado1"].ToString() + " " + r["emp_nbr_empleado2"].ToString();

				arrEmpleado.Add(objEmpleado);
			}
			return arrEmpleado;
		}

		//-------------------------------------------------------------
		/// <summary>
		/// Listado de los gerentes ACTIVOS filtrado por Linea de Servicio, Cargo y Oficina
		/// </summary>
		/// <returns> ArrayList con los resultados de la consulta</returns>
		public static ArrayList ListarGerentes(short LoS, int Cargo, short Oficina)
		{
			ArrayList arrGerente = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarGerentes, LoS, Cargo, Oficina); 

			ESEmpleado objInicial = new ESEmpleado(0,"[Seleccione]");
			arrGerente.Add(objInicial);

			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();

				objEmpleado.intCodStaff = Convert.ToInt32((r["emp_cod_empleado"]));
				objEmpleado.strNbr1 = r["emp_nbr_empleado1"].ToString();
				objEmpleado.strNbr2 = r["emp_nbr_empleado2"].ToString();
				objEmpleado.strApe1 = r["emp_ape_empleado1"].ToString();
				objEmpleado.strApe2 = r["emp_ape_empleado2"].ToString();
				objEmpleado.strIniciales = r["emp_abr_iniciales"].ToString();
				objEmpleado.shtCodLinea = Convert.ToInt16((r["emp_cod_linea"]));
				objEmpleado.shtCodCategoria = Convert.ToInt16((r["emp_cod_categoria"]));
				objEmpleado.shtCodOficina = Convert.ToInt16((r["emp_cod_oficina"]));
				objEmpleado.strAbrOficina = r["ofi_abr_oficina"].ToString();
				objEmpleado.strCategoria = r["cat_desc_categoria"].ToString();
				objEmpleado.strLoS = r["lin_desc_linea"].ToString();
				objEmpleado.strOficina = r["ofi_desc_oficina"].ToString();
				objEmpleado.strEmail = r["emp_str_email"].ToString();
				objEmpleado.strCedula = r["emp_str_cedula"].ToString();
				objEmpleado.dttFechaIngreso = Convert.ToDateTime((r["emp_fecha_ingreso"]));
				objEmpleado.strNombreCorto = r["emp_nbr_empleado1"].ToString() + ", " + r["emp_ape_empleado1"].ToString();
                objEmpleado.strNombreLargo = r["emp_ape_empleado1"].ToString() + " " + r["emp_ape_empleado2"].ToString() + ", " + r["emp_nbr_empleado1"].ToString() + " " + r["emp_nbr_empleado2"].ToString();
				arrGerente.Add(objEmpleado);
			}
			return arrGerente;
		}

		public static ArrayList ListarGerentes(short LoS)
		{
			ArrayList arrGerente = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarGerentes, LoS,0); 

			ESEmpleado objInicial = new ESEmpleado(0,"Todos","Todos");
			arrGerente.Add(objInicial);

			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();

				objEmpleado.intCodStaff = Convert.ToInt32((r["emp_cod_empleado"]));
				objEmpleado.strNbr1 = r["emp_nbr_empleado1"].ToString();
				objEmpleado.strNbr2 = r["emp_nbr_empleado2"].ToString();
				objEmpleado.strApe1 = r["emp_ape_empleado1"].ToString();
				objEmpleado.strApe2 = r["emp_ape_empleado2"].ToString();
				objEmpleado.strIniciales = r["emp_abr_iniciales"].ToString();
				objEmpleado.shtCodLinea = Convert.ToInt16((r["emp_cod_linea"]));
				objEmpleado.shtCodCategoria = Convert.ToInt16((r["emp_cod_categoria"]));
				objEmpleado.shtCodOficina = Convert.ToInt16((r["emp_cod_oficina"]));
				objEmpleado.strAbrOficina = r["ofi_abr_oficina"].ToString();
				objEmpleado.strCategoria = r["cat_desc_categoria"].ToString();
				objEmpleado.strLoS = r["lin_desc_linea"].ToString();
				objEmpleado.strOficina = r["ofi_desc_oficina"].ToString();
				objEmpleado.strEmail = r["emp_str_email"].ToString();
				objEmpleado.strCedula = r["emp_str_cedula"].ToString();
				objEmpleado.dttFechaIngreso = Convert.ToDateTime((r["emp_fecha_ingreso"]));
				objEmpleado.strNombreCorto = r["emp_nbr_empleado1"].ToString() + ", " + r["emp_ape_empleado1"].ToString();
				objEmpleado.strNombreLargo = r["emp_ape_empleado1"].ToString() + " " + r["emp_ape_empleado2"].ToString() + ", " + r["emp_nbr_empleado1"].ToString() + " " + r["emp_nbr_empleado2"].ToString();
				arrGerente.Add(objEmpleado);
			}
			return arrGerente;
		}

		//Lista Gerentes, Surpervisores y Directores de Assurance
		public static ArrayList ListarGerentesPresupuesto()
		{
			ArrayList arrGerente = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListadoGerentesPresupuesto); 

			ESEmpleado objInicial = new ESEmpleado(0,"Todos","Todos");
			arrGerente.Add(objInicial);

			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();

				objEmpleado.intCodStaff = Convert.ToInt32((r["emp_cod_empleado"]));
//				objEmpleado.strNbr1 = r["emp_nbr_empleado1"].ToString();
//				objEmpleado.strNbr2 = r["emp_nbr_empleado2"].ToString();
//				objEmpleado.strApe1 = r["emp_ape_empleado1"].ToString();
//				objEmpleado.strApe2 = r["emp_ape_empleado2"].ToString();
//				objEmpleado.strIniciales = r["emp_abr_iniciales"].ToString();
				objEmpleado.shtCodLinea = Convert.ToInt16((r["emp_cod_linea"]));
				objEmpleado.shtCodCategoria = Convert.ToInt16((r["emp_cod_categoria"]));
				objEmpleado.strNombreCorto = r["emp_ape_empleado1"].ToString() + ", " + r["emp_nbr_empleado1"].ToString() + "" + r["emp_nbr_empleado2"].ToString();
				//objEmpleado.strNombreLargo = r["emp_ape_empleado1"].ToString() + " " + r["emp_ape_empleado2"].ToString() + ", " + r["emp_nbr_empleado1"].ToString() + " " + r["emp_nbr_empleado2"].ToString();
				arrGerente.Add(objEmpleado);
			}
			return arrGerente;
		}

		/// <summary>
		/// Lista los gerentes y/o supervisores  de la Firma ordenados Alfabeticamente
		/// </summary>
		/// <returns>Arreglo de gerentes y supervisores</returns>
		public static ArrayList ListarGerenteSupervisor(int intParCodGrupo, short shtParCodEmpresa,
			short shtParCodOficina, short shtParCodLinea, short shtParCodEsp, short shtParCodProy, short shtParCodRecurrencia,
			short shtParCodCategoria, int intParCodEmpleado)
		{
			ArrayList arrGerente = new ArrayList();
			DataSet dstGerente = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarGerenteSupervisor,
				intParCodGrupo, shtParCodEmpresa, 
				shtParCodOficina, shtParCodLinea, shtParCodEsp, shtParCodProy, shtParCodRecurrencia, 
				shtParCodCategoria, intParCodEmpleado); 
			
			ESEmpleado objInicial = new ESEmpleado(0,"[Seleccione]");
			arrGerente.Add(objInicial);

			foreach(DataRow drwGerente in dstGerente.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();
				objEmpleado.intCodStaff = Convert.ToInt32(drwGerente["emp_cod_empleado"]);
				objEmpleado.strNombreCorto = drwGerente["NombreGerente"].ToString();
				arrGerente.Add(objEmpleado);
			}
			return arrGerente;
		}

		/// <summary>
		/// Lista el código del empleado y email de socios y gerentes de assurance.
		/// </summary>
		/// <returns>Arreglo con los socios y gerente</returns>
		public static ArrayList ListarSociosYGerentes()
		{
			ArrayList arrGerente = new ArrayList();
			DataSet dstGerente = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
				Queries.ES_ListadoSociosGerentes); 
			
			ESEmpleado objInicial = new ESEmpleado(0,"[Seleccione]");
			arrGerente.Add(objInicial);

			foreach(DataRow drwGerente in dstGerente.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();
				objEmpleado.intCodStaff = Convert.ToInt32(drwGerente["emp_cod_empleado"]);
				objEmpleado.strEmail = drwGerente["emp_str_email"].ToString();
				arrGerente.Add(objEmpleado);
			}
			return arrGerente;
		}

		public static ArrayList ListarSociosPresupuesto()
		{
			ArrayList arrEmpleado = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
				Queries.ES_ListadoSociosPresupuesto); 
			
			ESEmpleado objInicial = new ESEmpleado(0,"Todos");
			arrEmpleado.Add(objInicial);

			foreach(DataRow drwEmpleado in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();
				objEmpleado.intCodStaff = Convert.ToInt32(drwEmpleado["emp_cod_empleado"]);
				objEmpleado.strNombreCorto = drwEmpleado["NombreCorto"].ToString();
				arrEmpleado.Add(objEmpleado);
			}
			return arrEmpleado;
		}

		//Lista los Socios de presupuesto x oficina
		public static ArrayList ListarSociosOficina(short CodOficina)
		{
			ArrayList arrEmpleado = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
				Queries.ES_ListadoSociosPstosxOficina,CodOficina); 
			
			ESEmpleado objInicial = new ESEmpleado(0,"Todos");
			arrEmpleado.Add(objInicial);

			foreach(DataRow drwEmpleado in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();
				objEmpleado.intCodStaff = Convert.ToInt32(drwEmpleado["emp_cod_empleado"]);
				objEmpleado.strNombreCorto = drwEmpleado["NombreCorto"].ToString();
				arrEmpleado.Add(objEmpleado);
			}
			return arrEmpleado;
		}


		public static ArrayList ListarSociosProyecto(int intCodGrupo, short shtCodEmpresa,
			short shtCodOficina, short shtCodLinea, short shtCodEsp, short shtCodProy, short shtCodRecurrencia)
		{
			ArrayList arlArregloEmpleados = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), 
				Queries.ES_ListarSociosProyecto, intCodGrupo, shtCodEmpresa, 
				shtCodOficina, shtCodLinea, shtCodEsp, shtCodProy, shtCodRecurrencia); 
			ESEmpleado SocioI = new ESEmpleado();
			SocioI.intCodStaff = 0;
			SocioI.strNombreCorto ="[Seleccione]";
			arlArregloEmpleados.Add(SocioI);
			short shtSw=0;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				ESEmpleado Socio = new ESEmpleado ();
				Socio.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
				Socio.strNombreCorto = r["NombreSocio"].ToString();
				if(shtSw==0)
				{   DataRow r1 = ds.Tables[1].Rows[0];
					Socio.intCodSocioEncargado=Convert.ToInt32(r1["SocioEncargado"]);
					shtSw++;
				}
				arlArregloEmpleados.Add(Socio);
				
			}
			return arlArregloEmpleados;			
		}

		public ArrayList ListarEmpleadoCierresProyecto(bool blnSocio)
		{
			ArrayList arrResultado = new ArrayList();
			DataSet dstResultado;
			
			if( blnSocio )
			{
				dstResultado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
					Queries.ES_ListarSociosCombo, _shtCodLinea, _shtCodOficina); 
			}
			else
			{
				dstResultado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
					Queries.ES_ListarGerentesCombo, _shtCodLinea, _shtCodOficina); 
			}
			
			foreach(DataRow drwResultado in dstResultado.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();

				objEmpleado.intCodStaff = Convert.ToInt32(drwResultado["emp_cod_empleado"]);
				objEmpleado.strNombreCorto = drwResultado["nombre"].ToString();

				arrResultado.Add(objEmpleado);
			}
			return arrResultado;
		}

		public static ArrayList ListarSocios(short Categoria, short LoS )
		{
			ArrayList arrEmpleado = new ArrayList();
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.ES_ListarEmpleados,LoS,Categoria,0,0); 

			ESEmpleado objInicial = new ESEmpleado(0,"[Todos]","[Todos]");
			arrEmpleado.Add(objInicial);

			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();

				objEmpleado.intCodStaff = Convert.ToInt32((r["emp_cod_empleado"]));
				objEmpleado.strCodStaff = string.Format("{0:00000}",r["emp_cod_empleado"]);
				objEmpleado.strNbr1 = r["emp_nbr_empleado1"].ToString();
				objEmpleado.strNbr2 = r["emp_nbr_empleado2"].ToString();
				objEmpleado.strApe1 = r["emp_ape_empleado1"].ToString();
				objEmpleado.strApe2 = r["emp_ape_empleado2"].ToString();
				objEmpleado.strIniciales = r["emp_abr_iniciales"].ToString();
				objEmpleado.shtCodLinea = Convert.ToInt16((r["emp_cod_linea"]));
				objEmpleado.shtCodCategoria = Convert.ToInt16((r["emp_cod_categoria"]));
				objEmpleado.shtCodOficina = Convert.ToInt16((r["emp_cod_oficina"]));
				objEmpleado.strAbrOficina = r["ofi_abr_oficina"].ToString();
				//				objEmpleado.strCargo = r["car_nbr_cargo"].ToString();
				objEmpleado.strCategoria = r["cat_desc_categoria"].ToString();
				objEmpleado.strLoS = r["lin_desc_linea"].ToString();
				objEmpleado.strOficina = r["ofi_desc_oficina"].ToString();
				objEmpleado.strEmail = r["emp_str_email"].ToString();
				objEmpleado.strCedula = r["emp_str_cedula"].ToString();
				objEmpleado.dttFechaIngreso = Convert.ToDateTime((r["emp_fecha_ingreso"]));
				objEmpleado.strNombreLargo = r["emp_ape_empleado1"].ToString() + " " + r["emp_ape_empleado2"].ToString() + ", " + r["emp_nbr_empleado1"].ToString() + " " + r["emp_nbr_empleado2"].ToString();
				objEmpleado.strNombreCorto = r["emp_nbr_empleado1"].ToString() + ", " + r["emp_ape_empleado1"].ToString();
				objEmpleado.strNbrAbr=objEmpleado.strNombreCorto+ " (" + objEmpleado.strIniciales + ") ";
				arrEmpleado.Add(objEmpleado);
			}
			return arrEmpleado;
		}

//===< By Ramón
		public static ArrayList BuscarEmpleadosCoordinadorRH(string strPABuscar, short shtPCodLinea, short shtPCodCategoria, bool blnInactivos, int intCodigoCoordinador)
		{
			ArrayList arrArregloEmpleados = new ArrayList();
			
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
					Queries.ES_BuscarEmpleados_CoordinadorRH,strPABuscar, shtPCodLinea, shtPCodCategoria, intCodigoCoordinador); 
			
			foreach(DataRow r in dstEmpleado.Tables[0].Rows)
			{
				ESEmpleado Empleado = new ESEmpleado();
				
				if( !blnInactivos ) // SOLO ACTIVOS
				{
					if( Convert.ToByte(r["emp_bln_activo"]) == 1 )
					{
						Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
						Empleado.strCodStaff = Convert.ToString(r["emp_cod_empleado"]);
						Empleado.strNombreLargo = r["emp_nbr_empleado"].ToString();
						Empleado.shtCodLinea = Convert.ToInt16(r["emp_cod_linea"]);
						Empleado.shtCodCategoria = Convert.ToInt16(r["cat_cod_categoria"]);
						Empleado.strCategoria = r["cat_desc_categoria"].ToString();
						Empleado.strUsuario = r["emp_str_usuario"].ToString();
						Empleado.bytActivo = 1;

						arrArregloEmpleados.Add(Empleado);
					}
				}
				else // TODOS
				{
					Empleado.intCodStaff = Convert.ToInt32(r["emp_cod_empleado"]);
					Empleado.strCodStaff = Convert.ToString(r["emp_cod_empleado"]);
					Empleado.strNombreLargo = r["emp_nbr_empleado"].ToString();
					Empleado.shtCodLinea = Convert.ToInt16(r["emp_cod_linea"]);
					Empleado.shtCodCategoria = Convert.ToInt16(r["cat_cod_categoria"]);
					Empleado.strCategoria = r["cat_desc_categoria"].ToString();
					Empleado.strUsuario = r["emp_str_usuario"].ToString();
					Empleado.bytActivo = Convert.ToByte(r["emp_bln_activo"]);

					arrArregloEmpleados.Add(Empleado);
				}
			}
			return arrArregloEmpleados;			
		}


		public static ArrayList CargarEncargadosDeProyecto(int intCodigoEncargado, bool blnSocio)
		{
			ArrayList arrResultado = new ArrayList();
			
			DataSet dstResultado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),
								Queries.ES_CargarEncargadosDeProyecto,intCodigoEncargado);

			ESEmpleado objInicial = new ESEmpleado(0,"Todos","Todos");
			arrResultado.Add(objInicial);
			
			foreach(DataRow r in dstResultado.Tables[0].Rows)
			{
				ESEmpleado objEmpleado = new ESEmpleado();
				
				objEmpleado.intCodStaff = Convert.ToInt32(r["codigo_socio"]);
				objEmpleado.strNombreLargo = r["nombre_socio"].ToString();
				
				if( blnSocio ) // ES EL SOCIO
				{
					objEmpleado.intCodStaff = Convert.ToInt32(r["codigo_gerente"]);
					objEmpleado.strNombreLargo = r["nombre_gerente"].ToString();
				}

				arrResultado.Add(objEmpleado);
			}
			return arrResultado;			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="intParCodStaff"></param>
		/// <param name="shtNumAnio"></param>
		/// <returns></returns>
		public  bool BuscarEmpleadoHistorico(int intParCodStaff, short shtNumAnio)
		{
			DataSet dstEmpleado = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(), 
				Queries.ES_BuscarEmpleadoHistorico,
				intParCodStaff,
				shtNumAnio); 
			
			if (dstEmpleado.Tables[0].Rows.Count < 1)
				return false;

			DataRow drwEmpleado = dstEmpleado.Tables[0].Rows[0];
			
			intCodStaff = Convert.ToInt32(drwEmpleado["emp_cod_empleado"]);
			strCodStaff = Convert.ToString(drwEmpleado["emp_cod_empleado"]);
			strCedula = Convert.ToString(drwEmpleado["emp_str_cedula"]);
			strNbr1 = drwEmpleado["emp_nbr_empleado1"].ToString();
			strNbr2 = drwEmpleado["emp_nbr_empleado2"].ToString();
			strApe1 = drwEmpleado["emp_ape_empleado1"].ToString();
			strApe2 = drwEmpleado["emp_ape_empleado2"].ToString();
			strIniciales = drwEmpleado["emp_abr_iniciales"].ToString();
			shtCodOficina = Convert.ToInt16(drwEmpleado["emh_cod_oficina"]);
			
			if ((Convert.ToByte(drwEmpleado["emh_bln_LoS_Dep"]) == 0) && (Convert.ToString(drwEmpleado["emh_cod_linea"]).Length != 0))
				shtCodLinea = Convert.ToInt16(drwEmpleado["emh_cod_linea"]);
			
			shtCodCategoria = Convert.ToInt16(drwEmpleado["emh_cod_categoria"]);
			shtCodTipoEmpleado = Convert.ToInt16(drwEmpleado["emh_cod_tipo_empleado"]);
			strEmail = drwEmpleado["emp_str_email"].ToString();
			strOficina = drwEmpleado["ofi_desc_oficina"].ToString();
			strAbrOficina = drwEmpleado["ofi_abr_oficina"].ToString();
			strLoS = drwEmpleado["lin_desc_linea"].ToString();
			strCategoria = drwEmpleado["cat_desc_categoria"].ToString();
			strNombreCorto = drwEmpleado["nombrecorto"].ToString();
			strNombreLargo = drwEmpleado["nombrelargo"].ToString();
			strDepartamento = Convert.ToString(drwEmpleado["dep_desc_departamento"]);
			
			if ((Convert.ToByte(drwEmpleado["emh_bln_LoS_Dep"]) == 1) && (Convert.ToString(drwEmpleado["emh_cod_departamento"]).Length != 0))
				shtCodDepartamento = Convert.ToInt16(drwEmpleado["emh_cod_departamento"]);
			
			if(strIniciales.Length<=0)
				strIniciales=ObtenerIniciales(strNbr1,strApe1);
			
			if ( Convert.ToString(drwEmpleado["emp_fecha_ingreso"]).Length != 0 )
			{
				dttFechaIngreso = Convert.ToDateTime(drwEmpleado["emp_fecha_ingreso"]);
				strFechaIngreso = dttFechaIngreso.ToShortDateString();
			}
			else
				strFechaIngreso = string.Empty;
			
			if ( Convert.ToString(drwEmpleado["emp_fecha_egreso"]).Length != 0 )
			{
				dttFechaEgreso = Convert.ToDateTime(drwEmpleado["emp_fecha_egreso"]);
				strFechaEgreso = dttFechaEgreso.ToShortDateString();
			}
			else
				strFechaEgreso = string.Empty;
			
			shtIdCoordinador = Convert.ToInt16(drwEmpleado["emp_id_coordinador"]);
			bytMedioTiempo = Convert.ToByte(drwEmpleado["emp_bln_medio_tiempo"]);
			
			if ((Convert.ToByte(drwEmpleado["emh_bln_LoS_Dep"]) == 1))
			{
				if (drwEmpleado["dep_desc_departamento"] != System.DBNull.Value)
					strDeparLoS = Convert.ToString(drwEmpleado["dep_desc_departamento"]);

				if (drwEmpleado["emh_cod_departamento"] != System.DBNull.Value)
					shtDeparLoS = Convert.ToInt16(drwEmpleado["emh_cod_departamento"]);
			}
			else
			{
				strDeparLoS = Convert.ToString(drwEmpleado["lin_desc_linea"]);
				shtDeparLoS = Convert.ToInt16(drwEmpleado["emh_cod_linea"]);
			}

			if (Convert.ToString(drwEmpleado["emp_num_horas_trabajo"]).Length != 0)
				intHorasTrabajo = Convert.ToInt32(drwEmpleado["emp_num_horas_trabajo"]);
			else
			{
				if (bytMedioTiempo == 0)
					intHorasTrabajo = 8;
				else
					intHorasTrabajo = 4; 
			}

			chrSexo = Convert.ToChar(drwEmpleado["emp_val_sexo"]);

			return true;			
		}

//===>

	}
}
