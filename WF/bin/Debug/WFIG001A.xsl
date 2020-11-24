<?xml version="1.0"?>
<xsl:stylesheet version = "1.0" xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<xsl:for-each select='root'>
<div align="left">
  <table border="0" cellpadding="0" cellspacing="0" width="80%" align="left">
	<tr>
		<td width="30%">
			<img border="0">
				<xsl:attribute name="src"><xsl:value-of select='param6'/></xsl:attribute>
			</img>
		</td>
		<td width="70%">
			<b><font face="Arial" size="2"><xsl:value-of select='param0'/></font> - <font face="Arial" size="2" color="#0000FF"><xsl:value-of select='param8'/></font></b>
		</td>
    </tr>
    <tr><td height="20%"></td><td></td></tr>
   	<tr>
		<td><b><font face="Arial" size="2" color="#FF0000">ALERTA:</font></b></td>
		<td>
			<font face="Arial" size="2">El informe de gastos N° <xsl:value-of select='param1'/> de fecha <xsl:value-of select='param2'/>, <xsl:value-of select='param3'/></font>
			<b><font face="Arial" size="2" color="#0000FF"><xsl:value-of select='param4'/></font></b>
			<font face="Arial" size="2"> en el Sistema SPIN</font>
		</td>
    </tr>
    <tr><td height="20%"></td><td></td></tr>
	<tr>
		<td><b><font face="Arial" size="2" color="#FF0000">ACCIÓN:</font></b></td>
		<td>
			<font face="Arial" size="2">De acuerdo con los procedimientos establecidos, se dispone de </font>
			<b><font face="Arial" size="2" color="#0000FF">treinta (30) días a partir de la fecha de solicitud </font></b>
			<font face="Arial" size="2">para ejecutar dicha acción en el Sistema SPIN. </font>
			<font face="Arial" size="2">Al vencer este plazo dicho informe de gastos será </font>
			<b><font face="Arial" size="2" color="#FF0000">RECHAZADO AUTÓMATICAMENTE POR EL SISTEMA SPIN</font></b>
		</td>
    </tr>
    <tr><td height="20%"></td><td></td></tr>
    <tr>
		<td><font face="Arial" size="2">Referencia:</font></td>
		<td><b><font face="Arial" size="2"><xsl:value-of select='param1'/></font></b></td>
    </tr>
    <tr><td height="20%"></td><td></td></tr>
    <tr>
		<td><font face="Arial" size="2">Solicitante:</font></td>
		<td><b><font face="Arial" size="2"><xsl:value-of select='param5'/></font></b></td>
    </tr>
    <tr><td height="40%"></td><td></td></tr>
    <tr>
		<td colspan="2"><font face="Arial" size="2">Para gestionar alguna acción relacionada por favor acceda al sistema en la siguiente dirección: "spin.ve.pwcinternal.com/Spin/ES/Principal/Default.aspx"</font></td>
    </tr>
    <tr><td height="20%"></td><td></td></tr>
    <tr>
		<td colspan="2" align="center"><font face="Arial" size="2">Política para la Elaboración, Envío y Aprobación de Informes de Gastos</font></td>
    </tr>
    <tr><td height="20%"></td><td></td></tr>
    <tr>
		<td colspan="2"><font face="Arial" size="2">Servidor: <xsl:value-of select='param7'/></font></td>
    </tr>
  </table>
</div>
</xsl:for-each>
</xsl:template>
</xsl:stylesheet>
