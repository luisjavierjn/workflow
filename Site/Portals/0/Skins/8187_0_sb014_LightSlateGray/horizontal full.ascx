<%@ Control language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %> <%@ Register TagPrefix="dnn" TagName="SOLPARTMENU" Src="~/Admin/Skins/SolPartMenu.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %> <%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="CURRENTDATE" Src="~/Admin/Skins/CurrentDate.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LINKS" Src="~/Admin/Skins/Links.ascx" %> <%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %> <%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="HELP" Src="~/Admin/Skins/Help.ascx" %>
<!-- www.DotNetNukeSkin.com, www.DNNSource.com, www.DNNBlast.com -->
<table id="TableBg" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td id="TdMainFull">
		<table id="TableMain" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td id="TdBanner">
				<table id="TableBanner" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td id="TdLogo" nowrap>
						<dnn:LOGO runat="server" id="dnnLOGO" /></td>
						<td width="100%" align="right">
						<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
							<tr>
								<td id="TdRegisterLogin" nowrap>
								<span class="dnnUSER">
								<dnn:USER runat="server" id="dnnUSER" CssClass="dnnUSER" />&nbsp;::
								<dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="dnnLOGIN" />&nbsp;
								</span></td>
							</tr>
							<tr>
								<td id="SloganPane" class="sloganpane" runat="server" align="center" valign="middle">
								</td>
							</tr>
							<tr>
								<td id="TdSearch" nowrap>
								<span class="dnnSEARCH">
								<dnn:SEARCH runat="server" id="dnnSEARCH" Submit="&lt;img border=&quot;0&quot;; src=&quot;media/ButtonSearch.gif&quot;&gt;" CssClass="dnnSEARCH" />&nbsp;</span></td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td id="TdMenu">
				<table border="0" cellspacing="0" cellpadding="0" align="center" width="100%" height="100%">
					<tr>
						<td valign="top" nowrap>
						<dnn:SOLPARTMENU runat="server" id="dnnSOLPARTMENU" cleardefaults="true" delaysubmenuload="true" usearrows="false" menueffectsmouseoverdisplay="None" menueffectsmouseouthidedelay="500" userootbreadcrumbarrow="false" useskinpatharrowimages="true" downarrow="media/menuarrow_down.gif" rightarrow="media/menuarrow_right.gif" rightseparator="&lt;img src=&quot;media/MenuSprtr.gif&quot;&gt;" rootmenuitemlefthtml="&nbsp;" rootmenuitemrighthtml="&nbsp;" rootmenuitemcssclass="MainMenu_RootMenuItem" rootmenuitemactivecssclass="MainMenu_RootMenuItemActive" rootmenuitemselectedcssclass="MainMenu_RootMenuItemSel" rootmenuitembreadcrumbcssclass="MainMenu_RootMenuItemActive" submenuitemselectedcssclass="MainMenu_SubMenuItemSel" />
						</td>
						<td width="100%" align="right" valign="middle" nowrap>&nbsp;<dnn:CURRENTDATE runat="server" id="dnnCURRENTDATE" CssClass="dnnCURRENTDATE" DateFormat="MMMM d, yyyy" />&nbsp;
						</td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td id="ImagePane" class="imagepane" runat="server" valign="top">
				</td>
			</tr>
			<tr>
				<td height="100%" valign="top">
				<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
					<tr>
						<td width="0" valign="top">
						<table id="TableLeft" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td colspan="4" id="TdSkinLeft">
								<img src="<%= SkinPath %>media/spacer210x1.gif"></td>
							</tr>
							<tr>
								<td>
								<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
									<tr>
										<td id="TdPanelTop" width="10"><img src="<%= SkinPath %>media/spacer10x1.gif"></td>
										<td id="TdPanelTop" width="11" valign="bottom"><img src="<%= SkinPath %>media/PanelTL.gif"></td>
										<td id="TdPanelTop" background="<%= SkinPath %>media/PanelTC.gif" style="background-repeat: repeat-x; background-position: center bottom;"><img src="<%= SkinPath %>media/spacer.gif"></td>
										<td id="TdPanelTop" width="11" valign="bottom"><img src="<%= SkinPath %>media/PanelTR.gif"></td>
									</tr>
									<tr>
										<td width="10" valign="bottom" bgcolor="#FFFFFF"><img src="<%= SkinPath %>media/BL.gif"></td>
										<td width="11" valign="top" background="<%= SkinPath %>media/PanelML.gif" style="background-repeat: repeat-y; background-position: right top;"><img src="<%= SkinPath %>media/PanelML.gif"></td>
										<td valign="top" width="100%" height="100%">
										<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
											<tr>
												<td id="LeftPane" class="leftpane" runat="server" valign="top" height="100%">
												</td>
											</tr>
											<tr>
												<td id="LeftPane2" class="leftpane2" runat="server" valign="bottom">
												</td>
											</tr>
										</table>
										</td>
										<td width="11" valign="top" background="<%= SkinPath %>media/PanelMR.gif" style="background-repeat: repeat-y;"></td>
									</tr>
									<tr>
										<td id="TdCTPH" width="10"><img src="<%= SkinPath %>media/spacer10x1.gif"></td>
										<td id="TdCTPH" width="11" valign="top"><img src="<%= SkinPath %>media/PanelBL.gif"></td>
										<td id="TdCTPH" background="<%= SkinPath %>media/PanelBC.gif" style="background-repeat: repeat-x; background-position: center top;"><img src="<%= SkinPath %>media/spacer.gif"></td>
										<td id="TdCTPH" width="11" valign="top"><img src="<%= SkinPath %>media/PanelBR.gif"></td>
									</tr>
								</table>
								</td>
							</tr>
						</table>
						</td>
						<td width="100%" valign="top" bgcolor="ffffff">
						<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center">
							<tr>
								<td id="TdSkinRight">
								<img src="<%= SkinPath %>media/spacer570x1.gif"></td>
							</tr>
							<tr>
								<td id="TdBread" nowrap>
								<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center">
									<tr>
										<td width="100%" valign="top" nowrap>
										<span class="dnnBREADCRUMB">&nbsp;<img src="<%= SkinPath %>media/breadcrumb.gif"><dnn:BREADCRUMB runat="server" id="dnnBREADCRUMB" Separator="&lt;img src=&quot;media/breadcrumb.gif&quot;&gt;" CssClass="dnnBREADCRUMB" RootLevel="0" />
										</span>&nbsp;&nbsp; </td>
										<td align="right" valign="top" style="padding: 0px 0px 0px 0px;" nowrap>
										<span id="LanguageComboBox">
										<dnn:LANGUAGE runat="server" id="dnnLANGUAGE" />
										</span></td>
									</tr>
								</table>
								</td>
							</tr>
							<tr>
								<td id="TopPane" class="toppane" runat="server" valign="top">
								</td>
							</tr>
							<tr>
								<td valign="top">
								<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center">
									<tr>
										<td id="ContentPane" class="contentpane" runat="server" valign="top">
										</td>
										<td id="RightPane" class="rightpane" runat="server" valign="top">
										</td>
									</tr>
								</table>
								</td>
							</tr>
							<tr>
								<td id="BottomPane" class="bottompane" runat="server" valign="top" height="100%">
								</td>
							</tr>
							<tr>
								<td id="BottomPane2" class="bottompane2" runat="server" valign="bottom">
								</td>
							</tr>
							<tr>
								<td id="TdLinks" nowrap>&nbsp;<span class="dnnLINKS">
								<dnn:LINKS runat="server" id="dnnLINKS" CssClass="dnnLINKS" Separator=" :: " Level="Root" />
								</span>&nbsp;</td>
							</tr>
							<tr>
								<td id="TdCTPH" nowrap>&nbsp;<dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="dnnCOPYRIGHT" />&nbsp;
								<dnn:TERMS runat="server" id="dnnTERMS" CssClass="dnnTERMS" />&nbsp;
								<dnn:PRIVACY runat="server" id="dnnPRIVACY" CssClass="dnnPRIVACY" />&nbsp;
								<dnn:HELP runat="server" id="dnnHELP" CssClass="dnnHELP" />&nbsp;
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				</td>
			</tr>
		</table>
		</td>
	</tr>
</table>

