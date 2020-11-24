namespace Workflow.Controles
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using Componentes.BLL.WF;
    using Microsoft.Web.UI.WebControls;
    using Componentes.DAL;
    using Componentes.Web;

	/// <summary>
	///		Summary description for ResumenWorkflow.
	/// </summary>
	public partial class ResumenWorkflow : System.Web.UI.UserControl, WFIEditarControlWorkflow
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

        //protected System.Web.UI.WebControls.ListBox lstNiveles;
        //protected System.Web.UI.WebControls.ListBox lstEscogencia;
        //protected System.Web.UI.WebControls.Button btnAdd;
        //protected System.Web.UI.WebControls.Button btnDel;
        //protected System.Web.UI.WebControls.Label lblNodo;
		private const int NIVELES_EXPANDIDOS = 10;

        //string NodeIndex
        //{
        //    get 
        //    {
        //        if (ViewState["NodeData"] == null)
        //            return "0";
        //        else
        //            return (string)ViewState["NodeData"];
        //    }

        //    set { ViewState["NodeData"] = value; }
        //}
		
		bool FirstTime
		{
			get 
			{
				if (ViewState["FirstTime"] == null)
					return true;
				else
					return (bool)ViewState["FirstTime"];
			}

			set { ViewState["FirstTime"] = value; }
		}

		private int _WorkflowId = -1;

		public int WorkflowId 
		{
			get { return _WorkflowId; }
			set { _WorkflowId = value; }
		}

        private string _nodeIndex;

        public string NodeIndex
        {
            get { return _nodeIndex; }
            set { _nodeIndex = value; }
        }

		public bool Update() 
		{
			return true;
		}

		public void Initialize() 
		{
			lstNiveles.Items.Clear();
			lstEscogencia.Items.Clear();

            System.Web.UI.WebControls.TreeView wft = (System.Web.UI.WebControls.TreeView)Componentes.Web.Global.FindMyControl(Page, "wfTreeView");
            wft.Visible = true;
            wft.ExpandAll();
            //NodeIndex = wft.SelectedValue;

            if (WorkflowId != -1 && FirstTime)
            {
                FirstTime = false;
                wft.DataSource = WFPolitica.ObtenerRepresentacionXmlDataSourceConRutas(WorkflowId);

                // we want the full name displayed in the tree so 
                // do custom databindings
                TreeNodeBinding Binding = new TreeNodeBinding();
                Binding.TextField = "FullName";
                Binding.ValueField = "ID";
                wft.DataBindings.Add(Binding);

                wft.DataBind(); 
            }

            System.Web.UI.WebControls.TreeNode tn = Global.GetNodeFromPath(wft.Nodes, NodeIndex);
            if (tn == null || tn.ChildNodes.Count > 1) return; //MOSTRAR ALGUN MENSAJE DE ALARMA: no es una hoja donde se pueda conseguir una ruta

            int ID = 0;
            if (tn.Value[0] == 'R')
            {
                ID = Convert.ToInt32(tn.Value.Substring(2));
                
                //lstNiveles.DataSource = WFGrupoDeRoles.ObtenerGruposDeRolesExcepto(ID);
                lstNiveles.DataSource = WFGrupoDeRoles.ObtenerGruposDeRolesExcepto(0);
                lstNiveles.DataTextField = "strNbrRoles";
                lstNiveles.DataValueField = "intCodRoles";
                lstNiveles.DataBind();

                lstEscogencia.DataSource = WFGrupoDeRoles.ObtenerGruposDeRoles(ID, tn.Text);
                lstEscogencia.DataTextField = "strNbrRoles";
                lstEscogencia.DataValueField = "intCodRoles";
                lstEscogencia.DataBind();
            }
            else
            {
                lstNiveles.DataSource = WFGrupoDeRoles.ObtenerGruposDeRolesExcepto(ID);
                lstNiveles.DataTextField = "strNbrRoles";
                lstNiveles.DataValueField = "intCodRoles";
                lstNiveles.DataBind();
            }
            
            /*
            Microsoft.Web.UI.WebControls.TreeView tvw = (Microsoft.Web.UI.WebControls.TreeView)Page.FindControl("tvWorkflow");
			if(WorkflowId != -1 && FirstTime)
			{
				FirstTime = false;	
				tvw.TreeNodeSrc = WFPolitica.ObtenerRepresentacionXmlConRutas(WorkflowId);
				tvw.DataBind();
			}
			
			tvw.Visible = true;
			tvw.AutoPostBack = true;
			tvw.ExpandLevel = NIVELES_EXPANDIDOS;

			NodeIndex = tvw.SelectedNodeIndex;			
			Microsoft.Web.UI.WebControls.TreeNode tn = tvw.GetNodeFromIndex(NodeIndex);
			int ID = 0;
			if(tn != null)
			{
				if(tn.NodeData[0] != 'N')
				{
					ID = Convert.ToInt32(tn.NodeData);

					lstNiveles.DataSource = WFGrupoDeRoles.ObtenerGruposDeRolesExcepto(ID);
					lstNiveles.DataTextField = "strNbrRoles";
					lstNiveles.DataValueField = "intCodRoles";
					lstNiveles.DataBind();

					lstEscogencia.DataSource = WFGrupoDeRoles.ObtenerGruposDeRoles(ID,tn.Text);
					lstEscogencia.DataTextField = "strNbrRoles";
					lstEscogencia.DataValueField = "intCodRoles";
					lstEscogencia.DataBind();
				}
				else
				{
					lstNiveles.DataSource = WFGrupoDeRoles.ObtenerGruposDeRolesExcepto(ID);
					lstNiveles.DataTextField = "strNbrRoles";
					lstNiveles.DataValueField = "intCodRoles";
					lstNiveles.DataBind();
				}
			}*/
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
            System.Web.UI.WebControls.TreeView wft = (System.Web.UI.WebControls.TreeView)Componentes.Web.Global.FindMyControl(Page, "wfTreeView");
            System.Web.UI.WebControls.TreeNode tn = Global.GetNodeFromPath(wft.Nodes, NodeIndex);
            if (tn == null || tn.ChildNodes.Count > 1) return;

            if (lstNiveles.SelectedIndex > -1)
            {
                if (tn.Value[0] == 'R')
                {
                    int ID = Convert.ToInt32(tn.Value.Substring(2));
                    ArrayList rutas = WFGrupoDeRoles.ObtenerGruposDeRoles(ID, tn.Text);

                    string camino = "";
                    int i = 0;
                    for (int j = rutas.Count; i < j; i++)
                    {
                        camino += ((WFGrupoDeRoles)rutas[i]).intCodRoles.ToString() + ";";
                    }

                    camino += lstNiveles.SelectedValue + ";";

                    if (WFWorkflow.InsertarCamino(Int32.Parse(tn.Value.Substring(2)), camino))
                    {
                        FirstTime = true;
                        Initialize();
                    }
                }
                else
                {
                    string camino = lstNiveles.SelectedValue + ";";
                    int nodeData = Convert.ToInt32(tn.Value);

                    if (WFWorkflow.InsertarCaminoNuevo(nodeData, camino) > -1)
                    {
                        FirstTime = true;
                        Initialize();
                    }
                }
            }

            /*
            Microsoft.Web.UI.WebControls.TreeView tvw = (Microsoft.Web.UI.WebControls.TreeView)Page.FindControl("tvWorkflow");
			//NodeIndex = tvw.SelectedNodeIndex;			
			Microsoft.Web.UI.WebControls.TreeNode tn = tvw.GetNodeFromIndex(tvw.SelectedNodeIndex);			

			if (lstNiveles.SelectedIndex > -1) 
			{
				if(tn.NodeData[0] != 'N')
				{
					int ID = Convert.ToInt32(tn.NodeData);
					ArrayList rutas = WFGrupoDeRoles.ObtenerGruposDeRoles(ID,tn.Text);

					string camino = "";
					int i = 0;
					for(int j=rutas.Count; i<j; i++)
					{
						camino += ((WFGrupoDeRoles)rutas[i]).intCodRoles.ToString() + ";";
					}

					camino += lstNiveles.SelectedValue + ";";

					if (WFWorkflow.InsertarCamino(Int32.Parse(tn.NodeData),camino))
					{
						FirstTime = true;
						Initialize();
					}
				}
				else
				{
					string camino = lstNiveles.SelectedValue + ";";
					int nodeData = Int32.Parse(tn.NodeData.Substring(2,tn.NodeData.Length-2));

					if (WFWorkflow.InsertarCaminoNuevo(nodeData,camino) > -1)
					{
						FirstTime = true;
						Initialize();
					}
				}
			}
             * */
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
            System.Web.UI.WebControls.TreeView wft = (System.Web.UI.WebControls.TreeView)Componentes.Web.Global.FindMyControl(Page, "wfTreeView");
            System.Web.UI.WebControls.TreeNode tn = Global.GetNodeFromPath(wft.Nodes, NodeIndex);
            if (tn == null || tn.ChildNodes.Count > 1) return;

            if (lstEscogencia.SelectedIndex > -1 && tn.Value[0] == 'R')
            {
                if (lstEscogencia.Items.Count > 1)
                {
                    int ID = Convert.ToInt32(tn.Value.Substring(2));
                    ArrayList rutas = WFGrupoDeRoles.ObtenerGruposDeRoles(ID, tn.Text);

                    string camino = "";
                    int i = 0;
                    for (int j = rutas.Count; i < j; i++)
                    {
                        if (((WFGrupoDeRoles)rutas[i]).intCodRoles != Convert.ToInt32(lstEscogencia.SelectedValue))
                            camino += ((WFGrupoDeRoles)rutas[i]).intCodRoles.ToString() + ";";
                    }

                    if (WFWorkflow.InsertarCamino(Int32.Parse(tn.Value.Substring(2)), camino))
                    {
                        FirstTime = true;
                        Initialize();
                    }
                }
                else
                {
                    int ID = Convert.ToInt32(tn.Value.Substring(2));

                    if (WFWorkflow.BorrarCamino(ID))
                    {
                        FirstTime = true;
                        Initialize();
                    }
                }
            }


            /*
            Microsoft.Web.UI.WebControls.TreeView tvw = (Microsoft.Web.UI.WebControls.TreeView)Page.FindControl("tvWorkflow");
			//NodeIndex = tvw.SelectedNodeIndex;			
			Microsoft.Web.UI.WebControls.TreeNode tn = tvw.GetNodeFromIndex(tvw.SelectedNodeIndex);	

			if (lstEscogencia.SelectedIndex > -1 && tn.NodeData[0] != 'N') 
			{
				if(lstEscogencia.Items.Count > 1)
				{
					int ID = Convert.ToInt32(tn.NodeData);
					ArrayList rutas = WFGrupoDeRoles.ObtenerGruposDeRoles(ID,tn.Text);

					string camino = "";
					int i = 0;
					for(int j=rutas.Count; i<j; i++)
					{
						if(((WFGrupoDeRoles)rutas[i]).intCodRoles != Convert.ToInt32(lstEscogencia.SelectedValue))
							camino += ((WFGrupoDeRoles)rutas[i]).intCodRoles.ToString() + ";";
					}

					if (WFWorkflow.InsertarCamino(Int32.Parse(tn.NodeData),camino))
					{
						FirstTime = true;
						Initialize();
					}
				}
				else
				{
					int ID = Convert.ToInt32(tn.NodeData);

					if (WFWorkflow.BorrarCamino(ID))
					{
						FirstTime = true;
						Initialize();
					}
				}
			}
             * */
		}

    } // Fin de la Clase
} // Fin del Namespace
