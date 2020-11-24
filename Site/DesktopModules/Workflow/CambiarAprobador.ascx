<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CambiarAprobador.ascx.cs" Inherits="Workflow.CambiarAprobador" %>
<%@ Register TagPrefix="jlc" Namespace="JLovell.WebControls"   Assembly="StaticPostBackPosition" %>

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
					<TD style="WIDTH: 459px; HEIGHT: 24px" vAlign="middle" bgColor="#ffffff"><asp:label id="lblTitulo" runat="server" Width="333px" CssClass="NormalL" Height="8px">Workflow > Cambio de aprobador</asp:label><asp:button id="btnDefault" runat="server" Width="0px" Height="0px" Text="Button"></asp:button></TD>
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
									<TABLE class="TablaNormalEspecial" id="Table3" style="WIDTH: 480px; HEIGHT: 8px" cellSpacing="0"
										cellPadding="0" border="0">
										<TR>
											<TD style="WIDTH: 80px" vAlign="baseline" align="left" height="20"></TD>
											<TD style="WIDTH: 308px" vAlign="baseline" align="left" height="20"></TD>
											<TD vAlign="baseline" align="left" height="20"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 80px" vAlign="baseline" align="left" height="20"><asp:label id="lblEmpleado" runat="server" Width="80px" CssClass="EtiquetaNormal">Aprobador:</asp:label></TD>
											<TD style="WIDTH: 308px" vAlign="baseline" align="left" height="20"><asp:textbox id="txtCodigoEmpleado" runat="server" Width="56px" CssClass="TextoBloqueado" ReadOnly="True"></asp:textbox><asp:textbox id="txtEmpleado" runat="server" Width="248px" CssClass="TextoBloqueado" ReadOnly="True"></asp:textbox></TD>
											<TD vAlign="baseline" align="left" height="20">
												<asp:RequiredFieldValidator id="rfvAprobador" runat="server" CssClass="ValidadorNormal" ControlToValidate="txtEmpleado">*</asp:RequiredFieldValidator><asp:imagebutton id="ibtnBuscarEmpleado" runat="server" ImageUrl="../Imagenes/Buscar.gif" CausesValidation="False"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 80px; HEIGHT: 6px" vAlign="baseline" align="left" rowSpan="1"><asp:label id="lblModulo" runat="server" CssClass="EtiquetaNormal">Módulo:</asp:label></TD>
											<TD style="WIDTH: 308px; HEIGHT: 6px" vAlign="baseline" align="left"><asp:dropdownlist id="ddlModulo" runat="server" Width="304px" CssClass="ComboNormal" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD style="HEIGHT: 6px" vAlign="baseline" align="left">
												<asp:RequiredFieldValidator id="rfvModulo" runat="server" CssClass="ValidadorNormal" ControlToValidate="ddlModulo"
													Display="Dynamic" InitialValue="0">*</asp:RequiredFieldValidator>
												<asp:TextBox id="txtCategoriaOrigen" runat="server" Height="0px" Width="0px"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 80px; HEIGHT: 6px" vAlign="baseline" align="left"><asp:label id="lblWorkflow" runat="server" CssClass="EtiquetaNormal">Workflow: </asp:label></TD>
											<TD style="WIDTH: 308px; HEIGHT: 6px" vAlign="baseline" align="left"><asp:dropdownlist id="ddlWorkFlow" runat="server" Width="304px" CssClass="ComboNormal"></asp:dropdownlist></TD>
											<TD style="HEIGHT: 6px" vAlign="baseline" align="left">
												<asp:RequiredFieldValidator id="rfvWF" runat="server" CssClass="ValidadorNormal" ControlToValidate="ddlWorkFlow"
													Display="Dynamic" InitialValue="0">*</asp:RequiredFieldValidator><asp:imagebutton id="ibtnConsultar" runat="server" ImageUrl="../Imagenes/Goazul.JPG"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 80px" vAlign="baseline" align="left" height="15"></TD>
											<TD style="WIDTH: 308px" vAlign="baseline" align="left" height="15"></TD>
											<TD vAlign="baseline" align="left" height="15"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR height="13">
								<TD style="WIDTH: 8px" vAlign="top" align="left" height="300"></TD>
								<TD vAlign="top" align="left"><asp:datagrid id="dgdWorkflow" runat="server" Width="960px" CssClass="Gridview_cuerpo" ShowFooter="True"
										BorderColor="#4A3C8C" BorderStyle="None" BorderWidth="0px" CellPadding="0" GridLines="Horizontal" AutoGenerateColumns="False"
										AllowSorting="True" AllowPaging="True" BackColor="White">
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
													<asp:Label id="lblReferenciaTtiulo" runat="server" CssClass="Gridview_cuerpo" ForeColor="White">N°de documento</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblReferencia runat="server" CssClass="Gridview_cuerpo" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.strReferencia","{0:000000}") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="N&#176; Solicitud">
												<HeaderStyle Width="80px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblSolicitudTitulo" runat="server" CssClass="Gridview_cuerpo" ForeColor="White">N° solicitud</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblNumSolicitud runat="server" CssClass="Gridview_cuerpo" Width="70px" Text='<%# DataBinder.Eval(Container, "DataItem.intSolicitud", "{0:000000}") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Fecha creaci&#243;n">
												<HeaderStyle Width="120px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblCreacionTtiulo" runat="server" CssClass="Gridview_cuerpo" ForeColor="White">Fecha de creación</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblItemFechaCreacion runat="server" Width="110px" Text='<%# DataBinder.Eval(Container, "DataItem.dttFechaCreacion","{0:dd/MM/yyyy hh:mm tt}") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Workflow">
												<HeaderStyle Width="300px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblWFTitulo" runat="server" CssClass="Gridview_cuerpo" ForeColor="White">Workflow</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblWF runat="server" CssClass="Gridview_cuerpo" Text='<%# DataBinder.Eval(Container, "DataItem.strWorkFlow") %>'>
													</asp:Label>
													<asp:Label id=lblCodWF runat="server" CssClass="Gridview_cuerpo" Text='<%# DataBinder.Eval(Container, "DataItem.shtWorkFlow") %>' Visible="False">
													</asp:Label>
													<asp:Label id=lblRolAsoc runat="server" CssClass="Gridview_cuerpo" Text='<%# DataBinder.Eval(Container, "DataItem.intRolAsoc") %>' Visible="False">
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="Cliente" HeaderText="Solicitante">
												<HeaderStyle Width="180px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblSolicitanteTitulo" runat="server" CssClass="Gridview_cuerpo" ForeColor="White">Solicitante</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblSolicitante runat="server" CssClass="Gridview_cuerpo" Width="140px" Text='<%# DataBinder.Eval(Container, "DataItem.strSolicitante") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="Aprobador">
												<HeaderStyle Width="180px"></HeaderStyle>
												<HeaderTemplate>
													<asp:Label id="lblAprobadorTitulo" runat="server" CssClass="Gridview_cuerpo">Aprobador</asp:Label>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:Label id=lblAprobador runat="server" CssClass="Gridview_cuerpo" Width="140px" Text='<%# DataBinder.Eval(Container, "DataItem.strSiguienteAprobador") %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="10px"></HeaderStyle>
												<HeaderTemplate>
													<asp:CheckBox id="chkSeleccioneTitulo" runat="server"></asp:CheckBox>
												</HeaderTemplate>
												<ItemTemplate>
													<asp:CheckBox id="chkSeleccione" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Height="22px" HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>&nbsp;
									<asp:label id="lblCantidad" runat="server" ForeColor="#4A3C8C">lblCantidad</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 8px; HEIGHT: 23px" vAlign="top" align="left" height="23"></TD>
								<TD vAlign="top" align="left">
									<asp:Panel id="pnlDestino" runat="server" Visible="False">
										<TABLE class="TablaNormaEspecial" id="Table7" style="WIDTH: 961px; HEIGHT: 54px" cellSpacing="0"
											cellPadding="0" width="961" border="0">
											<TR>
												<TD align="right">
													<TABLE id="Table16" style="WIDTH: 936px; HEIGHT: 18px" cellSpacing="0" cellPadding="0"
														width="936" border="0">
														<TR>
															<TD style="WIDTH: 988px; HEIGHT: 14px" align="left" colSpan="1">&nbsp;</TD>
															<TD class="EtiquetaTitulo" style="WIDTH: 271px; HEIGHT: 14px" align="center">
																<asp:label id="lblTraspasar" runat="server" CssClass="EtiquetaNormal" Width="200px">Traspasar al aprobador</asp:label></TD>
															<TD style="WIDTH: 550px; HEIGHT: 14px" align="center"></TD>
														</TR>
														<TR style="HEIGHT: 5px">
															<TD style="WIDTH: 988px" align="left"></TD>
															<TD class="EtiquetaTitulo" style="WIDTH: 271px" align="center" colSpan="1"></TD>
															<TD class="EtiquetaTitulo" style="WIDTH: 550px" align="center" colSpan="2"></TD>
														</TR>
													</TABLE>
													<TABLE class="TablaNormalEspecial" id="Table6" style="WIDTH: 392px; HEIGHT: 38px" cellSpacing="0"
														cellPadding="0" width="392" border="0">
														<TR>
															<TD style="WIDTH: 113px">
																<asp:label id="lblEmpleadoD" runat="server" CssClass="EtiquetaNormal" Width="112px">Empleado aprobador:</asp:label></TD>
															<TD style="WIDTH: 447px">
																<asp:textbox id="txtCodigoEmpleadoD" runat="server" CssClass="TextoBloqueado" Width="56px" ReadOnly="True"></asp:textbox>
																<asp:textbox id="txtEmpleadoD" runat="server" CssClass="TextoBloqueado" Width="199px" ReadOnly="True"></asp:textbox>
																<asp:imagebutton id="ibtnBuscarDestino" runat="server" CausesValidation="False" ImageUrl="../Imagenes/Buscar.gif"></asp:imagebutton></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 113px">
																<asp:label id="lblCategoriaD" runat="server" CssClass="EtiquetaNormal" Width="112px">Categoría:</asp:label></TD>
															<TD style="WIDTH: 447px">
																<asp:textbox id="txtCategoriaD" runat="server" CssClass="TextoBloqueado" Width="256px" ReadOnly="True"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:Panel></TD>
							</TR>
						</TABLE>
						<TABLE class="TablaNormal" id="Table15" style="WIDTH: 970px; HEIGHT: 33px" cellSpacing="0"
							cellPadding="0" width="970" align="right" border="0">
							<TR>
								<TD style="WIDTH: 26px" align="right"></TD>
								<TD style="WIDTH: 545px" align="left">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD style="WIDTH: 7px" align="right"></TD>
								<TD align="right"><asp:button id="btnReversar" runat="server" CssClass="BotonNormal" Text="Aceptar"></asp:button></TD>
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
					<TD><asp:validationsummary id="vsmSolicitudFactura" runat="server" Width="784px" CssClass="ValidadorSumarioNormal"
							ForeColor=" " DisplayMode="List"></asp:validationsummary><asp:label id="lblError" runat="server" CssClass="ValidadorSumarioNormal"></asp:label></TD>
					<td width="8"></td>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 972px" vAlign="bottom" align="right" bgColor="#5375a4" colSpan="1"
			height="1" rowSpan="1">
			<TABLE class="TablaNormal" id="Table2" style="HEIGHT: 14px" cellSpacing="0" cellPadding="0"
				width="978" align="center" border="0">
				<TR>
					<TD width="8"></TD>
					<TD style="WIDTH: 422px; HEIGHT: 11px"><FONT color="#ccccff">ESWFP004A</FONT>
					</TD>
					<TD style="HEIGHT: 11px" align="right"><FONT color="#ccccff">Información restringida - 
							Clasificación DC2</FONT></FONT></TD>
					<TD width="8"></TD>
				</TR>
			</TABLE>
			<jlc:staticpostbackposition id="StaticPostBackPosition1" runat="server"></jlc:staticpostbackposition>
		</TD>
	</TR>
</TABLE>
