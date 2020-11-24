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
<table width="100%" cellspacing="0" cellpadding="0" align="center">
	<tr>
		<td id="Td_No_Title_b014v20">
		<table id="Table_Title_b014v20" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td><img src="<%= SkinPath %>media/BarRLightL.gif"></td>
				<td valign="middle" bgcolor="#B7C2CC" nowrap>
				<dnn:SOLPARTACTIONS runat="server" id="dnnSOLPARTACTIONS" />
				</td>
				<td valign="middle" bgcolor="#B7C2CC" nowrap>
				<dnn:ICON runat="server" id="dnnICON" /></td>
				<td width="100%" valign="middle" bgcolor="#B7C2CC" style="padding: 0px 5px 0px 0px;" nowrap>
				<dnn:TITLE runat="server" id="dnnTITLE" cssclass="dnnTitleWhite11px_b014v20" />
				</td>
				<td valign="top" bgcolor="#B7C2CC" style="padding: 0px 5px 0px 5px;" nowrap>
				<dnn:VISIBILITY runat="server" id="dnnVISIBILITY" /></td>
				<td><img src="<%= SkinPath %>media/BarRLightR.gif"></td>
			</tr>
		</table>
		</td>
	</tr>
	<tr valign="top">
		<td id="ContentPane" runat="server" align="center" style="padding: 5px 5px 0px 5px;">
		</td>
	</tr>
	<tr>
		<td height="0">
		<table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 0px; font-size: 0px;">
			<tr>
				<td valign="middle" style="padding-left: 5px; padding-right: 5px;" nowrap>
				<dnn:ACTIONBUTTON1 runat="server" id="dnnACTIONBUTTON1" commandname="AddContent.Action" displayicon="True" displaylink="True" />
				</td>
				<td width="100%" valign="middle" style="padding-right: 5px;" nowrap>
				<dnn:ACTIONBUTTON4 runat="server" id="dnnACTIONBUTTON4" commandname="ModuleSettings.Action" displayicon="True" displaylink="False" />
				</td>
				<td valign="middle" style="padding-right: 5px;" nowrap>
				<dnn:ACTIONBUTTON2 runat="server" id="dnnACTIONBUTTON2" commandname="SyndicateModule.Action" displayicon="True" displaylink="False" />
				</td>
				<td valign="middle" style="padding-right: 5px;" nowrap>
				<dnn:ACTIONBUTTON3 runat="server" id="dnnACTIONBUTTON3" commandname="PrintModule.Action" displayicon="True" displaylink="False" />
				</td>
			</tr>
		</table>
		</td>
	</tr>
</table>
<div class="BottomGap_p002v1">
&nbsp;</div>

