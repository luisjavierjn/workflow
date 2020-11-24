<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WizardWorkflow.ascx.cs" Inherits="Workflow.WizardWorkflow" %>
<%@ Register TagPrefix="jlc" Namespace="JLovell.WebControls" Assembly="StaticPostBackPosition" %>
<%@ Register TagPrefix="ie" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>

<asp:HiddenField ID="NodeIndex" runat="server" Value="0" />
<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD style="HEIGHT: 10px" vAlign="top" colSpan="2">
		    <%--<uc1:banner id="Banner1" runat="server"></uc1:banner>--%>
		</TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 395px" vAlign="top" align="center" bgColor="#ffffff">
			<TABLE class="TablaNormal" id="Table1" style="HEIGHT: 196px" cellSpacing="0" cellPadding="0"
				width="100%" align="left" border="0">
				<TR height="8">
					<td style="WIDTH: 8px"></td>
					<TD colSpan="2"></TD>
					<td style="WIDTH: 8px"></td>
				</TR>
				<TR height="20">
					<td style="WIDTH: 8px; HEIGHT: 20px" bgColor="#ffffff"></td>
					<TD style="WIDTH: 459px; HEIGHT: 20px" vAlign="middle" bgColor="#ffffff"><asp:label id="lblTitulo" runat="server" Width="239px" CssClass="EtiquetaTitulo">Workflow > Asistente de Configuración</asp:label></TD>
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
						<TABLE id="Table5" style="WIDTH: 569px; HEIGHT: 119px" cellSpacing="1" cellPadding="1"
							width="569" bgColor="#ffffff" border="0">
							<TR>
								<TD class="EtiquetaNormal">
									<P style="COLOR: black; FONT-FAMILY: Verdana">Configuración de Workflow
										<asp:Label id="lblNombre" runat="server"></asp:Label>
										<asp:label id="lblStepNumber" runat="server"></asp:label></P>
									<TABLE id="Table6" style="WIDTH: 501px; HEIGHT: 51px" cellSpacing="1" cellPadding="1" width="501"
										border="0">
										<TR>
											<TD vAlign="top"><asp:placeholder id="plhWizardStep" runat="server"></asp:placeholder>
												<TABLE id="Table7" style="WIDTH: 496px; HEIGHT: 20px" cellSpacing="1" cellPadding="1" width="496"
													border="0">
													<TR>
														<TD><asp:button id="btnCancel" runat="server" CssClass="BotonNormal" Text="Cancelar" CausesValidation="False"></asp:button>
                                                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
                                                                Visible="False" />
                                                        </TD>
														<TD align="right"><asp:button id="btnBack" runat="server" CssClass="BotonNormal" Text="Anterior"></asp:button><asp:button id="btnNext" runat="server" CssClass="BotonNormal" Text="Siguiente"></asp:button></TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="top">
												<ie:treeview id="tvWorkflow" runat="server" SystemImagesPath="~/DesktopModules/Workflow/Imagenes/treeimages"
													Visible="False" AutoPostBack="false">
													<ie:TreeNode Text="Árbol de Políticas" Expandable="CheckOnce" Expanded="True" ImageUrl="~/DesktopModules/Workflow/Imagenes/root.gif"></ie:TreeNode>
												</ie:treeview>
												<asp:TreeView ID="wfTreeView" ShowLines="true" runat="server" Visible="false" OnSelectedNodeChanged="wfTreeView_SelectedNodeChanged"
												    NodeStyle-ForeColor="DarkBlue"
                                                    NodeStyle-Font-Names="Verdana"
                                                    NodeStyle-Font-Size="8pt"
                                                    NodeStyle-HorizontalPadding="5"
                                                    NodeStyle-VerticalPadding="0"
                                                    NodeStyle-BorderColor="#FFFFFF"
                                                    NodeStyle-BorderStyle="solid"
                                                    NodeStyle-BorderWidth="0px"

                                                    RootNodeStyle-Font-Bold="true"

                                                    HoverNodeStyle-BackColor="#cccccc"
                                                    HoverNodeStyle-BorderColor="#888888"
                                                    HoverNodeStyle-BorderStyle="solid"
                                                    HoverNodeStyle-BorderWidth="0px"

                                                    SelectedNodeStyle-BackColor="#cccccc"
                                                    SelectedNodeStyle-BorderColor="#888888"
                                                    SelectedNodeStyle-BorderStyle="solid"
                                                    SelectedNodeStyle-BorderWidth="0px">
                                                </asp:TreeView>
											</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
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
					<TD align="right">&nbsp;</TD>
					<TD width="8"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR height="8">
		<TD bgColor="#ffffff"></TD>
	</TR>
	<TR>
		<TD class="ValidadorSumarioNormal" align="center" height="1"><TABLE class="TablaNormalEspecial" id="Table3" cellSpacing="0" cellPadding="0" width="100%"
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
					<TD style="WIDTH: 422px"><font color="#ccccff">ESWFP001A</font>
					</TD>
					<TD align="right"><font color="#ccccff">Información restringida - Clasificación DC2</font></FONT></TD>
					<td width="8"></td>
				</TR>
			</TABLE>
			<jlc:staticpostbackposition id="StaticPostBackPosition1" runat="server"></jlc:staticpostbackposition></TD>
	</TR>
</TABLE>