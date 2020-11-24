using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de WFIEditarStatusWF
/// </summary>
/// 

namespace Componentes.BLL.WF
{
    //***************************************************************************
    //
    // WFIEditarControlWorkflow Interface
    //
    // Esta interface esta implementada por cada paso en el Edit Workflow Wizard.
    //
    //***************************************************************************

    public interface WFIEditarStatusWF
    {
        void Status(string status, int userId);

        int IdPH(int idPH, int wfId, int creadorId, string status);
    }
}

//public class WFIEditarStatusWF
//{
//    public WFIEditarStatusWF()
//    {
//        //
//        // TODO: Agregar aquí la lógica del constructor
//        //
//    }
//}
