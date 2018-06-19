<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MembershipManagement.aspx.cs" Inherits="WebGA.WebPage.UploadFile.MembershipManagement" %>
<%@ Register Src="~/WebPage/UploadFile/Template/UpFile.ascx" TagName="bar" TagPrefix="upBar" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>成员管理</title>
    <script type="text/javascript" src="../../Content/js/jquery-3.3.1.min.js"></script>
    <link type="text/css" rel="Stylesheet" href="../../Content/css/bootstrap.min.css" />
    <script type="text/javascript" src="../Resources/js/ManagementMain.js"></script>
</head>
<body style="margin-top:160px">
    <upBar:bar ID="bar" runat="server" />
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
  
        <div class="row clearfix">
        <div class="col-md-10">
            <div style="border:1px solid red;">
            <div class="table-responsive">
                <table class="table">
                    <caption>成员管理</caption>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>LoginID</th>
                            <th>Name</th>
                            <th>Address</th>
                            <th>Phone</th>
                            <th>Mail</th>
                            <th>Character</th>
                            <th>Status</th>
                            <th>LastLoginTime</th>
                            <th>PersonalProfile</th>
                        </tr>
                    </thead>
                    <tbody id="tbody" runat="server">
                        
                    </tbody>
                    </table>
                </div>
                </div>
        
              
              <!-- 模态框 -->
              <div class="modal fade" id="myModal">
                <div class="modal-dialog modal-lg">
                  <div class="modal-content">
               
                    <!-- 模态框头部 -->
                    <div class="modal-header">
                      <h4 class="modal-title">修改成员资料</h4>
                      <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
               
                    <!-- 模态框主体 -->
                    <div class="modal-body">
                      
                      <div class="card mb-3">
                      
                          <h3 class="card-header">编辑</h3>
                          <div class="card-body">
                            <h5 class="card-title">登录账号</h5>
                            <h6 class="card-subtitle text-muted" id="displayLogId">LoginID</h6>
                          </div>

                          <div class="card-body">
                          <hr />
                            <p class="card-text">个人简介:</p>
                            <div class="form-group">
                                <textarea cols="30" class="form-control" id="signature" rows="5" ></textarea>
                            </div>
                          </div>
                          <ul id="Ul1" class="list-group list-group-flush" runat="server">
                            <li class="list-group-item">名 &nbsp&nbsp&nbsp&nbsp 称:<input type="text" class="form-control" id="txtName" /></li>
                            <li class="list-group-item">角 &nbsp&nbsp&nbsp&nbsp 色:<select id="role" class="form-control" runat="server"></select></li>
                            <li class="list-group-item">地 &nbsp&nbsp&nbsp&nbsp 址:<input type="text"  class="form-control" id="txtAddress" /></li>
                            <li class="list-group-item">手机号码:<input type="text"  class="form-control" id="txtPhone" /></li>
                            <li class="list-group-item">邮箱地址:<input type="text"  class="form-control" id="txtMail" /></li>
                          </ul>
                          
                          <div class="container">
                              
                              
                            
                          <div class="card-footer text-muted">
                              <button type="button" id="delInfo" class="btn btn-outline-danger" data-dismiss="modal">删除</button>                                                  
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
          
          <div class="col-md-2" style="background-color:Highlight;font-family:幼圆">
             <!-- 分页 -->
	            <div>
	            
                  <ul class="pagination">
                    <li class="page-item">
                      <a class="page-link" id="pagingProviousPage" runat="server" href="#">&laquo;</a>
                    </li>
                    <li class="page-item active">
                      <a class="page-link" id="pagingFistPage" runat="server" href="#">First</a>
                    </li>
                    <li class="page-item">
                      <a class="page-link" id="pagingLastPage" runat="server" href="#">Last</a>
                    </li>
                    <li class="page-item">
                      <a class="page-link" id="pagingNextPage" runat="server" href="#">&raquo;</a>
                    </li>
                      
                  </ul>
                  跳转到：<input type="text" class="" id="pagingGotoPage" runat="server" />页<button type="button" id="pagingbtnGotoPage" class="btn-info" runat="server">跳转</button>
                  <a class="m-0" id="pagingIndexPage" runat="server">当前页</a><p id="da" runat="server"></p>
                  <a class="m-0" id="pagingAllPage" runat="server">一共有90条数据</a>
                  
                </div>
          </div>
    </div> 
    </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" src="../../Content/js/bootstrap.min.js"></script>
    </form>
    <div class ="text-center"><p> &copy; 2018 <br />GAWeb</p>Designer by GAloliy</div>
    </body>
</html>
