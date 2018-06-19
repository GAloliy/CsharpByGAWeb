<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="WebGA.WebPage.Membership.PersonalInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/WebPage/Template/MenuBarRelativePath.ascx" TagName="bar" TagPrefix="relativepath"  %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>个人信息-<%=GetUserInfo(UserInfo.name)%></title>
    
    <script type="text/javascript" src="../../Content/js/jquery-3.3.1.min.js"></script>
    <link rel="Stylesheet" href="../../Content/css/bootstrap.min.css" type="text/css"/>
    <link rel="Stylesheet" href="../../Content/css/font-awesome.min.css" type="text/css" />
</head>
<body style="margin-top:85px">

 <relativepath:bar  ID="bar" runat="server"/>

<form id="form1" runat="server" style="font-family:幼圆">    
       
    <div style="width:65%;margin-left:10%;margin-top:120px">
        <div class="card mb-3">
          <h3 class="card-header"><%=GetUserInfo(UserInfo.name)%></h3>
          <div class="card-body">
            <h5 class="card-title">登录账号</h5>
            <h6 class="card-subtitle text-muted"><%=GetUserInfo(UserInfo.loginId) %></h6>
          </div>
          <div style="margin-right:auto;margin-left:auto;float:none;display:block;">
            <img class=" img-responsive img-thumbnail" src=<%=GetImageURI()%> alt="Card image">          
          </div>
          <hr />
          <div class="card-body">
            <p class="card-text">个人简介:<%=GetUserInfo(UserInfo.perSonalSynopsis) %></p>
          </div>
          <ul class="list-group list-group-flush">
            <li class="list-group-item">地址:<%=GetUserInfo(UserInfo.address) %></li>
            <li class="list-group-item">邮箱:<%=GetUserInfo(UserInfo.mail) %></li>
            <li class="list-group-item">手机号码:<%=GetUserInfo(UserInfo.phone) %></li>
            <li class="list-group-item">账号身份:<%=GetUserInfo(UserInfo.role) %></li>
            <li class="list-group-item">最后登录时间:<%=GetUserInfo(UserInfo.LastOnlineTime) %></li>
          </ul>
          <div class="card-body">
          
            <div class="container">
              <h2>资料修改</h2>
              <!-- 按钮：用于打开模态框 -->
              <button type="button" class="btn btn-outline-info" data-toggle="modal" data-target="#myModal">
                打开修改框
              </button>
              
              <!-- 模态框 -->
              <div class="modal fade" id="myModal">
                <div class="modal-dialog modal-lg">
                  <div class="modal-content">
               
                    <!-- 模态框头部 -->
                    <div class="modal-header">
                      <h4 class="modal-title">修改资料</h4>
                      <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
               
                    <!-- 模态框主体 -->
                    <div class="modal-body">
                      
                      <div class="card mb-3">
                      
                          <h3 class="card-header"><%=GetUserInfo(UserInfo.name) %></h3>
                          <div class="card-body">
                            <h5 class="card-title">登录账号</h5>
                            <h6 class="card-subtitle text-muted"><%=GetUserInfo(UserInfo.loginId) %></h6>
                          </div>
                          <div class="carousel-inner center">
                            <img class="img-responsive rounded-circle" alt="Card image" src="../../images/avatar_default.jpg">
                            <div class="carousel-caption"><a class="m-2">暂未开放上传图片</a></div>
                          </div>
                          <div class="card-body">
                          <hr />
                            <p class="card-text">个人简介:</p>
                            <div class="form-group">
                                <textarea class="form-control" id="signature" rows="5" runat="server"></textarea>
                                <span id="spSignature" runat="server"></span>
                            </div>
                          </div>
                          <ul id="Ul1" class="list-group list-group-flush" runat="server">
                            <li class="list-group-item">名 &nbsp&nbsp&nbsp&nbsp 称:<input type="text" class="form-control" id="txtName" runat="server" /><span id="apName" runat="server"></span></li>
                            <li class="list-group-item">地 &nbsp&nbsp&nbsp&nbsp 址:<input type="text"  class="form-control" id="txtAddress" runat="server" /><span id="spAdress"></span></li>
                            <li class="list-group-item">手机号码:<input type="text"  class="form-control" id="txtPhone" runat="server"  /><span id="spPhone"></span></li>
                            <li class="list-group-item">邮箱地址:<input type="text"  class="form-control" id="txtMail" runat="server" /><span id="spMail"></span></li>
                          </ul>>
                          
                          <div class="container">
                              <h2>密码</h2>
                              <a href="#demo" class="btn btn-outline-info" data-toggle="collapse">修改</a>
                              <hr />
                              <div id="demo" class="collapse">
                                <label for="oldPassword">旧密码</label>
                                <input class="form-control" id="oldPassword" type="password" placeholder="请输入原密码" runat="server"/>
                                <hr />
 
                              <div class="m">
                                 <label for="nodifyNewPassword">新密码</label>
                                 <input id="nodifyNewPassword" class="form-control" type="password" placeholder = "请输入6-20位密码" runat="server" />
                                 <hr />
                                 <label for="reNodifyNewPassword">确认密码</label>
                                <input class="form-control" id="reNodifyNewPassword" type="password" placeholder="请输入确认密码" runat="server" disabled="disabled" />
                                <span id="spanRe"></span>
                                
                                 <hr /> 
                                 <button class="btn btn-outline-info" id="btnSavePwd" type="button" runat="server" disabled="disabled" >保存密码</button>
                                 <span id="relut" runat="server"></span>
                                <hr />
                              </div>
                            </div>
                            
                          <div class="card-footer text-muted">
                            2 days ago
                          </div>
                        </div>
                    </div>
               
                    <!-- 模态框底部 -->
                    <div class="modal-footer">
                      <button type="button" class="btn btn-outline-info" id="btnModifyInfo" runat="server">保存</button>
                      <button type="button" class="btn btn-outline-danger" data-dismiss="modal">关闭</button>
                    </div>

                  </div>
                </div>
              </div>
              
            </div><!-- 模拟框 -->
            
          </div>
          <div id ="showDate" class="card-footer text-muted">
          时间
          </div>
          <script type="text/javascript">
          
            $(function(){
                setInterval("getTime();",1000);
            });
          
            function getTime(){
                var myDate = new Date();
                var date = myDate.toLocaleDateString();
                var hours = myDate.getHours();
                var minutes = myDate.getMinutes();
                var seconds = myDate.getSeconds();
                $("#showDate").html(date + ":" + hours + ":" + minutes + ":" + seconds);
            }
          </script>
        </div>
               
    </div>
    </form>
    
    <div class ="text-center"><p> &copy; 2018 <br />GAWeb</p>Designer by GAloliy</div>
    
    <script type="text/javascript" src="../../Content/js/bootstrap.min.js"></script>
    <script type="text/jscript" src="Resources/js/ModifyPassword.js"></script>
</body>
</html>
