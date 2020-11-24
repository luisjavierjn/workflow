using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Componentes.DAL;
using System.Configuration;
using Componentes.BLL.SE;
using System.Xml;
//using System.Web.UI.WebControls;

namespace Componentes.BLL.WF
{
	/// <summary>
	/// Summary description for WFPolitica.
	/// </summary>
	public class WFPolitica
	{
		int _intCodPolitica;
		int _intCodPoliticaSino;
		int _WorkflowId;
		int _intPadre;
		WFCondicion _objCondicion;
		string _strValor;
		WFTipoDeDato _objTipoDeDato;

		public WFPolitica(int workflowId, int intCodPolitica, int intPadre, WFCondicion objCondicion, string strValor, WFTipoDeDato objTipoDeDato)
		{
			_WorkflowId = workflowId;
			_intCodPolitica = intCodPolitica;
			_intPadre = intPadre;
			_objCondicion = objCondicion;
			_strValor = strValor;
			_objTipoDeDato = objTipoDeDato;
		}

		public int intCodPolitica
		{
			get {return _intCodPolitica;}
		}

		public int intCodPadre
		{
			get {return _intPadre;}
		}

		public int WorkflowId
		{
			get {return _WorkflowId;}
		}

        public WFCondicion objCondicion
        {
            get { return _objCondicion; }
            set { _objCondicion = value; }
        }

        public string strNbrCondicion
        {
            get { return _objCondicion.strNbrCondicion; }
            set { _objCondicion.strNbrCondicion = value; }
        }

        public string strValor
        {
            get { return _strValor; }
            set { _strValor = value; }
        }

        public WFTipoDeDato objTipoDeDato
        {
            get { return _objTipoDeDato; }
            set { _objTipoDeDato = value; }
        }

        public string strNbrTipoDeDato
        {
            get { return _objTipoDeDato.strNbrTipoDeDato; }
            set { _objTipoDeDato.strNbrTipoDeDato = value; }
        }

		public bool Save()
		{
			int Contrario = WFCondicion.ObtenerCondicionContrariaID(objCondicion.intCodCondicion);

			TreeNode tn1 = new TreeNode(WorkflowId,objCondicion.intCodCondicion,_strValor,objTipoDeDato.intCodTipoDeDato,_intPadre,0);
			TreeNode tn2 = new TreeNode(WorkflowId,Contrario,_strValor,objTipoDeDato.intCodTipoDeDato,_intPadre,1);

            using (SqlServerTreeProvider treeProvider = new SqlServerTreeProvider())
            {
                _intCodPolitica = treeProvider.AddNode(tn1);
            }

            using (SqlServerTreeProvider treeProvider = new SqlServerTreeProvider())
            {
                _intCodPoliticaSino = treeProvider.AddNode(tn2);
            }

			if(_intCodPolitica > -1 && _intCodPoliticaSino > -1) return true; 
			else return false;
		}

        public void Update()
        {
            TreeNode tn1 = new TreeNode(WorkflowId, objCondicion.intCodCondicion, _strValor, objTipoDeDato.intCodTipoDeDato, _intPadre, 0);

            using (SqlServerTreeProvider treeProvider = new SqlServerTreeProvider())
            {
                treeProvider.UpdateNode(tn1);
            }
        }

		public static string ObtenerRepresentacionXml(int workflowId)
		{
			string rValue = "<TREENODES>";
			bool blnExiste = false;

			SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
			ArrayList Array = treeProvider.GetChildren(0,workflowId);

			int i = 0;
			foreach(TreeNode tn in Array)
			{
				rValue += tn.GetXmlView(++i);
				blnExiste = true;
			}

			if(!blnExiste)
			{
				string Data = string.Empty;
				Data += "<treenode NodeData='' Text='Árbol de Políticas'>";
				Data += "</treenode>";
				rValue += Data;
			}

			rValue += "</TREENODES>";
			return rValue;
		}

        public static System.Web.UI.WebControls.XmlDataSource ObtenerRepresentacionXmlDataSource(int workflowId)
        {
            using (SqlServerTreeProvider treeProvider = new SqlServerTreeProvider())
            {
                // create an XmlDocument (with an XML declaration)
                XmlDocument XDoc = new XmlDocument();
                XmlDeclaration XDec = XDoc.CreateXmlDeclaration("1.0", null, null);
                XDoc.AppendChild(XDec);

                // create an element node to insert
                // note: Element names may not have spaces so use ID
                // note: Element names may not start with a digit so add underscore
                XmlElement NewNode = XDoc.CreateElement("_0");
                NewNode.SetAttribute("ID", "0");
                NewNode.SetAttribute("ParentID", "-1");
                NewNode.SetAttribute("FullName", "Arbol de Politicas");
                XDoc.AppendChild(NewNode);  // root node

                ArrayList Array = treeProvider.GetChildren(0, workflowId);

                int i = 0;
                foreach (Componentes.DAL.TreeNode tn in Array)
                {
                    NewNode.AppendChild(tn.GetXmlView(++i, XDoc, treeProvider, -1));
                }

                // we cannot bind the TreeView directly to an XmlDocument
                // so we must create an XmlDataSource and assign the XML text
                System.Web.UI.WebControls.XmlDataSource XDdataSource = new System.Web.UI.WebControls.XmlDataSource();
                XDdataSource.ID = DateTime.Now.Ticks.ToString();  // unique ID is required
                XDdataSource.Data = XDoc.OuterXml;

                return XDdataSource;
            }
        }

		public static string ObtenerRepresentacionXmlConRutas(int workflowId)
		{
			string rValue = "<TREENODES>";

			SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
			ArrayList Array = treeProvider.GetChildren(0,workflowId);

			int i = 0;
			foreach(TreeNode tn in Array)
			{
				rValue += tn.GetXmlViewConRutas(++i);
			}

			rValue += "</TREENODES>";
			return rValue;
		}

        public static System.Web.UI.WebControls.XmlDataSource ObtenerRepresentacionXmlDataSourceConRutas(int workflowId)
        {
            // create an XmlDocument (with an XML declaration)
            XmlDocument XDoc = new XmlDocument();
            XmlDeclaration XDec = XDoc.CreateXmlDeclaration("1.0", null, null);
            XDoc.AppendChild(XDec);

            // create an element node to insert
            // note: Element names may not have spaces so use ID
            // note: Element names may not start with a digit so add underscore
            XmlElement NewNode = XDoc.CreateElement("_0");
            NewNode.SetAttribute("ID", "0");
            NewNode.SetAttribute("ParentID", "-1");
            NewNode.SetAttribute("FullName", "Arbol de Politicas");
            XDoc.AppendChild(NewNode);  // root node

            SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
            ArrayList Array = treeProvider.GetChildren(0, workflowId);


            int i = 0;
            foreach (Componentes.DAL.TreeNode tn in Array)
            {
                NewNode.AppendChild(tn.GetXmlViewConRutas(++i, XDoc, treeProvider, -1));
            }

            // we cannot bind the TreeView directly to an XmlDocument
            // so we must create an XmlDataSource and assign the XML text
            System.Web.UI.WebControls.XmlDataSource XDdataSource = new System.Web.UI.WebControls.XmlDataSource();
            XDdataSource.ID = DateTime.Now.Ticks.ToString();  // unique ID is required
            XDdataSource.Data = XDoc.OuterXml;

            return XDdataSource;
        }

		public static string ObtenerRepresentacionXmlConRoles(int workflowId)
		{
			string rValue = "<TREENODES>";

			SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
			ArrayList Array = treeProvider.GetChildren(0,workflowId);

			int i = 0;
			foreach(TreeNode tn in Array)
			{
				rValue += tn.GetXmlViewConRoles(++i);
			}

			rValue += "</TREENODES>";
			return rValue;
		}

        public static System.Web.UI.WebControls.XmlDataSource ObtenerRepresentacionXmlDataSourceConRoles(int workflowId)
        {
            // create an XmlDocument (with an XML declaration)
            XmlDocument XDoc = new XmlDocument();
            XmlDeclaration XDec = XDoc.CreateXmlDeclaration("1.0", null, null);
            XDoc.AppendChild(XDec);

            // create an element node to insert
            // note: Element names may not have spaces so use ID
            // note: Element names may not start with a digit so add underscore
            XmlElement NewNode = XDoc.CreateElement("_0");
            NewNode.SetAttribute("ID", "0");
            NewNode.SetAttribute("ParentID", "-1");
            NewNode.SetAttribute("FullName", "Arbol de Politicas");
            XDoc.AppendChild(NewNode);  // root node

            SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
            ArrayList Array = treeProvider.GetChildren(0, workflowId);

            int i = 0;
            foreach (Componentes.DAL.TreeNode tn in Array)
            {
                NewNode.AppendChild(tn.GetXmlViewConRoles(++i, XDoc, treeProvider, -1));
            }

            // we cannot bind the TreeView directly to an XmlDocument
            // so we must create an XmlDataSource and assign the XML text
            System.Web.UI.WebControls.XmlDataSource XDdataSource = new System.Web.UI.WebControls.XmlDataSource();
            XDdataSource.ID = DateTime.Now.Ticks.ToString();  // unique ID is required
            XDdataSource.Data = XDoc.OuterXml;

            return XDdataSource;
        }

		public static ArrayList ObtenerRuta(int workflowId, string politicas, int staffId)
		{			
            using (SqlServerTreeProvider treeProvider = new SqlServerTreeProvider())
            {
                ArrayList retVal = null;

                ArrayList Array = treeProvider.GetChildren(0, workflowId);

                foreach (TreeNode tn in Array)
                {
                    retVal = tn.Evaluate(politicas, staffId);
                    if (retVal != null) break;
                }

                return retVal;
            }
		}

		public static ArrayList ObtenerPoliticasPorWorkflowId(int workflowId)
		{
			ArrayList arrPoliticas = new ArrayList();
			DataSet ds = SqlHelper.ExecuteDataset(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerPoliticasPorWorkflowId, workflowId); 
			
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				WFTipoDeDato objTipoDeDato = new WFTipoDeDato();
				objTipoDeDato.intCodTipoDeDato = Convert.ToInt16(r["wjp_cod_tipodedato"]);
				objTipoDeDato.strNbrTipoDeDato = Convert.ToString(r["wft_nbr_tipodedato"]);

				WFCondicion objCondicion = new WFCondicion();
				objCondicion.intCodCondicion = Convert.ToInt16(r["wjp_cod_condicion"]);
				objCondicion.strNbrCondicion = Convert.ToString(r["wfc_nbr_condicion"]);

				int intPadre = r["wjp_cod_nodopadre"] == System.DBNull.Value ? 0 : Convert.ToInt32(r["wjp_cod_nodopadre"]);
				int intCodPolitica = Convert.ToInt32(r["wjp_cod_nodo"]);
				string strValor = Convert.ToString(r["wjp_val_condicion"]);
				WFPolitica objPolitica = new WFPolitica(workflowId,intCodPolitica,intPadre,objCondicion,strValor,objTipoDeDato);
				arrPoliticas.Add(objPolitica);
			}

			return arrPoliticas;
		}

		public static void BorrarPoliticasEnCadena(int intNodoPadre, int intCodWorkflow)
		{
			SqlHelper.ExecuteNonQuery(ESSeguridad.FormarStringConexion(),Queries.WF_JerarquiPoliticaBorrarParejaDeNodos, intNodoPadre, intCodWorkflow); 
		}

	} // Fin de la Clase
} // Fin del Namespace
