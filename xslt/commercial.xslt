<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:c="http://my.company.com"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="c:commercials">
        <publications>
          <xsl:apply-templates select="c:commercial" />
        </publications>
    </xsl:template>
  <xsl:template match="c:commercial">
         <commercial>
           <company>
             <xsl:value-of select="@company"/>   
           </company>
           <website>
             <xsl:value-of select="c:webpage"/>
           </website>
           <logo>
             <xsl:value-of select="c:logo"/>
           </logo>
        </commercial>
  </xsl:template>
</xsl:stylesheet>
