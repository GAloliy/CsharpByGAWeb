 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaceReconition.aspx.cs" Inherits="WebGA.WebPage.FaceRecognition.FaceReconition" %>
<%@ Register Src="~/WebPage/Template/MenuBarRelativePath.ascx" TagName="bar" TagPrefix="relativepath"%>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>人脸识别</title>
    <script type="text/javascript" src="../../Content/js/jquery-3.3.1.min.js"></script>
    <link href="../../Content/css/bootstrap.min.css" rel="Stylesheet" type="text/css" />
    <link href="../../Content/css/font-awesome.min.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../Resources/js/FaceReconition.js">
    </script>
</head>
<body style="margin-top:100px;font-family:幼圆">
    
    <relativepath:bar ID="menubar" runat="server" />

    <div class="row clearfix">
        <div class ="col-md-8">
            <div style=" margin-top:2px; margin-left:20%">

                <video id="video" style="background-color:Black" width="800" height="600" autoplay="autoplay">
                </video>

                <canvas id="canvas" width="800" height="600" runat="server" hidden = "hidden"></canvas>
                
            </div>
            
        </div>
        <div class ="col-md-4">

            <div style="margin-left:30%;margin-right:auto">
                <div id="FRInfo">
                    <p class="h3">选择图片检测或拍照检测</p><input type="file" id="inputImage" accept="image/jpeg,image/png" />
                    <button id="reFace" class="btn btn-dark" runat="server">人脸检测(图片)</button>
                    <button id="snap" class="btn btn-info" runat="server">人脸检测(拍照)</button>
                    <span id="snapTakingpic"></span>
                </div>
                    
                <div id="FRResult">
                    
                </div>    
            </div>
            
        </div>
    </div>
        
    <form id="frForm" runat="server">
    </form>

    <div class ="text-center" style="margin-top:50px"><p> &copy; 2018 <br />GAWeb</p>Designer by GAloliy</div>

<script type="text/javascript" src="../../Content/js/bootstrap.min.js"></script>
</body>
</html>