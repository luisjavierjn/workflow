using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.ServiceProcess;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using MSXML2;
using Mensajeria;
using System.Threading;

namespace WinflowAC
{
	public class WinflowTask : System.ServiceProcess.ServiceBase
	{
		private System.Messaging.Message msg;
		private objMensaje objM;
		private ArrayList array;
		private int SolicitudActual;
		private IEnumerator arrayList;
		private int EstadoActual;
		private bool PostBack;

		private System.Timers.Timer timer;
		private System.Messaging.MessageQueue msgQueue;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinflowTask()
		{
			PostBack = false;

			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
			CargarWorkflowsEnProceso();
		}

		#region Código Generado Automáticamente
		// The main entry point for the process
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// More than one user Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = new System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new WinflowTask() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.timer = new System.Timers.Timer();
			this.msgQueue = new System.Messaging.MessageQueue();
			((System.ComponentModel.ISupportInitialize)(this.timer)).BeginInit();
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 5000;
			this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
			// 
			// msgQueue
			// 
			this.msgQueue.Path = "FormatName:DIRECT=OS:localhost\\private$\\alpha";
			// 
			// WinflowTask
			// 
			this.ServiceName = "WinflowTask";
			((System.ComponentModel.ISupportInitialize)(this.timer)).EndInit();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			CargarWorkflowsEnProceso();
		}

		private void CargarWorkflowsEnProceso()
		{
			if(!PostBack)
			{
				lock(msgQueue)
				{
					if(array == null) 
						array = new ArrayList();

					DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_WorkflowsEnProceso,StateConst.FIN);

					foreach(DataRow r in ds.Tables[0].Rows)
					{
						long solicitud = Convert.ToInt64(r["swf_cod_solicitud"]);
						int workflow = Convert.ToInt32(r["swf_cod_workflow"]);
						string referencia = Convert.ToString(r["swf_str_referencia"]);
						int estatuswkf = Convert.ToInt16(r["hwf_cod_estatuswkf"]);
						int estatusdoc = Convert.ToInt16(r["hwf_cod_estatusdoc"]);
						string ruta = Convert.ToString(r["swf_desc_ruta"]);
						int posicion = Convert.ToInt32(r["swf_num_posicion_actual"]);
						string prevxml = Convert.ToString(r["hwf_str_prevxmldata"]);
						string xml = Convert.ToString(r["hwf_str_xmldata"]);
						int creador = Convert.ToInt32(r["swf_cod_empleado_creador"]);
						int desde = Convert.ToInt32(r["hwf_cod_empleado_origen"]);
						int hasta = Convert.ToInt32(r["hwf_cod_empleado_destino"]);

						StateMachine sMach = new StateProcSmpl((int)solicitud,workflow,referencia,estatuswkf,estatusdoc,ruta,posicion,prevxml,xml,creador,desde,hasta);
						sMach.Check(Eventos.NEUTRO);
						array.Add(sMach);
					}
				} // unlock

				PostBack = true;
			}
		}

		private void CreateStateMachine(int idWorkflowAC, string Referencia, int idEmpleado, string Ruta)
		{
			object obj = SqlHelper.ExecuteScalar(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_InsertarSolicitud,idWorkflowAC,Referencia,idEmpleado,StateConst.INICIO,Ruta,1);

			if(obj != null)
			{
				SolicitudActual = Convert.ToInt32(obj); // N° de solicitud que se acaba de crear
				StateMachine sMach = new StateProcSmpl(SolicitudActual,idWorkflowAC,Referencia,StateConst.INICIO,Ruta,1);
				array.Add(sMach);
			}
			else
			{
				throw new Exception("No se pudo crear la solicitud del workflow");
			}
		}

		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			// TODO: Add code here to perform any tear-down necessary to stop your service.
			array.Clear();
		}

		private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			lock(msgQueue)
			{
				try
				{
					msg = msgQueue.Receive(new TimeSpan(0, 0, 3));
					msg.Formatter = new System.Messaging.XmlMessageFormatter(new Type[]{typeof(objMensaje),typeof(Eventos)});
					objM = (objMensaje)msg.Body;

					DOMDocument Xml = new DOMDocument();
					bool exitoso = Xml.loadXML(objM._Input);

					if(exitoso)
					{
						IXMLDOMElement root = Xml.documentElement;
						// primer parámetro : cod_workflow - segundo parámetro : str_referencia
						DataSet ds = SqlHelper.ExecuteDataset(WinflowAC.ConnectionString.FormarStringConexion(),Queries.WF_ConsultarSolicitud, int.Parse(root.childNodes[0].text), root.childNodes[1].text); 
						int nRows = ds.Tables[0].Rows.Count;
						int intCodCreador=0;
						
						//+ Nuevo
						int intNumPosAct = 0;
						int intCodWF = 0;
						string strNumRef = string.Empty;
						string strDescRuta = string.Empty;
						int intEstatusWF = 0;
						int intEstatusDoc = 0;
						string strPrevXml = string.Empty;
						string strXml = string.Empty;
						int intCodEmpDesde = 0;
						int intCodEmpHasta = 0;
						bool blnActual = false;
						int intIndexActual = 0;
						//+

						string strPrev=string.Empty;
						if(objM._Evento == Eventos.CREAR_SOLICITUD && nRows == 0)
						{
							CreateStateMachine(int.Parse(root.childNodes[0].text),root.childNodes[1].text,int.Parse(root.childNodes[2].text),root.childNodes[4].text);
						}
						else
						{
							SolicitudActual = Convert.ToInt32(ds.Tables[0].Rows[0]["swf_cod_solicitud"]);
							try
							{
								intCodCreador = Convert.ToInt32(ds.Tables[0].Rows[0]["hwf_cod_empleado_origen"]);
								strPrev=Convert.ToString(ds.Tables[0].Rows[0]["hwf_str_prevxmldata"]);
							}
							catch(Exception ee)
							{
								intCodCreador =0;
								strPrev=string.Empty;
								System.Console.Write(ee.Message);
							}
						}

						IEnumerator arrayList = array.GetEnumerator();
						if(objM._Evento == Eventos.CAMBIO_DE_DESTINATARIO)
						{
							//* Antes
							/*
							bool blnActualCD=false;
							int intIndexActualCD=0;
							while ( arrayList.MoveNext() )
							{
								blnActualCD=((StateMachine)arrayList.Current).Check(SolicitudActual);
								intIndexActualCD++;
								if(blnActualCD)
									break;
								
							}
							*/
							//*
							((StateProcSmpl)arrayList.Current).ActualizarAprobador(int.Parse(root.childNodes[2].text),SolicitudActual);
							((StateMachine)arrayList.Current).Check(SolicitudActual,objM._Evento,objM._Input);
							
//							array.RemoveAt(intIndexActual-1);
//							StateMachine sMach = new StateProcSmpl(SolicitudActual,int.Parse(root.childNodes[0].text),root.childNodes[1].text,StateConst.ESPERAR_CORRECCION,root.childNodes[4].text,1,intCodCreador,strPrev);
//							array.Add(sMach);
//							sMach.Check(SolicitudActual,objM._Evento,objM._Input);	
						}
						else
						{
							if(objM._Evento == Eventos.SOLICITUD_CORREGIDA)
							{
								blnActual=false;
								intIndexActual=0;
								while ( arrayList.MoveNext() )
								{
									blnActual=((StateMachine)arrayList.Current).Check(SolicitudActual);
									intIndexActual++;
									if(blnActual)
										break;
								
								}
								array.RemoveAt(intIndexActual-1);
								StateMachine sMach = new StateProcSmpl(SolicitudActual,int.Parse(root.childNodes[0].text),root.childNodes[1].text,StateConst.ESPERAR_CORRECCION,root.childNodes[4].text,1,intCodCreador,strPrev);
								array.Add(sMach);
								// *Anterior
								//sMach.Check(SolicitudActual,objM._Evento,objM._Input);	
							}
							// +Nuevo
							if( (objM._Evento == Eventos.SOLICITUD_APROBADA) ||
								(objM._Evento == Eventos.RECHAZADO_PARCIAL) ||
								(objM._Evento == Eventos.RECHAZADO_TOTAL))
							{
								//+ Nuevo
								intNumPosAct = Convert.ToInt32(ds.Tables[0].Rows[0]["swf_num_posicion_actual"]);
								intCodWF = Convert.ToInt32(ds.Tables[0].Rows[0]["swf_cod_workflow"]);
								strNumRef = Convert.ToString(ds.Tables[0].Rows[0]["swf_str_referencia"]);
								strDescRuta = Convert.ToString(ds.Tables[0].Rows[0]["swf_desc_ruta"]);
								intEstatusWF = Convert.ToInt32(ds.Tables[0].Rows[0]["hwf_cod_estatuswkf"]);
								intEstatusDoc = Convert.ToInt32(ds.Tables[0].Rows[0]["hwf_cod_estatusdoc"]);
								strPrevXml = Convert.ToString(ds.Tables[0].Rows[0]["hwf_str_prevxmldata"]);
								strXml = Convert.ToString(ds.Tables[0].Rows[0]["hwf_str_xmldata"]);
								intCodEmpDesde = Convert.ToInt32(ds.Tables[0].Rows[0]["hwf_cod_empleado_origen"]);
								intCodEmpHasta = Convert.ToInt32(ds.Tables[0].Rows[0]["hwf_cod_empleado_destino"]);
								intCodCreador = Convert.ToInt32(ds.Tables[0].Rows[0]["swf_cod_empleado_creador"]);
								//+

								blnActual = false;
								intIndexActual = 0;
								while ( arrayList.MoveNext() )
								{
									blnActual = ((StateMachine)arrayList.Current).Check(SolicitudActual);
									intIndexActual++;
									if(blnActual)
										break;
								
								}
								if(blnActual)
									array.RemoveAt(intIndexActual-1);

								StateMachine sMach = new StateProcSmpl((int)SolicitudActual,intCodWF,strNumRef,intEstatusWF,intEstatusDoc,strDescRuta,intNumPosAct,strPrevXml,strXml,intCodCreador,intCodEmpDesde,intCodEmpHasta);
								array.Add(sMach);
							}
							// +
							//*else
							//*{
								arrayList = array.GetEnumerator();
								while ( arrayList.MoveNext() )
									((StateMachine)arrayList.Current).Check(SolicitudActual,objM._Evento,objM._Input);
							//*}
						}
					}
				}
				catch
				{
					//arrayList = array.GetEnumerator();
					EstadoActual = StateConst.INICIO;

                    //while ( arrayList.MoveNext() )
                    //{
                    //    ((StateMachine)arrayList.Current).Check();
                    //    EstadoActual = ((StateMachine)arrayList.Current).EstadoActual;
                    //    if(EstadoActual == StateConst.FIN)
                    //    {
                    //        array.Remove(arrayList.Current);
                    //    }
                    //}

                    int i = 0, count = array.Count;
                    while (i < count)
                    {
                        ((StateMachine)array[i]).Check();
                        EstadoActual = ((StateMachine)array[i]).EstadoActual;
                        if (EstadoActual == StateConst.FIN)
                        {
                            array.RemoveAt(i);
                            count--;
                        }
                        else i++;
                    }

                    arrayList = array.GetEnumerator();
				} // end catch
			}
		}
	}
}
