<%@ Control language="vb" CodeBehind="~/admin/Containers/container.vb" AutoEventWireup="false" Explicit="True" Inherits="DotNetNuke.UI.Containers.Container" %>
<%@ Register TagPrefix="dnn" TagName="SOLPARTACTIONS" Src="~/Admin/Containers/SolPartActions.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ICON" Src="~/Admin/Containers/Icon.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TITLE" Src="~/Admin/Containers/Title.ascx" %>
<%@ Register TagPrefix="dnn" TagName="VISIBILITY" Src="~/Admin/Containers/Visibility.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON1" Src="~/Admin/Containers/ActionButton.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON2" Src="~/Admin/Containers/ActionButton.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON3" Src="~/Admin/Containers/ActionButton.ascx" %>
<%@ Register TagPrefix="dnn" TagName="ACTIONBUTTON4" Src="~/Admin/Containers/ActionButton.ascx" %>
<!-- Copyright 2005 BOR Group (www.DotNetNukeSkin.com, www.DNNSource.com, www.DNNBlast.com) -->
<table width="100%" cellspacing="0" cellpadding="0" align="center" style="border-left: 1px #85B845 solid; border-right: 1px #85B845 solid; border-top: 1px #85B845 solid; border-bottom: 1px #85B845 solid;">
	<tr>
		<td height="23">
		<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td valign="middle" nowrap><dnn:SOLPARTACTIONS runat="server" id="dnnSOLPARTACTIONS" /></td>
                <td valign="middle" nowrap><dnn:ICON runat="server" id="dnnICON" /></td>
				<td width="100%" valign="middle" style="padding-left: 5px; padding-right: 5px;" nowrap><dnn:TITLE runat="server" id="dnnTITLE" CssClass="Contitle_Silver_UC" /></td>
				<td valign="top" style="padding-left: 5px; padding-right: 5px;" nowrap><dnn:VISIBILITY runat="server" id="dnnVISIBILITY" /></td>
			</tr>
		</table>
		</td>
	</tr>
	<tr valign="top">
		<td id="ContentPane" runat="server" align="center" style="padding-left: 5px; padding-right: 5px; padding-top: 5px; padding-bottom: 5px;"></td>
	</tr>
	<tr>
		<td height="0">
		<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td valign="middle" style="padding-left: 5px; padding-right: 5px;" nowrap><dnn:ACTIONBUTTON1 runat="server" id="dnnACTIONBUTTON1" CommandName="AddContent.Action" DisplayIcon="True" DisplayLink="True" /></td>
				<td width="100%" valign="middle" style="padding-right: 5px;" nowrap><dnn:ACTIONBUTTON4 runat="server" id="dnnACTIONBUTTON4" CommandName="ModuleSettings.Action" DisplayIcon="True" DisplayLink="False" /></td>
				<td valign="middle" style="padding-right: 5px;" nowrap><dnn:ACTIONBUTTON2 runat="server" id="dnnACTIONBUTTON2" CommandName="SyndicateModule.Action" DisplayIcon="True" DisplayLink="False" /></td>
				<td valign="middle" style="padding-right: 5px;" nowrap><dnn:ACTIONBUTTON3 runat="server" id="dnnACTIONBUTTON3" CommandName="PrintModule.Action" DisplayIcon="True" DisplayLink="False" /></td>
			</tr>
		</table>
		</td>
	</tr>
</table>
<br>
