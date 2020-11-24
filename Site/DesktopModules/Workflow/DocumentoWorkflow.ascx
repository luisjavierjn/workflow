<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DocumentoWorkflow.ascx.cs" Inherits="Workflow.Controles.DocumentoWorkflow" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%--<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>--%>
<LINK href="estilos.css" type="text/css" rel="stylesheet">
<%--<fieldset><legend class="EtiquetaNormal">Documento</legend>--%>


<style type="text/css">
    .Gridview
    {
        text-align: center;
    }
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
        font-size: 11px;
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
        top: 0px;
        left: 0px;
    }
     .buttons
     {
            display:block;
            float:left;
            margin:0 7px 0 0;
            background-color:#f5f5f5;
            border:1px solid #dedede;
            border-top:1px solid #eee;
            border-left:1px solid #eee;   
            font-family:Helvetica, Verdana, sans-serif;
            font-size:100%;
            line-height:130%;
            text-decoration:none;
            font-weight:bold;
            color:#565656;
            cursor:pointer;
            padding:5px 10px 6px 7px; 
            text-align:center;
            color:Gray;
        }
          .Normal
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: 11px;
        font-weight: normal;
        text-align:center;
        line-height: 12px    
    }   
    .NormalL
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: 15px;
        font-weight: normal;
        line-height: 12px    
    }
    #listItem {
	font:12px Arial, Helvetica, sans-serif;
	width:200px;
	background-color:#FFF;
	border:1px solid #DDD;
	}
#listItem optgroup option	{
	padding:3px 0px 3px 15px;
	border-bottom-width:1px;
	border-bottom-style:solid;
	}
#listItem optgroup.galerias {
	background-color:#e6e6c2;
	color: #919245;
	}
#listItem optgroup.correo	{
	background-color:#c2e1e6;
	color:#336699;
	}
#listItem optgroup.galerias	{
	border-bottom-color:#8e8e83;
	}

</style>

<script type="text/javascript">
    function DocumentoWF() {
        //debugger
        var hfDocumento = $get('<%= this.hfDocumento.ClientID %>');
        var hfddlDocmt = $get('<%= this.ddlDocumento.ClientID %>');
        hfDocumento.value = hfddlDocmt.selectedIndex;
    }
</script>
<asp:HiddenField ID="hfddlDocmt" runat="server" />    
<asp:HiddenField ID="hfDocumento" runat="server" />
	<table class="TextoNormal" id="Table1" style="WIDTH: 368px; HEIGHT: 168px" cellPadding="5" width="368">
		<tr>
			<td><asp:label id="Label1" runat="server" CssClass="EtiquetaNormal" ToolTip="Lista los módulos de SPIN que requieren de un Flujo de Trabajo">Modulo de Trabajo</asp:label></td>
		</tr>
		<TR>
			<TD style="HEIGHT: 23px"><asp:dropdownlist id="ddlModulo" AutoPostBack="True" runat="server" CssClass="#listItem optgroup option" Width="250px" OnSelectedIndexChanged="ddlModulo_SelectedIndexChanged"></asp:dropdownlist>&nbsp;</TD>
		</TR>
		<tr>
			<td><asp:label id="Label2" runat="server" CssClass="EtiquetaNormal" ToolTip="Lista los distintos documentos que son manejados por un determinado Módulo de Trabajo">Tipo de Documento</asp:label></td>
		</tr>
		<tr>
			<td><asp:dropdownlist id="ddlDocumento" AutoPostBack="True" runat="server" CssClass="#listItem optgroup option" Width="250px" OnSelectedIndexChanged="ddlDocumento_SelectedIndexChanged" onchange="javascript:DocumentoWF()"></asp:dropdownlist></td>
		</tr>
		<tr>
			<td><asp:label id="Label3" runat="server" ToolTip="Muestra las principales características del Flujo de Trabajo relacionadas con el documento">Descripcion del Workflow</asp:label></td>
		</tr>
		<tr>
			<td><asp:textbox id="txtDescription" runat="Server" CssClass="TextoCajaNormal" Width="352px" TextMode="MultiLine"
					Rows="3" Columns="40" ReadOnly="True"></asp:textbox></td>
		</tr>
	</table>
<%--</fieldset>--%>
