<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IntroNuevoWorkflow.ascx.cs" Inherits="Workflow.Controles.IntroNuevoWorkflow" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<link href="estilos.css" type="text/css" rel="stylesheet">
<fieldset>
	<legend class="EtiquetaNormal">
		</legend>
	<table cellpadding="10" class="EtiquetaNormal">
		<tr>
			<td>
				Esta herramienta&nbsp;le guiara a traves de pasos muy sencillos en 
				la&nbsp;creacion de&nbsp;una nueva&nbsp;configuracion de Workflow.
				<br>
				<br>
				<asp:CheckBox id="chkSkip" Text="Saltar la proxima vez" Runat="Server" />
			</td>
		</tr>
	</table>
</fieldset>
