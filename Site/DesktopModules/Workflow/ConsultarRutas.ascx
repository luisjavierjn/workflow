<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ConsultarRutas.ascx.cs" Inherits="Workflow.ConsultarRutas" %>
<%@ Register TagPrefix="jlc" Namespace="JLovell.WebControls" Assembly="StaticPostBackPosition" %>

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

<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
	height="100%">
	<TR>
		<TD style="HEIGHT: 10px" vAlign="top">
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
					<td style="WIDTH: 8px; HEIGHT: 20px" bgColor="#ffffff"></td>
					<TD style="WIDTH: 459px; HEIGHT: 20px" vAlign="middle" bgColor="#ffffff"><asp:label id="lblTitulo" runat="server" Width="256px" CssClass="EtiquetaTitulo">Workflow > Consultar rutas para aprobacion</asp:label></TD>
					<TD style="HEIGHT: 20px" vAlign="middle" align="right" bgColor="#ffffff">
					<%--<uc1:navegacion id="Navegacion1" runat="server"></uc1:navegacion>--%>
					</TD>
					<td style="WIDTH: 8px; HEIGHT: 20px" bgColor="#ffffff"></td>
				</TR>
				<TR>
					<td style="WIDTH: 8px; HEIGHT: 11px"></td>
					<TD style="HEIGHT: 11px" colSpan="2"></TD>
					<td style="WIDTH: 8px; HEIGHT: 11px"></td>
				</TR>
				<TR>
					<td style="WIDTH: 13px"></td>
					<TD vAlign="top" colSpan="2">
						<TABLE id="tblDatos" style="WIDTH: 542px" cellSpacing="0" cellPadding="1" width="542" border="0">
							<TR>
								<TD style="WIDTH: 154px">
									<asp:label id="lblModulo" runat="server" CssClass="EtiquetaNormal" Width="144px">Modulo de trabajo:</asp:label></TD>
								<TD style="WIDTH: 414px">
									<asp:dropdownlist id="ddlModulo" runat="server" CssClass="#listItem" Width="300px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 87px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 154px">
									<asp:label id="lblTipoDocumento" runat="server" CssClass="EtiquetaNormal">Tipo de documento:</asp:label></TD>
								<TD style="WIDTH: 414px">
									<asp:dropdownlist id="ddlTipoDocumento" runat="server" CssClass="#listItem" Width="300px" AutoPostBack="True"></asp:dropdownlist>&nbsp;
									<asp:requiredfieldvalidator id="rfvTipoDocumento" runat="server" ControlToValidate="ddlTipoDocumento" InitialValue="0">*</asp:requiredfieldvalidator></TD>
								<TD style="WIDTH: 87px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 154px; HEIGHT: 20px">
									<asp:label id="lblWorkFlow" runat="server" CssClass="EtiquetaNormal" Width="144px">Descripcion del Workflow:</asp:label></TD>
								<TD style="WIDTH: 414px; HEIGHT: 20px">
									<asp:textbox id="txtDescripcion" runat="Server" CssClass="TextoBloqueado" Width="300px" ReadOnly="True"
										TextMode="MultiLine" Columns="40" Height="70px"></asp:textbox></TD>
								<TD style="WIDTH: 87px; HEIGHT: 20px"></TD>
							</TR>
						</TABLE>
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
					<TD align="right">
						<asp:Button id="btnConsultar" runat="server" CssClass="BotonNormal" Text="Consultar"></asp:Button>
					</TD>
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
					<TD style="WIDTH: 422px"><font color="#ccccff">ESWFP003A</font>
					</TD>
					<TD align="right"><font color="#ccccff">Informacion restringida - Clasificaci&oacute;n DC2</font></FONT></TD>
					<td width="8"></td>
				</TR>
			</TABLE>
			<jlc:StaticPostBackPosition id="StaticPostBackPosition1" runat="server"></jlc:StaticPostBackPosition>
		</TD>
	</TR>
</TABLE>
