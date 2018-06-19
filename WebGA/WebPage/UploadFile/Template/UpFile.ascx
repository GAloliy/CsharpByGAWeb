<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpFile.ascx.cs" Inherits="WebGA.WebPage.UploadFile.Template.UpFile" %>

   <!-- 顶部的导航栏 -->
<nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
  <a class="navbar-brand" href="#">编程社后台</a>
  <button class="navbar-toggler collapsed" type="button" data-toggle="collapse" data-target="#navbarColor02" aria-controls="navbarColor02" aria-expanded="false" aria-label="Toggle navigation" style="">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="navbar-collapse collapse" id="navbarColor02" style="">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="../Main.aspx">Home <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="UploadFile.aspx">上传文件</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="CommentManagement.aspx">评论管理</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="MembershipManagement.aspx">会员管理</a>
      </li>
    </ul>
    <!-- 搜索表单 -->
    <form class="form-inline my-2 my-lg-0" id="formSearch">
      <input class="form-control mr-sm-2" type="text" placeholder="搜索">
      <button class="btn btn-secondary my-2 my-sm-0" type="submit">搜索</button>
    </form>
  </div>
</nav>