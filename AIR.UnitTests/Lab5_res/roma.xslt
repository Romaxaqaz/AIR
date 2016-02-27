<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:template match="/">
    <html>
      <body>
        <h2>Data</h2>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th style="text-align:center; font-size:16pt;">Name</th>
            <th style="text-align:center; font-size:16pt;">Diameter</th>
            <th style="text-align:center; font-size:16pt;">Capacity</th>
            <th style="text-align:center; font-size:16pt;">RecordingSpeed</th>
            <th style="text-align:center; font-size:16pt;">Interface</th>
          </tr>
          <xsl:for-each select="collection/node()">
            <xsl:choose>
              <xsl:when test="@type = 'CD'">
                <tr style="background-color:#0033cc; 
                           color: white; 
                           text-align:right">
                  <td>
                    <xsl:value-of select="name(.)"/>
                  </td>
                  <td>
                    <xsl:value-of select="Diameter"/>
                  </td>
                  <td>
                    <xsl:value-of select="Capacity"/>
                  </td>
                  <td>
                    <xsl:value-of select="RecordingSpeed"/>
                  </td>
                  <td>
                    <xsl:value-of select="Interface"/>-
                  </td>
                </tr>
              </xsl:when>
              <xsl:when test="@type = 'HDD'">
                <tr style="background-color:#ffff00; 
                           text-align:left">
                  <td>
                    <xsl:value-of select="name(.)"/>
                  </td>
                  <td>
                    <xsl:value-of select="Diameter"/>
                  </td>
                  <td>
                    <xsl:value-of select="Capacity"/>
                  </td>
                  <td>
                    <xsl:value-of select="RecordingSpeed"/>
                  </td>
                  <td>
                    <xsl:value-of select="Interface"/>
                  </td>
                </tr>
              </xsl:when>
            </xsl:choose>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

