<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="WebGA.WebPage.ChatRoom.Chat" %>

<!DOCTYPE html">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>聊天室</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID ="message" runat="server"></asp:TextBox>
        <button id="send" onclick="login();">发送</button>
        <script type="text/javascript">
    //WebSocket的四个主要方法open onclose onerror send
    var  wsClient=new WebSocket( 'ws://localhost:65290');
    wsClient.open=function(e){
        console.log("连接!");
    }
    wsClient.onclose=function(e){
        console.log("关闭!");
    }
    wsClient.onmessage=function(e){
        console.log("接收消息:"+e.data);
    }
    wsClient.onerror=function(e){
        console.log(e.data);
    }
    function send(){
        var  oText=document.getElementById("message");
        wsClient.send(oText.value);
    }
        </script>
    </div>
    </form>
</body>
</html>
