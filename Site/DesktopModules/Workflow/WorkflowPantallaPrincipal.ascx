<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WorkflowPantallaPrincipal.ascx.cs" Inherits="Workflow.WorkflowPantallaPrincipal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<style type="text/css">
    
    .Gridview_cabecera
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: 11px;
        font-weight: normal;
        font-weight: bold;
        text-align: center;
        color: Green;
        line-height: 12px;
    }
    .Gridview_cuerpo
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: 10px;
        font-weight: normal;
        text-align: center;
        line-height: 12px;
    }
    .Detailsview_cabecera
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: 12px;
        font-weight: normal;
        text-align: center;
        vertical-align: middle;
    }
    .Detailsview_cuerpo
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: 9px;
        font-weight: normal;
        text-align: left;
        line-height: 12px;
    }
    .modalBackground
    {
        background-color: Gray;
        filter: alpha(opacity=70);
        opacity: 0.7;
    }
    .modalPopup
    {
        background-color: #FFF;
        border: solid 3px #333;
        padding: 3px;
        position: relative;
    }
    .buttons
    {
        display: block;
        float: left;
        margin: 0 7px 0 0;
        background-color: #f5f5f5;
        border: 1px solid #dedede;
        border-top: 1px solid #eee;
        border-left: 1px solid #eee;
        font-family: Helvetica, Verdana, sans-serif;
        font-size: 70%;
        line-height: 70%;
        text-decoration: none;
        font-weight: bold;
        color: #565656;
        cursor: pointer;
        padding: 5px 10px 6px 7px;
        text-align: center;
        color: Gray;
    }
    .style1
    {
        width: 200px;
        height: 23px;
    }
    .style2
    {
        width: 153px;
        height: 23px;
    }
    .style6
    {
        width: 216px;
    }
    .active
    {
        font-size: 16px;
        margin-left: 10px;
        text-decoration: none;
        font-family: Verdana, Helvetica, sans-serif;
    }
    .active1
    {
        font-size: 14px;
        margin-left: 10px;
        text-decoration: underline;
        cursor: auto;
        font-family: Verdana, Helvetica, sans-serif;
    }
    .active2
    {
        font-size: 11px;
        margin-left: 10px;
        text-decoration: underline;
        cursor: auto;
        font-family: Verdana, Helvetica, sans-serif;
    }
    .style12
    {
        width: 254px;
        height: 23px;
    }
    
</style>

<script type="text/javascript">

    function Cancelar() {
        //debugger;
        var vHfSource = $get('<%= this.hfSource.ClientID %>')
        var vBtnAprobar = document.getElementsByName("BtnAprobarId")
        var vBtnRechazar = document.getElementsByName("BtnRechazarId")
        var vBtnCancelar = document.getElementsByName("BtnCancelarId")
        var vBtnEnviar = document.getElementsByName("BtnEnviarId")

        if (vHfSource.value == "0") {
            vBtnAprobar[0].style.display = "none";
            vBtnRechazar[0].style.display = "none";
            vBtnCancelar[0].style.display = "block";
            vBtnEnviar[0].style.display = "block";
        }
        else if (vHfSource.value == "1") {
            vBtnAprobar[0].style.display = "block";
            vBtnRechazar[0].style.display = "block";
            vBtnCancelar[0].style.display = "block";
            vBtnEnviar[0].style.display = "none";
        }
    }

    function Aceptar() {
        //debugger;
    }
    
</script>

<asp:HiddenField ID="hfIdCuenta" runat="server" />
<asp:HiddenField ID="hfIdCliente" runat="server" />
<asp:HiddenField ID="hfIdDia" runat="server" />
<asp:HiddenField ID="hfPH" runat="server" />
<asp:HiddenField ID="hfSource" runat="server" />
<asp:HiddenField ID="hfIdUser" runat="server" />
<asp:HiddenField ID="hfOpcion" runat="server" />
<asp:HiddenField ID="hfRefId" runat="server" />
<asp:HiddenField ID="hfCancelar" runat="server" />
<asp:HiddenField ID="hfDataKey" runat="server" />
<asp:HiddenField ID="hfIdCreador" runat="server" />

<table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
    <tr valign="top">
        <td class="SubHead" width="170px">
            <table cellspacing="0" cellpadding="0" border="0" style="width: 170px">
                <tr>
                    <td>
                        <asp:LinkButton ID="LkBtnBE" Text="Bandeja de entrada" Font-Underline="false" CssClass="active1"
                            OnClick="LinkBtnBE_Click" runat="server"></asp:LinkButton>
                    <hr /></td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LkBtnAprobado" Text="Aprobado" OnClick="LinkBtnAprobados_Click"
                            Font-Underline="false" CssClass="active1" runat="server"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LkBtnRechazado" Text="Rechazado" OnClick="LinkBtnRechazado_Click"
                            Font-Underline="false" CssClass="active1" runat="server"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LkBtnPendiente" Text="Pendiente" OnClick="LinkBtnPendientes_Click"
                            Font-Underline="false" CssClass="active1" runat="server"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LkBtncorregir" Text="Por corregir" OnClick="LinkBtnPorCorregir_Click"
                            Font-Underline="false" CssClass="active1" runat="server"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LkBtnPausados" Text="Pausados" OnClick="LinkBtnPausados_Click"
                            Font-Underline="false" CssClass="active1" runat="server"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="LkBtnCancelados" Text="Cancelados" OnClick="LinkBtnCancelados_Click"
                            Font-Underline="false" CssClass="active1" runat="server"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </td>
        <td class="style6">
            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                <tr align="left">
                    <td>
                        <table cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td class="style2" align="center">
                                    <asp:Label ID="LinkButton1" Text="Nuevo:" runat="server"></asp:Label>
                                </td>
                                <td class="style2" align="center">
                                    <asp:DropDownList ID="DropDownList1" runat="server" Style="margin-left: 0px" Width="150px"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlPH_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="[Elegir]"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Formulario de Pagos"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Formulario de Pedidos"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Pedidos de Sublimacion"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style1" align="center">
                                    <asp:LinkButton ID="LinkButton2" Text="Eliminar" CssClass="active2" runat="server"></asp:LinkButton>
                                </td>
                                <td class="style12" align="left" style="width: 500px">
                                    <asp:LinkButton ID="LinkButton9" Text="Configuracion del Workflow" CssClass="active2"
                                        OnClick="LinkBtnConf_Click" Width="200px" runat="server"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table>
                <tr valign="top">
                    <td>
                        <asp:PlaceHolder ID="PlaceholderWF" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp; &nbsp; &nbsp;
                        <table>
                            <tr>
                                <td align="center" id="BtnAprobarId">
                                    <asp:Button ID="BtnAprobar" runat="server" Visible="false" Text="Aprobar" OnClick="BtnAprobar_Click"
                                        Width="141px"></asp:Button>
                                </td>
                                <td align="center" id="BtnEnviarId">
                                    <asp:Button ID="BtnEnviar" runat="server" Visible="false" Text="Salvar y Enviar" OnClick="BtnEnviar_Click"
                                        Width="141px"></asp:Button>
                                </td>
                                <td align="center" id="BtnRechazarId">
                                    <asp:Button ID="BtnRechazar" runat="server" Visible="false" Text="Rechazar" OnClick="BtnRechazar_Click"
                                        Width="141px"></asp:Button>
                                </td>
                                <td align="center" id="BtnSalvarId">
                                    <asp:Button ID="BtnSalvar" runat="server" Visible="false" Text="Salvar" OnClick="BtnSalvar_Click"
                                        Width="141px"></asp:Button>
                                </td>
                                <td align="center" id="BtnCancelarId">
                                    <asp:Button ID="BtnCancelar" runat="server" Visible="false" Text="Cancelar" OnClick="BtnCancelar_Click"
                                        Width="141px"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
    
<asp:Panel ID="Panel1" runat="server" Height="220px" Width="630px" CssClass="modalPopup"
    Style="display: none">
    <asp:Panel ID="Panel3" runat="server" Height="30" Style="cursor: move;">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </asp:Panel>
    <table class="TablaNormalEspecial" id="Table3" style="z-index: 101; left: 16px; width: 700px;
        position: absolute; top: 8px" cellspacing="0" cellpadding="0" width="584" border="0">
        <asp:Panel ID="pnlAprobar" runat="server">
            <tbody>
                <tr align="left">
                    <td style="height: 31px" width="180px">                        
                        <asp:Label ID="lblSiguienteAprobador" runat="server" Text="Siguiente aprobador:"></asp:Label>
                    </td>
                    <td style="height: 31px">
                        <asp:DropDownList ID="ddlAprobado" runat="server" CssClass="ComboNormal" Width="300px">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:ImageButton ID="ibtnAprobador" runat="server" Visible="false" ImageUrl="../Imagenes/Buscar.gif"
                            CausesValidation="False"></asp:ImageButton>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvAprobado" runat="server" CssClass="ValidadorNormal"
                            ErrorMessage="Aprobado" InitialValue="0" ControlToValidate="ddlAprobado" Enabled="False">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </tbody>
        </asp:Panel>
        <asp:Panel ID="pnlRechazar" runat="server">
            <tbody>
                <tr align="left">
                    <td style="height: 31px" width="180px">
                        <asp:Label ID="lblRechazo" runat="server">Tipo del Rechazo:</asp:Label>
                    </td>
                    <td style="height: 31px">
                        <asp:DropDownList ID="ddlRechazo" runat="server" CssClass="ComboNormal" Width="300px">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="rfvRechazo" runat="server" CssClass="ValidadorNormal"
                            ErrorMessage="Aprobado" InitialValue="0" ControlToValidate="ddlRechazo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
            </tbody>
        </asp:Panel>
        <tr>
            <td height="8">
            </td>
            <td>
            </td>
        </tr>
        <tr align="left">
            <td style="height: 31px" valign="top" width="180px">
                <asp:Label ID="lblObservaciones" runat="server">Observaciones:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextoNormal" Width="408px"
                    MaxLength="1000" Height="76px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="8">
            </td>
            <td>
            </td>
        </tr>
        <tr align="left">
            <td style="height: 31px" width="134">
            </td>
            <td style="height: 31px">
                <asp:Button ID="bttnAceptar" OnClick="bttnAceptar_Click" runat="server" CssClass="BotonNormal"
                    Text="Aceptar" OnClientClick="Aceptar()"></asp:Button><asp:Button ID="bttnCancelar"
                        runat="server" CssClass="BotonNormal" Text="Cancelar" OnClick="bttnCancelar_Click"
                        OnClientClick="Cancelar()"></asp:Button>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
            <td style="height: 10px">
            </td>
        </tr>
    </table>
</asp:Panel>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1"
    TargetControlID="BtnShowPopup" DropShadow="true" BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="Panel3" 
    RepositionMode="RepositionOnWindowResizeAndScroll">
</ajaxToolkit:ModalPopupExtender>

<asp:Button ID="BtnShowPopup" runat="server" Style="display: none" />

 

