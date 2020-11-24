<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AsistenteConfig.ascx.cs" Inherits="Workflow.AsistenteConfig" %>
<%@ Register TagPrefix="jlc" Namespace="JLovell.WebControls"   Assembly="StaticPostBackPosition" %>
<%@ Register TagPrefix="ie" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>

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
</style>

<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
	<TR>
		<TD style="HEIGHT: 10px" vAlign="top" colSpan="2">
		<%--<uc1:banner id="Banner1" runat="server"></uc1:banner>--%>
		</TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center" bgColor="#ffffff" style="HEIGHT: 395px">
			<TABLE class="TablaNormal" id="Table1" style="HEIGHT: 196px" cellSpacing="0" cellPadding="0"
				border="0" width="100%" align="left">
				<TR height="8">
					<td style="WIDTH: 8px"></td>
					<TD colSpan="2"></TD>
					<td style="WIDTH: 8px"></td>
				</TR>
				<TR height="20">
					<td style="WIDTH: 8px; HEIGHT: 20px" ></td>
					<TD style="WIDTH: 459px; HEIGHT: 20px" vAlign="middle" ><asp:label id="lblTitulo" runat="server" Width="408px" CssClass="NormalL">Workflow > Asistente de Configuración</asp:label></TD>
					<TD style="HEIGHT: 20px" vAlign="middle" align="right" >
					<%--<uc1:navegacion id="Navegacion1" runat="server"></uc1:navegacion>--%>
					</TD>
					<td style="WIDTH: 8px; HEIGHT: 20px" ></td>
				</TR>
				<TR>
					<td style="WIDTH: 8px; HEIGHT: 11px"></td>
					<TD style="HEIGHT: 11px" colSpan="2"></TD>
					<td style="WIDTH: 8px; HEIGHT: 11px"></td>
				</TR>
				<TR>
					<td style="WIDTH: 13px"></td>
					<TD vAlign="top" colSpan="2">
						<P>
							<asp:Label id="lblTituloArbol" runat="server" CssClass="EtiquetaNormal"></asp:Label></P>
						<ie:treeview id="tvWorkflow" runat="server" Visible="False" SystemImagesPath="/Spin/ES/Imagenes/treeimages/">
							<ie:TreeNode Text="Árbol de Políticas" Expandable="CheckOnce" Expanded="True" ImageUrl="/Spin/ES/Imagenes/root.gif"></ie:TreeNode>
						</ie:treeview>
                        <asp:TreeView ID="wfTreeView" ShowLines="true"  runat="server">
                        </asp:TreeView>
						<P>&nbsp;</P>
					</TD>
					<TD style="WIDTH: 13px"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD align="right" bgColor="#ffffff">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="8"></TD>
					<TD align="right">&nbsp;
						<asp:Button id="btnSalir" runat="server" CssClass="BotonNormal" Text="Salir" 
                            onclick="btnSalir_Click"></asp:Button></TD>
					<TD width="8"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR height="8">
		<TD bgColor="#ffffff"></TD>
	</TR>
	<TR>
		<TD class="ValidadorSumarioNormal" align="center" height="1">
			<TABLE class="TablaNormalEspecial" id="Table3" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TR>
					<td width="8"></td>
					<TD><asp:validationsummary id="vsmErrores" runat="server" Width="784px" CssClass="ValidadorSumarioNormal" DisplayMode="List"></asp:validationsummary><asp:label id="lblError" runat="server" CssClass="ValidadorSumarioNormal"></asp:label></TD>
					<td width="8"></td>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD align="right" bgColor="#5375a4" height="1">
			<TABLE class="TablaNormal" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td width="8"></td>
					<TD style="WIDTH: 422px"><font color="#ccccff">ESWFP001B</font>
					</TD>
					<TD align="right"><font color="#ccccff">Información restringida - Clasificación DC2</font></FONT></TD>
					<td width="8"></td>
				</TR>
			</TABLE>
			<jlc:StaticPostBackPosition id="StaticPostBackPosition1" runat="server"></jlc:StaticPostBackPosition>
		</TD>
	</TR>
</TABLE>
