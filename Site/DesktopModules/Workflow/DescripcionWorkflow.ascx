<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DescripcionWorkflow.ascx.cs" Inherits="Workflow.Controles.DescripcionWorkflow" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

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
#listItemoptgroup.option	{
	padding:3px 0px 3px 15px;
	border-bottom-width:1px;
	border-bottom-style:solid;
	}
#listItemoptgroup.galerias {
	background-color:#e6e6c2;
	color: #919245;
	}
#listItemoptgroup.correo	{
	background-color:#c2e1e6;
	color:#336699;
	}
#listItemoptgroup.galerias	{
	border-bottom-color:#8e8e83;
	}

</style>

<LINK href="estilos.css" type="text/css" rel="stylesheet">
<fieldset>
	<P><legend class="EtiquetaNormal">Reglas</legend></P>
	<P class="TextoNormal" style="WIDTH: 280px; HEIGHT: 28px">&nbsp; Configuracion de 
		reglas&nbsp;para el Worflow.</P>
	<table class="TextoNormal" style="WIDTH: 504px; HEIGHT: 159px" cellPadding="5" width="504">
		<tr>
			<td style="WIDTH: 324px">Intervalo de&nbsp;espera para la recepcion de una nueva 
				notificacion de aprobacion:
			</td>
			<TD>&nbsp;&nbsp;
				<asp:textbox id="txtIntervAprob" CssClass="TextoNormal" runat="Server" Columns="30" Width="50px"></asp:textbox>&nbsp;<asp:dropdownlist id="ddlNotificacion" CssClass="#listItemoptgroup.option" runat="server"></asp:dropdownlist>
				<asp:RequiredFieldValidator id="rfvAprobacion" runat="server" ErrorMessage="*" ControlToValidate="txtIntervAprob"></asp:RequiredFieldValidator>
				<asp:RangeValidator id="rvAprobacion" runat="server" ErrorMessage="*" ControlToValidate="txtIntervAprob"
					MinimumValue="1" MaximumValue="9999999"></asp:RangeValidator></TD>
		</tr>
		<tr>
			<td style="WIDTH: 324px">Intervalo de espera para la recepcion de una nueva 
				notificacion de correccion:
			</td>
			<TD>&nbsp;&nbsp;
				<asp:textbox id="txtIntervCorrec" CssClass="TextoNormal" runat="server" Columns="30" Width="50px"></asp:textbox>&nbsp;<asp:dropdownlist id="ddlCorreccion" CssClass="#listItemoptgroup.option" runat="server"></asp:dropdownlist>
				<asp:RequiredFieldValidator id="rfvCorreccion" runat="server" ErrorMessage="*" ControlToValidate="txtIntervCorrec"></asp:RequiredFieldValidator>
				<asp:RangeValidator id="rvCorreccion" runat="server" ErrorMessage="*" ControlToValidate="txtIntervCorrec"
					MinimumValue="1" MaximumValue="9999999"></asp:RangeValidator></TD>
		</tr>
		<tr>
			<td style="WIDTH: 324px">Numero de recordatorios de notificacion de aprobacion:
			</td>
			<TD>&nbsp;&nbsp;
				<asp:textbox id="txtNumRecor" CssClass="TextoNormal" runat="server" Columns="30" Width="50px"></asp:textbox>
				<asp:RequiredFieldValidator id="rfvRocordatorios" runat="server" ErrorMessage="*" ControlToValidate="txtNumRecor"></asp:RequiredFieldValidator>
				<asp:RangeValidator id="rvRecordatorios" runat="server" ErrorMessage="*" ControlToValidate="txtNumRecor"
					MinimumValue="1" MaximumValue="9999999"></asp:RangeValidator></TD>
		</tr>
	</table>
</fieldset>
