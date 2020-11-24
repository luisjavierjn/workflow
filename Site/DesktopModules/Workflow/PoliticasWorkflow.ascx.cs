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
	using Componentes.BLL;
	using Microsoft.Web.UI.WebControls;
	using Componentes.DAL;
    using Componentes.Web;
    using System.Web.UI;
    using System.Xml;

	/// <summary>
	///		Summary description for PoliticasWorkflow.
	/// </summary>
	public partial class PoliticasWorkflow : System.Web.UI.UserControl, WFIEditarControlWorkflow
	{
        //protected System.Web.UI.WebControls.ImageButton ImageButton6;
        //protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
        //protected System.Web.UI.WebControls.TextBox txtPolitica;
        //protected System.Web.UI.WebControls.DropDownList ddlCondicion;
        //protected System.Web.UI.WebControls.DropDownList ddlTipo;
        //protected System.Web.UI.WebControls.DataGrid dgdPoliticas;
		private const int NIVELES_EXPANDIDOS = 10;

        protected void Page_Load(object sender, System.EventArgs e)
        {
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
            //this.dgdPoliticas.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPoliticas_CancelCommand);
            //this.dgdPoliticas.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPoliticas_EditCommand);
            //this.dgdPoliticas.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPoliticas_UpdateCommand);
            //this.dgdPoliticas.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdPoliticas_DeleteCommand);
			//this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			//this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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

		int Informacion
		{
			get 
			{
				if (ViewState["Informacion"] == null)
					return 0;
				else
					return (int)ViewState["Informacion"];
			}

			set { ViewState["Informacion"] = value; }
		}

		int Condicion
		{
			get 
			{
				if (ViewState["Condicion"] == null)
					return 0;
				else
					return (int)ViewState["Condicion"];
			}

			set { ViewState["Condicion"] = value; }
		}

		string Valor
		{
			get 
			{
				if (ViewState["Valor"] == null)
					return "";
				else
					return (string)ViewState["Valor"];
			}

			set { ViewState["Valor"] = value; }
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
            BindCombos();
            BindPoliticas();

            //Microsoft.Web.UI.WebControls.TreeView tvw = (Microsoft.Web.UI.WebControls.TreeView)ES.Web.Global.FindMyControl(Page, "tvWorkflow");
            //tvw.Visible = true;
            //tvw.ExpandLevel = NIVELES_EXPANDIDOS;
            //NodeIndex = tvw.SelectedNodeIndex;

            //if(WorkflowId != -1)
            //{
            //    tvw.TreeNodeSrc = WFPolitica.ObtenerRepresentacionXml(WorkflowId);
            //    tvw.DataBind();
            //}

            System.Web.UI.WebControls.TreeView wft = (System.Web.UI.WebControls.TreeView)Componentes.Web.Global.FindMyControl(Page, "wfTreeView");
            wft.Visible = true;
            wft.ExpandAll();
            //NodeIndex = wft.SelectedValue;

            if (WorkflowId != -1)
            {
                wft.DataSource = WFPolitica.ObtenerRepresentacionXmlDataSource(WorkflowId);

                // we want the full name displayed in the tree so 
                // do custom databindings
                TreeNodeBinding Binding = new TreeNodeBinding();
                Binding.TextField = "FullName";
                Binding.ValueField = "ID";
                wft.DataBindings.Add(Binding);

                wft.DataBind();

                //string xml = WFPolitica.ObtenerRepresentacionXml(WorkflowId);
                //XmlDocument XDoc = new XmlDocument();
                //XmlDeclaration XDec = XDoc.CreateXmlDeclaration("1.0", null, null);
                //XDoc.AppendChild(XDec);
                //XDoc.LoadXml(xml);
                ////string str = XDoc.OuterXml;

                //// we cannot bind the TreeView directly to an XmlDocument
                //// so we must create an XmlDataSource and assign the XML text
                //XmlDataSource XDdataSource = new XmlDataSource();
                //XDdataSource.ID = DateTime.Now.Ticks.ToString();  // unique ID is required
                //XDdataSource.Data = XDoc.OuterXml;

                //// we want the full name displayed in the tree so 
                //// do custom databindings
                //TreeNodeBinding Binding = new TreeNodeBinding();
                //Binding.TextField = "Text";
                //Binding.ValueField = "NodeData";
                //wft.DataBindings.Add(Binding);

                //// Finally! Hook that bad boy up!       
                //wft.DataSource = XDdataSource;
                //wft.DataBind();                
            }
        }

        protected void hfCommand_ValueChanged(object sender, EventArgs e)
        {
            if (hfCommand.Value == "Update")
            {
                int index = Convert.ToInt32(hfIndex.Value);

                int hftipo = Convert.ToInt32(hfTipoDeDato.Value);
                int hfcond = Convert.ToInt32(hfCondicion.Value);

                if (hftipo != 0 && hfcond != 0 && hfValor.Value != String.Empty)
                {
                    ArrayList politicas = (ArrayList)dgdPoliticas.DataSource;
                    ArrayList tiposdedato = (ArrayList)ddlTipo.DataSource;
                    ArrayList condiciones = (ArrayList)ddlCondicion.DataSource;

                    WFPolitica selected = (WFPolitica)politicas[index];
                    selected.objTipoDeDato = (WFTipoDeDato)tiposdedato[hftipo];
                    selected.objCondicion = (WFCondicion)condiciones[hfcond];
                    selected.strValor = hfValor.Value;
                    //selected.Update();
                }
                //selected.

                //ddlCondicion.DataSource = WFCondicion.ObtenerCondiciones();

                
                //int condId = ((WFCondicion)cond[index]).intCodCondicion;

                //System.Web.UI.WebControls.TreeView tvw = (System.Web.UI.WebControls.TreeView)Componentes.Web.Global.FindMyControl(Page, "wfTreeView");
                //System.Web.UI.WebControls.TreeNode tn = Global.GetNodeFromPath(tvw.Nodes, NodeIndex);
                //DropDownList ddlTipoDeDato = (DropDownList)Global.FindMyControl(Page, "ddlTipoDeDatoItem");
                //string tipoDeDatoSelected = ddlTipoDeDato.SelectedValue;
            }

            if (hfCommand.Value == "Cancel")
            {
                int index = Convert.ToInt32(hfIndex.Value);

                //dgdPoliticas.EditItemIndex = -1;
                //dgdPoliticas.DataSource = WFPolitica.ObtenerPoliticasPorWorkflowId(WorkflowId);
                //dgdPoliticas.DataBind();
            }

            hfCommand.Value = "";
        }
        
		public void BindCombos()
		{
			ddlCondicion.DataSource = WFCondicion.ObtenerCondiciones();
			ddlCondicion.DataValueField = "intCodCondicion";
			ddlCondicion.DataTextField = "strNbrCondicion";
			ddlCondicion.DataBind();

			ddlTipo.DataSource = WFTipoDeDato.ObtenerTiposDeDato();
			ddlTipo.DataValueField = "intCodTipoDeDato";
			ddlTipo.DataTextField = "strNbrTipoDeDato";
			ddlTipo.DataBind();
		}

		public void BindPoliticas()
		{
			dgdPoliticas.DataSource = WFPolitica.ObtenerPoliticasPorWorkflowId(WorkflowId);
			dgdPoliticas.DataBind();
		}

		protected void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			int Condicion = Int32.Parse(ddlCondicion.SelectedItem.Value);
			int Tipo = Int32.Parse(ddlTipo.SelectedItem.Value);
			string Valor = txtPolitica.Text;
            Label lblError = (Label)Global.FindMyControl(Page, "lblError");

			if (Condicion == 0 || Tipo == 0 || Valor == "")
			{
				lblError.Visible = true;
				lblError.Text = ESMensajes.ObtenerMensaje(551);
				return;
			}
			else
			{
				lblError.Visible = false;
			}

			WFCondicion objCondicion = WFCondicion.ObtenerCondicionPorID(Condicion);
			WFTipoDeDato objTipo = WFTipoDeDato.ObtenerTiposDeDatoPorID(Tipo);            
            //Microsoft.Web.UI.WebControls.TreeView tvw = (Microsoft.Web.UI.WebControls.TreeView)Page.FindControl("tvWorkflow");
            System.Web.UI.WebControls.TreeView tvw = (System.Web.UI.WebControls.TreeView)Componentes.Web.Global.FindMyControl(Page, "wfTreeView");

            System.Web.UI.WebControls.TreeNode tn = Global.GetNodeFromPath(tvw.Nodes, NodeIndex);
            if (tn == null || tn.ChildNodes.Count > 0) return; //MOSTRAR ALGUN MENSAJE DE ALARMA: no se puede indexar más de una política dentro de otra
            
            int ID = Convert.ToInt32(tn.Value);
            WFPolitica newPolitica = new WFPolitica(WorkflowId, 0, ID, objCondicion, Valor, objTipo);
            if (newPolitica.Save())
            {
                ddlCondicion.SelectedIndex = 0;
                ddlTipo.SelectedIndex = 0;
                txtPolitica.Text = "";
                BindPoliticas();

                tvw.DataSource = WFPolitica.ObtenerRepresentacionXmlDataSource(WorkflowId);
                tvw.DataBind();
                HiddenField nodeIndex = (HiddenField)Global.FindMyControl(Page, "NodeIndex");
                nodeIndex.Value = "0";
                lblError.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = ESMensajes.ObtenerMensaje(302);
            }

            //Microsoft.Web.UI.WebControls.TreeNode tn = tvw.GetNodeFromIndex(NodeIndex);
            //int ID = 0;
            //if(tn.NodeData != "") ID = Convert.ToInt32(tn.NodeData);

            //WFPolitica newPolitica = new WFPolitica(WorkflowId, 0, ID, objCondicion, Valor, objTipo);
            //if (newPolitica.Save()) 
            //{
            //    ddlCondicion.SelectedIndex = 0;
            //    ddlTipo.SelectedIndex = 0;
            //    txtPolitica.Text = "";
            //    BindPoliticas();

            //    tvw.TreeNodeSrc = WFPolitica.ObtenerRepresentacionXml(WorkflowId);
            //    tvw.DataBind();
            //    lblError.Visible = false;
            //} 
            //else 
            //{
            //    lblError.Visible = true;
            //    lblError.Text = ESMensajes.ObtenerMensaje(302);
            //}
		}

        protected void dgdPoliticas_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            hfIndex.Value = e.Item.ItemIndex.ToString();
			dgdPoliticas.EditItemIndex = e.Item.ItemIndex;

			ArrayList arrPoliticas = WFPolitica.ObtenerPoliticasPorWorkflowId(WorkflowId);
			dgdPoliticas.DataSource = arrPoliticas;
			dgdPoliticas.DataBind();

			DropDownList ddlTipoDeDato = (DropDownList)dgdPoliticas.Items[e.Item.ItemIndex].FindControl("ddlTipoDeDatoItem");

			ddlTipoDeDato.DataSource = WFTipoDeDato.ObtenerTiposDeDato();
			ddlTipoDeDato.DataValueField = "intCodTipoDeDato";
			ddlTipoDeDato.DataTextField = "strNbrTipoDeDato";
			ddlTipoDeDato.DataBind();

			ddlTipoDeDato.Items.FindByValue(((WFPolitica)arrPoliticas[e.Item.ItemIndex]).objTipoDeDato.intCodTipoDeDato.ToString()).Selected = true;

			DropDownList ddlCondicion = (DropDownList)dgdPoliticas.Items[e.Item.ItemIndex].FindControl("ddlCondicionItem");

			ddlCondicion.DataSource = WFCondicion.ObtenerCondiciones();
			ddlCondicion.DataValueField = "intCodCondicion";
			ddlCondicion.DataTextField = "strNbrCondicion";
			ddlCondicion.DataBind();

			ddlCondicion.Items.FindByValue(((WFPolitica)arrPoliticas[e.Item.ItemIndex]).objCondicion.intCodCondicion.ToString()).Selected = true;

            //ImageButton ib = (ImageButton)FindMyControl(this, "ibtnActualizar");
            //ib.Attributes.Add("onclick", "javascritp:jsUpdate(" + e.Item.ItemIndex + ");");
//			DeshabilitarValidadores();
		}

        protected void dgdPoliticas_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			ArrayList arrPoliticas = WFPolitica.ObtenerPoliticasPorWorkflowId(WorkflowId);
			int intCodPadre = ((WFPolitica)arrPoliticas[e.Item.ItemIndex]).intCodPadre;
			int intCodWorkflow = ((WFPolitica)arrPoliticas[e.Item.ItemIndex]).WorkflowId;
			WFPolitica.BorrarPoliticasEnCadena(intCodPadre,intCodWorkflow);
			
			Initialize();
		}

//        protected void dgdPoliticas_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
//        {
//            dgdPoliticas.EditItemIndex = -1;
//            dgdPoliticas.DataSource = WFPolitica.ObtenerPoliticasPorWorkflowId(WorkflowId);
//            dgdPoliticas.DataBind();

////			HabilitarValidadores();
//        }

        private Control FindMyControl(Control ctrl, string controlID)
        {
            Control Ret = null;

            foreach (Control Ctrl in ctrl.Controls)
            {
                if (Ctrl.ID != null && Ctrl.ID.ToLower() == controlID.ToLower())
                {
                    Ret = Ctrl;
                    break;
                }
                else
                {
                    Ret = FindMyControl(Ctrl, controlID);
                    if (Ret != null)
                    {
                        break;
                    }
                }
            }
            return Ret;
        }

	} // Fin de la Clase
} // Fin del Namespace
