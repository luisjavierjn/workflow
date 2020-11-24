using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
//using System.Linq;
//using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using Componentes.Web;
using Componentes.DAL;

/// <summary>
/// Descripción breve de Formss
/// </summary>
public class Formss
{
   
        public Formss() { }


        int _workFlowId;
        string _referenciaId;
        int _responsableId;
        string _responsable;
        string _asunto;
        int _tipocomision;
        DateTime _fecha;
        string _cliente;
        string _idStatus;
        int _userId;
        Int64 _solicitudId;

        public Int64 SolicitudId
        {
            get { return _solicitudId; }
            set { _solicitudId = value; }
        }
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string IdStatus
        {
            get { return _idStatus; }
            set { _idStatus = value; }
        }

        public string ReferenciaId
        {
            get { return _referenciaId; }
            set { _referenciaId = value; }
        }

        public int WorkFlowId
        {
            get { return _workFlowId; }
            set { _workFlowId = value; }
        }

        public int ResponsableId
        {
            get { return _responsableId; }
            set { _responsableId = value; }
        }

        public string Responsable
        {
            get { return _responsable; }
            set { _responsable = value; }
        }

        public string Asunto
        {
            get { return _asunto; }
            set { _asunto = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public static List<Formss> ListarForms(int userId)
        {
            List<Formss> lstForms = new List<Formss>();
            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationManager.AppSettings[Global.CfgKeyConnString], Queries.WF_LlenarGridBandeja, userId);
            //string[] Fechas;
            while (dr.Read())
            {
                Formss Form = new Formss();

                Form._solicitudId = dr.GetInt64(0);
                Form._workFlowId = dr.GetInt32(1);
                Form._asunto = dr.GetString(2);
                Form._referenciaId = dr.GetString(3);
                Form._responsableId = dr.GetInt32(4);
                Form._responsable = dr.GetString(5);
                Form._idStatus = dr.GetString(7);
                Form._fecha = dr.GetDateTime(8);


                lstForms.Add(Form);
            }

            return lstForms;
        }

    }

