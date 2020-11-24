using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using Mensajeria;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Web.Security;
using System.Web.SessionState;
using System.Web;
using MSXML2;
using System.Web.UI.WebControls;

namespace WinflowAC
{
	public enum Estatus
	{
		CREADO			= 1,
		SIN_RESPUESTA	= 5,
		RECHAZADO		= 7,
		POR_CORREGIR	= 11,
		EN_TRANSICION	= 12,
		APROBADO		= 13,
		CORREGIDO		= 14,
		REVISADO		= 16,
		PENDIENTE		= 17
	}

	/// <summary>
	/// Summary description for StateProcSmpl.
	/// </summary>
	public class StateProcSmpl : StateMachine
	{
		// Códigos de Staff
		private int _staff_origen;
		private int _staff_from;
		private int _staff_to;

		// Email
		private string _email_origen;
		private string _email_from;
		private string _email_to;

		private string _roles;
		private string [] _ruta;
		private int _index;

		private string _email_title;
		private string _email_from_sys;

		public void ActualizarAprobador(int codHasta, int SolicitudActual)
		{
			_staff_to = codHasta;
			DataSet dsD = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_BuscarEmpleadoEspecifico,_staff_to);
			_email_to = dsD.Tables[0].Rows[0]["emp_str_email"].ToString();

			try
			{
				DataSet dsApp = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ActualizarAprobadorHistoricoVerificar, SolicitudActual, codHasta, _index,0);
				int intIndexInterno = Convert.ToInt32(dsApp.Tables[0].Rows[0]["Resultado"]);
				if(intIndexInterno==1)
					_index++;
			}
			catch(Exception App)
			{
				System.Console.Write(App.Message);
			}
	

		}
		public StateProcSmpl(int idSolicitud, int idWorkflow, string idReferencia, int ESTADO, string listaRoles, int Index) 
			: base(idSolicitud,idWorkflow,idReferencia,ESTADO)
		{
			_roles = listaRoles;
			_index = Index;

			if(_roles != "")
			{
				string _aux_roles = _roles.Substring(0,_roles.Length-1);
				_ruta = _aux_roles.Split(';');				
			}
			else
			{
				throw new Exception("No se logró establecer una ruta para el workflow");
			}
		}
		public StateProcSmpl(int idSolicitud, int idWorkflow, string idReferencia, int ESTADO, string listaRoles, int Index, int intCodCreador, string prevXml) 
			: base(idSolicitud,idWorkflow,idReferencia,ESTADO)
		{
			_roles = listaRoles;
			_index = Index;
			_staff_origen = intCodCreador;
			prevXmlData = prevXml;
			xmlData=prevXml;
			if(_roles != "")
			{
				string _aux_roles = _roles.Substring(0,_roles.Length-1);
				_ruta = _aux_roles.Split(';');				
			}
			else
			{
				throw new Exception("No se logró establecer una ruta para el workflow");
			}
		}
		public StateProcSmpl(int idSolicitud, int idWorkflow, string idReferencia, int ESTADO, int estadoDoc, string listaRoles, int Index, string prevXml, string xml, int codCreador, int codDesde, int codHasta) 
			: base(idSolicitud,idWorkflow,idReferencia,ESTADO)
		{
			_roles = listaRoles;
			_index = Index;

			if(_roles != "")
			{
				string _aux_roles = _roles.Substring(0,_roles.Length-1);
				_ruta = _aux_roles.Split(';');				
			}
			else
			{
				throw new Exception("No se logró establecer una ruta para el workflow");
			}

			//-------------------------------------------------------------------------------//

			prevXmlData = prevXml;
			xmlData = xml;

			_statusDoc = estadoDoc;

			_staff_origen = codCreador;
			DataSet dsO = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_BuscarEmpleadoEspecifico,_staff_origen);
			_email_origen = dsO.Tables[0].Rows[0]["emp_str_email"].ToString();

			_staff_from = codDesde;
			DataSet dsF = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_BuscarEmpleadoEspecifico,_staff_from);
			_email_from = dsF.Tables[0].Rows[0]["emp_str_email"].ToString();

			_staff_to = codHasta;
			DataSet dsD = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_BuscarEmpleadoEspecifico,_staff_to);
			_email_to = dsD.Tables[0].Rows[0]["emp_str_email"].ToString();
		}

		protected override void Inicio()
		{
			_email_title = "";
			_email_from_sys = "";
			_statusDoc = (int)Estatus.CREADO;

			_Referencia = root.childNodes[1].text; 
			_staff_from = int.Parse(root.childNodes[2].text);
			_staff_origen = _staff_from;
			_staff_to = int.Parse(root.childNodes[3].text);
			_Observacion = string.Empty;

			DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_BuscarEmpleadoEspecifico,_staff_from);
			_email_from = ds.Tables[0].Rows[0]["emp_str_email"].ToString();
			_email_origen = _email_from;

			// Se sale de este estado con un evento manual
			GuardarHistorico(_idSolicitud,_statusDoc,INICIO,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);
		}

		protected override void EnviarRecordatorioDeAprobacion()
		{
			_statusDoc = (int)Estatus.PENDIENTE;
			_Observacion = string.Empty;
			string Mensaje = ConstruirMensaje(_idWorkflow,_Referencia,ENVIAR_RECORDATORIO_DE_APROBACION,out _email_title, out _email_from_sys);
			EmailHelper.SendEmail(ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeySmtpServer],_email_to,_email_from_sys,_email_title,Mensaje,System.Web.Mail.MailFormat.Html);

			// Se sale de este estado por eventos automáticos selectivos, no se trata de un evento manual o
			// automático neutro, de manera que no se puede guardar en el histórico porque después no se puede
			// retomar el funcionamiento de la máquina de estado
		}

		protected override void EnviarRecordatorioDeCorreccion()
		{
			_statusDoc = (int)Estatus.POR_CORREGIR;
			_Observacion = string.Empty;
			string Mensaje = ConstruirMensaje(_idWorkflow,_Referencia,ENVIAR_RECORDATORIO_DE_CORRECCION,out _email_title, out _email_from_sys);
			EmailHelper.SendEmail(ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeySmtpServer],_email_origen,_email_from_sys,_email_title,Mensaje,System.Web.Mail.MailFormat.Html);

			// Se sale de este estado con un evento automático [Neutro]
//			GuardarHistorico(_idSolicitud,_statusDoc,ENVIAR_RECORDATORIO_DE_CORRECCION,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);

			// Se sale de este estado con un evento automático [Neutro]
			//GuardarHistorico(_idSolicitud,_statusDoc,ENVIAR_RECORDATORIO_DE_CORRECCION,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);

			// Se sale de este estado por eventos automáticos selectivos, no se trata de un evento manual o
			// automático neutro, de manera que no se puede guardar en el histórico porque después no se puede
			// retomar el funcionamiento de la máquina de estado
		}

		protected override void EnviarMsgAlRemitente()
		{
			_statusDoc = (int)Estatus.SIN_RESPUESTA;
			_Observacion = string.Empty;
			string Mensaje = ConstruirMensaje(_idWorkflow,_Referencia,ENVIAR_MSG_AL_REMITENTE,out _email_title, out _email_from_sys);
			EmailHelper.SendEmail(ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeySmtpServer],_email_from,_email_from_sys,_email_title,Mensaje,System.Web.Mail.MailFormat.Html);

			// Se sale de este estado con un evento automático [Neutro]
			GuardarHistorico(_idSolicitud,_statusDoc,ENVIAR_MSG_AL_REMITENTE,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);
		}

		protected override void EnviarNotifDeAprobacion()
		{
			_statusDoc = (int)Estatus.REVISADO;
			//_Observacion = _index + 1 < _ruta.Length ? root.childNodes[3].text : string.Empty;
            _Observacion = string.Empty;
			bool _fecha = _index + 1 < _ruta.Length ? true : false;
			DOMDocument Xml = new DOMDocument();
			Xml.loadXML(prevXmlData);
			IXMLDOMElement _root = Xml.documentElement;

			if(_index < _ruta.Length)
			{
				_staff_from = int.Parse(_root.childNodes[2].text);
				DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_BuscarEmpleadoEspecifico,_staff_from);
				_email_from = ds.Tables[0].Rows[0]["emp_str_email"].ToString();
			}
			
			//string Mensaje = ConstruirMensaje(_idWorkflow,_Referencia,ENVIAR_NOTIF_DE_APROBACION,out _email_title, out _email_from_sys);
			//EmailHelper.SendEmail(ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeySmtpServer],_email_origen,_email_from_sys,_email_title,Mensaje,System.Web.Mail.MailFormat.Html);
			//=====================================================
			// NUEVO FORMA
			//=====================================================
			string Mensaje = "";
			DataSet dstSolicitud = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_CargarDatosSolicitud,_idWorkflow,_Referencia);
			if( Convert.ToInt16(dstSolicitud.Tables[0].Rows[0]["posicion"]) == Convert.ToInt16(dstSolicitud.Tables[0].Rows[0]["num_aprob"]) ) // SI ES LA PROBACION FINAL
				Mensaje = ConstruirMensajeAprobacion(_idWorkflow,_Referencia,ENVIAR_NOTIF_DE_APROBACION,out _email_title, out _email_from_sys);
			else
				Mensaje = ConstruirMensaje(_idWorkflow,_Referencia,ENVIAR_NOTIF_DE_APROBACION,out _email_title, out _email_from_sys);

			EmailHelper.SendEmail(ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeySmtpServer],_email_origen,_email_from_sys,_email_title,Mensaje,System.Web.Mail.MailFormat.Html);
			dstSolicitud = null;
			//=====================================================
			//=====================================================

			_index ++;

			// Se sale de este estado con un evento automático [Neutro]
			GuardarHistorico(_idSolicitud,_statusDoc,ENVIAR_NOTIF_DE_APROBACION,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,_fecha);
		}

		protected override void EnviarNotifDeCorreccion()
		{
			_statusDoc = (int)Estatus.CORREGIDO;
			//_Observacion = root.childNodes[3].text;
			_Observacion = string.Empty;
            _staff_from = _staff_to;
			_staff_to = int.Parse(root.childNodes[2].text);
			DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_BuscarEmpleadoEspecifico,_staff_to);
			_email_to = ds.Tables[0].Rows[0]["emp_str_email"].ToString();
			_index = 1;

			// Se sale de este estado con un evento automático [Neutro]
			GuardarHistorico(_idSolicitud,_statusDoc,ENVIAR_NOTIF_DE_CORRECCION,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);
		}

		protected override void EnviarNotifDeRechazoTotal()
		{
			_statusDoc = (int)Estatus.RECHAZADO;
			//_Observacion = root.childNodes[3].text;
			_Observacion = string.Empty;
            _staff_from = _staff_to;
            _staff_to = int.Parse(root.childNodes[2].text);
			string Mensaje = ConstruirMensaje(_idWorkflow,_Referencia,ENVIAR_NOTIF_DE_RECHAZO_TOTAL,out _email_title, out _email_from_sys);
			EmailHelper.SendEmail(ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeySmtpServer],_email_origen,_email_from_sys,_email_title,Mensaje,System.Web.Mail.MailFormat.Html);

			// Se sale de este estado con un evento automático [Neutro]
			GuardarHistorico(_idSolicitud,_statusDoc,ENVIAR_NOTIF_DE_RECHAZO_TOTAL,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);
		}

		protected override void EnviarNotifDeRechazoParcial()
		{
			_statusDoc = (int)Estatus.POR_CORREGIR;
            //_Observacion = root.childNodes[3].text;
			_Observacion = string.Empty;
            _staff_from = _staff_to;
            _staff_to = int.Parse(root.childNodes[2].text);
			string Mensaje = ConstruirMensaje(_idWorkflow,_Referencia,ENVIAR_NOTIF_DE_RECHAZO_PARCIAL,out _email_title, out _email_from_sys);
			EmailHelper.SendEmail(ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeySmtpServer],_email_origen,_email_from_sys,_email_title,Mensaje,System.Web.Mail.MailFormat.Html);
			_index = 1;

			// Se sale de este estado con un evento automático [Neutro]
			GuardarHistorico(_idSolicitud,_statusDoc,ENVIAR_NOTIF_DE_RECHAZO_PARCIAL,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);
		}

		protected override void GenerarDatosDeInterfaz()
		{
			_statusDoc = (int)Estatus.APROBADO;
			_Observacion = string.Empty;

			// Se sale de este estado con un evento automático [Neutro]
			GuardarHistorico(_idSolicitud,_statusDoc,GENERAR_DATOS_DE_INTERFAZ,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);
		}

		protected override Eventos EncontrarDestinatarios()
		{
			_statusDoc = (int)Estatus.EN_TRANSICION;
			_Observacion = string.Empty;
			Eventos retVal = Eventos.NEUTRO;

			if(_index < _ruta.Length)
			{
				_staff_to = int.Parse(root.childNodes[2].text);
				DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_BuscarEmpleadoEspecifico,_staff_to);
				_email_to = ds.Tables[0].Rows[0]["emp_str_email"].ToString();

				retVal = Eventos.DESTINARIO_ENCONTRADO;
			} 
			else
			{
				retVal = Eventos.ULTIMO_DESTINATARIO;
			}

			// Se sale de este estado por eventos automáticos selectivos, no se trata de un evento manual o
			// automático neutro, de manera que no se puede guardar en el histórico porque después no se puede
			// retomar el funcionamiento de la máquina de estado
			return retVal;		
		}

		protected override void EsperarAprobacion()
		{
			if(_regAprob)
			{
				_statusDoc = (int)Estatus.PENDIENTE;
                _Observacion = root.childNodes[3].text;
				//_Observacion = string.Empty;
				string Mensaje = ConstruirMensaje(_idWorkflow,_Referencia,ESPERAR_APROBACION,out _email_title, out _email_from_sys);
				EmailHelper.SendEmail(ConfigurationSettings.AppSettings[WinflowAC.Global.CfgKeySmtpServer],_email_to,_email_from_sys,_email_title,Mensaje,System.Web.Mail.MailFormat.Html);

				// Se sale de este estado con un evento manual o por un evento automático selectivo. Sin embargo,
				// lo importante es que se sale con un evento manual es por eso que se puede guardar el histórico
				 GuardarHistorico(_idSolicitud,_statusDoc,ESPERAR_APROBACION,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);

				_regAprob = false;
			}
		}

		protected override void EsperarCorreccion()
		{
			if(_regCorre)
			{
				_Observacion = root.childNodes[3].text;
                //_Observacion = string.Empty;
				// Se sale de este estado con un evento manual o por un evento automático selectivo. Sin embargo,
				// lo importante es que se sale con un evento manual es por eso que se puede guardar el histórico
				GuardarHistorico(_idSolicitud,_statusDoc,ESPERAR_CORRECCION,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,true);

				_regCorre = false;
			}
		}

		protected override void Standby()
		{
			// Se sale de este estado con un evento manual
			GuardarHistorico(_idSolicitud,_statusDoc,STANDBY,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,false);
		}

		protected override void Fin()
		{
			// Este es único método donde no se actualiza el estado del documento 
			// porque conviene que finalice con el último status obtenido
			_Observacion = root.childNodes[3].text;

			// Al terminar este método sencillamente el workflow terminó y ni siquiera es tomado en cuenta
			GuardarHistorico(_idSolicitud,_statusDoc,FIN,_Observacion,_index,_staff_from,_staff_to,prevXmlData,xmlData,true);
		}

		private string ConstruirMensaje(int idWorkflow, string Referencia, int idEstatusWkf, out string emailTitle, out string emailFromSys)
		{
			/*
			DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ObtenerDatosEmail,idWorkflow,idEstatusWkf);

			Referencia = Referencia.Trim();
			string workflowName = ds.Tables[0].Rows[0]["wkf_nbr_documento"].ToString();
			emailTitle = ds.Tables[0].Rows[0]["ewf_nbr_titulo"].ToString();
			string explicacion = ds.Tables[0].Rows[0]["ewf_desc_explicacion"].ToString();
			emailFromSys = "SISTEMA_SPIN@soacat-ve";

			DataSet dsSolicitante = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ObtenerNombreSolicitante,idWorkflow,Referencia);
			string strSolicitante = dsSolicitante.Tables[0].Rows[0]["Solicitante"].ToString(); 
			string strData = "";

			if( (idWorkflow >= 308 && idWorkflow <= 311) || ( idWorkflow == 318 ) ) // CIERRES DE AUXILIARES
			{
				DataSet dstProyecto = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_CargarInfProyectoPorReferencia,Convert.ToInt32(Referencia));
				Referencia += " / Cliente: " + dstProyecto.Tables[0].Rows[0]["cliente"].ToString(); 
				Referencia += " / Socio: " + dstProyecto.Tables[0].Rows[0]["socio"].ToString(); 
			}

			string strServidor=System.Net.Dns.GetHostName();//GetHostByAddress(Request.ServerVariables["REMOTE_ADDR"]).HostName;
			strData += "<root><param0>"+workflowName+"</param0>";
			strData += "<param1>"+Referencia+"</param1>";
			strData += "<param2>"+strSolicitante+"</param2>";
			strData += "<param3>"+explicacion+"</param3>";
			strData += "<param4>"+strServidor+"</param4></root>";
			
			DOMDocument xslDoc = new DOMDocument();
			DOMDocument xmlDoc = new DOMDocument();
			
			xslDoc.load("EWIGF001A.xsl");
			xmlDoc.loadXML(strData);
			*/

			
			//=====================================================
			// NUEVO FORMATO DE CORREO
			//=====================================================
			DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ObtenerDatosEmail,idWorkflow,idEstatusWkf);
			Referencia = Referencia.Trim();
			string workflowName = ds.Tables[0].Rows[0]["wkf_nbr_documento"].ToString();
			string strAccion = " " + ds.Tables[0].Rows[0]["ewf_nbr_titulo"].ToString();
			string explicacion = ds.Tables[0].Rows[0]["ewf_desc_explicacion"].ToString();

			emailTitle = "";
			emailFromSys = "SISTEMA_SPIN@soacat-ve";
			string strSubTitulo = "";

			DataSet dsSolicitante = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ObtenerNombreSolicitante,idWorkflow,Referencia);
			string strSolicitante = dsSolicitante.Tables[0].Rows[0]["Solicitante"].ToString();
			string strFechaSolicitud = dsSolicitante.Tables[0].Rows[0]["fecha_solicitud"].ToString();
			string strData = "";
			
			string strImagenSemaforo = "";
			if(idEstatusWkf == 310 || idEstatusWkf == 280)
			{
				if(idEstatusWkf == 310) // SOLICITADO
					emailTitle = "Pendiente por " + strAccion + " - " + workflowName;
				if(idEstatusWkf == 280) // RECHAZO PARCIAL
				{
					emailTitle = strAccion + " - " + workflowName;
					strAccion = "";
				}
				
				strImagenSemaforo = "http://localhost/Spin/WF/bin/Debug/semaforo_amarillo.jpg";
				strSubTitulo = strAccion + " DE DOCUMENTOS";
			}
			if(idEstatusWkf == 250) // REVISADO
			{
				emailTitle = strAccion + " - " + workflowName;
				strImagenSemaforo = "http://localhost/Spin/WF/bin/Debug/semaforo_amarillo.jpg";
				strSubTitulo = "DOCUMENTO " + strAccion;
				strAccion = "";
			}
			if(idEstatusWkf == 270) // RECHAZO TOTAL
			{
				emailTitle = strAccion + " - " + workflowName;
				strImagenSemaforo = "http://localhost/Spin/WF/bin/Debug/semaforo_rojo.jpg";
				strSubTitulo = strAccion + " DE DOCUMENTOS";
				strAccion = "";
			}

			if( (idWorkflow >= 308 && idWorkflow <= 311) || ( idWorkflow == 318 ) ) // CIERRES DE AUXILIARES
			{
				DataSet dstProyecto = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_CargarInfProyectoPorReferencia,Convert.ToInt32(Referencia));
				Referencia += " / Cliente: " + dstProyecto.Tables[0].Rows[0]["cliente"].ToString(); 
				Referencia += " / Socio: " + dstProyecto.Tables[0].Rows[0]["socio"].ToString(); 

				dstProyecto = null;
			}

			// param0 = Nombre del WF
			// param1 = Referencia
			// param2 = Fecha de solicitud
			// param3 = Explicación
			// param4 = Acción
			// param5 = Nombre solicitante
			// param6 = Imagen semáforo
			// param7 = Servidor
			// param8 = SubTitulo
			string strServidor=System.Net.Dns.GetHostName();
			strData += "<root><param0>"+workflowName+"</param0>";
			strData += "<param1>"+Referencia+"</param1>";
			strData += "<param2>"+strFechaSolicitud+"</param2>";
			strData += "<param3>"+explicacion+"</param3>";
			strData += "<param4>"+strAccion+"</param4>";
			strData += "<param5>"+strSolicitante+"</param5>";
			strData += "<param6>"+strImagenSemaforo+"</param6>";
			strData += "<param7>"+strServidor+"</param7>";
			strData += "<param8>"+strSubTitulo+"</param8></root>";

			DOMDocument xslDoc = new DOMDocument();
			DOMDocument xmlDoc = new DOMDocument();

			if( (idWorkflow >= 303 && idWorkflow <= 305) || (idWorkflow == 300) || (idWorkflow == 322) ) // INFORMES DE GASTOS
			{
				if(idEstatusWkf == 270) // RECHAZO TOTAL
					xslDoc.load("WFNS001A.xsl");
				else
					xslDoc.load("WFIG001A.xsl");
			}
			else
				xslDoc.load("WFNS001A.xsl");

			xmlDoc.loadXML(strData);
			ds = null;
			dsSolicitante = null;
			//=====================================================
			//=====================================================
			

			return xmlDoc.transformNode(xslDoc);
		}

		//=====================================================
		// NUEVO FUNCION PARA APROBACION FINAL -- SEMAFORO VERDE
		//=====================================================
		private string ConstruirMensajeAprobacion(int idWorkflow, string Referencia, int idEstatusWkf, out string emailTitle, out string emailFromSys)
		{
			DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ObtenerDatosEmail,idWorkflow,idEstatusWkf);
			Referencia = Referencia.Trim();
			string workflowName = ds.Tables[0].Rows[0]["wkf_nbr_documento"].ToString();
			string strAccion = " " + ds.Tables[0].Rows[0]["ewf_nbr_titulo"].ToString();
			string explicacion = ds.Tables[0].Rows[0]["ewf_desc_explicacion"].ToString();
			string strSubTitulo = "";
			
			Label lblExplicacion = new Label();
			lblExplicacion.ForeColor = System.Drawing.Color.Green;
			lblExplicacion.Font.Bold = true;
			lblExplicacion.Text = "ha sido APROBADO";
			
			explicacion = lblExplicacion.Text;
			strAccion = "";
			strSubTitulo = "DOCUMENTO APROBADO";

			emailTitle = "";
			emailFromSys = "SISTEMA_SPIN@soacat-ve";

			DataSet dsSolicitante = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ObtenerNombreSolicitante,idWorkflow,Referencia);
			string strSolicitante = dsSolicitante.Tables[0].Rows[0]["Solicitante"].ToString();
			string strFechaSolicitud = dsSolicitante.Tables[0].Rows[0]["fecha_solicitud"].ToString();
			string strData = "";

			string strImagenSemaforo = "http://localhost/Spin/WF/bin/Debug/semaforo_verde.jpg";
			emailTitle = "DOCUMENTO APROBADO" + " - " + workflowName;

			if( (idWorkflow >= 308 && idWorkflow <= 311) || ( idWorkflow == 318 ) ) // CIERRES DE AUXILIARES
			{
				DataSet dstProyecto = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_CargarInfProyectoPorReferencia,Convert.ToInt32(Referencia));
				Referencia += " / Cliente: " + dstProyecto.Tables[0].Rows[0]["cliente"].ToString(); 
				Referencia += " / Socio: " + dstProyecto.Tables[0].Rows[0]["socio"].ToString(); 

				dstProyecto = null;
			}

			// param0 = Nombre del WF
			// param1 = Referencia
			// param2 = Fecha de solicitud
			// param3 = Explicación
			// param4 = Acción
			// param5 = Nombre solicitante
			// param6 = Imagen semáforo
			// param7 = Servidor
			string strServidor=System.Net.Dns.GetHostName();
			strData += "<root><param0>"+workflowName+"</param0>";
			strData += "<param1>"+Referencia+"</param1>";
			strData += "<param2>"+strFechaSolicitud+"</param2>";
			strData += "<param3>"+explicacion+"</param3>";
			strData += "<param4>"+strAccion+"</param4>";
			strData += "<param5>"+strSolicitante+"</param5>";
			strData += "<param6>"+strImagenSemaforo+"</param6>";
			strData += "<param7>"+strServidor+"</param7>";
			strData += "<param8>"+strSubTitulo+"</param8></root>";

			DOMDocument xslDoc = new DOMDocument();
			DOMDocument xmlDoc = new DOMDocument();

			xslDoc.load("WFNS001A.xsl");
			xmlDoc.loadXML(strData);

			ds = null;
			dsSolicitante = null;

			return xmlDoc.transformNode(xslDoc);
		}
		//=====================================================
		//=====================================================

		private void GuardarHistorico(int solicitud, int estatusdoc, int estatuswkf, string obs, int numsec, int origen, int destino, string prevxml, string currxml, bool fecha)
		{
			try
			{
				try
				{
					if(origen==0)
					{
						DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ConsultarCreador, solicitud); 
						origen= Convert.ToInt32(ds.Tables[0].Rows[0]["hwf_cod_empleado_origen"]);
					}
				}
				catch(Exception i)
				{
					Console.WriteLine(i.Message + " " + i.InnerException);
				}


				if(fecha)
					SqlHelper.ExecuteNonQuery(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_InsertarHistorico,solicitud,estatusdoc,estatuswkf,obs,numsec,origen,destino,prevxml,currxml,DateTime.Now);
				else
					SqlHelper.ExecuteNonQuery(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_InsertarHistorico,solicitud,estatusdoc,estatuswkf,obs,numsec,origen,destino,prevxml,currxml,System.DBNull.Value);
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message + " " + e.InnerException);
			}
		}
	}
}
