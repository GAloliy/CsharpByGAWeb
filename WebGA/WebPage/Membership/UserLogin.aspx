<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="WebGA.UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--
//
//
//                       _oo0oo_
//                      o8888888o
//                      88" . "88
//                      (| -_- |)
//                      0\  =  /0
//                    ___/`---'\___
//                  .' \\|     |// '.
//                 / \\|||  :  |||// \
//                / _||||| -:- |||||- \
//               |   | \\\  -  /// |   |
//               | \_|  ''\---/''  |_/ |
//               \  .-\__  '-'  ___/-. /
//             ___'. .'  /--.--\  `. .'___
//          ."" '<  `.___\_<|>_/___.' >' "".
//         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
//         \  \ `_.   \_ __\ /__ _/   .-` /  /
//     =====`-.____`.___ \_____/___.-`___.-'=====
//                       `=---='
//
//
//     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


       	  佛祖保佑       永无BUG BY - GA
 -->












<!DOCTYPE html>

<html lang="zh-cn">

    <head>
        
        <meta http-equiv="X-UA-Compatible" charset="UTF-8" content="IE=edge,chrome=1" /> 
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <script src="../../Content/js/LoginConsoleJS.js" type="text/javascript"></script>
        <link rel="stylesheet" type="text/css" href ="../../Content/css/Login_styles.css"/>
                <title>登录</title>
    </head>

<body>
<div class="jq22-container" style="padding-top:10px">

	<div class="login-wrap">
		<div class="login-html">
			<input id="tab-1" type="radio" name="tab" class="sign-in" checked ="checked"/><label for="tab-1" class="tab">登录</label>
			<input id="tab-2" type="radio" name="tab" class="sign-up"/><label for="tab-2" class="tab">注册</label>
			<div class="login-form">
                <form  id="flogin" method="post" runat ="server">
				<div class="sign-in-htm">
					<div class="group">
						<label for="lbuser" class="label">用户名</label>
						<asp:TextBox ID ="tbuser" CssClass="input" runat ="server"/>
					</div>
					<div class="group">
						<label for="lbpass" class="label">密码</label>
                        <asp:TextBox ID ="tbpassword" CssClass="input" runat ="server"  TextMode ="Password"/>
					</div>
					<div class="group">
                        <asp:CheckBox ID ="cbReme" BorderStyle="Dotted" runat="server" />
                        <label> 记住我</label>
					</div>
					<div class="group">
                        <asp:Button ID="Login" CssClass="button"  runat ="server" Text ="登录" OnClick ="Login_Click" />
					</div>
					<div class="hr"></div>
					<div class="foot-lnk">
						<a href="#forgot">忘记密码?</a>
					</div>
				</div>

				<div class="sign-up-htm">
					    <div class="group">
						    <label for="user" class="label">用户名</label>
                            <asp:TextBox ID ="tb1user" CssClass="input"  runat="server" />
					    </div>
					    <div class="group">
						    <label for="pass" class="label">密码</label>
                            <asp:TextBox ID="tb1password" TextMode="Password" CssClass ="input" runat="server"/>
					    </div>
					    <div class="group">
						    <label for="pass" class="label">确认密码</label>
						    <asp:TextBox ID="tb1repassword" TextMode="Password" CssClass ="input" runat="server" />
                            <asp:CompareValidator ID="cvrepwd" runat="server" ErrorMessage="* 两次密码输入不一致" ControlToValidate="tb1password" ControlToCompare="tb1repassword"></asp:CompareValidator>
					    </div>
					    <div class="group">
						    <label for="pass" class="label">邮箱地址</label>
                            <asp:TextBox ID="tbemail" CssClass="input" runat="server" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="邮箱格式不对，请重新输入" Display="Static" ControlToValidate="tbemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
					    </div>
					    <div class="group">
                            <asp:Button ID="Zhuc" CssClass="button" Text ="注册"  runat="server" OnClick ="Zhuc_Click"/>
					    </div>
					    <div class="hr"></div>
					    <div class="foot-lnk">
						    <label for="tab-1"><a>已有账户？</a></label>
					    </div>
				</div>
			 </form>
		</div>
	  </div>
   </div>
</div>

<div style="text-align:center;margin:50px 0; font:normal 14px/24px 'MicroSoft YaHei';">
<p>不支持IE8及以下浏览器。</p>
<p><a href="2595903671@qq.com"  target="_blank">仅供学习与交流使用。版权归原作者</a></p>
</div>
  
</body>
</html>

