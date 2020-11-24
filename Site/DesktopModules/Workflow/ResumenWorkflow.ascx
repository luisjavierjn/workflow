<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResumenWorkflow.ascx.cs" Inherits="Workflow.Controles.ResumenWorkflow" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<LINK href="estilos.css" type="text/css" rel="stylesheet">
<FIELDSET><LEGEND class="EtiquetaNormal">Rutas</LEGEND>
	<TABLE id="Table1" cellPadding="5" width="504" class="TextoNormal" style="WIDTH: 504px; HEIGHT: 162px">
		<TR>
			<TD>Agregue los niveles de aprobación en la política escogida.
			</TD>
		</TR>
		<TR>
			<TD>
				<asp:Label id="lblNodo" runat="server"></asp:Label>
				<TABLE id="Table2" class="TextoNormal" style="WIDTH: 488px; HEIGHT: 94px">
					<TR>
						<TD>Todos los Niveles</TD>
						<TD>&nbsp;</TD>
						<TD>Niveles Escogidos</TD>
					</TR>
					<TR>
						<TD>
							<asp:ListBox id="lstNiveles" Runat="Server" Width="250px" CssClass="TextoCajaNormal" Height="90px"></asp:ListBox></TD>
						<TD>
							<asp:Button id="btnAdd" style="FONT: 9pt Courier" Runat="server" Text="->"></asp:Button><BR>
							<asp:Button id="btnDel" style="FONT: 9pt Courier" Runat="server" Text="<-"></asp:Button></TD>
						<TD>
							<asp:ListBox id="lstEscogencia" Runat="Server" Width="250px" CssClass="TextoCajaNormal" Height="90px"></asp:ListBox></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</FIELDSET>
