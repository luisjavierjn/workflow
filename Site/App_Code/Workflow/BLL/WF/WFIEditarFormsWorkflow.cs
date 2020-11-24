using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;

namespace Componentes.BLL.WF
{
	//***************************************************************************
	//
    // WFIEditarFormsWorkflow Interface
	//
	// Esta interface esta implementada por cada paso en el Edit Workflow Wizard.
	//
	//***************************************************************************

	public interface WFIEditarFormsWorkflow
	{
        bool Initialize(object obj, int refId, int userId);

        int Save(int userId);

        void Send(int userId, int userDestinoId, string obs);

        void Approve(int userId, int userDestinoId, string obs);

        void Reject(int userId, int userDestinoId, string obs);

        void Revise(int userId, int userDestinoId, string obs);

        ArrayList Approvers(int userId, out int last);
	}
}

