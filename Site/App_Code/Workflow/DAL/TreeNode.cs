/*
 * Copyright (c) 2004, Developer Fusion Ltd
 * Author: James Crowley and modified by Luis Jiménez
 * Home Page: http://www.developerfusion.com/
 */
using System;
using System.Data.SqlClient;
using System.Collections;
using Componentes.DAL;
using System.Configuration;
using Componentes.BLL.WF;
using Componentes.BLL;
using Componentes.BLL.SE;
using System.Xml;

namespace Componentes.DAL
{
	/// <summary>
	/// Represents a node in the tree
	/// </summary>
	[Serializable]
	public class TreeNode
	{
		private int _workflowID;
		private int _uniqueID;
		private string _value;
		private int _datatypeID;
		private int _parentID;
		private int _conditionID;
		private int _depth;
		private ArrayList _children;
		private int _sino;

		public TreeNode() { }

		public TreeNode(int workflowID, int conditionID, string nValue, int datatypeID, int parentID, int sino) 
			: this(workflowID,0,conditionID,nValue,datatypeID,parentID,-1,sino)
		{
		}

		public TreeNode(int workflowID, int uniqueID, int conditionID, string nValue, int datatypeID, int parentID, int depth, int sino)
		{
			_workflowID = workflowID;
			_uniqueID = uniqueID;
			_conditionID = conditionID;
			_value = nValue;
			_datatypeID = datatypeID;
			_parentID = parentID;
			_depth = depth;
			_sino = sino;
		}

		public int WorkflowID
		{
			get { return _workflowID; }
		}

		/// <summary>
		/// Gets or sets the unique ID associated with this category
		/// </summary>
		/// <remarks>Once a non-zero ID has been set, it may not be modified.</remarks>
		public int UniqueID
		{
			get { return _uniqueID; }
			set 
			{ 
				if (_uniqueID == 0)
					_uniqueID = value;
				else
					throw new Exception("The UniqueID property cannot be modified once it has a non-zero value");
			}
		}

		public int ConditionID
		{
			get { return _conditionID; }
			set { _conditionID = value; }
		}

		/// <summary>
		/// Gets or sets the label for this node
		/// </summary>
		public string Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public int DatatypeID
		{
			get { return _datatypeID; }
			set { _datatypeID = value; }
		}

		/// <summary>
		/// The ID of the parent node
		/// </summary>
		public int ParentID
		{
			get { return _parentID; }
			set { _parentID = value; }
		}

		public int Depth
		{
			get { return _depth; }
		}

		/// <summary>
		/// Gets the children TreeNode objects for this category
		/// </summary>
		/// <remarks>In .NET 2.0, this can be modified to use generics, and have type ArrayList&lt;TreeNode></remarks>
		public ArrayList Children 
		{
			get { return _children; }
			set { _children = value; }
		}

		public int Sino
		{
			get { return _sino; }
		}

		public string GetXmlView(int Index)
		{
			string Data = "<treenode ";

			SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_JerarquiaPoliticaObtenerTitulo,UniqueID,WorkflowID);

			if(dr.Read())
			{
				Data += "NodeData='" + dr.GetInt32(0) + "' ";
				Data += Index != 2 ? "Text='" + dr.GetString(1) + "'>" : "Text='Sino'>";
				
				SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
				Children = treeProvider.GetChildren(UniqueID,WorkflowID);
                
				int i = 0;
				foreach(TreeNode tn in Children)
				{
					Data += tn.GetXmlView(++i);
				}
			}

			Data += "</treenode>";
			return Data;
		}

        public XmlElement GetXmlView(int Index, XmlDocument XDoc, SqlServerTreeProvider treeProvider, int parentId)
        {
            XmlElement NewNode = null;

            SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_JerarquiaPoliticaObtenerTitulo,UniqueID,WorkflowID);

            if (dr.Read())
            {
                // create an element node to insert
                // note: Element names may not have spaces so use ID
                // note: Element names may not start with a digit so add underscore
                NewNode = XDoc.CreateElement("_" + dr.GetInt32(0));
                NewNode.SetAttribute("ID", dr.GetInt32(0).ToString());
                NewNode.SetAttribute("ParentID", parentId.ToString());
                string Data = Index != 2 ? dr.GetString(1) : "Sino";
                NewNode.SetAttribute("FullName", Data);

                //SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
                Children = treeProvider.GetChildren(UniqueID, WorkflowID);

                int i = 0;
                foreach (TreeNode tn in Children)
                {
                    NewNode.AppendChild(tn.GetXmlView(++i, XDoc, treeProvider, dr.GetInt32(0)));
                }
            }

            return NewNode;
        }

		public string GetXmlViewConRutas(int Index)
		{
			string Data = "<treenode ";

			SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_JerarquiaPoliticaObtenerTitulo,UniqueID,WorkflowID);

			if(dr.Read())
			{
				Data += "NodeData='N." + dr.GetInt32(0) + "' ";
				Data += Index != 2 ? "Text='" + dr.GetString(1) + "'>" : "Text='Sino'>";
				
				SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
				Children = treeProvider.GetChildren(UniqueID,WorkflowID);
                Data += GetXmlRutas();

				int i = 0;
				foreach(TreeNode tn in Children)
				{
					Data += tn.GetXmlViewConRutas(++i);
				}
			}

			Data += "</treenode>";
			return Data;
		}

        public XmlNode GetXmlViewConRutas(int Index, XmlDocument XDoc, SqlServerTreeProvider treeProvider, int parentId)
        {
            XmlElement NewNode = null;

            SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_JerarquiaPoliticaObtenerTitulo,UniqueID,WorkflowID);

            if (dr.Read())
            {
                // create an element node to insert
                // note: Element names may not have spaces so use ID
                // note: Element names may not start with a digit so add underscore
                NewNode = XDoc.CreateElement("_" + dr.GetInt32(0));
                NewNode.SetAttribute("ID", dr.GetInt32(0).ToString());
                NewNode.SetAttribute("ParentID", parentId.ToString());
                string Data = Index != 2 ? dr.GetString(1) : "Sino";
                NewNode.SetAttribute("FullName", Data);
                XmlNode NewRuta = GetXmlRutas(XDoc, parentId);
                if (NewRuta != null) NewNode.AppendChild(NewRuta);

                //SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
                Children = treeProvider.GetChildren(UniqueID, WorkflowID);

                int i = 0;
                foreach (TreeNode tn in Children)
                {
                    NewNode.AppendChild(tn.GetXmlViewConRutas(++i, XDoc, treeProvider, dr.GetInt32(0)));
                }
            }

            return NewNode;
        }

		public string GetXmlViewConRoles(int Index)
		{
			string Data = "<treenode ";

			SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_JerarquiaPoliticaObtenerTitulo,UniqueID,WorkflowID);

			if(dr.Read())
			{
				Data += "NodeData='N." + dr.GetInt32(0) + "' ";
				Data += Index != 2 ? "Text='" + dr.GetString(1) + "'>" : "Text='Sino'>";
				
				SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
				Children = treeProvider.GetChildren(UniqueID,WorkflowID);
				Data += GetXmlRoles();

				int i = 0;
				foreach(TreeNode tn in Children)
				{
					Data += tn.GetXmlViewConRoles(++i);
				}
			}

			Data += "</treenode>";
			return Data;
		}

        public XmlNode GetXmlViewConRoles(int Index, XmlDocument XDoc, SqlServerTreeProvider treeProvider, int parentId)
        {
            XmlElement NewNode = null;

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings[Web.Global.CfgKeyConnString], Queries.WF_JerarquiaPoliticaObtenerTitulo, UniqueID, WorkflowID);

            if (dr.Read())
            {
                // create an element node to insert
                // note: Element names may not have spaces so use ID
                // note: Element names may not start with a digit so add underscore
                NewNode = XDoc.CreateElement("_" + dr.GetInt32(0));
                NewNode.SetAttribute("ID", dr.GetInt32(0).ToString());
                NewNode.SetAttribute("ParentID", parentId.ToString());
                string Data = Index != 2 ? dr.GetString(1) : "Sino";
                NewNode.SetAttribute("FullName", Data);
                XmlNode NewRole = GetXmlRoles(XDoc, parentId);
                if (NewRole != null) NewNode.AppendChild(NewRole);

                //SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
                Children = treeProvider.GetChildren(UniqueID, WorkflowID);

                int i = 0;
                foreach (TreeNode tn in Children)
                {
                    NewNode.AppendChild(tn.GetXmlViewConRoles(++i, XDoc, treeProvider, dr.GetInt32(0)));
                }
            }

            return NewNode;
        }

		public string GetXmlRutas()
		{
			string Data = "";

			SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerCaminosPorNodo,UniqueID);

			while(dr.Read())
			{
				Data += "<treenode ";
				Data += "NodeData='" + dr.GetInt32(0) + "' ";
				Data += "Text='" + dr.GetString(1) + "'>";
				Data += "</treenode>";
			}

			return Data;
		}

        public XmlNode GetXmlRutas(XmlDocument XDoc, int parentId)
        {
            XmlElement NewNode = null;

			SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerCaminosPorNodo,UniqueID);

            while (dr.Read())
            {
                NewNode = XDoc.CreateElement("_" + dr.GetInt32(0));
                NewNode.SetAttribute("ID", "R_" + dr.GetInt32(0).ToString());
                NewNode.SetAttribute("ParentID", parentId.ToString());
                NewNode.SetAttribute("FullName", dr.GetString(1));
            }

            return NewNode;
        }

		public string GetXmlRoles()
		{
			string Data = "";

			SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerCaminosConRoles,UniqueID);

			while(dr.Read())
			{
				Data += "<treenode ";
				Data += "NodeData='" + dr.GetInt32(0) + "' ";
				Data += "Text='" + dr.GetString(1) + "'>";
				Data += "</treenode>";
			}

			return Data;
		}

        public XmlNode GetXmlRoles(XmlDocument XDoc, int parentId)
        {
            XmlElement NewNode = null;

            SqlDataReader dr = SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings[Web.Global.CfgKeyConnString], Queries.WF_ObtenerCaminosConRoles, UniqueID);

            while (dr.Read())
            {
                NewNode = XDoc.CreateElement("_" + dr.GetInt32(0));
                NewNode.SetAttribute("ID", "R_" + dr.GetInt32(0).ToString());
                NewNode.SetAttribute("ParentID", parentId.ToString());
                NewNode.SetAttribute("FullName", dr.GetString(1));
            }

            return NewNode;
        }

		public ArrayList Evaluate(string politicas, int staffOrigen)
		{
			// Ejemplo de "politicas" = "Bs.;500000"
			// Ejemplo de "staffOrigen" = 10108
			ArrayList retVal = null;
			string ruta = "";
			string [] parser = politicas.Split(';');

			WFCondicion Cond = WFCondicion.ObtenerCondicionPorID(ConditionID);
			WFTipoDeDato Tdt = WFTipoDeDato.ObtenerTiposDeDatoPorID(DatatypeID);

			bool blnCumplioLaPolitica = false;
			switch(Tdt.strNbrTipoDeDato.Trim())
			{
				case "Monto":
				{
					double dblValor = Convert.ToDouble(parser[0]);
					blnCumplioLaPolitica = Comparar(Cond,Convert.ToDouble(_value),dblValor);	
				}
					break;

				case "Cantidad":
				{
					int intValor = Convert.ToInt32(parser[0]);
					blnCumplioLaPolitica = Comparar(Cond,Convert.ToInt32(_value),intValor);	
				}
					break;

				case "Fecha":
				{
					DateTime dttValor = Convert.ToDateTime(parser[0]);
					blnCumplioLaPolitica = Comparar(Cond,Convert.ToDateTime(parser[0]),dttValor);	
				}
					break;

				case "Moneda":
				{
					string strValor = parser[0].Trim();
					blnCumplioLaPolitica = Comparar(Cond,_value.Trim(),strValor);	
				}
					break;

				case "Nombre":
				{
					string strValor = parser[0].Trim();
					blnCumplioLaPolitica = Comparar(Cond,_value.Trim(),strValor);	
				}
					break;
			}

			if(blnCumplioLaPolitica)
			{
				if(Sino == 1)
				{
					SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
					Children = treeProvider.GetChildren(UniqueID,WorkflowID);

					bool tieneNodosHijos = false;
					foreach(TreeNode tn in Children)
					{
						tieneNodosHijos = true;
						retVal = tn.Evaluate(politicas,staffOrigen);
						if(retVal != null) break;
					}

					if(!tieneNodosHijos)
					{
						SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerCaminos,staffOrigen,WorkflowID,UniqueID);

						if(dr.Read())
						{
							retVal = new ArrayList();
							do
							{
								ruta = dr.GetString(0);
								retVal.Add(ruta);
							}
							while(dr.Read());
						}
						else
						{
							return null;
//							throw new Exception("No se pudo establecer la ruta a través de las políticas y el código de staff #3");
						}
					}
				}
				else
				{
					if(parser.Length > 1)
					{
						string politicasHijas = "";
						for(int j=1; j<parser.Length; j++) 
							politicasHijas += j+1 < parser.Length ? parser[j] + ";" : parser[j];
						
						SqlServerTreeProvider treeProvider = new SqlServerTreeProvider();
						Children = treeProvider.GetChildren(UniqueID,WorkflowID);

						bool tieneNodosHijos = false;
						foreach(TreeNode tn in Children)
						{
							tieneNodosHijos = true;
							retVal = tn.Evaluate(politicasHijas,staffOrigen);
							if(retVal != null) break;
						}

						if(!tieneNodosHijos)
						{
							SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerCaminos,staffOrigen,WorkflowID,UniqueID);

							if(dr.Read())
							{
								retVal = new ArrayList();
								do
								{
									ruta = dr.GetString(0);
									retVal.Add(ruta);
								}
								while(dr.Read());
							}
							else
							{
								return null;
//								throw new Exception("No se pudo establecer la ruta a través de las políticas y el código de staff #1");
							}
						}
					}	
					else
					{
						SqlDataReader dr = SqlHelper.ExecuteReader(ESSeguridad.FormarStringConexion(),Queries.WF_ObtenerCaminos,staffOrigen,WorkflowID,UniqueID);

						if(dr.Read())
						{
							retVal = new ArrayList();
							do
							{
								ruta = dr.GetString(0);
								retVal.Add(ruta);
							}
							while(dr.Read());
						}
						else
						{
							return null;
//							throw new Exception("No se pudo establecer la ruta a través de las políticas y el código de staff #2");
						}
					}
				}
			}

			return retVal;
		}

		public bool Comparar(WFCondicion Cond, string TNValor, string Valor)
		{
			bool retVal = false;
			switch(Cond.strNbrCondicion.Trim())
			{
				case "=": if(Valor == TNValor) retVal = true; break;
				case "<>": if(Valor != TNValor) retVal = true; break;
			}
			return retVal;
		}

		public bool Comparar(WFCondicion Cond, double TNValor, double Valor)
		{
			bool retVal = false;
			switch(Cond.strNbrCondicion.Trim())
			{
				case "=": if(Valor == TNValor) retVal = true; break;
				case "<>": if(Valor != TNValor) retVal = true; break;
				case "<": if(Valor < TNValor) retVal = true; break;
				case ">=": if(Valor >= TNValor) retVal = true; break;
				case ">": if(Valor > TNValor) retVal = true; break;
				case "<=": if(Valor <= TNValor) retVal = true; break;
			}
			return retVal;
		}

		public bool Comparar(WFCondicion Cond, int TNValor, int Valor)
		{
			bool retVal = false;
			switch(Cond.strNbrCondicion.Trim())
			{
				case "=": if(Valor == TNValor) retVal = true; break;
				case "<>": if(Valor != TNValor) retVal = true; break;
				case "<": if(Valor < TNValor) retVal = true; break;
				case ">=": if(Valor <= TNValor) retVal = true; break;
				case ">": if(Valor > TNValor) retVal = true; break;
				case "<=": if(Valor <= TNValor) retVal = true; break;
			}
			return retVal;
		}

		public bool Comparar(WFCondicion Cond, DateTime TNValor, DateTime Valor)
		{
			bool retVal = false;
			switch(Cond.strNbrCondicion.Trim())
			{
				case "=": if(Valor == TNValor) retVal = true; break;
				case "<>": if(Valor != TNValor) retVal = true; break;
				case "<": if(Valor < TNValor) retVal = true; break;
				case ">=": if(Valor <= TNValor) retVal = true; break;
				case ">": if(Valor > TNValor) retVal = true; break;
				case "<=": if(Valor <= TNValor) retVal = true; break;
			}
			return retVal;
		}
    } // Fin de la Clase
} // Fin del Namespace
