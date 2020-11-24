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
<table class="Border_Gray_b014v20" cellspacing="0" cellpadding="0" width="100%" align="center">
	<tr>
		<td id="Td_Title_b014v20" background="<%= SkinPath %>media/BarImg1.gif" style="background-repeat: repeat-x; background-position: center bottom;">
		<table id="Table_Title_b014v20" class="LineBot_Gray_b014v20" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td valign="middle" nowrap>
				<dnn:SOLPARTACTIONS runat="server" id="dnnSOLPARTACTIONS" />
				</td>
				<td valign="middle" nowrap>
				<dnn:ICON runat="server" id="dnnICON" /></td>
				<td width="100%" valign="middle" style="padding: 0px 5px 0px 5px;" nowrap>
				<dnn:TITLE runat="server" id="dnnTITLE" cssclass="dnnTitleGray11px_b014v20" />
				</td>
				<td valign="top" style="padding: 0px 5px 0px 5px;" nowrap>
				<dnn:VISIBILITY runat="server" id="dnnVISIBILITY" /></td>
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

