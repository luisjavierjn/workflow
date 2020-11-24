<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PoliticasWorkflow.ascx.cs" Inherits="Workflow.Controles.PoliticasWorkflow" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="ie" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>

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
    #listItem {
	font:12px Arial, Helvetica, sans-serif;
	width:200px;
	background-color:#FFF;
	border:1px solid #DDD;
	}
#listItem optgroup option	{
	padding:3px 0px 3px 15px;
	border-bottom-width:1px;
	border-bottom-style:solid;
	}
#listItem optgroup.galerias {
	background-color:#e6e6c2;
	color: #919245;
	}
#listItem optgroup.correo	{
	background-color:#c2e1e6;
	color:#336699;
	}
#listItem optgroup.galerias	{
	border-bottom-color:#8e8e83;
	}
</style>

<asp:HiddenField ID="hfIndex" runat="server" />
<asp:HiddenField ID="hfCommand" runat="server" OnValueChanged="hfCommand_ValueChanged" />
<asp:HiddenField ID="hfTipoDeDato" runat="server" />
<asp:HiddenField ID="hfCondicion" runat="server" />
<asp:HiddenField ID="hfValor" runat="server" />

<script type="text/javascript">

    function jsCommand(command) {
        //debugger;
        var hfCommand = $get('<%= this.hfCommand.ClientID %>');
        hfCommand.value = command;

        var grid = $get('<%= this.dgdPoliticas.ClientID %>');
        var hfIndex = $get('<%= this.hfIndex.ClientID %>');
        
        var hfTipoDeDato = $get('<%= this.hfTipoDeDato.ClientID %>');
        var hfCondicion = $get('<%= this.hfCondicion.ClientID %>');        
        var hfValor = $get('<%= this.hfValor.ClientID %>');

        var i = parseInt(hfIndex.value);
        hfTipoDeDato.value = grid.rows[i + 1].cells[0].childNodes[0].value;
        hfCondicion.value = grid.rows[i + 1].cells[1].childNodes[0].value;
        hfValor.value = grid.rows[i + 1].cells[2].childNodes[0].value;
    }

</script>

<fieldset style="WIDTH: 519px; HEIGHT: 72px"><legend class="EtiquetaNormal">Politicas
	</legend>
	<asp:datagrid id="dgdPoliticas" CssClass="Gridview_cuerpo" Width="512px" GridLines="Horizontal" CellPadding="3"
		BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#E7E7FF" AutoGenerateColumns="False"
		runat="server" 
		    OnDeleteCommand="dgdPoliticas_DeleteCommand" 
            OnEditCommand="dgdPoliticas_EditCommand"> 
            
<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE">
</FooterStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C">
</SelectedItemStyle>

<AlternatingItemStyle BackColor="#F7F7F7">
</AlternatingItemStyle>

<ItemStyle ForeColor="#4A3C8C" BackColor="#E7E7FF">
</ItemStyle>

<HeaderStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#999966">
</HeaderStyle>

<Columns>
<asp:TemplateColumn HeaderText="Informaci&#243;n">
<HeaderTemplate>
<asp:Label id=lblTipoDeDatoTitulo runat="server">Informacion</asp:Label>
</HeaderTemplate>

<ItemTemplate>
<asp:Label id=lblTipoDeDatoItem runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.strNbrTipoDeDato") %>'>
					</asp:Label>
</ItemTemplate>

<EditItemTemplate>
<asp:DropDownList id=ddlTipoDeDatoItem runat="server" Width="150px" CssClass="ComboNormal"></asp:DropDownList>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Condici&#243;n">
<HeaderTemplate>
					<asp:Label id="lblCondicionTitulo" runat="server">Condicion</asp:Label>
				
</HeaderTemplate>

<ItemTemplate>
					<asp:Label id=lblCondicionItem runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.strNbrCondicion") %>'>
					</asp:Label>
				
</ItemTemplate>

<EditItemTemplate>
					<asp:DropDownList id="ddlCondicionItem" CssClass="ComboNormal" Width="150px" runat="server"></asp:DropDownList>
				
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Valor">
<HeaderTemplate>
<asp:Label id=lblValorTitulo runat="server">Valor</asp:Label>
</HeaderTemplate>

<ItemTemplate>
<asp:Label id=lblValorItem runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.strValor") %>'>
					</asp:Label>
</ItemTemplate>

<EditItemTemplate>
<asp:TextBox id=txtValor runat="server" CssClass="TextoDerecha" Text='<%# DataBinder.Eval(Container, "DataItem.strValor") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<HeaderStyle Width="45px">
</HeaderStyle>

<ItemStyle Width="45px">
</ItemStyle>

<ItemTemplate>
					<asp:ImageButton id="Editar" runat="server" 
                        ImageUrl="~/DesktopModules/Workflow/Imagenes/Actualizar.gif" CommandName="Edit"></asp:ImageButton>&nbsp;&nbsp;
					<asp:ImageButton id="Eliminar" runat="server" ImageUrl="~/DesktopModules/Workflow/Imagenes/Eliminar.gif" CommandName="Delete"></asp:ImageButton>
				
</ItemTemplate>

<EditItemTemplate>
					<asp:ImageButton id="ibtnActualizar" runat="server" 
                        ImageUrl="~/DesktopModules/Workflow/Imagenes/Salvar.gif" OnClientClick="javascript:jsCommand('Update');"></asp:ImageButton>&nbsp;&nbsp;
					<asp:ImageButton id="ibtnCancelar" runat="server" 
                        ImageUrl="~/DesktopModules/Workflow/Imagenes/Cancelar.gif" OnClientClick="javascript:jsCommand('Cancel');"></asp:ImageButton>
				
</EditItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle HorizontalAlign="Right" ForeColor="#4A3C8C" BackColor="#E7E7FF" Mode="NumericPages">
</PagerStyle>
	</asp:datagrid>
	<TABLE id="Table1" style="WIDTH: 512px; HEIGHT: 8px" cellSpacing="0" cellPadding="0" width="512"
		border="0">
		<TR>
			<TD style="WIDTH: 156px; HEIGHT: 14px" bgColor="#738a9c"><P align="center"><asp:dropdownlist id="ddlTipo" CssClass="ComboNormal" Width="150px" runat="server"></asp:dropdownlist></P>
			</TD>
			<TD style="WIDTH: 156px; HEIGHT: 14px" align="center" bgColor="#738a9c">
				<P align="center"><asp:dropdownlist id="ddlCondicion" CssClass="ComboNormal" Width="150px" runat="server" DataMember="cas_nbr_cargoasoc"></asp:dropdownlist></P>
			</TD>
			<TD style="WIDTH: 156px; HEIGHT: 14px" align="center" bgColor="#738a9c"><asp:textbox id="txtPolitica" CssClass="TextoNormal" runat="server"></asp:textbox></TD>
			<TD style="WIDTH: 46px; HEIGHT: 14px" bgColor="#738a9c"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="~/DesktopModules/Workflow/Imagenes/Aceptar.gif" OnClick="ibtnAgregar_Click"></asp:imagebutton>&nbsp;&nbsp;
				<asp:imagebutton id="ImageButton6" runat="server" ImageUrl="~/DesktopModules/Workflow/Imagenes/Cancelar.gif"></asp:imagebutton></TD>
		</TR>
	</TABLE>
</fieldset> 

