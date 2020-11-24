using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Users;
using System.Drawing;
using Componentes.DAL;
using Componentes.BLL.SE;
using Componentes.BLL.WF;
using System.Collections;

namespace Workflow
{
    public partial class GridPantallaPrincipal : System.Web.UI.UserControl, WFIEditarFormsWorkflow, WFIEditarStatusWF
    {
        WFIEditarStatusWF wpp;

        UserInfo _usuarioLogueado = default(UserInfo);
        //int _userId;
        int i = 0;
        string _azulPastel = "#BFCFFE";
        string _rojoPastel = "#FE8080";

        protected void Page_Load(object sender, EventArgs e)
        {
            //_usuarioLogueado = DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo();
            //_userId = _usuarioLogueado.UserID;
            //GridView1.DataSource = Formss.ListarForms(_userId);
            //GridView1.DataBind();

            //while (i < GridView1.Rows.Count)
            //{

            //    //TextBox MM = (TextBox)GridView1.Rows[i].FindControl("txtMoneyMarket");
            //    Label LbStat = (Label)GridView1.Rows[i].FindControl("LbStatus");


            //    if (LbStat.Text == "Pendiente")
            //    {
            //        GridView1.RowStyle.Font.Bold = true;

            //    }
            //    else if (LbStat.Text == "Aprobado")
            //    {
            //        GridView1.RowStyle.BackColor = Color.Red;
            //    }
            //    //else if (lstTransVI.Count != 0 && fechaVI <= fechaFltro)
            //    //{
            //    //    input = MM.Text;

            //    //    input = FormatString(input);
            //    //    //(TextBox)GridView1.Rows[i].FindControl("txtMoneyMarket") =
            //    //    MM.Text = input;
            //    //    i++;
            //    //}

            //}

            

            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';";//this.style.backgroundColor='white';this.style.color='white';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";//this.style.backgroundColor='white';this.style.color='Black';";

                //"this.style.textDecoration='none';this.style.backgroundColor='"+ e. + "';this.style.color='Black';";

                //TextBox MM = (TextBox)GridView1.Rows[i].FindControl("txtMoneyMarket");
                Label LbStat = (Label)e.Row.FindControl("LbStatus");

                if (LbStat.Text == "Pendiente")
                {
                    //e.Row.Font.Bold = true;
                }
                else if (LbStat.Text == "Aprobado")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml(_azulPastel);// ("#BFCFFE");
                }
                else if (LbStat.Text == "Rechazado")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml(_rojoPastel);// ("#BFCFFE");
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idPH = Convert.ToInt32(this.GridView1.DataKeys[GridView1.SelectedIndex].Values["ReferenciaId"]);
            int wfId = Convert.ToInt32(this.GridView1.DataKeys[GridView1.SelectedIndex].Values["WorkFlowId"]);
            int rpId = Convert.ToInt32(this.GridView1.DataKeys[GridView1.SelectedIndex].Values["ResponsableId"]);
            string status = this.GridView1.DataKeys[GridView1.SelectedIndex].Values["IdStatus"].ToString();

            wpp.IdPH(idPH, wfId, rpId, status);
            //WFIEditarStatusWF wppp = (WFIEditarStatusWF)Componentes.Web.Global.FindMyControl(Page, "WorkflowPP");
            //int transaccionId = Convert.ToInt32(this.GridView1.DataKeys[GridView1.SelectedIndex].Values["TransaccionId"]);
            //int tipoInstId = Convert.ToInt32(this.GridView1.DataKeys[GridView1.SelectedIndex].Values["Tipo"]);
            //MostrarDetalles(transaccionId, tipoInstId);
        }


        #region Miembros de WFIEditarStatusWF

        public void Status(string status, int userId)
        {
            List<Formss> lsta = Formss.ListarForms(userId);
            if (status != "Todos")
            {
                lsta = lsta.FindAll(c => c.IdStatus == status);
                GridView1.DataSource = lsta;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = lsta;
                GridView1.DataBind();
            }
            /*
            while (i < GridView1.Rows.Count)
            {

                //TextBox MM = (TextBox)GridView1.Rows[i].FindControl("txtMoneyMarket");
                Label LbStat = (Label)GridView1.Rows[i].FindControl("LbStatus");
                Label LbRespon = (Label)GridView1.Rows[i].FindControl("LbResponsable");
                Label LbAsnto = (Label)GridView1.Rows[i].FindControl("LbAsunto");
                Label LbDate = (Label)GridView1.Rows[i].FindControl("LbFecha");

                if (LbStat.Text == "Pendiente")
                {
                    LbStat.Font.Bold = true;
                    LbRespon.Font.Bold = true;
                    LbAsnto.Font.Bold = true;
                    LbDate.Font.Bold = true;
                    // GridView1.RowStyle.Font.Bold = true;

                }
                else if (LbStat.Text == "Aprobado")
                {
                    GridView1.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(_azulPastel);
                }
                else if (LbStat.Text == "Rechazado")
                {
                    GridView1.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(_rojoPastel);
                }

                i++;
            }
            */
        }

        public int IdPH(int _idPH, int source, int creadorId, string status)
        {
            //throw new NotImplementedException();
            return _idPH;
        }

        #endregion

        #region Miembros de WFIEditarFormsWorkflow

        public int Save(int userId)
        {
            //throw new NotImplementedException();
            return 0;
        }

        public void Send(int userId, int userDestinoId, string obs)
        {
            //throw new NotImplementedException();
        }

        public void Approve(int userId, int userDestinoId, string obs)
        {
            //throw new NotImplementedException();
        }

        public void Reject(int userId, int userDestinoId, string obs)
        {
            //throw new NotImplementedException();
        }

        public void Revise(int userId, int userDestinoId, string obs)
        {
            //throw new NotImplementedException();
        }

        public ArrayList Approvers(int userId, out int last)
        {
            last = 0;
            return null;
        }

        public bool Initialize(object obj, int refId, int userId)
        {
            wpp = (WFIEditarStatusWF)obj;
            GridView1.DataSource = Formss.ListarForms(userId);
            GridView1.DataBind();
            return true;
        }

        #endregion
    }
}