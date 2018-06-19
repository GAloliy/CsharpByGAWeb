<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBarRelativePath.ascx.cs" Inherits="WebGA.WebPage.Template.MenuBarRelativePath" %>

       <!-- 顶部的导航栏 -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
      <a class="navbar-brand" id="homePost"  runat="server" href="#">欢迎━(*｀∀´*)ノ亻!</a>
      <button class="navbar-toggler collapsed" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation" style="">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="navbar-collapse collapse" id="navbarColor02" style="font-family:幼圆">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <a class="nav-link"  href="../Main.aspx"><i class="fa fa-home" aria-hidden="true"></i> Home <span class="sr-only">(current)</span></a>
          </li>
          
           <!-- 下拉框 -->         
          <li class="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown"><i class="fa fa-user" aria-hidden="true"></i> 用户</a>
              <div class="dropdown-menu">
                <a class="dropdown-item" href="../Membership/PersonalInfo.aspx"><i class="fa fa-address-card-o" aria-hidden="true"></i> 个人资料</a>
                <a class="dropdown-item" href="../Membership/UserLogin.aspx"><i class="fa fa-id-badge" aria-hidden="true"></i> 登录</a>
                <a class="dropdown-item" id="zhux" href="#" runat="server"><i class="fa fa-reply" aria-hidden="true"></i> 注销</a>
              </div>
          </li>
          
        <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="navsearchdrop" data-toggle="dropdown"><i class="fa fa-search" aria-hidden="true"></i> 搜索框</a>
            
            <div class="dropdown-menu">
                <!-- 搜索表单 -->
                <div class="form-inline my-2 my-lg-0 dropdown-item" id="formSearch">
                  <input class="form-control mr-sm-2" type="text" placeholder="搜索">
                  <button class="btn btn-outline-secondary my-2 my-sm-0" type="submit">搜索</button>
                </div>
            </div>
        </li>
         
          <li class="nav-item">
            <a class="nav-link" href="../FaceRecognition/FaceReconition.aspx"><i class="fa fa-smile-o" aria-hidden="true"></i> 人脸识别</a>
          </li>

          <li class="nav-item">
            <a class="nav-link" href="../MassageBoard/MassageBoard.aspx"><i class="fa fa-align-left" aria-hidden="true"></i> 留言板</a>
          </li>
          
          <li class="nav-item">
            <a class="nav-link" href="../About.aspx"><i class="fa fa-question-circle-o" aria-hidden="true"></i> 关于</a>
          </li>
        </ul>
      </div>
    </nav>