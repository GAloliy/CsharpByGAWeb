            $(function () {
            
                var video = document.getElementById("video");
                var canvas=document.getElementById("canvas");
                var context=canvas.getContext('2d');
                var base64Img = "BASE64";

                //获取摄像头对象
                navigator.getUserMedia=navigator.getUserMedia||navigator.webkitGetUserMedia||navigator.mozGetUserMedia||navigator.msGetUserMedia;

                navigator.getUserMedia({video:true,audio: false},gotStream,noStream);//打开摄像头
                
                    //成功打开摄像头
                    function gotStream(stream){
                    
                        video.src =URL.createObjectURL(stream);
                        video.onerror= function(){
                        
                            stream.stop();
                        }
                        
                         stream.onended = noStream;

                        video.onloadedmetadata =function()
                        {
                            $("#snapTakingpic").html("<p>摄像头已打开</p>");
                            //alert("摄像头已打开!")
                        };
                    }
                    
                    //打开摄像头失败
                    function noStream(error){
                        $("#snapTakingpic").html("<p>无法打开摄像头（是否有摄像头? 暂不支持手机在线拍摄,手机请选择图片检测)</p>");
                        //alert(error)
                    }
        
                    
                 $("#reFace").click(function () {
                    
                    var imageFile = $('#inputImage').get(0).files[0];
                    
  
                    if(window.FileReader){                 
                     
                        var reader = new FileReader();
                        
                        if(imageFile != null){
                            reader.readAsDataURL(imageFile);
                            reader.onloadend = function(e){
                                base64Img = "";
                                base64Img = e.target.result.toString().replace("data:image/jpeg;base64,","");
                                postFaceRecoition(base64Img);
                            }
                        }else{
                            alert('请您先选择要操作的图片!');
                        }
                    }else{
                        alert('您的浏览器不支持FileReader请更换浏览器再尝试!')
                    }
                
                });
                    
            
                $("#snap").click(function () {
                
                    context.drawImage(video,0,0,800,600);  
                    base64Img = canvas.toDataURL("image/png").toString().replace("data:image/png;base64,",""); 
                    
                    postFaceRecoition(base64Img);
                    
                  

                });
                
                
                function postFaceRecoition(imageBase64){
                
                      $.ajax({
                        url: "../FaceRecognition/FaceReconition.aspx/SearchFace",//发送到本页面后台方法
                        type: "POST",
                        dataType: "json",
                        async: false,//false表示同步，会等待执行完成，true为异步
                        contentType: "application/json; charset=utf-8",//上下文类型。不可少
                        data: "{'param':'" + base64Img + "'}",
                        beforeSend : function(){
                        
                            $("#FRResult").html("<p>加载中</p>");
                            
                        },
                        success: function (data) {
                            //alert(data.d);
                             $("#FRResult").html(data.d);
                             
                        },
                        error: function (XMLHttpRequest,textStatus,errorThrown) {
                        
                            alert("请求出错状态信息:" + XMLHttpRequest.status + "ReadState:" + XMLHttpRequest.readState + "TextStatue:" + textStatus + "Thrown:" + errorThrown);
                            
                        },
                        complete: function(XMLHttpRequest, textStatus) {
                        
                            this; // 调用本次AJAX请求时传递的options参数
                            
                        }
                    });
                    
                }
                
            });