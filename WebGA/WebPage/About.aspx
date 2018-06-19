<%@ Page Language="C#" MasterPageFile="~/WebPage/Template/Main.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebGA.WebPage.About" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>关于</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<div style="width:80%;margin-top:8%;margin-left:5%;font-family:幼圆">
    <ul class="nav nav-tabs">
  <li class="nav-item">
    <a class="nav-link active show" href="#home" data-toggle="tab">关于本网站</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" href="#profile" data-toggle="tab">编程社<span class="badge badge-pill badge-primary">点我点我!</span></a>
  </li>
</ul>
<div class="tab-content" id="Div1">
  <div class="tab-pane fade active show" id="home">
    <p class="mb-0">由于时间太仓促,前端不熟悉,也没功夫弄美工(如果有漂亮小姐姐加入就好了desu)所以网站就成这个样子了。前端有借鉴网上大佬的操作(所以那部分版权归作者所有)后台是三层结构加上一个基础类库,后台基本上是完善的(就是有些我不知道的Bug),如果想问我该网站更多的细节可以进群找我,本网站难免会有Bug,请多多见谅！最后:感谢柯老师和其他老师的指导和帮助!</p>
     <blockquote class="blockquote text-right">
        <footer class="blockquote-footer">都是朕的错! From <cite title="Source Title">副社的留言</cite></footer>
    </blockquote>
  </div>
  <div class="tab-pane fade" id="profile">
    <p calss="mb-0">关于编程社,说来遗憾创建后基本很少搞活动,所以创建者之一的我想说(真是难受的索不出Fuck):因为我们的一些原因(经常去图书馆查阅资料,研究网站框架,所有知识都是从0开始的)没有继续组织社团活动,我觉得有所失职,实在是对不住了各位社员,请多多原谅! 如果各位社员有什么建议,可以提出来,我们会依据实际情况举办活动!</p>
    <blockquote class="blockquote text-right">
        <footer class="blockquote-footer">都是朕的错! From <cite title="Source Title">副社的留言</cite></footer>
    </blockquote>
  </div>
</div>
    <div class ="text-center" style="margin-top:300px;"><p> &copy; 2018 <br />GAWeb</p>Designer by GAloliy</div>
</div>
</asp:Content>
