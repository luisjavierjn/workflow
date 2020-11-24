using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Serialization;
using MSXML2;
using Mensajeria;

namespace WinflowAC
{
	/// <summary>
	/// Summary description for StateMachine.
	/// </summary>
	public abstract class StateMachine : StateConst
	{
		#region Variables

		// Variables de Control
		protected System.DateTime _lastDate;
		protected System.TimeSpan _lapso;
		protected int _idSolicitud;
		protected int _idWorkflow;
		protected int _numVeces;
		protected bool _regAprob;
		protected bool _regCorre;

		// Estado en Proceso
		protected int Estado_Actual;	
		protected int Estado_Previo;
		protected string xmlData;
		protected string prevXmlData;
		protected IXMLDOMElement root;
		
		// Manejo de Documentos
		protected int _statusDoc;
		protected string _Observacion;
		protected string _Referencia;

		// Constantes
		protected readonly int INTERVALO_DE_APROBACION;
		protected readonly int INTERVALO_DE_CORRECCION;
		protected readonly int NUMERO_DE_RECORDATORIOS;

		#endregion

		#region Propiedades

		public int Solicitud
		{
			get
			{
				return _idSolicitud;
			}
		}

		public int EstadoActual
		{
			get
			{
				return Estado_Actual;
			}
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor de la clase
		/// </summary>
		/// <param name="idSolicitud">Id del Workflow a ser atendido</param>
		/// <param name="isp">Implementación a utilizar para la Máquina de Estado</param>
		/// <param name="intervalo">Intervalo en segundos</param>
		public StateMachine(int idSolicitud, int idWorkflow, string idReferencia, int ESTADO)
		{
			// Parámetros
			_idSolicitud = idSolicitud;
			_idWorkflow = idWorkflow;
			_Referencia = idReferencia; 
			Estado_Actual = ESTADO;

			SqlDataReader sdr = SqlHelper.ExecuteReader(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ConsultarReglas,_idWorkflow);

			// Reglas
			if(sdr.Read())
			{
				int divA = 1;
				int divC = 1;

				// ULTIMO CAMBIO - PRINCIPIO
				int COD_LAPSO_APROBACION = sdr.GetInt32(3);
				int COD_LAPSO_CORRECCION = sdr.GetInt32(4);

				switch(COD_LAPSO_APROBACION)
				{
					case 2: divA = 60; break;
					case 3: divA = 3600; break;
					case 4: divA = 86400; break;
					case 5: divA = 604800; break;
				}

				switch(COD_LAPSO_CORRECCION)
				{
					case 2: divC = 60; break;
					case 3: divC = 3600; break;
					case 4: divC = 86400; break;
					case 5: divC = 604800; break;
				}

				INTERVALO_DE_APROBACION = sdr.GetInt32(0) * divA;
				INTERVALO_DE_CORRECCION = sdr.GetInt32(1) * divC;
				NUMERO_DE_RECORDATORIOS = sdr.GetInt32(2);
				// ULTIMO CAMBIO - FIN

//				Esto es lo que estaba antes
//				INTERVALO_DE_APROBACION = sdr.GetInt32(0);
//				INTERVALO_DE_CORRECCION = sdr.GetInt32(1);
//				NUMERO_DE_RECORDATORIOS = sdr.GetInt32(2);
			}
			else
			{
				INTERVALO_DE_APROBACION = int.Parse(ConfigurationSettings.AppSettings[WinflowAC.Global.IntervaloAprobacion]);
				INTERVALO_DE_CORRECCION = int.Parse(ConfigurationSettings.AppSettings[WinflowAC.Global.IntervaloCorreccion]);
				NUMERO_DE_RECORDATORIOS = int.Parse(ConfigurationSettings.AppSettings[WinflowAC.Global.NumeroRecordatorios]);
			}

			// Bannderas y Contadores
			_numVeces = 0;

			SqlDataReader sqlLastDate = SqlHelper.ExecuteReader(WinflowAC.ConnectionString.FormarStringConexion(),
				Queries.WF_ObtenerUltimaFecha,_idSolicitud,_idWorkflow,_Referencia);
			if(sqlLastDate.Read())
				_lastDate=sqlLastDate.GetDateTime(0);


			//_lastDate = System.DateTime.Now;
			_regAprob = false;
			_regCorre = false;
		}

		#endregion

		#region Métodos Check()

		public void Check()
		{
			_lapso = System.DateTime.Now - _lastDate;

			if((Estado_Actual == ESPERAR_APROBACION && _lapso.TotalSeconds > INTERVALO_DE_APROBACION) ||
			   (Estado_Actual == ESPERAR_CORRECCION && _lapso.TotalSeconds > INTERVALO_DE_CORRECCION))
			{
				Ejecutar(T(Estado_Actual,Eventos.TIEMPO_LIMITE_ALCANZADO));
				_lastDate = System.DateTime.Now;
			}
		}

		public void Check(int idSolicitud, Eventos evento, string xmlContent)
		{
			if(idSolicitud == _idSolicitud)
			{
				prevXmlData = xmlData;
				xmlData = xmlContent;

				DOMDocument Xml = new DOMDocument();
				Xml.loadXML(xmlData);
				root = Xml.documentElement;
				
				Ejecutar(T(Estado_Actual,evento));
			}
		}

		public void Check(Eventos evt)
		{
			Ejecutar(T(Estado_Actual,evt));
		}
		public bool Check(int idSolicitud)
		{
			if(idSolicitud == _idSolicitud)
				return true;
			else
				return false;
		}
		#endregion
    
		#region Tabla de Correspondencia

		// Dado un estado_inicial y un evento devuelve un estado_final
		private int T(int initial_state, Eventos evento) 
		{
			switch(initial_state) 
			{
				case INICIO:
					if(evento == Eventos.CREAR_SOLICITUD) return INICIO;
					if(evento == Eventos.INCLUIR_SOLICITUD) return ENCONTRAR_DESTINATARIOS;					
					break;
				case ENVIAR_NOTIF_DE_APROBACION:
					if(evento == Eventos.NEUTRO) return ENCONTRAR_DESTINATARIOS;
					break;
				case ENVIAR_NOTIF_DE_CORRECCION:
					if(evento == Eventos.NEUTRO) return ESPERAR_APROBACION;
					break;
				case ENCONTRAR_DESTINATARIOS:
					if(evento == Eventos.DESTINARIO_ENCONTRADO) return ESPERAR_APROBACION;
					if(evento == Eventos.ULTIMO_DESTINATARIO) return GENERAR_DATOS_DE_INTERFAZ;
					break;
				case ENVIAR_MSG_AL_REMITENTE:
					if(evento == Eventos.NEUTRO) return ESPERAR_APROBACION;
					break;
				case ESPERAR_APROBACION:
					if(evento == Eventos.TIEMPO_LIMITE_ALCANZADO) return ENVIAR_RECORDATORIO_DE_APROBACION;
					if(evento == Eventos.CAMBIO_DE_DESTINATARIO) return ESPERAR_APROBACION;					
					if(evento == Eventos.RECHAZADO_TOTAL) return ENVIAR_NOTIF_DE_RECHAZO_TOTAL;
					if(evento == Eventos.RECHAZADO_PARCIAL) return ENVIAR_NOTIF_DE_RECHAZO_PARCIAL;
					if(evento == Eventos.SOLICITUD_APROBADA) return ENVIAR_NOTIF_DE_APROBACION;
					if(evento == Eventos.SUSPENDER_APROBACION) return STANDBY;
					if(evento == Eventos.CANCELAR_WORKFLOW) return FIN;
					break;
				case ESPERAR_CORRECCION:
					if(evento == Eventos.TIEMPO_LIMITE_ALCANZADO) return ENVIAR_RECORDATORIO_DE_CORRECCION;
					if(evento == Eventos.SOLICITUD_CORREGIDA) return ENVIAR_NOTIF_DE_CORRECCION;
					if(evento == Eventos.SUSPENDER_CORRECCION) return STANDBY;
					if(evento == Eventos.CANCELAR_WORKFLOW) return FIN;
					break;
				case ENVIAR_RECORDATORIO_DE_APROBACION:					
					if(evento == Eventos.NUMERO_DE_VECES_MENOR_AL_TOPE) return ESPERAR_APROBACION;
					if(evento == Eventos.NUMERO_DE_VECES_TOPE) return ENVIAR_MSG_AL_REMITENTE;
					break;
				case ENVIAR_RECORDATORIO_DE_CORRECCION:
					if(evento == Eventos.NEUTRO) return ESPERAR_CORRECCION;
					break;
				case ENVIAR_NOTIF_DE_RECHAZO_TOTAL:
					if(evento == Eventos.NEUTRO) return FIN;
					break;
				case ENVIAR_NOTIF_DE_RECHAZO_PARCIAL:
					if(evento == Eventos.NEUTRO) return ESPERAR_CORRECCION;
					break;
				case STANDBY:
					if(evento == Eventos.REANUDAR_APROBACION) return ESPERAR_APROBACION;
					if(evento == Eventos.REANUDAR_CORRECCION) return ESPERAR_CORRECCION;
					if(evento == Eventos.CANCELAR_WORKFLOW) return FIN;
					break;
				case GENERAR_DATOS_DE_INTERFAZ:
					if(evento == Eventos.NEUTRO) return FIN;
					break;
				case FIN:
					break;
			}

			return NEUTRO;
		}

		#endregion

		#region Tabla de Ejecución

		// Ejecuta la accion asociada a un estado dado por parametro
		private void Ejecutar(int state) 
		{       
			if(state!=NEUTRO) 
			{
				Estado_Previo = Estado_Actual;
				Estado_Actual = state;
			}
        
			switch(state) 
			{
				// Estado de hacer nada
				case INICIO: _Inicio(); break;
				case ENVIAR_RECORDATORIO_DE_APROBACION: _EnviarRecordatorioDeAprobacion(); break;
				case ENVIAR_RECORDATORIO_DE_CORRECCION: _EnviarRecordatorioDeCorreccion(); break;
				case ENVIAR_MSG_AL_REMITENTE: _EnviarMsgAlRemitente(); break;
				case ENVIAR_NOTIF_DE_APROBACION: _EnviarNotifDeAprobacion(); break;
				case ENVIAR_NOTIF_DE_CORRECCION: _EnviarNotifDeCorreccion(); break;
				case ENVIAR_NOTIF_DE_RECHAZO_TOTAL: _EnviarNotifDeRechazoTotal(); break;
				case ENVIAR_NOTIF_DE_RECHAZO_PARCIAL: _EnviarNotifDeRechazoParcial(); break;
				case GENERAR_DATOS_DE_INTERFAZ: _GenerarDatosDeInterfaz(); break;
				case ENCONTRAR_DESTINATARIOS: _EncontrarDestinatarios(); break;
				case ESPERAR_APROBACION: _EsperarAprobacion(); break;
				case ESPERAR_CORRECCION: _EsperarCorreccion(); break;
				case STANDBY: _Standby(); break;
				case FIN: _Fin(); break;
				default: break; // NEUTRO
			}
		}

		#endregion

		#region Métodos de Control

		private void _Inicio()
		{
			Inicio();
		}

		private void _EnviarRecordatorioDeAprobacion()
		{
			EnviarRecordatorioDeAprobacion();
			ActualizarFechaRecordatorio();
			_lastDate = System.DateTime.Now;

			if(++_numVeces < NUMERO_DE_RECORDATORIOS)
			{
				Ejecutar(T(Estado_Actual,Eventos.NUMERO_DE_VECES_MENOR_AL_TOPE));
			}
			else
			{
				Ejecutar(T(Estado_Actual,Eventos.NUMERO_DE_VECES_TOPE));
			}
		}
		private void ActualizarFechaRecordatorio()
		{
			try
			{
				SqlHelper.ExecuteNonQuery(WinflowAC.ConnectionString.FormarStringConexion(),
					Queries.WF_ActualizarFechaRecordatorio,System.DateTime.Now,_idSolicitud,_idWorkflow,_Referencia);
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message + " " + e.InnerException);
			}
		}

		private void _EnviarRecordatorioDeCorreccion()
		{
			EnviarRecordatorioDeCorreccion();
			ActualizarFechaRecordatorio();

			_regCorre = true;

			_lastDate = System.DateTime.Now;

			Ejecutar(T(Estado_Actual,Eventos.NEUTRO));
		}

		private void _EnviarMsgAlRemitente()
		{
			EnviarMsgAlRemitente();

			_numVeces = 0;

			_regAprob = true;

			_lastDate = System.DateTime.Now;

			Ejecutar(T(Estado_Actual,Eventos.NEUTRO));
		}

		private void _EnviarNotifDeAprobacion()
		{
			EnviarNotifDeAprobacion();

			Ejecutar(T(Estado_Actual,Eventos.NEUTRO));
		}

		private void _EnviarNotifDeCorreccion()
		{
			EnviarNotifDeCorreccion();

			_regAprob = true;

			_lastDate = System.DateTime.Now;

			Ejecutar(T(Estado_Actual,Eventos.NEUTRO));
		}

		private void _EnviarNotifDeRechazoTotal()
		{
			EnviarNotifDeRechazoTotal();

			Ejecutar(T(Estado_Actual,Eventos.NEUTRO));
		}

		private void _EnviarNotifDeRechazoParcial()
		{
			EnviarNotifDeRechazoParcial();

			_regCorre = true;

			_lastDate = System.DateTime.Now;

			Ejecutar(T(Estado_Actual,Eventos.NEUTRO));
		}

		private void _GenerarDatosDeInterfaz()
		{
			GenerarDatosDeInterfaz();

			Ejecutar(T(Estado_Actual,Eventos.NEUTRO));
		}

		private void _EncontrarDestinatarios()
		{
			Eventos retVal = EncontrarDestinatarios();

			switch(retVal)
			{
				case Eventos.DESTINARIO_ENCONTRADO:

					_regAprob = true;

					_lastDate = System.DateTime.Now;

					Ejecutar(T(Estado_Actual,Eventos.DESTINARIO_ENCONTRADO));

					break;

				case Eventos.ULTIMO_DESTINATARIO:

					Ejecutar(T(Estado_Actual,Eventos.ULTIMO_DESTINATARIO));

					break;
			}
		}

		private void _EsperarAprobacion()
		{
			EsperarAprobacion();
		}

		private void _EsperarCorreccion()
		{
			EsperarCorreccion();
		}

		private void _Standby()
		{
			if(Estado_Previo == ESPERAR_APROBACION)
			{
				_regAprob = true;

				_lastDate = System.DateTime.Now;
			}
			else if(Estado_Previo == ESPERAR_CORRECCION)
			{
				_regCorre = true;

				_lastDate = System.DateTime.Now;
			}

			Standby();
		}

		private void _Fin()
		{
			Fin();
		}

		#endregion

		#region Métodos Abstractos

		protected abstract void Inicio();

		protected abstract void EnviarRecordatorioDeAprobacion();

		protected abstract void EnviarRecordatorioDeCorreccion();

		protected abstract void EnviarMsgAlRemitente();

		protected abstract void EnviarNotifDeAprobacion();

		protected abstract void EnviarNotifDeCorreccion();

		protected abstract void EnviarNotifDeRechazoTotal();

		protected abstract void EnviarNotifDeRechazoParcial();

		protected abstract void GenerarDatosDeInterfaz();

		protected abstract Eventos EncontrarDestinatarios();

		protected abstract void EsperarAprobacion();

		protected abstract void EsperarCorreccion();

		protected abstract void Standby();

		protected abstract void Fin();

		#endregion
	}
}

