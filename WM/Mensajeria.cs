using System;
using System.Xml.Serialization;

namespace Mensajeria
{
	/// <summary>
	/// Los valores de los estados deben coincidir con los
	/// valores que aparecen en la base de datos
	/// </summary>
	public class StateConst
	{
		protected const int NEUTRO = 200;
		public const int INICIO = 210;
		protected const int ENVIAR_RECORDATORIO_DE_APROBACION = 220;
		protected const int ENVIAR_RECORDATORIO_DE_CORRECCION = 230;
		protected const int ENVIAR_MSG_AL_REMITENTE = 240;
		protected const int ENVIAR_NOTIF_DE_APROBACION = 250;
		protected const int ENVIAR_NOTIF_DE_CORRECCION = 260;
		protected const int ENVIAR_NOTIF_DE_RECHAZO_TOTAL = 270;
		protected const int ENVIAR_NOTIF_DE_RECHAZO_PARCIAL = 280;
		protected const int GENERAR_DATOS_DE_INTERFAZ = 290;
		protected const int ENCONTRAR_DESTINATARIOS = 300;
		protected const int ESPERAR_APROBACION = 310;
		public const int ESPERAR_CORRECCION = 320;
		protected const int STANDBY = 330;
		public const int FIN = 340;
	}

	public enum Eventos
	{
		CREAR_SOLICITUD,
		INCLUIR_SOLICITUD,
		DESTINARIO_ENCONTRADO,
		SOLICITUD_APROBADA,
		SOLICITUD_CORREGIDA,
		RECHAZADO_TOTAL,
		RECHAZADO_PARCIAL,
		ULTIMO_DESTINATARIO,
		CAMBIO_DE_DESTINATARIO,
		TIEMPO_LIMITE_ALCANZADO,
		NUMERO_DE_VECES_TOPE,
		NUMERO_DE_VECES_MENOR_AL_TOPE,
		SUSPENDER_APROBACION,
		SUSPENDER_CORRECCION,
		REANUDAR_APROBACION,
		REANUDAR_CORRECCION,
		CANCELAR_WORKFLOW,
		NEUTRO
	}

	[XmlInclude(typeof(Eventos))]
	public struct objMensaje
	{
		public Eventos _Evento;
		public string _Input;

		public objMensaje(Eventos evento)
		{
			_Evento = evento;
			_Input = null;
		}

		public objMensaje(Eventos evento,string input)
		{
			_Evento = evento;
			_Input = input;
		}
	}
}
