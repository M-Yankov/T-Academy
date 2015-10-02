<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                              xmlns:mine="urn:students"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/mine:university">
    <html>
      <head>
        <style rel="text/stylesheet">

          body {
          font-family: Arial;
          font-size: 14px;
          }

          body h3 {
          text-align: center;
          }

          body table th.width, td.width {
          width: 125px;
          }

          body table td, th {
          text-align: center;
          }

          body table td.left {
          text-align: left;
          }

          body .exam-name {
          font-weight: bold;
          }
          
          body .exam-tutor {
          font-style: italic;
         }
         
         body .exam-score {
          text-decoration: underline;
         }
        </style>
      </head>
      <body>
        <h3>Welcome to university</h3>
        <h4>Students:</h4>
        <table border="1" cellpadding="5" cellspacing="0">
          <thead>
            <tr>
              <th>Name:</th>
              <th>Sex:</th>
              <th>Birth Date:</th>
              <th class="width">Phone:</th>
              <th>Email:</th>
              <th>Course:</th>
              <th>Speciality:</th>
              <th>Faculty number:</th>
              <th>Exams:</th>
              <th>Enrollments:</th>
              <th>Endrosments:</th>
            </tr>
          </thead>
          <tbody>
            <span>
            </span>
            <xsl:for-each select="mine:students/mine:student">
              <tr>
                <td><xsl:value-of select="mine:name"/></td>
                <td><xsl:value-of select="mine:sex"/></td>
                <td><xsl:value-of select="mine:birdthdate"/></td>
                <td><xsl:value-of select="mine:phone"/></td>
                <td><xsl:value-of select="mine:email"/></td>
                <td><xsl:value-of select="mine:course"/></td>
                <td><xsl:value-of select="mine:spceiality"/></td>
                <td><xsl:value-of select="mine:facultyNumber"/></td>

                <td class="left">
                  <ul>
                  <xsl:for-each select="mine:exams/mine:exam">
                    <li>
                      <span class="exam-name"> <xsl:value-of select="mine:name"/>
                       </span> by 
                      <span class="exam-tutor"><xsl:value-of select="mine:tutor"/>&#160;
                      </span>  
                      <span class="exam-score">achieved: <xsl:value-of select="mine:score"/>
                    </span>
                    </li>
                  </xsl:for-each>
                  </ul>
                </td>
                
                <td class="left width">
                  <xsl:for-each select="mine:enrollments/mine:enrollment">
                    <strong>
                      <xsl:value-of select="mine:date"/>
                    </strong>
                    - 
                    <em>
                      <xsl:value-of select="mine:Score"/>
                    </em>
                    <br/>
                  </xsl:for-each>
                </td>
                
                <td class="left">
                  <dl>
                  <xsl:for-each select="mine:endrosmnets/mine:endrosment">
                    <dt>
                      <xsl:value-of select="mine:tutor"/> said:
                    </dt>
                    <dd>
                      <xsl:value-of select="mine:message"/>
                    </dd>
                  </xsl:for-each>
                  </dl>
                </td>
              </tr>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
    <!--<xsl:copy>
      <xsl:apply-templates select="@* | node()"/>
    </xsl:copy>-->
  </xsl:template>
</xsl:stylesheet>
