<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MassageBoard.aspx.cs" Inherits="WebGA.WebPage.MassageBoard.MassageBoard" %>
<%@ Register Src="~/WebPage/Template/MenuBarRelativePath.ascx" TagName="bar" TagPrefix="relativepath" %>

<!DOCTYPE html>

<head id="Head1" runat="server">
    <title>编程社留言板</title>
    <link href="../../Content/css/bootstrap.min.css" rel="Stylesheet"  type="text/css"/>
    <link href="../../Content/css/font-awesome.min.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        

        .content{width:520px;margin:50px auto;}
        /* fl_menu */
        #fl_menu{position:absolute;top:100px;left:0px;z-index:9999;width:50px;height:50px;}
        #fl_menu .label{padding-left:20px;line-height:50px;font-size:14px;font-weight:bold;background:#000;color:#fff;letter-spacing:7px;}
        #fl_menu .menu{display:none;}
        #fl_menu .menu .menu_item{display:block;background:#000;color:#bbb;border-top:1px solid #333;padding:10px 20px;font-size:12px;text-decoration:none;}
        #fl_menu .menu a.menu_item:hover{background:#333;color:#fff;}        
    </style>
</head>
<body style="font-family:幼圆">
    <relativepath:bar ID="menubar" runat="server" />

    <form id="formForum" runat="server">
            <div class="container" style="margin-top:150px">
	        <div class="row clearfix">
		        <div class="col-md-8 column">
			        <div class="row clearfix">
				        <div class="col-md-12 column">
        				
				            <!-- 轮播 -->
                            <div id="mark" class="carousel slide" data-ride="carousel">
                             
                              <!-- 指示符 -->
                              <ul class="carousel-indicators">
                                <li data-target="#mark" data-slide-to="0" class="active"></li>
                                <li data-target="#mark" data-slide-to="1"></li>
                                <li data-target="#mark" data-slide-to="2"></li>
                              </ul>
                              
                             <a name="top"></a>
                             
                              <!-- 轮播图片 -->
                              <div class="carousel-inner">
                                <div class="carousel-item active">
                                  <img src="../../images/haixiao.png" class="img-responsive center-block" >
                                  <div class="carousel-caption">
                                    <h3 class="text-primary" ><strong style="color:Blue;">广东省海洋工程职业技术学校</strong></h3>
                                    <p><em>广东省海洋工程职业技术学校（原广东省水产学校）创办于1935年，隶属于广东省海洋与渔业局，是公立全日制国家级重点学校，全国职业教育先进单位，省示范性中等职业学校，省高技能人才培养试点学校。....</em></p>
                                  </div>
                                </div>
                                <div class="carousel-item">
                                  <img src="../../images/haixiao1.jpg">
                                  <div class="carousel-caption">
                                    <h3><strong style="color:Blue;">学校介绍</strong></h3>
                                    <p>目前，学校内设有五十多间先进的实验实训室，校外设有六十多个企业实习基地，是全国中高级制冷工、中高级养成工、中高级计算机操作员、高级食品检验工证、会计从业资格证、制冷技师、养成技师、网络工程师等多种资格证书的考试单位。....</p>
                                  </div>
                                </div>
                                <div class="carousel-item">
                                  <img src="../../images/haixiao2.jpg">
                                  <div class="carousel-caption">
                                    <h3><strong style="color:Blue;">校长寄语</strong></h3>
                                    <p>厚德重技、质量立校、就业导向、高端带动、校企合作、从严治校</p>
                                  </div>
                                </div>
                              </div>
                             
                              <!-- 左右切换按钮 -->
                              <a class="carousel-control-prev" href="#mark" data-slide="prev">
                                <span class="carousel-control-prev-icon"></span>
                              </a>
                              <a class="carousel-control-next" href="#mark" data-slide="next">
                                <span class="carousel-control-next-icon"></span>
                              </a>
                             
                            </div> 
                            
        						
				        </div>
			        </div>
        			
			        <div class="page-header">
			            <hr />
				        <h1>
					        海校编程社论坛 <small>在这发布你的创意！</small>
				        </h1>
			        </div>
                    <hr />
                    <asp:ScriptManager ID="ScriptManagerMB" runat="server" ScriptMode="Auto">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="upMassageBorad" runat="server">
                    <ContentTemplate>
                    	 <blockquote>
				            <p>
					            该页面于测试阶段可能会有BUG!如遇BUG,请尝试联系我! (摊手
				            </p> <small>Form <cite>副社</cite></small>
			            </blockquote>
                        <hr /> 		       
			            
                        <div class="list-group" id="divMassageBorad" runat="server">
                        
                        
                       </div>	
                       <hr />
                       <!-- 分页 -->
			            <div>
			            
                          <ul class="pagination">
                            <li class="page-item">
                              <a class="page-link" id="pagingProviousPage" runat="server" href="#">&laquo;</a>
                            </li>
                            <li class="page-item active">
                              <a class="page-link" id="pagingFistPage" runat="server" href="#">首页</a>
                            </li>
                            <li class="page-item">
                              <a class="page-link" id="pagingLastPage" runat="server" href="#">最后一页</a>
                            </li>
                            <li class="page-item">
                              <a class="page-link" id="pagingNextPage" runat="server" href="#">&raquo;</a>
                            </li>
                              
                          </ul>
                          跳转到：<input type="text" class="" id="pagingGotoPage" runat="server" />页 <input type="button" class="btn-info" id="pagingbtnGotoPage" value="跳转" runat="server"/>
                          <a class="m-0" id="pagingIndexPage" runat="server">当前页</a>
                          <a class="m-0" id="pagingAllPage" runat="server">一共有90条数据</a>
                          
                        </div>
                             
                    </ContentTemplate>
                    </asp:UpdatePanel>
                <hr />

		        </div>
		        <div class="col-md-4 column">
			        <div class="row clearfix">
				        <div class="col-md-12 column">
			        
			                <!-- 信息卡片 -->
                            <div class="card border-primary mb-3" style="max-width: 20rem;">
                              <div class="card-header">个人信息</div>
                              <div class="card-body">
                                <h4 class="card-title" id="userName" runat="server">公众用户</h4>
                                <p class="card-text"><img class="rounded-circle"  src="../../images/avatar_default.jpg" width="80" height="80" /></p>
                              </div>
                            </div>
					        
					        <h2>分类</h2>
					        <hr />
                            <!-- 留言分类 -->				        
                            <ul class="list-group" id="ulMBCategories" runat="server">
                              <li class="list-group-item d-flex justify-content-between align-items-center">
                                社团活动建议
                                <span class="badge badge-primary badge-pill">14</span>
                              </li>
                              <li class="list-group-item d-flex justify-content-between align-items-center">
                                技术留言
                                <span class="badge badge-primary badge-pill">2</span>
                              </li>
                              <li class="list-group-item d-flex justify-content-between align-items-center">
                                问题
                                <span class="badge badge-primary badge-pill">1</span>
                              </li>
                            </ul>
                            
					       <hr />
					        <div class="list-group">
						         <a class="list-group-item active" href="#">留言板</a>
						        <div class="list-group-item">
							        输入您的留言
						        </div>
						        <div class="list-group-item">
							        <h4 class="list-group-item-heading">
								        <div class="form-group">
								            <label for="txtTitile">标题:</label>
								            <input class="form-control" id="txtTitile" placeholder ="标题可为空!" runat="server" />
								            <hr />
								            <label for="comment">评论内容:</label>
								            <textarea class="form-control" rows="5" id="txtComment" runat ="server"></textarea>
								            <hr />
								            <label for="MBcategories">分类</label>
                                            <asp:DropDownList ID="MBcategories" CssClass="form-group" runat="server">
                                            </asp:DropDownList>
								        </div>
							        </h4>
							        <p class="list-group-item-text">
								        <button class="btn btn-outline-success" type="button" id ="btnPublish" runat="server">发表</button>
								        <span id="spPublishReult" runat="server"></span>
							        </p>
						        </div>
						        <div class="list-group-item">
							         <span class="badge badge-pill badge-info">留言功能已开放</span> 
						        </div> 
					        </div>
				        </div>
			        </div>
		        </div>
	        </div>
	        <div class="row clearfix">
		        <div class="col-md-6 column">
			        <dl>
			        
				        <dt>关于本网站
				        </dt>
				        <dd>一时兴起写的网站,供学习与参考,想知道更多,请进群详聊。
				        </dd>
				        
				        <dt>关于社团
				        </dt>
				        <dd>编程社
				        </dd>
				        <dd>丰富同学们的课余生活，丰富学校的社团结构
				        </dd>
				        
				        <dt>设计者
				        </dt>
				        <dd>副社
				        </dd>
			        </dl>
		        </div>
		        <div class="col-md-6 column">
			         <address> <strong>ProgrammingSocietyForum</strong><br /> 广州市海珠区<br /> 赤沙路15号<br /><abbr title="邮箱">E:</abbr> 2595903671@qq.com</address>
		        </div>
		        
                <div id="fl_menu">
                    <div class="label"><i class="fa fa-universal-access" aria-hidden="true" title="辅助菜单栏"></i></div>
                    <div class="menu">
	                    <a href="#top" class="menu_item"><i class="fa fa-anchor" aria-hidden="true" title="返回到首页"></i></a>
                        <a href="../ProgrammingSociety/Portal.html" class="menu_item"><i class="fa fa-university" aria-hidden="true" title="编程社门户"></i></a>
                        <a href="https://jq.qq.com/?_wv=1027&k=5CjTe5p" class="menu_item"><i class="fa fa-qq" aria-hidden="true" title="加入我们的编程社交流群"></i></a>
                    </div>
                </div>
                
	        </div>
        </div>
    </form>
    
    <div class ="text-center"><p> &copy; 2018 <br />GAWeb</p>Designer by GAloliy</div>
    
    <script src="../../Content/js/jquery-3.3.1.min.js" type="text/javascript"></script>
    <script src="../../Content/js/jquery.1.10.2.min.js" type="text/javascript"></script>
    <script src="../../Content/js/jquery.easing.js" type="text/javascript"></script>
    <script src="../../Content/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Resources/js/MessgeBoardMain.js" type="text/javascript"></script>
</body>
</html>
