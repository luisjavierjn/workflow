<?xml version="1.0"?>
<xsl:stylesheet version = "1.0" xmlns:xsl = "http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<xsl:for-each select='root'>
<div align="left">
  <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="802" height="1" id="AutoNumber1">
    <tr>
      <td width="802" height="1"><img border="0" src="http://ve-admapp003/Spin/WF/EWIGF01.gif"/></td>
    </tr>
  </table>
</div>
<p><font face="Arial" size="2">Un documento de &quot;<xsl:value-of select='param0'/>&quot; <xsl:value-of select='param3'/></font></p>
<p><font face="Arial" size="2">El identificador del documento es:</font></p>
<p><font face="Arial" size="2">Referencia: </font><xsl:value-of select='param1'/></p>
<p><font face="Arial" size="2">El creador del documento es:</font></p>
<p><font face="Arial" size="2">Solicitante: </font><xsl:value-of select='param2'/></p>
<p><b><font face="Arial" size="2" color="#FF0000">Para gestionar alguna acción relacionada con esta solicitud
por favor acceda al sistema en el siguiente link:</font></b></p>
<p><font face="Arial" size="2">spin.ve.pwcinternal.com</font></p>
<p><font face="Arial" size="2">Servidor: </font><xsl:value-of select='param4'/></p>

</xsl:for-each>
</xsl:template>
</xsl:stylesheet>