<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBarControl.ascx.cs" Inherits="WebGA.WebPage.ProgrammingSociety.Template.MenuBarControl" %>

<!-- 顶部的导航栏 -->
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="#">编程社后台</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor03" aria-controls="navbarColor03" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarColor03">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">网站设置</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">订阅管理</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#">关于</a>
      </li>
    </ul>
    <form class="form-inline my-2 my-lg-0">
      <input class="form-control mr-sm-2" type="text" placeholder="搜索">
      <button class="btn btn-secondary my-2 my-sm-0" type="submit">搜索</button>
    </form>
  </div>
</nav>