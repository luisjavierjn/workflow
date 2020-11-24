<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlDePagos.ascx.cs" Inherits="Workflow.ControlDePagos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<style type="text/css">
    .NormalOperaciones
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: 11px;
        font-weight: normal;
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
    .style1
    {
        width: 155px;
    }
    .style2
    {
        width: 193px;
    }
    .Detailsview_cuerpo
    {
        font-family: Verdana, Helvetica, sans-serif;
        font-size: 9px;
        font-weight: normal;
        text-align: left;
        line-height: 12px;
    }
</style>

<script type="text/javascript" language="javascript">

    function getNumberMilesSeparator() {
        return '.';
    }

    function getNumberPointSeparator() {
        return ',';
    }

    // invocar en el onblur del input
    function formatInput(id, dec) {

        var decimal = dec;

        //value = parseFloatFormat(document.getElementById(id).value);
        value = parseFloatFormat(id.value);
        if (isNaN(value)) {
            value = "0";
        }

        id.value = format(value, decimal);

    }

    function parseFloatFormat(str) {
        miles = getNumberMilesSeparator();
        point = getNumberPointSeparator();

        str0 = new String(str);

        if (point == ',') {
            while (str0.indexOf(miles) != -1) { str0 = str0.replace(miles, ""); }
            while (str0.indexOf(point) != -1) { str0 = str0.replace(point, "."); }
        }

        return parseFloat(str0);
    }

    function format(str, decimal) {
        miles = getNumberMilesSeparator();
        point = getNumberPointSeparator();
        //   alert(str)
        str0 = new String(str);

        num = parseFloat(str0);

        str1 = new String(num);
        str2 = new String();

        if (str1 == "NaN") {
            return str1;
        }

        index = str1.lastIndexOf(miles);

        if (index == -1) {
            index = str1.length;
        }

        for (i = index, digits = 1; i > 0; i--, digits++) {
            str2 = str1.slice(i - 1, i).concat(str2);

            if ((digits % 3) == 0 && i != 1 && str1.slice(i - 2, i - 1) != "-") {
                str2 = miles.concat(str2);
            }
        }
        if (decimal > 0) {
            str2 = str2.concat(point);
            for (i = index, digits = 0; digits < decimal; i++, digits++) {
                if ((i + 1) < str1.length) {
                    str2 = str2.concat(str1.slice(i + 1, i + 2));
                } else {
                    str2 = str2.concat("0");
                }
            }
        }
        return str2;
    }



    function FormatoMonto(vObjetoNumero) {
        //** Funcin para validar los Montos de dinero en formato 999999.00
        //** Se implementa utilizando el evento:
        //** ==> onKeyUp="FormatoMonto(this)"
        //** en el TextBox que corresponda
        var ObjetoNumero = '';
        var strChequear = '0123456789,.-';
        for (var i = 0; i < vObjetoNumero.value.length; i++) {
            // Creando string numerico para 0123456789,/
            if (strChequear.indexOf(vObjetoNumero.value.substr(i, 1)) != -1) {

                if (vObjetoNumero.value.substr(i, 1) == '.') {
                    ObjetoNumero = ObjetoNumero + ',';
                }
                else {
                    ObjetoNumero = ObjetoNumero + vObjetoNumero.value.substr(i, 1);
                }

            }
        }
        if (vObjetoNumero.value != ObjetoNumero) {
            vObjetoNumero.value = ObjetoNumero;
        }
        return false;
    }

    function FormatoMonto2(vObjetoNumero) {
        //** Funcin para validar los Montos de dinero en formato 999999.00
        //** Se implementa utilizando el evento:
        //** ==> onKeyUp="FormatoMonto(this)"
        //** en el TextBox que corresponda
        var ObjetoNumero = '';
        var strChequear = '0123456789,.-';
        for (var i = 0; i < vObjetoNumero.value.length; i++) {
            // Creando string numerico para 0123456789,/
            if (strChequear.indexOf(vObjetoNumero.value.substr(i, 1)) != -1) {

                if (vObjetoNumero.value.substr(i, 1) == '.') {
                    ObjetoNumero = ObjetoNumero + '';
                }
                else {
                    ObjetoNumero = ObjetoNumero + vObjetoNumero.value.substr(i, 1);
                }

            }
        }
        if (vObjetoNumero.value != ObjetoNumero) {
            vObjetoNumero.value = ObjetoNumero;
        }
        else {
            vObjetoNumero.value = vObjetoNumero.value;
        }
        return false;
    }



    function formateaMonto(monto) {
        var str2 = insertaChr((monto.substring(0, monto.length - 2)), '.', 3);
        str2 = str2 + "," + monto.substring(monto.length - 2, monto.length + 1);
        return str2;
    }
    function insertaChr(s1, chr, num) {
        var lenstr1 = s1.length;
        var cantChr = Math.floor((lenstr1 - 1) / num);
        var str2 = "";
        while (cantChr > 0) {
            str2 = chr + s1.substring(lenstr1 - num, lenstr1) + str2;
            lenstr1 = lenstr1 - num;
            cantChr--;
        }
        str2 = s1.substring(0, lenstr1) + str2;
        return str2;

    }



    function ValidarControles() {
        var txtCalendario = $get('<%= this.txtCalendario.ClientID %>');
        var hdCalendario = $get('<%= this.hdCalendario.ClientID %>');
        hdCalendario.value = txtCalendario.value;
    }

    function refreshPanel() {
        //debugger
        var fecha = $get('<%= this.txtCalendario.ClientID %>');
        var fechaPost = $get('<%= this.hfFechaDep.ClientID %>');

        fechaPost.value = fecha.value;

        return true;
    }


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
        if (largo <= ndec) {
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

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hdCalendario" runat="server" />
        <asp:HiddenField ID="hdFirma" runat="server" />
        <asp:HiddenField ID="hfIdCuenta" runat="server" />
        <asp:HiddenField ID="hfFechaDep" runat="server" />
        <table style="width: 100%;" cellspacing="1" cellpadding="1" border="1" class="NormalOperaciones">
            <tr>
                <td colspan="3" align="center">
                    &nbsp;<asp:Label ID="Label9" runat="server" Text="Informacion del Deposito"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="Label1" Text="Nombre del Cliente:" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="textbox1" Text="" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
          <%--  <tr>
                <td class="style1">
                    <asp:Label ID="Label2" Text="Nombre de la Empresa:" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="textbox3" Text="" runat="server" Width="89%"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td class="style1">
                    <asp:Label ID="lbMoneda" runat="server" Text="Moneda:" Width="100px"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlMoneda" runat="server" Style="margin-left: 0px" Width="150px">
                        <asp:ListItem Value="1">USD</asp:ListItem>
                        <asp:ListItem Value="12">BsF</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lbTipoTransaccion" runat="server" Text="Tipo de Transaccion:" Width="150px"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlTipoTransaccion" runat="server" Style="margin-left: 0px"
                        Width="150px">
                        <asp:ListItem Value="3">Deposito Bancario</asp:ListItem>
                        <asp:ListItem Value="4">Deposito Transferencia</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lbCuenta" runat="server" Text="Cuenta:" Width="100px"></asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlCuentas" runat="server" Style="margin-left: 0px" Width="250px">
                    <asp:ListItem Value="3">Banco Exterior</asp:ListItem>
                    </asp:DropDownList>
                    <%--<asp:ObjectDataSource ID="ODSCuentas" runat="server" 
                    SelectMethod="ObtenerBrokersCtaTerceros" 
                    TypeName="CleverFinancial.Modules.Portafolios.Cuenta">
                </asp:ObjectDataSource> DataTextField="Beneficiario" DataValueField="CuentaId" 
                    DataSourceID="ODSCuentas" --%>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lbNroTransaccion" runat="server" Text="Numero Transaccion:" Width="150px"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtNroTransaccion" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Debe agregar su clave"
                        ControlToValidate="txtNroTransaccion" Width="150px" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lbFechaTransaccion" runat="server" Text="Fecha del deposito:" Width="150px"></asp:Label>
                </td>
                <td class="style2">
                    <div style="width: 178px">
                        <asp:TextBox ID="txtCalendario" runat="server" Width="150px" BackColor="#E4E4E4"
                            ReadOnly="True"></asp:TextBox>
                        <asp:ImageButton ID="ibCalendario" runat="server" ImageUrl="~/DesktopModules/Workflow/Imagenes/Calendario.png" />
                    </div>
                </td>
                <td>
                    <ajaxToolkit:CalendarExtender 
               ID="CalendarExtender1" 
               runat="server" 
               TargetControlID="txtCalendario" 
               PopupButtonID="ibCalendario" 
                     Format="dd/MM/yyyy" />
                    <em><span style="font-size: 8pt">dd/mm/yyyy</span></em>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lbMonto" runat="server" Text="Monto:" Width="150px"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtMonto" runat='server' MaxLength='11' Width="150px"  
                        OnBlur="MaskFull(this,2)"
                        onkeyup="decimalesPorcentaje5(this,this.value.charAt(this.value.length-1),2)">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvMonto" runat="server" ErrorMessage="* Debe agregar monto"
                        ControlToValidate="txtMonto" Width="130px" Display="Dynamic"></asp:RequiredFieldValidator>
                    <em><span style="font-size: 8pt">Ej: 1000; 1000.17 </span></em>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="lbFechaTransaccion0" runat="server" Text="Observaciones:" Width="150px"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtObservaciones" runat="server" Width="189px" Height="62px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            
           
            <%--<td class="style1" >
                    <asp:Label ID="lbFirma" runat="server"   
                    Text="Firma *:" Width="150px"></asp:Label>
            </td>
            <td class="style2" >
                <asp:TextBox ID="txtFirma" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
            </td>
            <td>
             <asp:RequiredFieldValidator ID="rfvFirma" runat="server" 
                    ErrorMessage="* Debe agregar su clave" ControlToValidate="txtFirma" 
                    Width="150px" Display="Dynamic"></asp:RequiredFieldValidator>
             </td>--%>
            <%-- <tr>
    
       <td>
                 <asp:Button ID="Label8" Text="Aceptar" runat="server" 
                            Width="141px"></asp:Button>                          
            </td>
            <td>
             <asp:Button ID="Cancelar" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" 
                            Width="141px"></asp:Button>
               </td>
        </tr>--%>
        </table>
        <%--  <cc1:ModalPopupExtender ID="LBProcesarMPE"
        runat="server" 
        BackgroundCssClass="modalBackground" 
        DropShadow="true"             
        PopupControlID="Panel2" 
        PopupDragHandleControlID="Panel3" 
        TargetControlID="btnShowPopup" 
       >
    </cc1:ModalPopupExtender>--%>
    </ContentTemplate>
</asp:UpdatePanel>
