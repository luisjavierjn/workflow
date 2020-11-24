<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GridPantallaPrincipal.ascx.cs" Inherits="Workflow.GridPantallaPrincipal" %>

<style type="text/css">
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
        font-size: 10px;
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
    }
    .buttons
    {
        display: block;
        float: left;
        margin: 0 7px 0 0;
        background-color: #f5f5f5;
        border: 1px solid #dedede;
        border-top: 1px solid #eee;
        border-left: 1px solid #eee;
        font-family: Helvetica, Verdana, sans-serif;
        font-size: 70%;
        line-height: 70%;
        text-decoration: none;
        font-weight: bold;
        color: #565656;
        cursor: pointer;
        padding: 5px 10px 6px 7px;
        text-align: center;
        color: Gray;
    }
    .style1
    {
        width: 165px;
    }
    .style2
    {
        width: 153px;
    }
    .style5
    {
        width: 212px;
    }
    .style6
    {
        width: 216px;
    }
    .style7
    {
        width: 173px;
    }
    .style8
    {
        width: 232px;
    }
    .style9
    {
        height: 56px;
    }
</style>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" RowStyle-CssClass="Gridview_cuerpo"
    OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
    DataKeyNames="ReferenciaId, WorkFlowId, ResponsableId, IdStatus" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
    Width="640px" EmptyDataRowStyle-CssClass="Gridview_cuerpo" EnableViewState="False"
    ShowFooter="True">
    <RowStyle CssClass="Gridview_cuerpo"></RowStyle>
    <EmptyDataRowStyle CssClass="Gridview_cuerpo"></EmptyDataRowStyle>
    <Columns>
        <asp:TemplateField HeaderText="">
            <ItemStyle CssClass="Gridview_cuerpo"></ItemStyle>
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Responsable">
            <ItemStyle CssClass="Gridview_cuerpo"></ItemStyle>
            <ItemTemplate>
                <asp:Label ID="LbResponsable" runat="server" Text='<%# Eval("Responsable") %>'>
                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Asunto">
            <ItemStyle CssClass="Gridview_cuerpo"></ItemStyle>
            <ItemTemplate>
                <asp:Label ID="LbAsunto" runat="server" Text='<%# Eval("Asunto") %>'>
                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status">
            <ItemStyle CssClass="Gridview_cuerpo"></ItemStyle>
            <ItemTemplate>
                <asp:Label ID="LbStatus" runat="server" Text='<%# Eval("IdStatus") %>'>
                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha">
            <ItemStyle CssClass="Gridview_cuerpo"></ItemStyle>
            <ItemTemplate>
                <asp:Label ID="LbFecha" runat="server" Text='<%# Eval("Fecha") %>'>
                </asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
