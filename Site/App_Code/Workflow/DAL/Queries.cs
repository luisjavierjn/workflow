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

namespace Componentes.DAL
{
    /// <summary>
    /// Descripción breve de Queries
    /// </summary>
    public class Queries
    {
        public const string WF_ObtenerCondiciones = "WF_ObtenerCondiciones";
        public const string WF_ObtenerCondicionPorID = "WF_ObtenerCondicionPorID";
        public const string WF_ObtenerGrupoDeRolesExcepto = "WF_ObtenerGrupoDeRolesExcepto";
        public const string WF_ObtenerGrupoDeRoles = "WF_ObtenerGrupoDeRoles";
        public const string WF_ListarLapsosDeTiempo = "WF_ListarLapsosDeTiempo";
        public const string WF_ObtenerModulos = "WF_ObtenerModulos";
        public const string WF_ObtenerTodosModulos = "WF_ObtenerTodosModulos";
        public const string WF_ObtenerPoliticasPorWorkflowId = "WF_ObtenerPoliticasPorWorkflowId";
        public const string WF_JerarquiPoliticaBorrarParejaDeNodos = "WF_JerarquiPoliticaBorrarParejaDeNodos";
        public const string WF_ObtenerReglas = "WF_ObtenerReglas";
        public const string WF_ActualizarReglas = "WF_ActualizarReglas";
        public const string WF_ListarSolicitudWorkflowPorAprobador = "WF_ListarSolicitudWorkflowPorAprobador";
        public const string WF_ReversarWorkFlow = "WF_ReversarWorkFlow";
        public const string WF_ActualizarAprobadorHistorico = "WF_ActualizarAprobadorHistorico";
        public const string WF_VerificarWFViaje = "WF_VerificarWFViaje";
        public const string WF_ObtenerTiposDeDato = "WF_ObtenerTiposDeDato";
        public const string WF_ObtenerTipoDeDatoPorID = "WF_ObtenerTipoDeDatoPorID";
        public const string WF_InsertarWorkflow = "WF_InsertarWorkflow";
        public const string WF_CambiarReferencia = "WF_CambiarReferencia";
        public const string WF_ObtenerWorkflowPorID = "WF_ObtenerWorkflowPorID";
        public const string WF_ObtenerCreador = "WF_ObtenerCreador";
        public const string WF_ActualizarRutaSolicitud = "WF_ActualizarRutaSolicitud";
        public const string WF_InsertarCamino = "WF_InsertarCamino";
        public const string WF_InsertarCaminoNuevo = "WF_InsertarCaminoNuevo";
        public const string WF_BorrarCamino = "WF_BorrarCamino";
        public const string WF_ObtenerDatosRuta = "WF_ObtenerDatosRuta";
        public const string WF_ListarWorkflows = "WF_ListarWorkflows";
        public const string WF_ActualizarHistoricoMismoRolAprobador = "WF_ActualizarHistoricoMismoRolAprobador";
        public const string WF_ObtenerPosicionAprobacion = "WF_ObtenerPosicionAprobacion";
        public const string WF_ActualizarPosicionAprobacion = "WF_ActualizarPosicionAprobacion";
        public const string WF_JerarquiaPoliticaAgregarNodo = "WF_JerarquiaPoliticaAgregarNodo";
        public const string WF_JerarquiaPoliticaActualizarNodo = "WF_JerarquiaPoliticaActualizarNodo";
        public const string WF_JerarquiaPoliticaBorrarNodo = "WF_JerarquiaPoliticaBorrarNodo";
        public const string WF_JerarquiaPoliticaObtenerArbol = "WF_JerarquiaPoliticaObtenerArbol";
        public const string WF_JerarquiaPoliticaObtenerRuta = "WF_JerarquiaPoliticaObtenerRuta";
        public const string WF_JerarquiaPoliticaObtenerHijos = "WF_JerarquiaPoliticaObtenerHijos";
        public const string WF_JerarquiaPoliticaObtenerHijosPorWfID = "WF_JerarquiaPoliticaObtenerHijosPorWfID";
        public const string WF_JerarquiaPoliticaObtenerSubHijos = "WF_JerarquiaPoliticaObtenerSubHijos";
        public const string WF_JerarquiaPoliticaObtenerTitulo = "WF_JerarquiaPoliticaObtenerTitulo";
        public const string WF_ObtenerCaminosPorNodo = "WF_ObtenerCaminosPorNodo";
        public const string WF_ObtenerCaminosConRoles = "WF_ObtenerCaminosConRoles";
        public const string WF_ObtenerCaminos = "WF_ObtenerCaminos";
        public const string WF_ListarSolicitudWorkflow = "WF_ListarSolicitudWorkflow";
        public const string WF_ListarHistoricoWorkflow = "WF_ListarHistoricoWorkflow";
        public const string WF_ListaAprobacion = "WF_ListaAprobacion";
        public const string WF_ConsultarAprobadorWorkflow = "WF_ConsultarAprobadorWorkflow";
        public const string WF_ConsultarAprobadorActual = "WF_ConsultarAprobadorActual";
        //-
        public const string WF_ObtenerSocioLiderCodigo = "WF_ObtenerSocioLiderCodigo"; //ES//
        public const string WF_ObtenerSocioPrincipalCodigo = "WF_ObtenerSocioPrincipalCodigo"; //ES//
        public const string WF_ObtenerAyuda = "WF_ObtenerAyuda"; //ES//
        public const string WF_ObtenerMensaje = "WF_ObtenerMensaje"; //ES//
        public const string WF_InsertarPagos = "WF_InsertarPagos";
        public const string WF_InsertarPedidos = "WF_InsertarPedidos";
        public const string WF_LlenarGridBandeja = "WF_LlenarGridBandeja";
        public const string WF_ActualizarUltimaAprobacionPedido = "WF_ActualizarUltimaAprobacionPedido";
        public const string WF_ActualizarUltimaAprobacionPago = "WF_ActualizarUltimaAprobacionPago";
        public const string WF_ObtenerPedidos = "WF_ObtenerPedidos";
        public const string WF_ObtenerPagos = "WF_ObtenerPagos";
        public const string WF_ListarMotivosRechazo = "WF_ListarMotivosRechazo";

        #region (stored procedures)

        //- ESEmpleado
        public const string ES_BuscarEmpleados = "ES_BuscarEmpleados";
        public const string ES_BuscarCoordinadorLoS = "ES_BuscarCoordinadorLoS";
        public const string ES_BuscarEmpleadosExtenso = "ES_BuscarEmpleadosExtenso";
        public const string ES_BuscarEmpleadosExtensoWF = "ES_BuscarEmpleadosExtensoWF";
        public const string ES_BuscarEmpleados_NivelGerencial = "ES_BuscarEmpleados_NivelGerencial";
        public const string ES_BuscarEmpleadosxParametros = "ES_BuscarEmpleadosxParametros";
        public const string ES_BuscarEmpleadoEspecifico = "ES_BuscarEmpleadoEspecifico";
        public const string ES_ListarEmpleado = "ES_ListarEmpleado";
        public const string ES_BuscarRespCobranza = "ES_BuscarRespCobranza";
        public const string ES_ListaEmpleadoOficina1 = "ES_ListaEmpleadoOficina1";
        public const string ES_ListarEmpleados = "ES_ListarEmpleados";
        public const string ES_ListarGerentes = "ES_ListarGerentes";
        public const string ES_ListadoGerentesPresupuesto = "ES_ListadoGerentesPresupuesto";
        public const string ES_ListarGerenteSupervisor = "ES_ListarGerenteSupervisor";
        public const string ES_ListadoSociosGerentes = "ES_ListadoSociosGerentes";
        public const string ES_ListadoSociosPresupuesto = "ES_ListadoSociosPresupuesto";
        public const string ES_ListadoSociosPstosxOficina = "ES_ListadoSociosPstosxOficina";
        public const string ES_ListarSociosProyecto = "ES_ListarSociosProyecto";
        public const string ES_ListarSociosCombo = "ES_ListarSociosCombo";
        public const string ES_ListarGerentesCombo = "ES_ListarGerentesCombo";
        public const string ES_BuscarEmpleados_CoordinadorRH = "ES_BuscarEmpleados_CoordinadorRH";
        public const string ES_CargarEncargadosDeProyecto = "ES_CargarEncargadosDeProyecto";
        public const string ES_BuscarEmpleadoHistorico = "ES_BuscarEmpleadoHistorico";   
     
        //- ESUsuario
        public const string ES_Login = "ES_Login";
        public const string ES_LoginUsuario = "ES_LoginUsuario";
        public const string ES_LoginCodigo = "ES_LoginCodigo";
        public const string ES_CambiarPassword = "ES_CambiarPassword";
        public const string ES_ConsultaUsuario = "ES_ConsultaUsuario";
        public const string ES_ListarUsuarios = "ES_ListarUsuarios";
        public const string ES_ListarUsuariosIniciales = "ES_ListarUsuariosIniciales";
        public const string ES_VerificarUsuario = "ES_VerificarUsuario";
        public const string ES_CargarUsuario = "ES_CargarUsuario";
        public const string ES_InsertarUsuario = "ES_InsertarUsuario";
        public const string ES_ActualizarUsuario = "ES_ActualizarUsuario";
        public const string ES_VerificarGeneracion = "ES_VerificarGeneracion";
        public const string ES_VerificarCaducidad = "ES_VerificarCaducidad";

        //- ESLog
        public const string ES_ListarTipoLog = "ES_ListarTipoLog";
        public const string ES_ListarTipoTransaccion = "ES_ListarTipoTransaccion";
        public const string ES_InsertarLog = "ES_InsertarLog";
        public const string ES_ListarLog = "ES_ListarLog";

        //- ESSeguridad
        public const string ES_VerificarAcceso = "ES_VerificarAcceso";
        public const string ES_VerificarGeneracionConexion = "ES_VerificarGeneracionConexion";
        public const string ES_VerificarCaducidadConexion = "ES_VerificarCaducidadConexion";
        public const string ES_VerificarDiasDeVigencia = "ES_VerificarDiasDeVigencia";
        public const string ES_CambiarContrasenaConexion = "ES_CambiarContrasenaConexion";
        public const string ES_CambiarContrasenaSA = "ES_CambiarContrasenaSA";

        //- ESRol
        public const string ES_ListarGrupoRoles = "ES_ListarGrupoRoles";
        public const string ES_InsertarRol = "ES_InsertarRol";
        public const string ES_ActualizarRol = "ES_ActualizarRol";
        public const string ES_ListarRoles = "ES_ListarRoles";
        public const string ES_ListarRolesSinAcceso = "ES_ListarRolesSinAcceso";
        public const string ES_ListarRolesAsignados = "ES_ListarRolesAsignados";
        public const string ES_ListarRolesNoAsignados = "ES_ListarRolesNoAsignados";
        public const string ES_ListarRolesAsignadosGrupo = "ES_ListarRolesAsignadosGrupo";
        public const string ES_ListarRolesNoAsignadosGrupo = "ES_ListarRolesNoAsignadosGrupo";
        public const string ES_ListarRolesAsignadosCategoria = "ES_ListarRolesAsignadosCategoria";
        public const string ES_ListarRolesNoAsignadosCategoria = "ES_ListarRolesNoAsignadosCategoria";
        public const string ES_ObtenerAdministradorPresupuesto = "ES_ObtenerAdministradorPresupuesto";
        public const string ES_ObtenerSocioAsignaciones = "ES_ObtenerSocioAsignaciones";
        public const string ES_ObtenerSocioPlanificacion = "ES_ObtenerSocioPlanificacion";
        public const string ES_ObtenerLiderLoS = "ES_ObtenerLiderLoS";
        public const string ES_ObtenerLiderLoSCCS = "ES_ObtenerLiderLoSCCS";
        public const string ES_VerificarrSocioLiderLoS = "ES_VerificarrSocioLiderLoS";
        public const string ES_ObtenerGerenteEncargado = "ES_ObtenerGerenteEncargado";
        public const string ES_ObtenerSecretaria = "ES_ObtenerSecretaria";
        public const string ES_ObtenerSocioEncargado = "ES_ObtenerSocioEncargado";
        public const string ES_ObtenerCoordinadorLoS = "ES_ObtenerCoordinadorLoS";
        public const string ES_ObtenerSocioPrincipal = "ES_ObtenerSocioPrincipal";
        public const string ES_AsignarRol = "ES_AsignarRol";
        public const string ES_AsignarRolGrupo = "ES_AsignarRolGrupo";
        public const string ES_EliminarRol = "ES_EliminarRol";
        public const string ES_AsignarRolCategoria = "ES_AsignarRolCategoria";
        public const string ES_EliminarRolCategoria = "ES_EliminarRolCategoria";
        public const string ES_EliminarRolGrupo = "ES_EliminarRolGrupo";
        public const string ES_AsignarAcceso = "ES_AsignarAcceso";
        public const string ES_EliminarAcceso = "ES_EliminarAcceso";
        public const string ES_ObtenerCodigoAcceso = "ES_ObtenerCodigoAcceso";
        public const string ES_ObtenerEmpleadoRol = "ES_ObtenerEmpleadoRol";
        public const string ES_VerificarRolEspecifico = "ES_VerificarRolEspecifico";
        public const string ES_ObtenerEmpleadoRolEspecifico = "ES_ObtenerEmpleadoRolEspecifico";

        #endregion

        public const string WF_ObtenerTransaccion = "WF_ObtenerTransaccion";
        public const string WF_InsertarTransaccion = "WF_InsertarTransaccion";
        public const string WF_ActualizarUltimaAprobacionTrans = "WF_ActualizarUltimaAprobacionTrans";
    }
}