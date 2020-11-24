//Desarrollado por:		Ramón Rosales.
//Fecha de Creación:	11/07/2008

using System;
using System.Collections;
using System.Configuration;
// Para encriptar y desencriptar
using System.Security.Cryptography;
using System.Text; 
using System.IO;

namespace WinflowAC
{
	/// <summary>
	/// Summary description for ConnectionString.
	/// </summary>
	public class ConnectionString
	{
		public ConnectionString()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static ArrayList CargarArchivoConexion(ArrayList arrDatos)
		{
			arrDatos = new ArrayList();
			
			StreamReader objReader = new StreamReader(@"c:\Inetpub\wwwroot\"+ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeyPath]+"\\"+ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeyPath]+".txt");

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
			StreamReader objReader = new StreamReader(@"c:\Inetpub\wwwroot\"+ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeyPath]+"\\"+ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeyPath]+".txt");

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
	}
}
