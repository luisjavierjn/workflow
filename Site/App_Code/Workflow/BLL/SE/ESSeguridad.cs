
using System;
using System.Web;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
using System.Collections;
using Componentes.DAL;
using Mensajeria;

// Para encriptar y desencriptar
using System.Security.Cryptography;
using System.Text; 
using System.IO;

namespace Componentes.BLL.SE
{
	/// <summary>
	/// ESSeguridad, se encarga de los procesos relacionados con seguridad del sistema, como encriptación 
	/// de contraseñas y validación de perfiles de seguridad.
	/// </summary>
	
	public class ESSeguridad
	{	
		public ESSeguridad()
		{
		}

		public static string Encriptar(string cleanString)
		{
			Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
			Byte[] hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
			
			return BitConverter.ToString(hashedBytes);
		}

		//*********************************************************************
		//
		// <summary>
		// Validates the input text using a Regular Expression and replaces any input expression
		// characters with empty string.Removes any characters not in [a-zA-Z0-9_]. 
		// <summary>
		// <remarks>
		// For a good reference on Regular Expressions, please see
		//	 - http://regexlib.com
		//	 - http://py-howto.sourceforge.net/regex/regex.html
		// </remarks>
		// <param name="inputText">The text to validate.</param>
		// <returns>Sanitized string</returns>
		//
		//*********************************************************************

		public static string CleanStringRegex(string inputText)
		{
			RegexOptions options = RegexOptions.IgnoreCase;
			return ReplaceRegex(inputText,@"[^\\.!?""',\-\w\s@]",options);
		}

		//*********************************************************************
		//
		// <summary>
		// Removes designated characters from an input string input text using a Regular Expression.
		// </summary>
		// <remarks>
		// For a good reference on Regular Expressions, please see
		//	 - http://regexlib.com
		//	 - http://py-howto.sourceforge.net/regex/regex.html
		// </remarks>
		// <param name="inputText">The text to clean.</param>
		// <param name="regularExpression">The regular expression</param>
		// <returns>Sanitized string.</returns>
		//
		//*********************************************************************

		private static string ReplaceRegex(string inputText, string regularExpression, RegexOptions options)
		{
			Regex regex = new Regex(regularExpression,options);
			return regex.Replace(inputText,"");
		}


		public static bool CaracterEspecial(string strTexto, bool blnVariableControl)
		{
			blnVariableControl = ( strTexto.IndexOf("|",0) >= 0 ) ? true : blnVariableControl;
			blnVariableControl = ( strTexto.IndexOf("^",0) >= 0 ) ? true : blnVariableControl;
			blnVariableControl = ( strTexto.IndexOf("<",0) >= 0 ) ? true : blnVariableControl;
			blnVariableControl = ( strTexto.IndexOf(">",0) >= 0 ) ? true : blnVariableControl;

			return blnVariableControl;
		}

		public static bool VerificarAcceso(int intEmpleado, string strRequerimiento, short shtTransaccion)
		{
			return Convert.ToBoolean(SqlHelper.ExecuteScalar(ESSeguridad.FormarStringConexion(),Queries.ES_VerificarAcceso, intEmpleado, strRequerimiento, shtTransaccion)); 
		}

		public static ArrayList CargarArchivoConexion(ArrayList arrDatos)
		{
			arrDatos = new ArrayList();
			
			StreamReader objReader = new StreamReader(@"c:\Inetpub\wwwroot\"+ConfigurationSettings.AppSettings[Web.Global.CfgKeyPath]+"\\"+ConfigurationSettings.AppSettings[Web.Global.CfgKeyPath]+".txt");

			string sLine="";
			while (sLine != null)
			{
				sLine = objReader.ReadLine();
				if (sLine != null)
					arrDatos.Add(sLine);
			}

			objReader.Close();
			objReader = null;

			return arrDatos;
		}

		public static string CargarContrasenaConexion()
		{
			StreamReader objReader = new StreamReader(@"c:\Inetpub\wwwroot\"+ConfigurationSettings.AppSettings[Web.Global.CfgKeyPath]+"\\"+ConfigurationSettings.AppSettings[Web.Global.CfgKeyPath]+".txt");

			string sLine = "";
			string strContrasena = string.Empty;
			short shtIndice = 0;
			while (sLine != null)
			{
				sLine = objReader.ReadLine();
				if( shtIndice == 4 ) // CONTRASEÑA
				{
					strContrasena = sLine;
					sLine = null;
				}
				else
					shtIndice ++;
			}

			objReader.Close();
			objReader = null;

			return DesencriptarTexto(strContrasena,null);
		}

		public static bool ActualizarArchivoConexion(ArrayList arrDatos, string strPasswordNuevo)
		{	
			StreamWriter objWriter = new StreamWriter(@"c:\Inetpub\wwwroot\"+ConfigurationSettings.AppSettings[Web.Global.CfgKeyPath]+"\\"+ConfigurationSettings.AppSettings[Web.Global.CfgKeyPath]+".txt");

			for( int i=0; i<arrDatos.Count; i++ )
			{
				switch(i)
				{
					case 4 : // CONTRASEÑA
						objWriter.WriteLine(strPasswordNuevo);
						break;
					case 5 : // FECHA DEL CAMBIO
						objWriter.WriteLine(DateTime.Today.ToShortDateString());
						break;
					default:
						objWriter.WriteLine(arrDatos[i]);
						break;
				}
			}

			objWriter.Close();
			objWriter = null;

			// VALIDO SI SE CREO BIEN EL ARCHIVO
			ArrayList arrDatosNuevos = new ArrayList();
			arrDatosNuevos = CargarArchivoConexion(arrDatosNuevos);
			if( (arrDatosNuevos[4].ToString() == strPasswordNuevo) &&
				(arrDatosNuevos[5].ToString() == DateTime.Today.ToShortDateString()) )
				return true;
			else
				return false;
		}

		public static void RestaurarArchivoConexion(ArrayList arrDatos, string strPasswordViejo, string strFechaVieja)
		{	
			StreamWriter objWriter = new StreamWriter(@"c:\Inetpub\wwwroot\"+ConfigurationSettings.AppSettings[Web.Global.CfgKeyPath]+"\\"+ConfigurationSettings.AppSettings[Web.Global.CfgKeyPath]+".txt");

			for( int i=0; i<arrDatos.Count; i++ )
			{
				switch(i)
				{
					case 4 : // CONTRASEÑA
						objWriter.WriteLine(strPasswordViejo);
						break;
					case 5 : // FECHA DEL CAMBIO
						objWriter.WriteLine(strFechaVieja);
						break;
					default:
						objWriter.WriteLine(arrDatos[i]);
						break;
				}
			}

			objWriter.Close();
			objWriter = null;
		}

		public static string FormarStringConexion()
		{
			ArrayList arrConexion = new ArrayList();
			string strConexion = string.Empty;
			string strPwd = string.Empty;

			arrConexion = CargarArchivoConexion(arrConexion);

			strPwd = DesencriptarTexto(arrConexion[4].ToString(), arrConexion);
			
			strConexion = "server="+ arrConexion[0] +";Trusted_Connection="+ arrConexion[1] +";database="+ arrConexion[2] +";user id='"+ arrConexion[3] +"';pwd='"+ strPwd +"'";
			arrConexion = null;

			return strConexion;
		}

		public static string EncriptarTexto(string strTexto, ArrayList arrPConexion)
		{
			byte[] mIV = new byte[8];
			byte[] mKey = new byte[8];
			ArrayList arrConexion = new ArrayList();
			string strMIV = string.Empty;
			string strMKey = string.Empty;
			string strAuxiliar = string.Empty;
			bool blnContinuar = true;
			DESCryptoServiceProvider des;
			byte[] inputByteArray;
			MemoryStream ms;
			CryptoStream cs;
			
			if( arrPConexion == null )
				arrConexion = CargarArchivoConexion(arrConexion);
			else
				arrConexion = arrPConexion;
			
			strMIV = arrConexion[6].ToString();
			strMKey = arrConexion[7].ToString();

			while(blnContinuar)
			{
				strAuxiliar = strMIV.Substring(0,4);
				mIV[Convert.ToInt32(strAuxiliar.Substring(2,2))-1] = Convert.ToByte(strAuxiliar.Substring(0,2));

				strAuxiliar = strMKey.Substring(0,4);
				mKey[Convert.ToInt32(strAuxiliar.Substring(2,2))-1] = Convert.ToByte(strAuxiliar.Substring(0,2));

				if( strMIV.Length > 4 )
				{
					strMIV = strMIV.Substring(5);
					strMKey = strMKey.Substring(5);
				}
				else
					blnContinuar = false;
			}

			try
			{
				des = new DESCryptoServiceProvider();
				inputByteArray = Encoding.UTF8.GetBytes(strTexto);
				ms = new MemoryStream();
				cs = new CryptoStream(ms, des.CreateEncryptor(mKey, mIV), CryptoStreamMode.Write);
				cs.Write(inputByteArray, 0, inputByteArray.Length);
				cs.FlushFinalBlock();
			}
			catch(Exception e)
			{  
				System.Console.WriteLine(e.Message + " " + e.InnerException);
				
				des = null;
				ms = null;
				cs = null;
				arrConexion = null;
				strMIV = null;
				strMKey = null;
				strAuxiliar = null;
				
				return "-1";
			}

			strAuxiliar = Convert.ToBase64String(ms.ToArray());
			des = null;
			ms = null;
			cs = null;
			arrConexion = null;
			strMIV = null;
			strMKey = null;
			
			return strAuxiliar;
		}

		public static string DesencriptarTexto(string strTexto, ArrayList arrPConexion)
		{
			byte[] mIV = new byte[8];
			byte[] mKey = new byte[8];
			ArrayList arrConexion = new ArrayList();
			string strMIV = string.Empty;
			string strMKey = string.Empty;
			string strAuxiliar = string.Empty;
			bool blnContinuar = true;
			DESCryptoServiceProvider des;
			byte[] inputByteArray;
			System.Text.Encoding encoding;
			MemoryStream ms;
			CryptoStream cs;
			
			if( arrPConexion == null )
				arrConexion = CargarArchivoConexion(arrConexion);
			else
				arrConexion = arrPConexion;

			strMIV = arrConexion[6].ToString();
			strMKey = arrConexion[7].ToString();

			while(blnContinuar)
			{
				strAuxiliar = strMIV.Substring(0,4);
				mIV[Convert.ToInt32(strAuxiliar.Substring(2,2))-1] = Convert.ToByte(strAuxiliar.Substring(0,2));

				strAuxiliar = strMKey.Substring(0,4);
				mKey[Convert.ToInt32(strAuxiliar.Substring(2,2))-1] = Convert.ToByte(strAuxiliar.Substring(0,2));

				if( strMIV.Length > 4 )
				{
					strMIV = strMIV.Substring(5);
					strMKey = strMKey.Substring(5);
				}
				else
					blnContinuar = false;
			}

			try
			{
				des = new DESCryptoServiceProvider();
				inputByteArray = Convert.FromBase64String(strTexto);
				ms = new MemoryStream();
				cs = new CryptoStream(ms, des.CreateDecryptor(mKey, mIV), CryptoStreamMode.Write);
				cs.Write(inputByteArray, 0, inputByteArray.Length);
				cs.FlushFinalBlock();
			}
			catch(Exception e)
			{  
				System.Console.WriteLine(e.Message + " " + e.InnerException);
				
				des = null;
				ms = null;
				cs = null;
				arrConexion = null;
				strMIV = null;
				strMKey = null;
				strAuxiliar = null;
				
				return "-1";
			}

			encoding = System.Text.Encoding.UTF8;
			strAuxiliar = encoding.GetString(ms.ToArray());
			des = null;
			ms = null;
			cs = null;
			arrConexion = null;
			strMIV = null;
			strMKey = null;
			
			return strAuxiliar;
		}

		public static bool VerificarGeneracionConexion(string strPassword, short shtGeneraciones)
		{
			return	Convert.ToBoolean(SqlHelper.ExecuteScalar(
				ESSeguridad.FormarStringConexion(),
				Queries.ES_VerificarGeneracionConexion,
				strPassword,
				shtGeneraciones));
		}

		public static short VerificarCaducidadConexion()
		{
			return	Convert.ToInt16(SqlHelper.ExecuteScalar(
				ESSeguridad.FormarStringConexion(),
				Queries.ES_VerificarCaducidadConexion));
		}
		
		public static short VerificarDiasDeVigencia()
		{
			return	Convert.ToInt16(SqlHelper.ExecuteScalar(
				ESSeguridad.FormarStringConexion(),
				Queries.ES_VerificarDiasDeVigencia));
		}

		public static bool CambiarContrasenaConexion(string strPassword,
					string strPasswordViejoPlano, string strPasswordNuevoPlano, int intCodigoEmpleado)
		{
			try
			{
				SqlHelper.ExecuteScalar(
					ESSeguridad.FormarStringConexion(),
					Queries.ES_CambiarContrasenaConexion,
					strPassword);

				SqlHelper.ExecuteScalar(
					ESSeguridad.FormarStringConexion(),
					Queries.ES_CambiarContrasenaSA,
					strPasswordViejoPlano,
					strPasswordNuevoPlano,
					intCodigoEmpleado);
				
				return true;
			}
			catch(Exception e)
			{  
				System.Console.WriteLine(e.Message + " " + e.InnerException);
				return false;
			}
		}
	}
}
