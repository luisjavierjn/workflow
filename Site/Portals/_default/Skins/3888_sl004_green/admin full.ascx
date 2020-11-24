<%@ Control language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="CURRENTDATE" Src="~/Admin/Skins/CurrentDate.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %> 
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %> 
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SOLPARTMENU" Src="~/Admin/Skins/SolPartMenu.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %> 
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="HELP" Src="~/Admin/Skins/Help.ascx" %>
<!-- DNN320 Copyright 2005 BOR Group (www.DotNetNukeSkin.com, www.DNNSource.com, www.DNNBlast.com) -->
<center>
<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center" bgcolor="#ffffff">
	<tr>
		<td>
		<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center" bgcolor="#ffffff" style="border-left: 1px #666666 solid; border-right: 1px #666666 solid;">
			<tr>
				<td height="101" valign="top">
				<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
					<tr valign="top">
						<td>
						<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
							<tr>
								<td nowrap>&nbsp;
								<dnn:CURRENTDATE runat="server" id="dnnCURRENTDATE" CssClass="Current_Date" DateFormat="MMMM d, yyyy" /></td>
								<td align="right" nowrap>
								<dnn:USER runat="server" id="dnnUSER" CssClass="Top_Link" />
								<dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="Top_Link" />&nbsp;
								</td>
							</tr>
						</table>
						</td>
					</tr>
					<tr>
						<td valign="middle" height="100%" style="padding-left: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 10px;"><dnn:LOGO runat="server" id="dnnLOGO" /></td>
					</tr>
					<tr>
						<td height="28" style="border-top: 1px solid #666666; border-bottom: 1px solid #666666;">
						<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" bgcolor="#eeeeee">
							<tr>
								<td valign="middle" nowrap>
								<dnn:SOLPARTMENU runat="server" 
								id="dnnSOLPARTMENU" 
								cleardefaults="true" 
								delaysubmenuload="true"
								menueffectsmouseoverdisplay="None" 
								menueffectsmouseouthidedelay="500"
								useskinpatharrowimages="true" 
								userootbreadcrumbarrow="false" 
								downarrow="media/menuarrow_down.gif" 
								rightarrow="media/menuarrow_right.gif" 
								rightseparator="<img src=&quot;media/sprtr.gif&quot;>"  
								menuiconcssclass="MainMenu_MenuIcon_Admin"
								menubreakcssclass="MainMenu_MenuBreak_Admin"
								rootmenuitemcssclass="MainMenu_RootMenuItem_Admin" 
								rootmenuitemactivecssclass="MainMenu_RootMenuItemActive_Admin" 
								rootmenuitemselectedcssclass="MainMenu_RootMenuItemSel_Admin" 
								rootmenuitembreadcrumbcssclass="MainMenu_RootMenuItemActive_Admin"
								submenuitemselectedcssclass="MainMenu_SubMenuItemSel"  
								/></td>
								<td width="100%" align="right" valign="middle" nowrap>
								<span id="SearchTextBox_Admin">
								&nbsp;<dnn:SEARCH runat="server" id="dnnSEARCH" CssClass="Search" />&nbsp;
								</span>
								</td>
								<td valign="middle" nowrap>
								<span id="LanguageComboBox"><dnn:LANGUAGE runat="server" id="dnnLANGUAGE" /></span>
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td valign="top" width="100%" height="100%">
				<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center">
					<tr>
						<td id="ContentPane" class="contentpane" runat="server" valign="top"></td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td height="21" align="center" valign="top" bgcolor="#f2f2f2" style="border-top: 1px #666666 solid;" nowrap>&nbsp;
				<dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="Copyright" />&nbsp;
				<dnn:TERMS runat="server" id="dnnTERMS" CssClass="Bottom_Link" />&nbsp;
				<dnn:PRIVACY runat="server" id="dnnPRIVACY" CssClass="Bottom_Link" />&nbsp;
				<dnn:HELP runat="server" id="dnnHELP" CssClass="Bottom_Link" />&nbsp;</td>
			</tr>
		</table>
		</td>
	</tr>
</table>
</center>
