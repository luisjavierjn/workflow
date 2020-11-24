<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReversoAprobacion.ascx.cs" Inherits="Workflow.ReversoAprobacion" %>
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
<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" height="100%" cellSpacing="0"
	cellPadding="0" width="100%" border="0">
	<TR>
		<TD style="HEIGHT: 10px" vAlign="top" colSpan="2">
		<%--<uc1:banner id="Banner1" runat="server"></uc1:banner>--%>
		</TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center" bgColor="#ffffff">
			<TABLE class="TablaNormal" id="Table1" style="HEIGHT: 196px" cellSpacing="0" cellPadding="0"
				width="100%" align="left" border="0">
				<TR height="8">
					<td style="WIDTH: 8px"></td>
					<TD colSpan="2"></TD>
					<td style="WIDTH: 8px"></td>
				</TR>
				<TR height="20">
					<td style="WIDTH: 8px; HEIGHT: 24px" bgColor="#ffffff"></td>
					<TD style="WIDTH: 459px; HEIGHT: 24px" vAlign="middle" bgColor="#ffffff"><asp:label id="lblTitulo" runat="server" Height="8px" CssClass="EtiquetaTitulo" Width="333px">Workflow > Reverso de aprobación</asp:label><asp:button id="btnDefault" runat="server" Height="0px" Width="0px" Text="Button"></asp:button></TD>
					<TD style="HEIGHT: 24px" vAlign="middle" align="right" bgColor="#ffffff">
					<%--<uc1:navegacion id="Navegacion1" runat="server"></uc1:navegacion>--%>
					</TD>
					<td style="WIDTH: 8px; HEIGHT: 24px" bgColor="#ffffff"></td>
				</TR>
				<TR>
					<td style="WIDTH: 8px; HEIGHT: 1px"></td>
					<TD style="HEIGHT: 1px" colSpan="2"><A href="javascript:OpenCalendar('txtFechaFin', false)"></A></TD>
					<td style="WIDTH: 8px; HEIGHT: 1px"></td>
				</TR>
				<TR>
					<TD style="WIDTH: 3px"></TD>
					<TD vAlign="baseline" align="right" width="100%" colSpan="2">
						<TABLE class="TablaNormal" id="Table4" style="HEIGHT: 225px" cellSpacing="0" cellPadding="0"
							width="100%" border="0">
							<TR>
								<TD style="WIDTH: 8px; HEIGHT: 5px" vAlign="top" align="left"></TD>
								<TD style="WIDTH: 975px; HEIGHT: 11px" vAlign="top" align="left">
									<TABLE class="TablaNormalEspecial" id="Table3" style="WIDTH: 413px; HEIGHT: 88px" cellSpacing="0"
										cellPadding="0" border="0">
										<TR>
											<TD style="WIDTH: 100px" vAlign="baseline" align="left" height="20"></TD>
											<TD style="WIDTH: 138px" vAlign="baseline" align="left" height="20"></TD>
											<TD vAlign="baseline" align="left" height="20"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 100px; HEIGHT: 6px" vAlign="baseline" align="left" rowSpan="1"><asp:label id="lblModulo" runat="server" CssClass="EtiquetaNormal">Módulo:</asp:label></TD>
											<TD style="WIDTH: 138px; HEIGHT: 6px" vAlign="baseline" align="left"><asp:dropdownlist id="ddlModulo" runat="server" CssClass="ComboNormal" Width="250px" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD style="HEIGHT: 6px" vAlign="baseline" align="left"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 100px; HEIGHT: 6px" vAlign="baseline" align="left"><asp:label id="lblWorkflow" runat="server" CssClass="EtiquetaNormal">Workflow: </asp:label></TD>
											<TD style="WIDTH: 138px; HEIGHT: 6px" vAlign="baseline" align="left"><asp:dropdownlist id="ddlWorkFlow" runat="server" CssClass="ComboNormal" Width="250px"></asp:dropdownlist></TD>
											<TD style="HEIGHT: 6px" vAlign="baseline" align="left"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 100px" vAlign="baseline" align="left"><asp:label id="lblEmpleado" runat="server" CssClass="EtiquetaNormal" Width="136px">Solicitante (código/nombre):</asp:label></TD>
											<TD style="WIDTH: 138px; HEIGHT: 25px" vAlign="baseline" align="left"><asp:textbox id="txtEmpleado" runat="server" CssClass="TextoNormal" Width="250px"></asp:textbox><A href="javascript:BorrarText('txtFechaFin')"></A></TD>
											<TD style="HEIGHT: 25px" vAlign="baseline" align="left"><asp:imagebutton id="ibtnConsultar" runat="server" ImageUrl="../Imagenes/Goazul.JPG"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR height="13">
								<TD style="WIDTH: 8px" vAlign="top" align="left" height="300"></TD>
								<TD vAlign="top" align="left" height="300"><asp:datagrid id="dgdWorkflow" runat="server" CssClass="Gridview_cuerpo" Width="960px" BackColor="White"
										AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" GridLines="Horizontal" CellPadding="0" BorderWidth="0px" BorderStyle="None"
										BorderColor="#4A3C8C" ShowFooter="True">
										<FooterStyle Height="22px" ForeColor="#4A3C8C" VerticalAlign="Top" BackColor="#B5C7DE"></FooterStyle>
										<SelectedItemStyle Height="22px" ForeColor="#4A3C8C" VerticalAlign="Top" BackColor="#FFCC66"></SelectedItemStyle>
										<EditItemStyle Height="22px" ForeColor="#4A3C8C" BackColor="#FFCC66"></EditItemStyle>
										<AlternatingItemStyle Height="22px" VerticalAlign="Top" BackColor="#F7F7F7"></AlternatingItemStyle>
										<ItemStyle Height="22px" ForeColor="#4A3C8C" VerticalAlign="Top" BackColor="#E7E7FF"></ItemStyle>
										<HeaderStyle Height="22px" ForeColor="#F7F7F7" VerticalAlign="Top" BackColor="#999966"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn>
												<HeaderStyle Width="10px"></HeaderStyle>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Referencia">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<HeaderTemplate>
													<asp:Label id="lblReferenciaTtiulo" runat="server" CssClass="EtiquetaNormal" ForeColor="White">N° documento</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblReferencia runat="server" CssClass="EtiquetaNormal" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.strReferencia","{0:000000}") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="N&#176; Solicitud">
												<HeaderStyle Width="80px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblSolicitudTitulo" runat="server" CssClass="EtiquetaNormal" ForeColor="White">N° solicitud</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblNumSolicitud runat="server" CssClass="EtiquetaNormal" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.intSolicitud", "{0:000000}") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Fecha creaci&#243;n">
												<HeaderStyle Width="120px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblCreacionTtiulo" runat="server" CssClass="EtiquetaNormal" ForeColor="White">Fecha de creación</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblItemFechaCreacion runat="server" Width="110px" Text='<%# DataBinder.Eval(Container, "DataItem.dttFechaCreacion","{0:dd/MM/yyyy hh:mm tt}") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Codigo Solicitante">
												<HeaderStyle Width="70px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblCodigoTitulo" runat="server" CssClass="EtiquetaNormal" ForeColor="White">Código solicitante</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblCodigo runat="server" CssClass="EtiquetaNormal" Text='<%# DataBinder.Eval(Container, "DataItem.intCodSolicitante","{0:000000}") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="Cliente" HeaderText="Solicitante">
												<HeaderStyle Width="150px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblSolicitanteTitulo" runat="server" CssClass="EtiquetaNormal" ForeColor="White">Solicitante</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblSolicitante runat="server" CssClass="EtiquetaNormal" Width="140px" Text='<%# DataBinder.Eval(Container, "DataItem.strSolicitante") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Ultimo aprobador">
												<HeaderStyle Width="150px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblUltimoTitulo" runat="server" CssClass="EtiquetaNormal">Ultimo aprobador</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblUltimo runat="server" CssClass="EtiquetaNormal" Width="140px" Text='<%# DataBinder.Eval(Container, "DataItem.strUltimoAprobador") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Fecha aprobacion">
												<HeaderStyle Width="120px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblTituloFechaAprobacion" runat="server" CssClass="EtiquetaNormal" ForeColor="White">Fecha aprobación</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblItemFechaAprobacion runat="server" Width="110px" Text='<%# DataBinder.Eval(Container, "DataItem.dttFechaRevision","{0:dd/MM/yyyy hh:mm tt}") %>'>
													</asp:Label>
													<asp:Label id="lblItemAprobacionNada" runat="server" CssClass="EtiquetaNormal" Width="140px"
														Text="---" Visible="False"></asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Siguiente aprobador">
												<HeaderStyle Width="150px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblSiguienteTitulo" runat="server" CssClass="EtiquetaNormal" CommandName="OrdenarTipoSolicitud"
														ForeColor="White">Siguiente aprobador</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblSiguiente runat="server" CssClass="EtiquetaNormal" Width="140px" Text='<%# DataBinder.Eval(Container, "DataItem.strSiguienteAprobador") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Estatus">
												<HeaderStyle Width="70px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblEstatusTitulo" runat="server" CssClass="EtiquetaNormal">Estatus</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblEstatus runat="server" CssClass="EtiquetaNormal" Width="60px" Text='<%# DataBinder.Eval(Container, "DataItem.strEstatus") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20px"></HeaderStyle>
												<HeaderTemplate>
													<asp:CheckBox id="chkSeleccioneTitulo" runat="server"></asp:CheckBox>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:CheckBox id="chkSeleccione" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="10px"></HeaderStyle>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Height="22px" HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>&nbsp;
									<asp:label id="lblCantidad" runat="server" Width="151px" CssClass="EtiquetaItems">0 Documentos pendientes</asp:label>&nbsp;</TD>
							</TR>
						</TABLE>
						<TABLE class="TablaNormal" id="Table15" style="WIDTH: 970px; HEIGHT: 33px" cellSpacing="0"
							cellPadding="0" width="970" align="right" border="0">
							<TR>
								<TD style="WIDTH: 26px" align="right"></TD>
								<TD style="WIDTH: 545px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD style="WIDTH: 7px" align="right"></TD>
								<TD align="right"><asp:button id="btnReversar" runat="server" CssClass="BotonNormal" Text="Reversar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD class="ValidadorSumarioNormal" style="WIDTH: 973px" align="center" height="1">
			<TABLE class="TablaNormalEspecial" id="Table5" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TR>
					<td width="8"></td>
					<TD><asp:validationsummary id="vsmSolicitudFactura" runat="server" CssClass="ValidadorSumarioNormal" Width="784px"
							DisplayMode="List" ForeColor=" "></asp:validationsummary><asp:label id="lblError" runat="server" CssClass="ValidadorSumarioNormal"></asp:label></TD>
					<td width="8"></td>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 972px" vAlign="bottom" bgColor="#5375a4" colSpan="1" height="1" rowSpan="1">
			<TABLE class="TablaNormal" id="Table2" style="HEIGHT: 14px" cellSpacing="0" cellPadding="0"
				width="978" align="center" border="0">
				<TR>
					<TD width="8"></TD>
					<TD style="WIDTH: 422px; HEIGHT: 11px"><FONT color="#ccccff">ESWFP002A</FONT>
					</TD>
					<TD style="HEIGHT: 11px" align="right"><FONT color="#ccccff">Información restringida - 
							Clasificación DC2</FONT></FONT></TD>
					<TD width="8"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>

