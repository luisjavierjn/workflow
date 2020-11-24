<%@ Control language="vb" CodeBehind="~/admin/Skins/skin.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Skins.Skin" %>
<%@ Register TagPrefix="dnn" TagName="LOGO" Src="~/Admin/Skins/Logo.ascx" %>
<%@ Register TagPrefix="dnn" TagName="USER" Src="~/Admin/Skins/User.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LOGIN" Src="~/Admin/Skins/Login.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SOLPARTMENU" Src="~/Admin/Skins/SolPartMenu.ascx" %>
<%@ Register TagPrefix="dnn" TagName="BREADCRUMB" Src="~/Admin/Skins/BreadCrumb.ascx" %>
<%@ Register TagPrefix="dnn" TagName="CURRENTDATE" Src="~/Admin/Skins/CurrentDate.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LANGUAGE" Src="~/Admin/Skins/Language.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SEARCH" Src="~/Admin/Skins/Search.ascx" %>
<%@ Register TagPrefix="dnn" TagName="LINKS" Src="~/Admin/Skins/Links.ascx" %>
<%@ Register TagPrefix="dnn" TagName="COPYRIGHT" Src="~/Admin/Skins/Copyright.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TERMS" Src="~/Admin/Skins/Terms.ascx" %>
<%@ Register TagPrefix="dnn" TagName="PRIVACY" Src="~/Admin/Skins/Privacy.ascx" %>
<%@ Register TagPrefix="dnn" TagName="HELP" Src="~/Admin/Skins/Help.ascx" %>
<!-- Copyright 2005 BOR Group (www.DotNetNukeSkin.com, www.DNNSource.com, www.DNNBlast.com) -->
<center>
<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
	<tr>
		<td valign="top">
		<table id="Banner_Bg" border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
			<tr>
				<td id="Logo_Td" rowspan="2" align="center" valign="middle" style="padding-left: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px;"><dnn:LOGO runat="server" id="dnnLOGO" /></td>
				<td align="right" valign="top" style="padding-right: 2px;">
				<table border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top"><img src="<%= SkinPath %>media/top_l.gif"></td>
						<td height="23" align="right" valign="middle" background="<%= SkinPath %>media/top_c.gif" style="background-repeat: repeat-x;" nowrap>&nbsp;<dnn:CURRENTDATE runat="server" id="dnnCURRENTDATE" CssClass="Current_Date" DateFormat="MMMM d, yyyy" />
						<span class="Top_Link_Sprtr">|</span>&nbsp;
						<span id="SearchTextBox">
						<dnn:SEARCH runat="server" 
						id="dnnSEARCH" 
						CssClass="Top_Link"
						/></span>&nbsp;
						<span class="Top_Link_Sprtr">|</span>&nbsp;
						<dnn:USER runat="server" id="dnnUSER" CssClass="Top_Link" />&nbsp;
						<dnn:LOGIN runat="server" id="dnnLOGIN" CssClass="Top_Link" />&nbsp;&nbsp;
						</td>
						<td valign="top"><img src="<%= SkinPath %>media/top_r.gif"></td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td height="27" valign="bottom" nowrap>
				<dnn:SOLPARTMENU runat="server" id="dnnSOLPARTMENU"  
				cleardefaults="true"
				delaysubmenuload="true"
				menualignment="Left"
				menueffectsmouseoverdisplay="None"  
				menueffectsmouseouthidedelay="500"
				useskinpatharrowimages="true"  
				userootbreadcrumbarrow="false"  
				downarrow="media/menuarrow_down.gif"  
				rightarrow="media/menuarrow_right.gif"  
		 		leftseparator="<img src=&quot;media/menuitem_l.gif&quot;>"  
				rightseparator="<img src=&quot;media/menuitem_r.gif&quot;>"  
				leftseparatoractive="<img src=&quot;media/menuitemsel_l.gif&quot;>"  
				rightseparatoractive="<img src=&quot;media/menuitemsel_r.gif&quot;>"  
		 		leftseparatorbreadcrumb="<img src=&quot;media/menuitemsel_l.gif&quot;>"  
		 		rightseparatorbreadcrumb="<img src=&quot;media/menuitemsel_r.gif&quot;>" 				
				rootmenuitemcssclass="MainMenu_RootMenuItem"  
				rootmenuitemactivecssclass="MainMenu_RootMenuItemActive"  
				rootmenuitemselectedcssclass="MainMenu_RootMenuItemSel"  
				submenuitemselectedcssclass="MainMenu_SubMenuItemSel"  
		 		rootmenuitembreadcrumbcssclass="MainMenu_RootMenuItemActive"  
				 /></td>
			</tr>
			<tr>
				<td colspan="2" height="5" valign="top" background="<%= SkinPath %>media/menubar_bot.gif" style="background-repeat: repeat-x; background-position: center top;" nowrap>
				</td>
			</tr>
		</table>
		</td>
	</tr>
	<tr>
		<td bgcolor="#36750B">
		<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
			<tr>
				<td id="SloganPane" class="sloganpane" runat="server" align="center" valign="middle"></td>
			</tr>
		</table>
		</td>
	</tr>
	<tr>
		<td height="100%" valign="top" style="padding-left: 2px; padding-top: 2px;">
		<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center">
			<tr>
				<td id="Left_Td" valign="top">
				<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center">
					<tr>
						<td id="LeftPane" class="leftpane" runat="server" valign="top" height="100%"></td>
					</tr>
					<tr>
						<td id="LeftPane2" class="leftpane" runat="server" valign="bottom"></td>
					</tr>
				</table>
				</td>
				<td valign="top" height="100%">
				<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center">
					<tr>
						<td height="19" valign="top">
						<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center">
							<tr>
								<td valign="top"><img src="<%= SkinPath %>media/bread_img.gif"><span class="Breadcrumb"><dnn:BREADCRUMB runat="server" 
								id="dnnBREADCRUMB" 
								Separator="&lt;img src=&quot;media/breadcrumb.gif&quot;&gt;" 
								CssClass="Breadcrumb_Link" 
								RootLevel="0"
								/></span>&nbsp;&nbsp;&nbsp;</td>
								<td align="right" nowrap>
								<span id="LanguageComboBox"><dnn:LANGUAGE runat="server" id="dnnLANGUAGE" /></span>
								</td>
							</tr>
						</table>
						</td>
					</tr>
					<tr>
						<td id="TopPane" class="toppanef" runat="server" valign="top"></td>
					</tr>
					<tr>
						<td>
						<table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%" align="center">
							<tr>
								<td id="ContentPane" class="contentpane" runat="server" valign="top"></td>
								<td id="RightPane" class="rightpanef" runat="server" valign="top"></td>
							</tr>
						</table>
						</td>
					</tr>
					<tr>
						<td id="BottomPane" class="bottompanef" runat="server" valign="top"></td>
					</tr>
					<tr>
						<td id="BottomPane2" class="bottompanef2" runat="server" valign="bottom"></td>
					</tr>
				</table>				
				</td>
			</tr>
			<tr>
				<td colspan="2" height="2"></td>
			</tr>
			<tr>
				<td colspan="2" height="25" align="center" valign="middle" bgcolor="#f2f2f2" style="padding-top: 3px;" nowrap>
				<span class="Content_Link">
				<dnn:LINKS runat="server" 
				id="dnnLINKS" 
				CssClass="Content_Link" 
				Separator="  |  " 
				Level="Root"
				/></span></td>
			</tr>
			<tr>
				<td colspan="2" height="1"></td>
			</tr>
			<tr>
				<td colspan="2" height="21" align="center" valign="top" bgcolor="#DFDFDF" nowrap>&nbsp;
				<dnn:COPYRIGHT runat="server" id="dnnCOPYRIGHT" CssClass="Copyright" />&nbsp;
				<dnn:TERMS runat="server" id="dnnTERMS" CssClass="Bottom_Link" />&nbsp;
				<dnn:PRIVACY runat="server" id="dnnPRIVACY" CssClass="Bottom_Link" />&nbsp;
				<dnn:HELP runat="server" id="dnnHELP" CssClass="Bottom_Link" />&nbsp;</td>
			</tr>
			<tr>
				<td colspan="2" height="19"></td>
			</tr>
		</table>
		</td>
	</tr>
</table>
</center>
