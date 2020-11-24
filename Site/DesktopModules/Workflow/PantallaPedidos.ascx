<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PantallaPedidos.ascx.cs" Inherits="Workflow.PantallaPedidos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<style type="text/css">
    .style1
    {
        width: 199px;
    }
    .style2
    {
        width: 140px;
    }
    .style3
    {
        width: 138px;
    }
    .styleKg
    {
        width: 20px;
    }
    .Gridview_cuerpo
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: 10px;
        font-weight: normal;
        text-align: center;
        line-height: 12px;
    }
</style>


<script type="text/javascript" language="javascript">
function decimalesPorcentaje5(donde, caracter, ndec) {
        pat = /[\*,\+,\(,\),\?,\\,\$,\[,\],\^,\|]/
        valor = donde.value
        largo = valor.length
        crtr = true
        dec = false;
        if (isNaN(caracter) || pat.test(caracter) == true) {
            if (pat.test(caracter) == true) {
                caracter = "\\" + caracter
            }
            carcter = new RegExp(caracter, "g")
            valor = valor.replace(carcter, "")
            donde.value = valor
            crtr = false
        }
        else {
            var nums = new Array()
            cont = 0
            for (m = 0; m < largo; m++) {
                if (valor.charAt(m) == "." || valor.charAt(m) == " " || valor.charAt(m) == ",") {
                    continue;
                }
                else {
                    nums[cont] = valor.charAt(m)
                    cont++
                }
            }
        }
        var cad1 = "", cad2 = "", tres = 0
        if (largo > ndec && crtr == true) {
            for (k = nums.length - 1; k >= 0; k--) {
                cad1 = nums[k]
                cad2 = cad1 + cad2
                tres++
                if (tres == ndec) {
                    if (k != 0) {
                        cad2 = "," + cad2
                        dec = true;
                    }
                }
                if (dec && (tres - ndec) != 0) {
                    if (((tres - ndec) % 3) == 0) {
                        if (k != 0) {
                            cad2 = "." + cad2
                        }
                    }
                }
            }
            donde.value = cad2
        }
    }

    function MaskFull(donde, ndec) {
       //debugger
       var ceros = "";
       var Proc = "";
       var valor = donde.value
       var largo = valor.length
       if (largo <= ndec)
                {
                    //if (largo == 0) donde.value = "0";
                    for (var i = 0; i < ndec; i++) ceros += "0";
                    //Proc = String(valor);
                    //valor = TrunkZeros(Proc);
                    valor = TrunkZeros(valor);
                    //valor = String(parseInt(valor)) + ceros;
                    valor = valor + ceros;
                    donde.value = valor;
                    decimalesPorcentaje5(donde, "", ndec);
                    
                }
        return true;

    }

    function TrunkZeros(string) {
        var str = "";
        var i = -1;
        if (string != "") while (string.charAt(++i) == "0");
        // en "i" esta el indice del primer caracter no igual a cero

        str = string.substring(i, string.length);
        if (str == "") str = "0";
        return str;
    }

</script>


<asp:HiddenField ID="hfPH" runat="server" />
<table cellspacing="0" class="Gridview_cuerpo" cellpadding="0" border="0" style="width: 640px">
    <tr valign="top">
        <td class="SubHead" width="130">
            <table cellspacing="1" cellpadding="1" border="1" style="width: 640px">
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label1" Text="Nombre del Cliente:" runat="server"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="textbox1" Text="" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label9" Text="Kilos de Piso Pre-Q:" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textbox2" Text="" runat="server" Width="80%"
                        OnBlur="MaskFull(this,2)"
                        onkeyup="decimalesPorcentaje5(this,this.value.charAt(this.value.length-1),2)"></asp:TextBox>
                       
                    </td>
                    <td class="styleKg">
                    <asp:Label ID="LbKg1" Text="Kg" CssClass="styleKg" runat="server"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label2" Text="Nombre del Solicitante:" runat="server"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="textbox3" Text="" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label11" Text="Kilos de Cojín:" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textbox4" Text="" runat="server" Width="80%"
                        OnBlur="MaskFull(this,2)"
                        onkeyup="decimalesPorcentaje5(this,this.value.charAt(this.value.length-1),2)"></asp:TextBox>
                    </td>
                    <td class="styleKg">
                    <asp:Label ID="Label4" Text="Kg" CssClass="styleKg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label3" Text="Número/Código de Pedido:" runat="server"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="textbox5" Text="" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label13" Text="Kilos de Cordón Mini" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textbox6" Text="" runat="server" Width="80%" 
                        OnBlur="MaskFull(this,2)"
                        onkeyup="decimalesPorcentaje5(this,this.value.charAt(this.value.length-1),2)"></asp:TextBox>
                    </td>
                    <td class="styleKg">
                    <asp:Label ID="Label8" Text="Kg" CssClass="styleKg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label5" Text="Fecha de Solicitud de Pedido:" runat="server"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="textbox7" Text="" runat="server" Width="60%" BackColor="#E4E4E4" ReadOnly="True"></asp:TextBox>
                        <asp:ImageButton ID="ibCalendario" runat="server" ImageUrl="~/DesktopModules/Workflow/Imagenes/Calendario.png" />
                         <ajaxToolkit:CalendarExtender 
               ID="CalendarExtender1" 
               runat="server" 
               TargetControlID="textbox7" 
               PopupButtonID="ibCalendario" 
                     Format="dd/MM/yyyy" />
                    <em><span style="font-size: 8pt">dd/mm/yyyy</span></em>
                    </td>
                   
                    <td class="style3">
                        <asp:Label ID="Label15" Text="Kilos de Cemento:" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textbox8" Text="" runat="server" Width="80%"
                        OnBlur="MaskFull(this,2)"
                        onkeyup="decimalesPorcentaje5(this,this.value.charAt(this.value.length-1),2)"></asp:TextBox>
                    </td>
                    <td class="styleKg">
                    <asp:Label ID="Label10" Text="Kg" CssClass="styleKg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label6" Text="Tipo de Contenedor en FT :" runat="server"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="textbox9" Text="" runat="server" Width="80%"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label17" Text="Kilos de Tira Alfa:" runat="server"></asp:Label>
                    </td>
                    
                    <td>
                        <asp:TextBox ID="textbox10" Text="" runat="server" Width="80%"
                        OnBlur="MaskFull(this,2)"
                        onkeyup="decimalesPorcentaje5(this,this.value.charAt(this.value.length-1),2)"></asp:TextBox>
                    </td>
                    
                    <td class="styleKg">
                    <asp:Label ID="Label12" Text="Kg" CssClass="styleKg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label7" Text="Peso Total de Pedido en Kg :" runat="server"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="textbox11" Text="" runat="server" Width="80%"
                        OnBlur="MaskFull(this,2)"
                        onkeyup="decimalesPorcentaje5(this,this.value.charAt(this.value.length-1),2)"></asp:TextBox>
                    </td>
                   
                    <td class="style3">
                        <asp:Label ID="Label19" Text="Kilos de Pintura:" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="textbox12" Text="" runat="server" Width="80%"
                        OnBlur="MaskFull(this,2)"
                        onkeyup="decimalesPorcentaje5(this,this.value.charAt(this.value.length-1),2)"></asp:TextBox>
                    </td>
                    <td class="styleKg">
                    <asp:Label ID="Label16" Text="Kg" CssClass="styleKg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <%--  <tr>
                    <td align="center" class="style9" >
                        <asp:Button ID="Label8" Text="Aprobar" runat="server" OnClick="BtnAceptar_Click"
                            Width="141px"></asp:Button>
                            &nbsp;
                            &nbsp;
                            &nbsp;
                            <asp:Button ID="Cancelar" runat="server" Text="Rechazar" OnClick="BtnRechazar_Click" 
                            Width="141px"></asp:Button> 
                              &nbsp;
                            <asp:Button ID="BtnCorregir" runat="server" Text="Corregir" OnClick="BtnCorregir_Click" 
                            Width="141px"></asp:Button>
                    </td>
                    </tr>--%>
        </td>
    </tr>
</table>
