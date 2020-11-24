using System;

namespace Componentes.BLL.WF
{
	//***************************************************************************
	//
	// WFIEditarControlWorkflow Interface
	//
	// Esta interface esta implementada por cada paso en el Edit Workflow Wizard.
	//
	//***************************************************************************

	public interface WFIEditarControlWorkflow
	{
		int WorkflowId 
		{
			get;
			set;
		}

        string NodeIndex
        {
            get;
            set;
        }

		bool Update();

		void Initialize();
	}
}
