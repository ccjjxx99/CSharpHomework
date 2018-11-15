<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/Order">
    <html>
      <head>
        <title>Order</title>
      </head>
      <body>
        <h1>
          订单编号  <xsl:value-of select="Id"/>
        </h1>
        <table border="1">
          <tr bgcolor="#EEEEEE">
            <th>客户编号</th>
            <th>客户姓名</th>
            <th>客户手机</th>
          </tr>
          <tr>
            <xsl:for-each select="Customer">
              <td>
                <xsl:value-of select="Id"/>
              </td>
              <td>
                <xsl:value-of select="Name"/>
              </td>
              <td>
                <xsl:value-of select="Phone"/>
              </td>
            </xsl:for-each>
          </tr>
        </table>

        <h2>订单明细</h2>

        <table border="1">
          <tr  bgcolor="#EEEEEE">
            <th>明细编号</th>
            <th>商品编号</th>
            <th>商品名</th>
            <th>商品价格</th>
            <th>购买数量</th>
          </tr>
          <xsl:for-each select="details">
            <xsl:for-each select="OrderDetail">
              <tr>
                <td>
                  <xsl:value-of select="Id"/>
                </td>
                <xsl:for-each select="Goods">
                  <td>
                    <xsl:value-of select="Id"/>
                  </td>
                  <td>
                    <xsl:value-of select="Name"/>
                  </td>
                  <td>
                    <xsl:value-of select="Price"/>
                  </td>
                </xsl:for-each>
                <td>
                  <xsl:value-of select="Quantity"/>
                </td>
              </tr>
            </xsl:for-each>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>