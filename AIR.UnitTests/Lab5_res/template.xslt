<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:template match="/">
    <html>
      <head>
        <title>DS</title>
      </head>
      <style>
        .lt100 { background-color: antiquewhite; }
        .lt200 { background-color: burlywood; }
        .gt200 { background-color: darkgreen; }
        .table {margin: auto;}
        thead tr {background-color: black; color: white;}
      </style>
      <body>
        <table class="table">
          <thead>
            <tr>
              <td>Item</td>
              <td>Capacity</td>
              <td>Recording Speed</td>
              <td>Additional data</td>
            </tr>
          </thead>
          <tbody>
            <xsl:for-each select="//collection/node()">
              <xsl:if test="name(.) != '' ">
                <tr>
                  <xsl:if test="Capacity &lt; 100">
                    <xsl:attribute name="class">
                      <xsl:text>lt100</xsl:text>
                    </xsl:attribute>
                  </xsl:if>
                  <xsl:if test="Capacity &lt; 200 and  Capacity &gt; 100">
                    <xsl:attribute name="class">
                      <xsl:text>lt200</xsl:text>
                    </xsl:attribute>
                  </xsl:if>
                  <xsl:if test="Capacity &gt; 200">
                    <xsl:attribute name="class">
                      <xsl:text>gt200</xsl:text>
                    </xsl:attribute>
                  </xsl:if>
                  <td>
                    <xsl:value-of select="name(.)"/>
                  </td>
                  <td>
                    <xsl:value-of select="Capacity"/>
                  </td>
                  <td>
                    <xsl:value-of select="RecordingSpeed"/>
                  </td>
                  <td>
                    <xsl:if test="Diameter != ''">
                      <div>
                        <p>Diameter</p>
                        <p>
                          <xsl:value-of select="Diameter"/>
                        </p>
                      </div>
                    </xsl:if>
                    <xsl:if test="Interface != ''">
                      <div>
                        <p>Interface</p>
                        <p>
                          <xsl:value-of select="Interface"/>
                        </p>
                      </div>
                    </xsl:if>
                  </td>
                </tr>
              </xsl:if>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
