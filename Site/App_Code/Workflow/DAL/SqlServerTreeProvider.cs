/*
 * Copyright (c) 2004, Developer Fusion Ltd
 * Author: James Crowley and modified by Luis Jiménez
 * Home Page: http://www.developerfusion.com/
 */

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Componentes.BLL;
using Componentes.BLL.SE;

namespace Componentes.DAL
{
	/// <summary>
	/// Provides an implementation of the TreeProvider for SQL Server
	/// </summary>
	public class SqlServerTreeProvider : IDisposable
	{
		readonly string connectionString = ESSeguridad.FormarStringConexion();
        SqlConnection sqlConn;

        public SqlServerTreeProvider()
        {
            sqlConn = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            sqlConn.Close();
            sqlConn = null;
        }

		public int AddNode(TreeNode treeNode)
		{
			// automatically dispose of the SqlConnection object
			// when we're done
			//using (SqlConnection sqlConn = new SqlConnection(connectionString) )
			{
				// execute the WF_JerarquiaPoliticaAgregarNodo procedure
				SqlCommand sqlComm = new SqlCommand(Queries.WF_JerarquiaPoliticaAgregarNodo,sqlConn);
				sqlComm.CommandType = CommandType.StoredProcedure;
				sqlComm.Parameters.Add("@cod_workflow",SqlDbType.Int).Value = treeNode.WorkflowID;
				sqlComm.Parameters.Add("@cod_nodopadre",SqlDbType.Int).Value = treeNode.ParentID;
				sqlComm.Parameters.Add("@cod_condicion",SqlDbType.TinyInt).Value = treeNode.ConditionID;
				sqlComm.Parameters.Add("@valor",SqlDbType.NVarChar,50).Value = treeNode.Value;
				sqlComm.Parameters.Add("@cod_tipodedato",SqlDbType.TinyInt).Value = treeNode.DatatypeID;
				sqlComm.Parameters.Add("@bln_sino",SqlDbType.Bit).Value = treeNode.Sino;

				sqlComm.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

				sqlConn.Open();
				sqlComm.ExecuteNonQuery();

				return (int)sqlComm.Parameters["@RETURN_VALUE"].Value;
			}
		}

		public void UpdateNode(TreeNode treeNode)
		{
			//using (SqlConnection sqlConn = new SqlConnection(connectionString) )
			{
				// execute the WF_JerarquiaPoliticaActualizarNodo stored procedure
				SqlCommand sqlComm = new SqlCommand(Queries.WF_JerarquiaPoliticaActualizarNodo,sqlConn);
				sqlComm.CommandType = CommandType.StoredProcedure;
				sqlComm.Parameters.Add("@cod_workflow",SqlDbType.Int).Value = treeNode.WorkflowID;
				sqlComm.Parameters.Add("@cod_nodo",SqlDbType.Int).Value = treeNode.UniqueID;
				sqlComm.Parameters.Add("@cod_nodopadre",SqlDbType.Int).Value = treeNode.ParentID;
				sqlComm.Parameters.Add("@cod_condicion",SqlDbType.TinyInt).Value = treeNode.ConditionID;
				sqlComm.Parameters.Add("@valor",SqlDbType.NVarChar,50).Value = treeNode.Value;
				sqlComm.Parameters.Add("@cod_tipodedato",SqlDbType.TinyInt).Value = treeNode.DatatypeID;

				sqlConn.Open();
				sqlComm.ExecuteNonQuery();
			}
		}

		public void RemoveNode(int uniqueID)
		{
			//using (SqlConnection sqlConn = new SqlConnection(connectionString) )
			{
				// execute the WF_JerarquiaPoliticaBorrarNodo stored procedure
				SqlCommand sqlComm = new SqlCommand(Queries.WF_JerarquiaPoliticaBorrarNodo,sqlConn);
				sqlComm.CommandType = CommandType.StoredProcedure;
				sqlComm.Parameters.Add("@cod_nodo",SqlDbType.Int).Value = uniqueID;
				sqlConn.Open();
				sqlComm.ExecuteNonQuery();
			}
		}

		public TreeNode GetTree(int uniqueID)
		{
			return ProcessTree(Queries.WF_JerarquiaPoliticaObtenerArbol,
				new SqlParameter("@cod_nodo",uniqueID));
		}

		public ArrayList GetTreeList(int uniqueID)
		{
			return ProcessList(Queries.WF_JerarquiaPoliticaObtenerArbol,
				new SqlParameter("@cod_nodo",uniqueID));
		}

		public ArrayList GetPath(int uniqueID)
		{
			return ProcessList(Queries.WF_JerarquiaPoliticaObtenerRuta,
				new SqlParameter("@cod_nodo",uniqueID));
		}

//		public ArrayList GetValidParents(int rootID, int uniqueID)
//		{
//			return ProcessList("dfTreeGetValidParents",
//				new SqlParameter("@rootId",rootID),
//				new SqlParameter("@id",uniqueID));
//		}

		public ArrayList GetChildren(int uniqueID)
		{
			return ProcessList(Queries.WF_JerarquiaPoliticaObtenerHijos,
				new SqlParameter("@cod_nodo",uniqueID));
		}

		public ArrayList GetChildren(int uniqueID, int workflowID)
		{
			return ProcessList(Queries.WF_JerarquiaPoliticaObtenerHijosPorWfID,
				new SqlParameter("@cod_nodo",uniqueID),
				new SqlParameter("@cod_workflow",workflowID));
		}

		public ArrayList GetSubChildren(int uniqueID, int depth)
		{
			return ProcessList(Queries.WF_JerarquiaPoliticaObtenerSubHijos,
				new SqlParameter("@cod_nodo",uniqueID),
				new SqlParameter("@profundidad",depth));
		}

//		public TreeNode GetTreeNode(int uniqueID)
//		{
//			ArrayList item = ProcessList("dfTreeGetNode",
//				new SqlParameter("@id",uniqueID)); 
//
//			return (item.Count > 0) ? (TreeNode)item[0] : null;
//		}

		protected TreeNode ProcessTree(string storedProcedure, params SqlParameter[] parameters) 
		{
			//using (SqlConnection sqlConn = new SqlConnection(connectionString) )
			{
				// execute the appropriate sp
				SqlCommand sqlComm = new SqlCommand(storedProcedure,sqlConn);
				sqlComm.CommandType = CommandType.StoredProcedure;
				foreach(SqlParameter param in parameters)
					sqlComm.Parameters.Add(param);

				// open the connection
				sqlConn.Open();
				// fetch the rows
				SqlDataReader dr = sqlComm.ExecuteReader();
				// populate a TreeNode object and all its children
				TreeNode node = PopulateTreeNodesFromReader(dr);
				dr.Close();
				sqlConn.Close();

				return node;
			}
		}

		protected ArrayList ProcessList(string storedProcedure, params SqlParameter[] parameters) {

			//using (SqlConnection sqlConn = new SqlConnection(connectionString) )
			{
				// execute the appropriate sp
				SqlCommand sqlComm = new SqlCommand(storedProcedure,sqlConn);
				sqlComm.CommandType = CommandType.StoredProcedure;
				foreach(SqlParameter param in parameters)
					sqlComm.Parameters.Add(param);
				
				ArrayList nodes = new ArrayList();

				sqlConn.Open();
				SqlDataReader dr = sqlComm.ExecuteReader();

				while (dr.Read())
					nodes.Add ( TreeNodeFromDataReader(dr) );

				dr.Close();
				sqlConn.Close();

				return nodes;
			}
		}


		protected virtual TreeNode TreeNodeFromDataReader(SqlDataReader dr) 
		{
			
				int a = dr.GetInt32(0);
				int b = dr.GetInt32(1);
				int c = (int)dr.GetByte(2);
				string d = dr.GetString(3);
				int e = (int)dr.GetByte(4);
				int f = dr["wjp_cod_nodopadre"] == DBNull.Value ? 0 : (int)dr["wjp_cod_nodopadre"];
				int g = dr.GetInt32(6);
				bool h = dr.GetBoolean(7);
				int hh = h ? 1 : 0;

			TreeNode node = new TreeNode(a,b,c,d,e,f,g,hh);

//			TreeNode node = new TreeNode(
//				(int)dr["wjp_cod_workflow"],
//				(int)dr["wjp_cod_nodo"],
//				(int)dr["wjp_cod_condicion"],
//				(string)dr["wjp_val_condicion"],
//				(int)dr["wjp_cod_tipodedato"],
//				dr["wjp_cod_nodopadre"] == DBNull.Value ? 0 : (int)dr["wjp_cod_nodopadre"],
//				(int)dr["wjp_num_profundidad"]);
			
			return node;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dr"></param>
		/// <returns></returns>
		/// <remarks>In order for this to work, we require the first row
		/// in the DataReader to be the root of the tree. In addition, we require
		/// the rows to be ordered such that if the depth increases, the next
		/// row will be a child of the previous row (and therefore the depth
		/// has only changed by 1).</remarks>
		protected TreeNode PopulateTreeNodesFromReader(SqlDataReader dr) 
		{
			//Stack<Category> categories = new Stack();
			Stack nodes = new Stack();

			// if we have no rows, then we don't have a tree!
			if (!dr.Read())
				return null;

			TreeNode rootNode = TreeNodeFromDataReader(dr);
			
			// we're currently at the root, so the
			// depth is zero
			int currentDepth = 0;

			TreeNode currentNode = rootNode;

			// now that we've got a "root" of our tree,
			// start populating its children
			while (dr.Read()) 
			{
				if ((int)dr["wjp_str_profundidad"] > currentDepth) 
				{
					// assert dr["depth"] = currentDepth + 1
					// assert currentCategory!=null

					// we now have a child of the last category
					nodes.Push(currentNode);
					// set the current depth
					currentDepth = (int)dr["depth"];
				} 
				else if ((int)dr["wjp_str_profundidad"] < currentDepth) 
				{
					// pop off appropriate number of items from stack
					while ((int)dr["wjp_str_profundidad"] < currentDepth) 
					{
						--currentDepth;
						nodes.Pop();
					}
				}

				currentNode = TreeNodeFromDataReader(dr);
				((TreeNode)nodes.Peek()).Children.Add(currentNode);

			}

			nodes.Clear();

			// return the children
			return rootNode;
		}
    }
}
