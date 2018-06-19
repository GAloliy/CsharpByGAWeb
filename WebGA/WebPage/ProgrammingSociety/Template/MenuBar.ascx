<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBar.ascx.cs" Inherits="WebGA.WebPage.ProgrammingSociety.Template.MenuBar" %>

<!-- 顶部导航栏部分 -->
<nav class ="navbar navbar-inverse">
    <div class="container-fluid">
        <a class="navbar-brand" title="logoTitle" href="#">编程社后台管理</a>
    </div>
    <div class="collapse navbar-collapse">
        <ul class="nav navbar-nav navbar-right">
            <li role="presentation">
                <a href="#">当前用户：<span class="badge">TestUse</span></a>
            </li>
            <li>
                <a href="#"><span class="glyphicon glyphicon-lock"></span>退出登录</a>
            </li>
        </ul>
    </div>
</nav>