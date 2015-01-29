<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" 
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"
xmlns:d="http://tempuri.org/"
xmlns:a="http://schemas.datacontract.org/2004/07/DataContracts"
xmlns:i="http://www.w3.org/2001/XMLSchema-instance"
xmlns:b="http://schemas.microsoft.com/2003/10/Serialization/Arrays">
<xsl:variable name="root" select="/Timesheet"/>
<xsl:template match="/">
  <html>
  <body>
  <h2>UNN Timesheet</h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th style="text-align:left">Weekday</th>
        <th style="text-align:left">Time</th>
        <xsl:for-each select="$root/Headers/GroupList/int">
        <td><xsl:value-of select="."/></td>
        </xsl:for-each>
      </tr>
      <xsl:for-each select="$root/Headers/WeekdayList/Weekday">
      <xsl:variable name="day" select="."/>
        <xsl:for-each select="$root/Headers/StartTimeList/string">
        <xsl:variable name="time" select="."/>
        <tr>
          <xsl:if test="position() = 1">
          <td rowspan="8"><xsl:value-of select="$day"/></td>
          </xsl:if>
          <td><xsl:value-of select="."/></td>
          <xsl:for-each select="$root/Headers/GroupList/int">
          <xsl:variable name="group" select="."/>
          <xsl:variable name="class" select="$root/Classes/Class[Weekday=$day and StartTime=$time and Groups/Group/GroupId=$group]"/>
          <xsl:choose>
           <xsl:when test="$class">
             <td BGCOLOR="#CCCCCC">
               <b><xsl:value-of select="$class/ClassName"/></b> <br/> 
               <xsl:value-of select="$class/Teacher/LastName"/>&#160;<xsl:value-of select="$class/Teacher/FirstName"/> <br/>
               <xsl:value-of select="$class/Room/RoomNumber"/>&#160;(<xsl:value-of select="$class/Room/BuildingId"/>)
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