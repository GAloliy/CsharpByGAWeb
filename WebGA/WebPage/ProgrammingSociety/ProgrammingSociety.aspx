<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgrammingSociety.aspx.cs" Inherits="WebGA.WebPage.ProgrammingSociety.ProgrammingSociety" %>


<!DOCTYPE html>
<head>
    <title>编程社团 | ProgrammingSociety</title>

    <!-- META DATA -->
    <meta http-equiv="content-type" content="text/html;charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="author" content="">

    <!-- CSS Implementing Plugins -->
    <link rel="stylesheet" type="text/css" href="../../Content/css/font-awesome.min.css">
    <link rel="stylesheet" href ="../../Content/css/PSP_bicolor.min.css">

    <!-- CSS Global Compulsory -->
    <link rel="stylesheet" href ="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link rel="stylesheet" href="../../Content/css/PSP_animate.min.css" >
    <link rel="stylesheet" href ="../../Content/css/PSP_style.css">
    <!--<link rel="stylesheet" href="assets/css/PSP_custom.css">-->

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
    <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <!-- FAVICONS -->
    <link rel="shortcut icon" href ="../../images/favicon.png">
    <link rel="apple-touch-icon" href="../../images/apple-touch-icon.png">
    <link rel="apple-touch-icon" sizes="72x72" href="../../images/apple-touch-icon-72x72.png">
    <link rel="apple-touch-icon" sizes="114x114" href="../../images/apple-touch-icon-114x114.png">

</head>
<body>

<div id="awd-site-wrap" class="bg bg-home">

<div id="bg">
    <div id="overlay">
        <div class="awd-site-bg bg-home"></div>
        <div class="awd-site-bg bg-subscribe"></div>
        <div class="awd-site-bg bg-about"></div>
        <div class="awd-site-bg bg-contact"></div>
        <div class="awd-site-bg bg-services"></div>
    </div>
    <canvas id="awd-site-canvas"></canvas>
</div>

<!-- START SITE HEADER -->
<header id="awd-site-header">
    <div id="awd-site-logo" class="animated" data-animation="fadeInDown" data-animation-delay="500">
        <h1><a href="#" class="go-slide" data-slide="home"><i class="fa fa-commenting-o"></i><span>编程社</span></a></h1>
    </div>

    <button class="menu-toggle animated" data-animation="fadeInDown" data-animation-delay="500" data-role="toggle">
        <span></span>
        <span></span>
        <span></span>
    </button>
    <!-- START NAVIGATION -->
    <nav id="awd-site-nav" class="navigation animated" data-animation="fadeInDown" data-animation-delay="500">
        <div class="nav-container">

            <!-- START NAVIGATION MENU ITEMS -->
            <ul>
                <li><a href="#" data-slide="home" class="active">首页</a></li>
                <li><a href="#" data-slide="subscribe">订阅</a></li>
                <li><a href="#" data-slide="about">关于</a></li>
                <li><a href="#" data-slide="services">活动</a></li>
                <li><a href="#" data-slide="contact">联系我们</a></li>
            </ul>
            <!-- END NAVIGATION MENU ITEMS -->

        </div>
    </nav>
    <!-- END NAVIGATION -->
</header>
<!-- END SITE HEADER -->

<!-- START MAIN -->
<main id="awd-site-main">
<!-- START SECTION -->
<section id="awd-site-content">
<div class="sections-block">
<div class="slides">

<div class="slides-wrap">
<!-- HOME SECTION -->
<div class="slide-item" data-slide-id="home">
    <!-- START CONTAINER -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <!-- START SLIDE CONTENT-->
                <div class="slide-content">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 svm">
                            <div class="section-info text-left">
                                <div class="countdown">
                                    <div id="clock" class="animated" data-animation="fadeIn" data-animation-delay="60"></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5 col-lg-offset-1 col-md-6 svm">
                            <div class="section-info text-right">
                                <!-- START TITLE -->
                                <h2 class="section-title text-default animated" data-animation="fadeIn" data-animation-delay="50">Hey
                                    Guys!<br> 想成为编程大牛吗?在编程的世界里你什么都能做(if you can do it)。只要对编程感兴趣的都可以来我们社团.</h2>
                                <!-- END TITLE -->
                                <p class="animated" data-animation="fadeIn" data-animation-delay="55">我们的社团正在招人<br/> 有你的加入它将是非常棒的社团.</p>
                                <a href="#" class="btn go-slide animated" data-animation="fadeIn" data-animation-delay="60" data-slide="about">更多资料</a>
                                <a href="#" class="btn btn-inverse go-slide animated" data-animation="fadeIn" data-animation-delay="60" data-slide="subscribe">联系我们!</a>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END SLIDE CONTENT-->
            </div>
        </div>
    </div>
    <!-- END CONTAINER -->
</div>

<!-- SUBSCRIBE SECTION -->
<div class="slide-item" data-slide-id="subscribe">
    <!-- START CONTAINER -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">

                <!-- START SLIDE CONTENT-->
                <div class="slide-content">

                    <div class="row">
                        <div class="col-lg-5 col-lg-offset-2 col-md-6 col-md-offset-1 col-md-push-5 svm">
                            <div class="section-info text-right">
                                <!-- START TITLE -->
                                <h2 class="section-title text-default animated" data-animation="fadeIn" data-animation-delay="60">加入  <br/> 我们的交流群</h2>
                                <!-- END TITLE -->

                                <p class="animated" data-animation="fadeIn" data-animation-delay="100"><strong>欢迎━(*｀∀´*)ノ亻!.</strong>加入我们的交流群.
                                    <br/> 你也许会成为下一个<br/> 艾伦·麦席森·图灵
                                </p>
                            </div>
                        </div>
                        <div class="col-md-5 col-md-pull-7 svm">
                            <div class="section-info text-left">
                                <p><strong>点击</strong>下面的QQ图标或<strong><a href="https://jq.qq.com/?_wv=1027&k=5CjTe5p">点击这里</a></strong>将打开我们的群链接</p>
                                <!-- Subscribe Form -->
                                    <div>
                                        <img src="../../images/PCerweima.png" width="250px" height="320px">
                                    </div>
                                <!-- end Subscribe Form -->
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END SLIDE CONTENT-->
            </div>
        </div>
        <!-- END ROW -->
    </div>
    <!-- END CONTAINER -->
</div>

<!-- ABOUT SECTION -->
<div class="slide-item" data-slide-id="about">
    <!-- START CONTAINER -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">

                <!-- START SLIDE CONTENT-->
                <div class="slide-content">
                    <div class="row">
                        <div class="col-lg-5 col-lg-offset-2 col-md-6 col-md-offset-1 col-md-push-5 svm">
                            <div class="section-info text-right">
                                <!-- START TITLE -->
                                <h2 class="section-title text-default animated" data-animation="fadeIn" data-animation-delay="60">关于我们</h2>
                                <!-- END TITLE -->
                                <p class="animated" data-animation="fadeIn" data-animation-delay="100">随着信息技术时代的到来，像 AI人工智能越来越普遍，我们信息应用技术广泛被社会所重视。那么我们的目的是搞什么呢？(wa ka ra nai)</p>
                            </div>
                        </div>
                        <div class="col-md-5 col-md-pull-7 svm">
                            <div class="section-info text-left">
                                <!-- START FEATURES-LIST -->
                                <div class="features-list">

                                 <div class="featured-item">

                                    <!-- FEATURE -->
                                    <div class="featured-item animated" data-animation="fadeIn"
                                         data-animation-delay="150">
                                        <div class="featured-text">
                                            <h3><i class="fa fa-rocket"></i> 锻炼思维和交流能力</h3>

                                            <p>编程是一种很'吃脑'的工作,想编写出好的程序就需要不断的思考,实践等(当你遇到很蛋疼的问题的时候并且自己解决了问题,我相信你会喜欢那种成就感)。所以,会编程的人思维都很灵活(不会编程的人思维灵活,学编程会更加灵活)。社团里可以互相交流学习切磋(不许营造GAY里GAY气的气氛.橘里橘气也不许.哪些在群里开车的同学会被扣留工ju.sdefrytguhipop'[
                                            'ewap'ofui;hy]),</p>
                                        </div>
                                    </div>

                                        <!-- FEATURE -->
                                        <div class="featured-item animated" data-animation="fadeIn"
                                             data-animation-delay="150">
                                            <div class="featured-text">
                                                <h3><i class="icon-paint"></i> 培养兴趣丰富课余生活</h3>

                                                <p>也许有人会说：上课学习就已经够难受了,下课还要去研究什么编程。对于这类同学，我只想说:难道你就没有当技术宅(这只是调侃,我可没叫你们去当'宅')的心吗？没有就来这里培养兴趣。或许你会发现你隐藏的优点</p>
                                            </div>
                                        </div>
                                    </div>



                                </div>
                                <!-- END FEATURES-LIST -->
                            </div>
                        </div>
                    </div>
                </div>
                <!-- END SLIDE CONTENT-->
            </div>
        </div>
        <!-- END ROW -->
    </div>
    <!-- END CONTAINER -->
</div>

<!-- SERVICES SECTION -->
<div class="slide-item" data-slide-id="services">
    <!-- START CONTAINER -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <!-- START SLIDE CONTENT-->
                <div class="slide-content">
                    <div class="row">
                        <div class="col-lg-5 col-lg-offset-2 col-md-6 col-md-offset-1 col-md-push-5 svm">
                            <div class="section-info text-right">
                                <!-- START TITLE -->
                                <h2 class="section-title text-default animated" data-animation="fadeIn">关于社团活动</h2>
                                <!-- END TITLE -->
                                <p class="animated" data-animation="fadeIn" data-animation-delay="100">我们社团活动主要(缺经费)在学校机房举行。当然,我们也会听取社员的意见来举行一些有学习(学习使我快乐！)意义的小比赛。</p>
                            </div>
                        </div>
                        <div class="col-md-5 col-md-pull-7 svm">
                            <div class="section-info text-left">
                                <!-- SERVICE -->
                                <div class="service animated" data-animation="fadeIn" data-animation-delay="150">
                                    <h3>活动事宜</h3>

                                    <p>活动由社长发起(所以想搞事情先搞社长)在群里公布活动事宜。有些专业上课时间不对口的。请找宣传部长说明，我们会尽量将活动时间安排对口</p>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
                <!-- END SLIDE CONTENT-->
            </div>
        </div>
        <!-- END ROW -->
    </div>
    <!-- END CONTAINER -->
</div>

<!-- CONTACT SECTION -->
<div class="slide-item" data-slide-id="contact">
    <!-- START CONTAINER -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <!-- START SLIDE CONTENT-->
                <div class="slide-content">
                    <div class="row">
                        <div class="col-lg-5 col-lg-offset-1 col-md-6 col-md-push-6 svm">

                            <div class="section-info text-right">
                                <!-- START TITLE -->
                                <h2 class="section-title text-default animated" data-animation="fadeIn">联系我们</h2>
                                <!-- END TITLE -->
                                <div class="contact-info">
                                    <p class="contact-item"><i class="fa fa-phone"></i> 手机号码: 不行,这个不能发出来</p>
                                    <p class="contact-item"><i class="fa fa-phone"></i> 社长QQ：13719138844
                                    <p class="contact-item"><i class="fa fa-envelope"></i> 副社邮箱: 2595903671@qq.com</p>
                                    <p class="contact-item"><i class="fa fa-map-marker"></i> 广东省 广州 海洋工程技术学校 编程社
                                </div>
                                <p class="animated" data-animation="fadeIn" data-animation-delay="100"
									<h3> 从兴趣抓起   让编程更简单</h3>
									<h5>让我们一起建立更好的课余生活</h5>
                                </p>
                            </div>
                        </div>
                        
                        <div class="col-lg-6 col-md-6 col-md-pull-6 svm">
                            <div class="section-info text-left">
                            <!-- START CONTACT FORM -->
                            <form id="contactReform" runat="server" class="contact-form">
                                <div class="row">
                                    <div class="col-lg-4 col-md-6 col-md-12 animated" data-animation="fadeIn" data-animation-delay="200">
                                        <input type="text" name="contact-name" id="name" runat="server" placeholder="真实姓名"
                                               class="contact-form-name required"/>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-md-12 animated" data-animation="fadeIn" data-animation-delay="200">
                                        <input type="text" name="contact-information" id="contactin" runat="server" placeholder="联系方式"
                                               class="contact-form-name required"/>
                                    </div>
                                    <div class="col-lg-4 col-md-12 animated" data-animation="fadeIn" data-animation-delay="200">
                                        <input type="text" id="profession" runat="server" name="contact-profession" placeholder="所在专业"
                                               class="contact-form-profession required"/>
                                    </div>
                                    <!-- END COLUMN 4 -->
                                    <div class="col-md-12 animated" data-animation="fadeIn" data-animation-delay="150">
                                        <textarea id = "contactMessage" name="contact-message" runat="server" placeholder="说两句吧..."
                                                  class="contact-form-message required"
                                                  rows="4"></textarea>
                                      <button class="btn btn-block" runat="server" type="submit" id="submit" name="submit"><span>放飞梦想</span>
                                            <i class="fa fa-send"></i></button>
                                    </div>
                                    <!-- END COLUMN 8 -->
                                </div>
                                <!-- END ROW -->
                                <div class="contact-notice"></div>
                            </form>
                            <!-- END CONTACT FORM -->
                            </div>
                        </div>
                        
                    </div>

                </div>
                <!-- END SLIDE CONTENT-->
            </div>
        </div>
        <!-- END ROW -->
    </div>
    <!-- END CONTAINER -->
</div>

</div>
</div>
</div>
</section>
<!-- END SECTION -->
</main>
<!-- END MAIN -->


<footer id="awd-site-footer">
    <!-- START COPYRIGHT -->
    <div class="copyright animated" data-animation="fadeInUp" data-animation-delay="500">
        <p>© 2018 - Copyright to the original author</p>
    </div>
    <!-- END COPYRIGHT -->

    <!-- START SOCIAL ICONS -->
    <nav class="social-icons animated" data-animation="fadeInUp" data-animation-delay="500">
        <ul>
            <li title="兼容火狐"><a href="###"><i class="fa fa-firefox"></i></a></li>
            <li title="兼容Opera"><a href="###"><i class="fa fa-opera"></i></a></li>
            <li title="兼容IE"><a href="###"><i class="fa fa-internet-explorer"></i></a></li>
            <li title="兼容谷歌"><a href="###"><i class="fa fa-chrome"></i></a></li>
            <li title="QQ"><a href="https://jq.qq.com/?_wv=1027&k=5CjTe5p"><i class="fa fa-qq"></i></a></li>
            <li title="WeChat" class="weixin-list"><a href="###"><i class="fa fa-weixin"></i></a></li>
            <li title="微博"><a href="###"><i class="fa fa-weibo"></i></a></li>
            <li title="开始"><a href="###"><i class="fa fa-windows"></i></a></li>
        </ul>
    </nav>
    <!-- END SOCIAL ICONS -->
</footer>

</div>

<!-- JS -->
<!-- <script type="text/javascript" src ="../../Content/js/jquery.1.10.2.min.js"></script> -->
<script type="text/javascript" src="http://libs.baidu.com/jquery/1.10.2/jquery.min.js"></script>
<script type="text/javascript" src ="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
<script type="text/javascript" src ="../../Content/js/PSP_vendor.js"></script>
<script type="text/javascript" src ="../../Content/js/PSP_options.js"></script>
<script type="text/javascript" src ="../../Content/js/PSP_main.js"></script>

</body>
</html>