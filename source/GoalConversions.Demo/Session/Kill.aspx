<%@ Page Language="C#" AutoEventWireup="true" %>
<script runat="server">
public void Page_Load(object sender, EventArgs args)
{
 
 Session.Abandon();
}
</script>
<html>
 <body>
  <p>The session was abandoned.</p>
 </body>
</html>