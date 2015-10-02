<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                >
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/catalogue">
    <html>
      <head>
        <title>Task 13</title>
        <style rel="text/stylesheet">
          body {
          font-family: Arial;
          }
          h3 {
          text-align: center;
          }

          table {
          background-color: #41210C;
          }

          table td, th {
          border: 5px brown ridge;
          background-color: #2C1504;
          color:white;
          -webkit-box-sizing: border-box; 
          -moz-box-sizing: border-box;    
          box-sizing: border-box;
          position: relative;
          }

          table td > div, th > div {
          position: relative;
          
          }

          table td:hover, th:hover {
          border: 5px brown groove;

          }

          table td:hover > div, th:hover > div {
          /*margin-left: 2px;
          margin-top: 2px*/
          left: 2px;
          top: 2px;
          }
        </style>
      </head>
      <body>
        <h3>Catalog - Albums <em>It looks like a chocolate mmmm.</em></h3>
        <table border="1" cellpadding="10" cellspacing="5">
          <thead>
            <tr>
              <th>
                <div>Name</div>
              </th>
              <th>
                <div>Artist</div>
              </th>
              <th>
                <div>Year</div>
              </th>
              <th>
                <div>Producer</div>
              </th>
              <th>
                <div>Price</div>
              </th>
              <th>
                <div>Songs</div>
              </th>
            </tr>
          </thead>
          <tbody>
            <xsl:for-each select="albums/album">
              <tr>
                <td>
                  <div>
                    <xsl:value-of select="name"/>
                  </div>
                </td>
                <td>
                  <div>
                    <xsl:value-of select="artist"/>
                  </div>
                </td>
                <td>
                  <div>
                    <xsl:value-of select="year"/>
                  </div>
                </td>
                <td>
                  <div>
                    <xsl:value-of select="producer"/>
                  </div>
                </td>
                <td>
                  <div>
                    <xsl:value-of select="price"/>
                  </div>
                </td>
                <td>
                  <div>
                    <ul>
                      <xsl:for-each select="songs/song">
                        <li>
                          <span class="underline">
                            <xsl:value-of select="title"/>
                          </span>
                          <span> - </span>
                          <strong>
                            <xsl:value-of select="duration"/>
                          </strong>
                        </li>
                      </xsl:for-each>
                    </ul>
                  </div>
                </td>
              </tr>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
