<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" 
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"
xmlns:d="http://tempuri.org/"
xmlns:a="http://schemas.datacontract.org/2004/07/DataContracts"
xmlns:i="http://www.w3.org/2001/XMLSchema-instance"
xmlns:b="http://schemas.microsoft.com/2003/10/Serialization/Arrays">
<xsl:variable name="root" select="/s:Envelope/s:Body/d:GetTimesheetResponse/d:GetTimesheetResult"/>
<xsl:template match="/">
  <html>
  <body>
  <h2>UNN Timesheet</h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th style="text-align:left">Weekday</th>
        <th style="text-align:left">Time</th>
        <xsl:for-each select="$root/a:Headers/a:GroupList/b:int">
        <td><xsl:value-of select="."/></td>
        </xsl:for-each>
      </tr>
      <xsl:for-each select="$root/a:Headers/a:WeekdayList/a:Weekday">
      <xsl:variable name="day" select="."/>
        <xsl:for-each select="$root/a:Headers/a:StartTimeList/b:string">
        <xsl:variable name="time" select="."/>
        <tr>
          <xsl:if test="position() = 1">
          <td rowspan="8"><xsl:value-of select="$day"/></td>
          </xsl:if>
          <td><xsl:value-of select="."/></td>
          <xsl:for-each select="$root/a:Headers/a:GroupList/b:int">
          <xsl:variable name="group" select="."/>
          <xsl:variable name="class" select="$root/a:Classes/a:Class[a:Weekday=$day and a:StartTime=$time and a:Groups/a:Group/a:GroupId=$group]"/>
          <xsl:choose>
           <xsl:when test="$class">
             <td BGCOLOR="#CCCCCC">
               <b><xsl:value-of select="$class/a:ClassName"/></b> <br/> 
               <xsl:value-of select="$class/a:Teacher/a:LastName"/>&#160;<xsl:value-of select="$class/a:Teacher/a:FirstName"/> <br/>
               <xsl:value-of select="$class/a:Room/a:RoomNumber"/>&#160;(<xsl:value-of select="$class/a:Room/a:BuildingId"/>)
             </td>
           </xsl:when>
           <xsl:otherwise>
             <td></td>
           </xsl:otherwise>
          </xsl:choose>
          </xsl:for-each>
        </tr>
        </xsl:for-each>
      </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>